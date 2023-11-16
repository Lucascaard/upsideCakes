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

   var clienteExiste = await _dbContext.Cliente.FindAsync(pagamento.idCliente);
   if (clienteExiste is null) return BadRequest("Cliente especificado não existe");

   var pedidoExiste = await _dbContext.Pedido.FindAsync(pagamento.idPedido);
   if (pedidoExiste is null) return BadRequest("Pedido especificado não existe");

   // Carregar a entidade para atualização
   var pagamentoExiste = await _dbContext.Pagamento.FindAsync(pagamento.id);
   if (pagamentoExiste != null)
   {
       _dbContext.Entry(pagamentoExiste).CurrentValues.SetValues(pagamento);
   }
   else
   {
       await _dbContext.AddAsync(pagamento);
   }

   await _dbContext.SaveChangesAsync();
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
/*
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();

        var pagamentos = await _dbContext.Pagamento
            .Include(p => p.Clientes)  // Inclua a referência para o Cliente
            .Include(p => p.Pedidos)   // Inclua a referência para o Pedido
            .ToListAsync();

        return pagamentos;
    }
*/
 [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
        {
            if (_dbContext is null || _dbContext.Pagamento is null)
                return NotFound("Não foi possível acessar os dados de Pagamento.");

            var pagamentos = await _dbContext.Pagamento
                .Include(p => p.cliente) // Inclui a propriedade de navegação Cliente
                .Include(p => p.pedido) // Inclui a propriedade de navegação Pedido
                .ToListAsync();

            return Ok(pagamentos);
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
