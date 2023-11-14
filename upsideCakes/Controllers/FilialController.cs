using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;

[ApiController]
[Route("[controller]")]

public class FilialController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;

    public FilialController(UpsideCakesDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Filial filial)
    {
        if (filial == null) return NotFound();
        await _dbContext.Filial.AddAsync(filial);
        await _dbContext.SaveChangesAsync();
        return Created("Filial cadastrada com sucesso", filial);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Filial>>> Listar()
    {   
        return await _dbContext.Filial.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Filial>> ListarPorID (int id)
    {
        var filialTemp = await _dbContext.Filial.FindAsync(id);
        if (filialTemp is null) return NotFound();
        return Ok(filialTemp);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> alterar (Filial filial)
    {
        var newFilial = await _dbContext.Filial.FindAsync(filial.id);
        if(newFilial is null) return NotFound();
        newFilial.cidade = filial.cidade;
        newFilial.rua = filial.rua;
        newFilial.cep = filial.cep;
        _dbContext.Update(newFilial);
        await _dbContext.SaveChangesAsync();
        return Ok(newFilial);
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        var filial = await _dbContext.Filial.FindAsync(id);

        if(filial is null || id  == 0)
        {
            return NotFound();
        }
        _dbContext.Filial.Remove(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }
}