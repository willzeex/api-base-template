namespace Noazul.Services.Api.Controllers;

[Route("api/v1/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ICategoryRepository categoryRepository;

    public CategoryController(IMediator mediator, ICategoryRepository categoryRepository)
    {
        this.mediator = mediator;
        this.categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> Get() =>
        await categoryRepository.GetAll();

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
