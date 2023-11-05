using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noazul.Domain.Models;
using NetDevPack.Data;

namespace Noazul.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Category>
    {
        Task<Category> GetById(Guid id);
        Task<Category> GetByEmail(string email);
        Task<IEnumerable<Category>> GetAll();

        void Add(Category customer);
        void Update(Category customer);
        void Remove(Category customer);
    }
}