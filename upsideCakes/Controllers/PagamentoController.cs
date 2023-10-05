using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;

      public PagamentoController(UpsideCakesDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    [Route("novopagamento")]
    public async Task<ActionResult> Cadastrar(Pagamento pagamento)
    {
        if (_dbContext is null) return NotFound();

       /*/ var clienteExiste = await _dbContext.Cliente.FindAsync(pagamento._cliente);
        if (clienteExiste is null) return BadRequest("Cliente especificado não existe"); */

        var pedidoExiste = await _dbContext.Pedido.FindAsync(pagamento._pedido._id);
        if (pedidoExiste is null) return BadRequest("Pedido especificado não existe");

        await _dbContext.AddAsync(pagamento);
        await _dbContext.SaveChangesAsync();
        return Created("Pagamento realizado!", pagamento);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pagamento pagamento)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoAlterar = await _dbContext.Pagamento.FindAsync(pagamento._id);
        if (pagamentoAlterar is null) return NotFound();
        _dbContext.Entry(pagamentoAlterar).CurrentValues.SetValues(pagamento);
        await _dbContext.SaveChangesAsync();
        return Created("Alterado com sucesso", pagamento);
    }

    [HttpDelete()]
    [Route("excluir/{_id}")]
    public async Task<ActionResult> Excluir(int _id)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoDeletar = await _dbContext.Pagamento.FindAsync(_id);
        if (pagamentoDeletar is null) return NotFound();
        _dbContext.Pagamento.Remove(pagamentoDeletar);
        await _dbContext.SaveChangesAsync();
        return Ok($"Pagamento com id {_id} deletado com successo!");
    }

}
