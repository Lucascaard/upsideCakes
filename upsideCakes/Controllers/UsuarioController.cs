using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;

[ApiController]
[Route("[controller]")]

public class UsuarioController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;

    public UsuarioController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Usuario usuario)
    {
        await _dbContext.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return Created("", usuario);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Usuario>>> Listar()
    {
        return await _dbContext.Usuario.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{login}")]
    public async Task<ActionResult<Usuario>> Buscar(string login)
    {
        if(_dbContext.Usuario is null) return NotFound();
        var usuarioTemp = await _dbContext.Usuario.FindAsync(login);
        if(usuarioTemp is null) return NotFound();
        return usuarioTemp;
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Usuario usuario)
    {
        if(_dbContext.Usuario is null) return NotFound();
        if(await _dbContext.Usuario.FindAsync(usuario._login) is null) return NotFound();
        _dbContext.Update(usuario);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    [Route("mudarsenha/{login}")]
    public async Task<ActionResult> MudarSenha(string login, [FromForm] string senha)
    {
        if(_dbContext.Usuario is null) return NotFound();
        var usuarioTemp = await _dbContext.Usuario.FindAsync(login);
        if(usuarioTemp is null) return NotFound();
        usuarioTemp._senha = senha;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(string login)
    {
        if(_dbContext.Usuario is null) return NotFound();
        var usuarioTemp = await _dbContext.Usuario.FindAsync(login);
        if(usuarioTemp is null) return NotFound();
        _dbContext.Usuario.Remove(usuarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}