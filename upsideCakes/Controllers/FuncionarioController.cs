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
    public async Task<ActionResult> CadastrarFunc(Funcionario func)
    {
        if (_dbContext is null) return NotFound();

        await _dbContext.AddAsync(func);
        await _dbContext.SaveChangesAsync();
        return Created("", func);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        return await _dbContext.Funcionario.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{_id}")]
    public async Task<ActionResult<Funcionario>> ListarPorID(int _id)
    {
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(_id);
        if (funcionarioTemp == null) return NotFound();
        return Ok(funcionarioTemp);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario func)
    {
        var existingFuncionario = await _dbContext.Funcionario.FindAsync(func._id);
        if (existingFuncionario is null) return NotFound();
        _dbContext.Entry(existingFuncionario).CurrentValues.SetValues(func);
        await _dbContext.SaveChangesAsync();
        return Ok("Funcionario alterado com sucesso.");
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int _id)
    {
        if (_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(_id);
        if (funcionarioTemp is null) return NotFound();
        _dbContext.Funcionario.Remove(funcionarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok("Funcionario excluido com sucesso.");
    }
}

