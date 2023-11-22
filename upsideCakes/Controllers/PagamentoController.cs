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
        var pagamentoAlterar = await _dbContext.Pagamento.FindAsync(pagamento.id);
        if (pagamentoAlterar is null) return NotFound();
        _dbContext.Entry(pagamentoAlterar).CurrentValues.SetValues(pagamento);
        await _dbContext.SaveChangesAsync();
        return Ok();
    } 

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pagamento is null) return NotFound();

        return await _dbContext.Pagamento.ToListAsync();
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


    var detalhesPagamentos = new List<object>();

    foreach (var pagamento in pagamentos)
    {
        var detalhesPagamento = new
        {
            IDPagamento = pagamento.id,
            MetodoPagamento = pagamento.formaDePagamento,
            Valor = pagamento.valor,
            Data = pagamento.data,
            Cliente = new
            {
                Nome = pagamento.cliente.nome,
                Cpf = pagamento.cliente.cpf,
                Telefone = pagamento.cliente.telefone,
                Email = pagamento.cliente.email,

                // Adicione outros detalhes do cliente, se necessário
            },
            Pedido = new
            {
                Numero = pagamento.pedido.itens,
                Total = pagamento.pedido.qtde,
                // Adicione outros detalhes do pedido, se necessário
            }
        };

        detalhesPagamentos.Add(detalhesPagamento);
    }

    return Ok(detalhesPagamentos);
    }

*/
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
        return Ok();
    }
}
