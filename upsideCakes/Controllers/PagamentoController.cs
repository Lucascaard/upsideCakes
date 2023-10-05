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

        var clienteExiste = await _dbContext.Cliente.FindAsync(pagamento._cliente);
        if (clienteExiste is null) return BadRequest("Cliente especificado não existe");

        var pedidoExiste = await _dbContext.Pedido.FindAsync(pagamento._pedido);
        if (pedidoExiste is null) return BadRequest("Pedido especificado não existe");

        await _dbContext.AddAsync(pagamento);
        await _dbContext.SaveChangesAsync();
        return Created("Pagamento realizado!", pagamento);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        return await _dbContext.Pagamento.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{_idPedido}")]
    public async Task<ActionResult<Pagamento>> Buscar(int idPedido)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoLista = await _dbContext.Pagamento.FindAsync(idPedido);
        if (pagamentoLista is null) return NotFound();
        return pagamentoLista;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pagamento pagamento)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoAlterar = await _dbContext.Pagamento.FindAsync(pagamento._idPedido);
        if (pagamentoAlterar is null) return NotFound();
        _dbContext.Pagamento.Update(pagamento);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{_idPedido}")]
    public async Task<ActionResult> Excluir([FromRoute] int _idPedido)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoDeletar = await _dbContext.Pagamento.FindAsync(_idPedido);
        if (pagamentoDeletar is null) return NotFound();
        _dbContext.Pagamento.Remove(pagamentoDeletar);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}
