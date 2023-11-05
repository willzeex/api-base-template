using System;

namespace Noazul.Domain.Commands.Categories.GetById;

public record GetByIdResponse(Guid Id, string Name, string Description, bool Active, DateTime CreatedAt);
