/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;
using upsideCakes;
using System.ComponentModel.DataAnnotations;
namespace upsideCakes.Controllers;


[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private UpsideCakesDbContext _dbContext;

    public GerenteController(UpsideCakesDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    //retornar qualquer tipo de resultado HTTP genérico, como Ok(), NotFound(), 
    public async Task<IActionResult> Cadastrar(Gerente gerente)
    {
        if (_dbContext is null) return NotFound();

        await _dbContext.AddAsync(gerente);
        await _dbContext.SaveChangesAsync();
        return Created("", gerente);
        // "" URL - não é especificada, e é usada uma string vazia para indicar que o sistema deve criar automaticamente a URL 
    }


    [HttpGet]
    [Route("listar")]
    //É usado quando você deseja retornar um resultado HTTP específico juntamente com um objeto do modelo
    public async Task<ActionResult<IEnumerable<Gerente>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        return await _dbContext.Gerente.ToListAsync();
    }


    [HttpGet()]
    [Route("buscar/{_idGerente}")]
    public async Task<ActionResult<Gerente>> Buscar(int idGerente)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        var gerenteLista = await _dbContext.Gerente.FindAsync(idGerente);
        if (gerenteLista is null) return NotFound();

        return gerenteLista;
    }


    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Gerente gerente)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        var gerenteAlterar = await _dbContext.Gerente.FindAsync(gerente._idGerente);
        if (gerenteAlterar is null) return NotFound();

        _dbContext.Gerente.Update(gerente);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{_idGerente}")]
    public async Task<ActionResult> Excluir([FromRoute] int _idGerente)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Gerente is null) return NotFound();

        var gerenteDeletar = await _dbContext.Gerente.FindAsync(_idGerente);
        if (gerenteDeletar is null) return NotFound();

        _dbContext.Gerente.Remove(gerenteDeletar);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
*/