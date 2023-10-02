using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;


namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;
    public ProdutoController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Produto produto)
    {
        await _dbContext.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
        return Created("", produto);
    }

    //Listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Produto>>> Listar()
    {
        return await _dbContext.Produto.ToListAsync();
    }

    //Listar por ID
    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Produto>> ListarPorID (int id)
    {
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp != null) return NotFound();
        return Ok(produtoTemp);
    }

    //Alterar
    [HttpPut]
    [Route("alterar")]

    public async Task<ActionResult> Alterar (Produto produto)
    {
        if (_dbContext.Produto is null) return NotFound();
        if (await _dbContext.Produto.FindAsync(produto._id) is null) return NotFound();
        _dbContext.Update(produto);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    //Alterar somente preço
    [HttpPatch]
    [Route("alterarpreco/{id}")]
    public async Task<ActionResult> AtualizarPreco (int id, [FromForm] float preco)
    {
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp is null) return NotFound();
        produtoTemp._preco = preco;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    //Excluir
    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir (int id)
    {
        if (_dbContext.Produto is null) return NotFound();
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp is null) return NotFound();
        _dbContext.Produto.Remove(produtoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
