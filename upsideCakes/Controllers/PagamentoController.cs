using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;
using static upsideCakes.Controllers.ClienteController;
using static upsideCakes.Controllers.PedidoController;

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
        
        using (var novoContexto = new UpsideCakesDbContext())
        {
        // Verifica se o cliente existe
            var clientesResult = await BuscarCliente(pagamento.idCliente);
            var clientes = clientesResult.Value; // Obtém a lista de clientes do ActionResult
            var cliente = clientes.FirstOrDefault(); // Pega o primeiro cliente da lista (se existir)

            if (cliente == null)
            {
                return BadRequest("Cliente especificado não existe");
            }

            // Verifica se o pedido existe
            var pedidosResult = await BuscarPedido(pagamento.idPedido);
            var pedidos = pedidosResult.Value; // Obtém a lista de pedidos do ActionResult
            var pedido = pedidos.FirstOrDefault(); // Pega o primeiro pedido da lista (se existir)

            if (pedido == null)
            {
                return BadRequest("Pedido especificado não existe");
            }

            pagamento.Clientes = new List<Cliente> { cliente };
            pagamento.Pedidos = new List<Pedido> { pedido };


            await novoContexto.AddAsync(pagamento);
            await novoContexto.SaveChangesAsync();
        }

        return Created("Pagamento realizado!", pagamento);
    }




    [HttpGet()]
    [Route("buscarCliente/{id}")]
    public async Task<ActionResult<Cliente>> BuscarCliente(int id)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Cliente is null) return NotFound();

        var clienteLista = await _dbContext.Cliente.FindAsync(id);
        if (clienteLista is null) return NotFound();

        return clienteLista;
    }

    [HttpGet()]
    [Route("buscarPedido/{id}")]
    public async Task<ActionResult<Pedido>> BuscarPedido(int id)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pedido is null) return NotFound();

        var pedidoLista = await _dbContext.Pedido.FindAsync(id);
        if (pedidoLista is null) return NotFound();

        return pedidoLista;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pagamento pagamento)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoAlterar = await _dbContext.Pagamento.FindAsync(pagamento.id);
        if (pagamentoAlterar is null) return NotFound();
        _dbContext.Entry(pagamentoAlterar).CurrentValues.SetValues(pagamento);
        await _dbContext.SaveChangesAsync();
        return Created("Alterado com sucesso", pagamento);
    }


    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();

        var pagamentos = await _dbContext.Pagamento
        .Include(p => p.Clientes)
        .Include(p => p.Pedidos)
        .ToListAsync();

        return await _dbContext.Pagamento.ToListAsync();
    }


    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();
        var pagamentoDeletar = await _dbContext.Pagamento.FindAsync(id);
        if (pagamentoDeletar is null) return NotFound();
        _dbContext.Pagamento.Remove(pagamentoDeletar);
        await _dbContext.SaveChangesAsync();
        return Ok($"Pagamento com id {id} deletado com successo!");
    }

}
