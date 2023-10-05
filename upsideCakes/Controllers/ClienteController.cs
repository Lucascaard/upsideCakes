namespace upsideCakes.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;

    public ClienteController(UpsideCakesDbContext context)
    {
        _dbContext = context;
    }

    
}
