using Microsoft.EntityFrameworkCore;
using Noazul.Domain.Interfaces;
using Noazul.Domain.Models;
using Noazul.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noazul.Infra.Data.Repository;

public class CategoryRepository : ICategoryRepository
{
    protected readonly NoazulContext Db;
    protected readonly DbSet<Category> DbSet;

    public CategoryRepository(NoazulContext context)
    {
        Db = context;
        DbSet = Db.Set<Category>();
    }

    public async Task<Category> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await DbSet.ToListAsync();
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
