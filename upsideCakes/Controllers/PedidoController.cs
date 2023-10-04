using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        var genExiste = await _dbContext.Funcionario.FindAsync(pedido._gerenteID);
        if (genExiste is null) return BadRequest("Gerente especificado não existe");

        // Validação da Lista de Itens
        if (pedido._itens != null)
        {
            foreach (var itemPedido in pedido._itens)
            {
                // Verifique se o produto com o ID especificado existe no banco de dados
                var produtoExistente = await _dbContext.Produto.FindAsync(itemPedido._id);
                if (produtoExistente == null)
                {
                    // Se o produto não existe, adicione uma mensagem de erro à lista de erros
                    erros.Add($"Produto com o ID {itemPedido._id} não existe.");
                }
                else
                {
                    // Desanexe o objeto Produto do contexto do Entity Framework
                    /*EXPLICAÇÃO
                     A linha _dbContext.Entry(produtoExistente).State = EntityState.Detached; tem a função de desanexar (ou desconectar) uma entidade do contexto do Entity Framework. Isso significa que o objeto produtoExistente, que representa uma entidade do banco de dados, não será mais rastreado pelo contexto do Entity Framework após essa operação.

                    Quando uma entidade está anexada ao contexto (o estado é "Attached"), o Entity Framework a rastreia e a monitora para detectar alterações. No entanto, em alguns cenários, você pode querer interromper o rastreamento dessa entidade, como no caso em que você está reutilizando objetos que já foram buscados do banco de dados anteriormente e não deseja que o Entity Framework rastreie suas alterações.

                    Ao definir o estado da entidade como EntityState.Detached, você está informando ao Entity Framework que ele não deve mais rastrear essa entidade, e quaisquer alterações feitas no objeto produtoExistente após esse ponto não serão refletidas no banco de dados, a menos que você anexe explicitamente a entidade novamente ao contexto.

                    Essa operação é útil quando você deseja trabalhar com objetos desconectados, fazendo modificações neles sem que o Entity Framework as rastreie automaticamente. Em essência, "desanexar" uma entidade permite que você gerencie manualmente seu ciclo de vida em vez de depender do rastreamento automático do Entity Framework.
                     */
                    _dbContext.Entry(produtoExistente).State = EntityState.Detached;
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
        return Ok("Pedido criado com sucesso!");
    }

    //Listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pedido>>> Listar()
    {
        return await _dbContext.Pedido.ToListAsync();
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





