using MediatR;
using Noazul.Domain.Interfaces;
using Nudes.Retornator.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Noazul.Domain.Commands.Categories.GetById;

public class GetByIdCommand : IRequestHandler<GetByIdRequest, ResultOf<GetByIdResponse>>
{
    private readonly ICategoryRepository categoryRepository;

    public GetByIdCommand(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<ResultOf<GetByIdResponse>> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await categoryRepository.GetById(request.Id);

        return new GetByIdResponse(response.Id, response.Name, response.Description, response.Active, response.CreatedAt);
    }

}
