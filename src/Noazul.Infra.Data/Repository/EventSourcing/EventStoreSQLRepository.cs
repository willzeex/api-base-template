using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noazul.Domain.Core.Events;
using Noazul.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Noazul.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private readonly EventStoreContext _context;

        public EventStoreSqlRepository(EventStoreContext context)
        {
            _context = context;
        }

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            return await (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToListAsync();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}