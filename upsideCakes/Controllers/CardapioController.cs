using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;

[ApiController]
[Route("[controller]")]

public class CardapioController : ControllerBase
{
    private UpsideCakesDbContext _dbContext;

    public CardapioController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar (Cardapio cardapio)
    {
        await _dbContext.AddAsync(cardapio);
        await _dbContext.SaveChangesAsync();
        return Created("", cardapio);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cardapio>>> Listar()
    {
        return await _dbContext.Cardapio.ToListAsync();  
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Cardapio>> Buscar(int id)
    {
        if(_dbContext.Cardapio is null) return NotFound();
        var cardapio = await _dbContext.Cardapio.FindAsync(id);
        if(cardapio is null) return NotFound();
        return cardapio;
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext.Cardapio is null) return NotFound();
        var cardapio = await _dbContext.Cardapio.FindAsync(id);
        if(cardapio is null) return NotFound();
        _dbContext.Cardapio.Remove(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}