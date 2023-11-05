using MediatR;
using Microsoft.AspNetCore.Mvc;
using Noazul.Domain.Commands.Categories.GetById;
using Nudes.Retornator.Core;

namespace Noazul.Services.Api.Controllers;

[Route("api/v1/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator mediator;

    public CategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id:guid}")]
    public async Task<ResultOf<GetByIdResponse>> Get(Guid id) => await mediator.Send(new GetByIdRequest(id));

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
