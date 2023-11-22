using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;
namespace upsideCakes.Controllers;


[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;

    public GerenteController(UpsideCakesDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Gerente gerente)
    {
        await _dbContext.AddAsync(gerente);
        await _dbContext.SaveChangesAsync();
        return Created("", gerente);
    }


    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Gerente>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        return await _dbContext.Gerente.ToListAsync();
    }


    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Gerente>> Buscar(int id)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        var gerenteLista = await _dbContext.Gerente.FindAsync(id);
        if (gerenteLista is null) return NotFound();

        return gerenteLista;
    }


    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Gerente gerente)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        var gerenteAlterar = await _dbContext.Gerente.FindAsync(gerente.id);
        if (gerenteAlterar is null) return NotFound();

        _dbContext.Entry(gerenteAlterar).CurrentValues.SetValues(gerente);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        var gerenteDeletar = await _dbContext.Gerente.FindAsync(id);
        if (gerenteDeletar is null) return NotFound();

        _dbContext.Gerente.Remove(gerenteDeletar);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
