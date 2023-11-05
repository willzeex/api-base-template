using MediatR;
using Nudes.Retornator.Core;
using System;

namespace Noazul.Domain.Commands.Categories.GetById;

public record GetByIdRequest(Guid Id) : IRequest<ResultOf<GetByIdResponse>>;
