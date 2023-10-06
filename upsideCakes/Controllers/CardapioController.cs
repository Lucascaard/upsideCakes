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
    [Route("cadastrarCardapio")]
    public async Task<ActionResult> CadastrarCardapio(Cardapio cardapio)
    {
        await _dbContext.AddAsync(cardapio);
        await _dbContext.SaveChangesAsync();
        return Created("", cardapio);
    }

    [HttpPut]
    [Route("addItem")]
    public async Task<ActionResult> CadastrarItem (int id, [FromForm] int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c._id == id);

        if(cardapio._itens is null || item is null)
        {
            return NotFound();
        }

        cardapio._itens.Add(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok(cardapio);
    }

    [HttpPut]
    [Route("alterarPreco")]
    public async Task<ActionResult> alterarPreco (int id, double preco, [FromForm] int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c._id == id);

        if(cardapio._itens is null || item is null)
        {
            return NotFound();
        }

        item._preco = preco;

        cardapio._itens.Add(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok(cardapio);
    }

    [HttpPut]
    [Route("alterarCategoria")]
    public async Task<ActionResult> alterarCategoria (int id, string categoria, [FromForm] int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c._id == id);

        if(cardapio._itens is null || item is null)
        {
            return NotFound();
        }

        item._categoria = categoria;

        cardapio._itens.Add(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok("Categoria alterada com sucesso.");
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cardapio>>> Listar()
    {
        
        var cardapio = _dbContext.Cardapio
            .Include(c => c._itens)
            .ToList();

        return cardapio;
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<IEnumerable<Cardapio>>> Buscar(int id)
    {
        var cardapio = _dbContext.Cardapio
            .Include(c => c._itens)
            .Where(c => c._id == id)
            .ToList();

        return cardapio;
    }

    [HttpDelete]
    [Route("excluiritem")]
    public async Task<ActionResult> ExcluirItem(int id, int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c._id == id);

        if(cardapio._itens is null || item is null)
        {
            return NotFound();
        }
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=off;");
        cardapio._itens.Remove(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=on;");
        return Ok("Item excluido com sucesso.");
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(id);
        if(cardapio is null) return NotFound();
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=off;");
        _dbContext.Cardapio.Remove(cardapio);
        await _dbContext.SaveChangesAsync();
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=on;");
        return Ok("Cardápio removido com sucesso!");
    }
}