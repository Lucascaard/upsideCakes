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
    [Route("listar/{_id}")]
    public async Task<ActionResult<Filial>> ListarPorID (int _id)
    {
        var filialTemp = await _dbContext.Filial.FindAsync(_id);
        if (filialTemp is null) return NotFound();
        return Ok(filialTemp);
    }

    [HttpPut]
    [Route("alterarCep")]
    public async Task<ActionResult> alterarCep (int _id, string novoCep)
    {
        var filial = await _dbContext.Filial.FindAsync(_id);
        if(filial._id == 0 || novoCep is null) return NotFound();
        filial._cep = novoCep;
        _dbContext.Update(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }

    [HttpPut]
    [Route("alterarRua")]
    public async Task<ActionResult> alterarRua (int _id, string rua)
    {
        var filial = await _dbContext.Filial.FindAsync(_id);
        if( filial is null || rua is null) return NotFound();
        filial._rua = rua;
        _dbContext.Update(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }

    [HttpPut]
    [Route("alterarCidade")]
    public async Task<ActionResult> alterarCidade (int _id, string cidade)
    {
        var filial = await _dbContext.Filial.FindAsync(_id);
        if(filial is null || cidade is null) return NotFound();
        filial._cidade = cidade;
        _dbContext.Update(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int _id)
    {
        var filial = await _dbContext.Filial.FindAsync(_id);

        if(filial is null || _id  == 0)
        {
            return NotFound();
        }
        _dbContext.Filial.Remove(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }
}