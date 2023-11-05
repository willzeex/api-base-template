using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noazul.Domain.Interfaces;
using Noazul.Domain.Models;
using Noazul.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Noazul.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly NoazulContext Db;
        protected readonly DbSet<Category> DbSet;

        public CustomerRepository(NoazulContext context)
        {
            Db = context;
            DbSet = Db.Set<Category>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Category> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Category> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(Category customer)
        {
           DbSet.Add(customer);
        }

        public void Update(Category customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Category customer)
        {
            DbSet.Remove(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
