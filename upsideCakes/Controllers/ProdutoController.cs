using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;


namespace upsideCakes.Controllers;
[ApiController]
[Route("[produtocontroller]")]

public class ProdutoController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;
    public ProdutoController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //CREATE
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Produto produto)
    {
        await _dbContext.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
        return Created("", produto);
    }

    //READ
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Produto>>> Read()
    {
        return await _dbContext.Produto.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Produto>> ReadForID(int id)
    {
        var productTemp = await _dbContext.Produto.FindAsync(id);
        if (productTemp != null) return NotFound();
        return Ok(productTemp);
    }

    [HttpPut]
    [Route("alterar")]

    public async Task<ActionResult> Update(Produto product)
    {
        if (_dbContext.Produto is null) return NotFound();
        if (await _dbContext.Produto.FindAsync(product.Id) is null) return NotFound();
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("alterarpreco/{id}")]
    public async Task<ActionResult> UpdatePrice(int id, [FromForm] float price)
    {
        var productTemp = await _dbContext.Produto.FindAsync(id);
        if (productTemp is null) return NotFound();
        productTemp.Preco = price;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_dbContext.Produto is null) return NotFound();
        var productTemp = await _dbContext.Produto.FindAsync(id);
        if (productTemp is null) return NotFound();
        _dbContext.Produto.Remove(productTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
