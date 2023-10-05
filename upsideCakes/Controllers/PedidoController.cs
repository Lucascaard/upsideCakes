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

        // Validação do Funcionário
        var funcExiste = await _dbContext.Funcionario.FindAsync(pedido._funcionarioID);
        if (funcExiste is null) return BadRequest("Funcionário especificado não existe");

        // Validação do Gerente
        var genExiste = await _dbContext.Gerente.FindAsync(pedido._gerenteID);
        if (genExiste is null) return BadRequest("Gerente especificado não existe");

        if(pedido._itens != null)
        {
            foreach (var item in pedido._itens)
            {
                var TMP_ID = 0;
                TMP_ID = await _dbContext.Produto
                    .Where(p => p._id == item._id)
                    .Select(p => p._id)
                    .FirstOrDefaultAsync();

                if (TMP_ID == 0)
                {
                    erros.Add($"O produto '{item._nome}' com id {item._id} não existe.");
                }
            }
        }
        // Se houver erros de validação, retorne uma resposta BadRequest
        if (erros.Count > 0)
        {
            // A resposta BadRequest indica que a solicitação do cliente contém dados inválidos
            return BadRequest(erros);
        }

        // Se todas as validações passarem, continue com a criação do pedido
        await _dbContext.Pedido.AddAsync(pedido);
        await _dbContext.SaveChangesAsync();
        return Created("Pedido criado com sucesso!", pedido);
    }

    //Listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pedido>>> Listar()
    {
        return await _dbContext.Pedido.ToListAsync();
    }

    //Listar por ID
    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Pedido>> ListarPorID(int id)
    {
        var pedidoTemp = await _dbContext.Pedido.FindAsync(id);
        if (pedidoTemp == null) return NotFound();
        return Ok(pedidoTemp);
    }

    //Alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pedido pedido)
    {
        var existingPedido = await _dbContext.Pedido.FindAsync(pedido._id);
        if (existingPedido is null) return NotFound();
        _dbContext.Entry(existingPedido).CurrentValues.SetValues(pedido);
        await _dbContext.SaveChangesAsync();
        return Ok($"Pedido com id {pedido._id} alterado com sucesso.");
    }

    //Excluir
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





