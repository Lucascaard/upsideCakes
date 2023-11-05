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
    public async Task<ActionResult> CadastrarCardapio()
    {
        var cardapio = new Cardapio();
        await _dbContext.AddAsync(cardapio);
        await _dbContext.SaveChangesAsync();
        return Created("", cardapio);
    }

    [HttpPut]
    [Route("addItem")]
    public async Task<ActionResult> CadastrarItem (int id, int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c.id == id);

        if(cardapio.itens is null || item is null) return NotFound();

        cardapio.itens.Add(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok(cardapio);
    }

    // [HttpPut]
    // [Route("alterarPreco")]
    // public async Task<ActionResult> alterarPreco (int id, double preco, [FromForm] int idCardapio)
    // {
    //     var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
    //     var item = _dbContext.Produto
    //         .FirstOrDefault(c => c.id == id);

    //     if(cardapio.itens is null || item is null)
    //     {
    //         return NotFound();
    //     }

    //     item.preco = preco;

    //     cardapio.itens.Add(item);
    //     _dbContext.Update(cardapio);
    //     await _dbContext.SaveChangesAsync();
    //     return Ok(cardapio);
    // }

    // [HttpPut]
    // [Route("alterarCategoria")]
    // public async Task<ActionResult> alterarCategoria (int id, string categoria, [FromForm] int idCardapio)
    // {
    //     var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
    //     var item = _dbContext.Produto
    //         .FirstOrDefault(c => c.id == id);

    //     if(cardapio.itens is null || item is null)
    //     {
    //         return NotFound();
    //     }

    //     item.categoria = categoria;

    //     cardapio.itens.Add(item);
    //     _dbContext.Update(cardapio);
    //     await _dbContext.SaveChangesAsync();
    //     return Ok("Categoria alterada com sucesso.");
    // }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> alterar (int idCardapio, Produto produto)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c.id == produto.id);

        if(cardapio is null || item is null)
        {
            return NotFound();
        }

        // _dbContext.Entry(item).CurrentValues.SetValues(produto);        
        item.categoria = produto.categoria;
        item.nome = produto.nome;
        item.preco = produto.preco;

        cardapio.itens.Add(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok("Item alterado com sucesso.");
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cardapio>>> Listar()
    {
        
        var cardapio = _dbContext.Cardapio
            .Include(c => c.itens)
            .ToList();

        return cardapio;
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<IEnumerable<Cardapio>>> Buscar(int id)
    {
        var cardapio = _dbContext.Cardapio
            .Include(c => c.itens)
            .Where(c => c.id == id)
            .ToList();

        return cardapio;
    }

    [HttpDelete]
    [Route("excluiritem")]
    public async Task<ActionResult> ExcluirItem(int id, int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        var item = _dbContext.Produto
            .FirstOrDefault(c => c.id == id);

        if(cardapio.itens is null || item is null)
        {
            return NotFound();
        }
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=off;");
        cardapio.itens.Remove(item);
        _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=on;");
        return Ok("Item excluido com sucesso.");
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> ExcluirCardapio(int id)
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