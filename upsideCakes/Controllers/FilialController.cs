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
    [Route("listar/{cep}")]
    public async Task<ActionResult<Filial>> ListarPorID(string cep)
    {
        var filialTemp = await _dbContext.Filial.FindAsync(cep);
        if (filialTemp is null) return NotFound();
        return Ok(filialTemp);
    }

    [HttpPut]
    [Route("alterarCep")]
    public async Task<ActionResult> alterarCep (string cep, string novoCep)
    {
        var filial = await _dbContext.Filial.FindAsync(cep);
        // var item = _dbContext.Produto
        //     .FirstOrDefault(c => c._id == id);

        if(filial._cep is null || novoCep is null)
        {
            return NotFound();
        }

        filial._cep = novoCep;
        // _dbContext.Entry(filial).CurrentValues.SetValues(cep);
        _dbContext.Update(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }

    [HttpPut]
    [Route("alterarRua")]
    public async Task<ActionResult> alterarRua (string cep, string rua)
    {
        var filial = await _dbContext.Filial.FindAsync(cep);
        // var item = _dbContext.Produto
        //     .FirstOrDefault(c => c._id == id);

        if(filial._rua is null || rua is null)
        {
            return NotFound();
        }

        filial._rua = rua;
        // _dbContext.Entry(filial).CurrentValues.SetValues(cep);
        _dbContext.Update(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }

    [HttpPut]
    [Route("alterarCidade")]
    public async Task<ActionResult> alterarCidade (string cep, string cidade)
    {
        var filial = await _dbContext.Filial.FindAsync(cep);
        // var item = _dbContext.Produto
        //     .FirstOrDefault(c => c._id == id);

        if(filial._cidade is null || cidade is null)
        {
            return NotFound();
        }

        filial._cidade = cidade;
        // _dbContext.Entry(filial).CurrentValues.SetValues(cep);
        _dbContext.Update(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> ExcluirItem(string cep)
    {
        var filial = await _dbContext.Filial.FindAsync(cep);

        if(filial is null || cep is null)
        {
            return NotFound();
        }
        _dbContext.Filial.Remove(filial);
        await _dbContext.SaveChangesAsync();
        return Ok(filial);
    }
}