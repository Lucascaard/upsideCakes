using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]

public class PedidoController : ControllerBase
{
        private readonly UpsideCakesDbContext _dbContext;
        public PedidoController(UpsideCakesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    [HttpPost]
    [Route("novopedido")]
    public async Task<ActionResult> NovoPedido(Pedido pedido)
    {
        var erros = new List<string>();

        var funcExiste = await _dbContext.Funcionario.FindAsync(pedido.funcionarioID);
        if (funcExiste is null) return BadRequest("Funcionário especificado não existe");

        var genExiste = await _dbContext.Gerente.FindAsync(pedido.gerenteID);
        if (genExiste is null) return BadRequest("Gerente especificado não existe");

        if(pedido.itens != null)
        {
            foreach (var item in pedido.itens)
            {
                var TMP_ID = 0;
                TMP_ID = await _dbContext.Produto
                    .Where(p => p.id == item.id)
                    .Select(p => p.id)
                    .FirstOrDefaultAsync();

                if (TMP_ID == 0)
                {
                    erros.Add($"O produto '{item.nome}' com id {item.id} não existe.");
                }
            }
        }

        if (erros.Count > 0) return BadRequest(erros);

        await _dbContext.Pedido.AddAsync(pedido);
        await _dbContext.SaveChangesAsync();
        return Created("Pedido criado com sucesso!", pedido);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pedido>>> Listar()
    {
        return await _dbContext.Pedido.ToListAsync();
    }

    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Pedido>> ListarPorID(int id)
    {
        var pedidoTemp = await _dbContext.Pedido.FindAsync(id);
        if (pedidoTemp == null) return NotFound();
        return Ok(pedidoTemp);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pedido pedido)
    {
        var existingPedido = await _dbContext.Pedido.FindAsync(pedido.id);
        if (existingPedido is null) return NotFound();
        _dbContext.Entry(existingPedido).CurrentValues.SetValues(pedido);
        await _dbContext.SaveChangesAsync();
        return Ok($"Pedido com id {pedido.id} alterado com sucesso.");
    }

    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext.Pedido is null) return NotFound();
        var pedidoTemp = await _dbContext.Pedido.FindAsync(id);
        if (pedidoTemp is null) return NotFound();
        _dbContext.Pedido.Remove(pedidoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok($"Pedido com {id} excluido com sucesso!");
    }
}





