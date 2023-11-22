using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]

public class FuncionarioController : ControllerBase
{

    private readonly UpsideCakesDbContext _dbContext;
    public FuncionarioController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> CadastrarFunc(Funcionario funcionario)
    {
        if (_dbContext is null) return NotFound();

        await _dbContext.AddAsync(funcionario);
        await _dbContext.SaveChangesAsync();
        return Created("", funcionario);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        return await _dbContext.Funcionario.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Funcionario>> BuscarPorId(int id)
    {
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        if (funcionarioTemp == null) return NotFound();
        return Ok(funcionarioTemp);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario func)
    {
        var existingFuncionario = await _dbContext.Funcionario.FindAsync(func.id);
        if (existingFuncionario is null) return NotFound();
        _dbContext.Entry(existingFuncionario).CurrentValues.SetValues(func);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        _dbContext.Funcionario.Remove(funcionarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}

