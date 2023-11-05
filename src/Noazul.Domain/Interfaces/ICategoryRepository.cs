using Noazul.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noazul.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetById(Guid id);
    Task<IEnumerable<Category>> GetAll();

    void Add(Category category);
    void Update(Category category);
    void Remove(Category category);
}
