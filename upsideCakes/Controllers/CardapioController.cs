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
        // var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        // if(_dbContext.Produto is null) return NotFound();
        // var itemCardapio = await _dbContext.ItemCardapio.FindAsync(item);
        // if(itemCardapio is null) return NotFound();
        // cardapio._itens.Add(itemCardapio);
        // return Ok();
    }

    [HttpPatch]
    [Route("addItem")]
    public async Task<ActionResult> CadastrarItem(int id, [FromForm] int idCardapio)
    {
        var cardapio = await _dbContext.Cardapio.FindAsync(idCardapio);
        if (cardapio is null) return NotFound();
        var itemCardapio = await _dbContext.Produto.FindAsync(id);
        if (itemCardapio is null) return NotFound();
        // if (cardapio._itens is null) cardapio._itens = new List<ItemCardapio>();
        // var novoItem = new ItemCardapio
        // {
        //     _nome = itemCardapio._nome,
        //     _preco = itemCardapio._preco
        // };
        cardapio._itens.Add(itemCardapio);
        _dbContext.Entry(itemCardapio).CurrentValues.SetValues(cardapio);
       // _dbContext.Update(cardapio);
        await _dbContext.SaveChangesAsync();
        return Ok(cardapio);
    } // terminar aqui

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cardapio>>> Listar()
    {

        // return await _dbContext.Cardapio.ToListAsync();  
        // var cardapios = await _dbContext.Cardapio
        // .Select(c => new Cardapio
        // {
        //     _id = c._id,
        //     _itens = c._itens
        // })
        // .ToListAsync();
        var cardapio =  _dbContext.Cardapio
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
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        // if(_dbContext.Cardapio is null) return NotFound();
        var cardapio = await _dbContext.Cardapio.FindAsync(id);
        if (cardapio is null) return NotFound();
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=off;");
        _dbContext.Cardapio.Remove(cardapio);
        await _dbContext.SaveChangesAsync();
        _dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=on;");
        return Ok("Cardápio removido com sucesso!");
    }
}