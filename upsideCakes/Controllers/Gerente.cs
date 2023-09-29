using Microsoft.AspNetCore.Mvc;
using ups_idGerenteeCakes.Models;
using ups_idGerenteeCakes.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiFindWorks.Controllers;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private ProductDbContext _dbContext;

    public GerenteController(ProductDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Gerente>>> Listar()
    {
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Gerente.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Gerente Gerente)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(Gerente);
        await _dbContext.SaveChangesAsync();
        return Created("", Gerente);
    }
    
    [HttpGet()]
    [Route("buscar/{_idGerente}")]
    public async Task<ActionResult<Gerente>> Buscar([FromRoute] int _idGerente)
    {
        if (_dbContext is null)
            return NotFound();
        var Gerente = await _dbContext.Gerente.FindAsync(_idGerente);
        if (Gerente is null)
            return NotFound();
        return Gerente;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Gerente Gerente)
    {
        if (_dbContext is null)
            return NotFound();

        // Busque o registro existente pelo _idGerente (ou outra chave primária) do usuário
        var existingGerente = await _dbContext.Gerente.FindAsync(Gerente._idGerente);

        if (existingGerente is null)
            return NotFound();

        // Atualize apenas os campos que foram fornec_idGerenteos no objeto usuário
        if (Gerente.__nomeGerente  != "string")
        {
            existingGerente._nomeGerente  = Gerente._nomeGerente ;
        }

        if (Gerente.Senha != "string")
        {
            existingGerente.Senha = Gerente.Senha;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingGerente).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{_idGerente}")]
    public async Task<ActionResult> Excluir([FromRoute] int _idGerente)
    {
        if (_dbContext is null) return NotFound();
        var Gerente = await _dbContext.Gerente.FindAsync(_idGerente);
        if (Gerente is null) return NotFound();
        _dbContext.Gerente.Remove(Gerente);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}