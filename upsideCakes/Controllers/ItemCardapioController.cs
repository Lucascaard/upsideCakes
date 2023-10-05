using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;

[ApiController]
[Route("[controller]")]

public class ItemCardapioController : ControllerBase
{
    private UpsideCakesDbContext _dbContext;

    public ItemCardapioController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar (ItemCardapio item)
    {
        await _dbContext.AddAsync(item);
        await _dbContext.SaveChangesAsync();
        return Created("", item);
        // var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        // if(_dbContext.Produto is null) return NotFound();
        // var itemCardapio = await _dbContext.ItemCardapio.FindAsync(item);
        // if(itemCardapio is null) return NotFound();
        // cardapio._itens.Add(itemCardapio);
        // return Ok();
    } // terminar aqui

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<ItemCardapio>>> Listar()
    {
        return await _dbContext.ItemCardapio.ToListAsync();  
    }

    [HttpGet]
    [Route("listar/{nome}")]
    public async Task<ActionResult<ItemCardapio>> Buscar(string nome)
    {
        if(_dbContext.Cardapio is null) return NotFound();
        var item = await _dbContext.ItemCardapio.FindAsync(nome);
        if(item is null) return NotFound();
        return item;
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext.ItemCardapio is null) return NotFound();
        var item = await _dbContext.ItemCardapio.FindAsync(id);
        if(item is null) return NotFound();
        _dbContext.ItemCardapio.Remove(item);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}