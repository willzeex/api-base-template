using System;
using NetDevPack.Domain;

namespace Noazul.Domain.Models;

public class Category : Entity, IAggregateRoot
{
    public Category(Guid id, string name, string description, bool active, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Active = active;
        CreatedAt = createdAt;
    }

    protected Category() { }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; private set; }
}
