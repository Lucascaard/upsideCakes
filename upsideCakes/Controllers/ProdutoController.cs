using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;


namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{
    private readonly UpsideCakesDbContext _dbContext;
    public ProdutoController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Produto produto)
    {
        await _dbContext.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
        return Created($"Produto '{produto._nome}' cadastrado com sucesso.", produto);
    }

    //Listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Produto>>> Listar()
    {
        return await _dbContext.Produto.ToListAsync();
    }

    //Listar por ID
    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Produto>> ListarPorID (int id)
    {
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp == null) return NotFound();
        return Ok(produtoTemp);
    }

    //Alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Produto produto)
    {
        var existingProduto = await _dbContext.Produto.FindAsync(produto._id);
        if (existingProduto is null) return NotFound();

        /*EXPLICAÇÃO
         * 
         * Use Attach para indicar que você deseja atualizar a entidade existente
         * 
         * _dbContext: Esta é a instância do contexto do banco de dados do Entity Framework que você está usando para acessar e modificar os dados do banco de dados.

        existingProduto: É a entidade Produto existente que você recuperou do contexto do banco de dados usando await _dbContext.Produto.FindAsync(produto._id);. É importante notar que esta entidade já está sendo rastreada pelo contexto, pois você a recuperou com o FindAsync.

        .Entry(existingProduto): Isso é usado para obter um objeto EntityEntry associado à entidade existingProduto. O EntityEntry fornece informações sobre o estado da entidade no contexto, como se ela foi modificada, adicionada ou excluída.

        .CurrentValues: Isso é usado para obter um objeto que representa os valores atuais da entidade existingProduto no contexto. Basicamente, é uma representação dos valores da entidade conforme estão no contexto nesse momento.

        .SetValues(produto): Esta é a parte principal. Ela define os valores da entidade existingProduto para que correspondam aos valores da nova instância de produto que você está passando como parâmetro. Isso efetivamente copia os valores de produto para existingProduto.

        Em resumo, essa linha de código está copiando os valores da entidade produto (que é a nova versão que você deseja atualizar) para a entidade existingProduto (que já está sendo rastreada pelo contexto) antes de chamar SaveChangesAsync() para persistir as mudanças no banco de dados. Isso garante que os valores na entidade existente sejam atualizados com base nos valores da nova entidade, e é uma maneira eficaz de atualizar uma entidade existente no Entity Framework.
         */
        _dbContext.Entry(existingProduto).CurrentValues.SetValues(produto);
        await _dbContext.SaveChangesAsync();
        return Ok($"Produto {produto._nome} alterado com sucesso.");
    }

    //Alterar somente preço
    [HttpPatch]
    [Route("alterarpreco/{id}")]
    public async Task<ActionResult> AtualizarPreco (int id, [FromForm] float preco)
    {
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp is null) return NotFound();
        produtoTemp._preco = preco;
        await _dbContext.SaveChangesAsync();
        return Ok($"Preço do produto {produtoTemp._nome} alterado para R${preco}");
    }

    //Excluir
    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir (int id)
    {
        if (_dbContext.Produto is null) return NotFound();
        var produtoTemp = await _dbContext.Produto.FindAsync(id);
        if (produtoTemp is null) return NotFound();
        _dbContext.Produto.Remove(produtoTemp);
        await _dbContext.SaveChangesAsync();
        return Ok($"Produto {produtoTemp._nome} excluido com sucesso.");
    }
}
