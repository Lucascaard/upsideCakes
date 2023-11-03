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

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Produto produto)
    {
        await _dbContext.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
        return Created($"Produto '{produto.nome}' cadastrado com sucesso.", produto);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Produto>>> Listar()
    {
        return await _dbContext.Produto.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Produto>> ListarPorID (int id)
    {
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp == null) return NotFound();
        return Ok(produtoTemp);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Produto produto)
    {
        var existingProduto = await _dbContext.Produto.FindAsync(produto.id);
        if (existingProduto is null) return NotFound();
        _dbContext.Entry(existingProduto).CurrentValues.SetValues(produto);
        await _dbContext.SaveChangesAsync();
        return Ok($"Produto {produto.nome} alterado com sucesso.");
    }

    [HttpPatch]
    [Route("alterarpreco/{id}")]
    public async Task<ActionResult> AtualizarPreco (int id, [FromForm] float preco)
    {
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp is null) return NotFound();
        produtoTemp.preco = preco;
        await _dbContext.SaveChangesAsync();
        return Ok($"Preço do produto {produtoTemp.nome} alterado para R${preco}");
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir (int id)
    {
        if (_dbContext.Produto is null) return NotFound();
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp is null) return NotFound();
        _dbContext.Produto.Remove(produtoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok($"Produto {produtoTemp.nome} excluido com sucesso.");
    }
}
