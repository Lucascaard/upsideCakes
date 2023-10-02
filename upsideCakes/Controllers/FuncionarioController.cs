using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]

public class FuncionarioController : ControllerBase
{

    private readonly UpsideCakesDbContext _dbContext;
    public FuncionarioController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }












}

