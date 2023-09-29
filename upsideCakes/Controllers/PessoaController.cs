using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;

[ApiController]
[Route("[controller]")]

public class PessoaController : ControllerBase
{
    private UpsideCakesDbContext _dbContext;

    public PessoaController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Pessoa pessoa)
    {
        await _dbContext.AddAsync(pessoa);
        await _dbContext.SaveChangesAsync();
        return Created("", pessoa);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pessoa>>> Listar()
    {
        return await _dbContext.Pessoa.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{cpf}")]
    public async Task<ActionResult<Pessoa>> Buscar(string cpf)
    {
        if(_dbContext.Pessoa is null) return NotFound();
        var pessoaTemp = await _dbContext.Pessoa.FindAsync(cpf);
        if(pessoaTemp is null) return NotFound();
        return pessoaTemp;
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pessoa pessoa)
    {
        if(_dbContext.Pessoa is null) return NotFound();
        if(await _dbContext.Pessoa.FindAsync(pessoa.Cpf) is null) return NotFound();
        _dbContext.Update(pessoa);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("mudarnome/{cpf}")]
    public async Task<ActionResult> MudarNome(string cpf, [FromForm] string nome)
    {
        if(_dbContext.Pessoa is null) return NotFound();
        var pessoaTemp = await _dbContext.Pessoa.FindAsync(cpf);
        if(pessoaTemp is null) return NotFound();
        pessoaTemp.Nome = nome;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(string cpf)
    {
        if(_dbContext.Pessoa is null) return NotFound();
        var pessoaTemp = await _dbContext.Pessoa.FindAsync(cpf);
        if(pessoaTemp is null) return NotFound();
        _dbContext.Pessoa.Remove(pessoaTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}