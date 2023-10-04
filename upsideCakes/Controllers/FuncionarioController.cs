using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers;
[ApiController]
[Route("[controller]")]

public class FuncionarioController : ControllerBase
{

    private readonly UpsideCakesDbContext _dbContext;
    public FuncionarioController(UpsideCakesDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> CadastrarFunc(Funcionario func)
    {
        if (_dbContext is null) return NotFound();

        await _dbContext.AddAsync(func);
        await _dbContext.SaveChangesAsync();
        return Created("", func);
    }

    //Listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        return await _dbContext.Funcionario.ToListAsync();
    }

    //Listar por ID
    [HttpGet]
    [Route("listar/{id}")]
    public async Task<ActionResult<Funcionario>> ListarPorID(int id)
    {
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        if (funcionarioTemp == null) return NotFound();
        return Ok(funcionarioTemp);
    }

    /* ALTERAR ANTIGO
     *  //Alterar
        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar (Funcionario func)
        {
            if (_dbContext.Funcionario is null) return NotFound();
            if (await _dbContext.Funcionario.FindAsync(func._id) is null) return NotFound();
            _dbContext.Update(func);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }*/

    //Alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario func)
    {
        var existingFuncionario = await _dbContext.Funcionario.FindAsync(func._id);
        if (existingFuncionario is null) return NotFound();

        /*EXPLICAÇÃO
         * 
         * Use Attach para indicar que você deseja atualizar a entidade existente
         * 
         * _dbContext: Esta é a instância do contexto do banco de dados do Entity Framework que você está usando para acessar e modificar os dados do banco de dados.

        existingFuncionario: É a entidade Funcionario existente que você recuperou do contexto do banco de dados usando await _dbContext.Funcionario.FindAsync(produto._id);. É importante notar que esta entidade já está sendo rastreada pelo contexto, pois você a recuperou com o FindAsync.

        .Entry(existingFuncionario): Isso é usado para obter um objeto EntityEntry associado à entidade existingFuncionario. O EntityEntry fornece informações sobre o estado da entidade no contexto, como se ela foi modificada, adicionada ou excluída.

        .CurrentValues: Isso é usado para obter um objeto que representa os valores atuais da entidade existingFuncionario no contexto. Basicamente, é uma representação dos valores da entidade conforme estão no contexto nesse momento.

        .SetValues(produto): Esta é a parte principal. Ela define os valores da entidade existingFuncionario para que correspondam aos valores da nova instância de produto que você está passando como parâmetro. Isso efetivamente copia os valores de produto para existingFuncionario.

        Em resumo, essa linha de código está copiando os valores da entidade produto (que é a nova versão que você deseja atualizar) para a entidade existingFuncionario (que já está sendo rastreada pelo contexto) antes de chamar SaveChangesAsync() para persistir as mudanças no banco de dados. Isso garante que os valores na entidade existente sejam atualizados com base nos valores da nova entidade, e é uma maneira eficaz de atualizar uma entidade existente no Entity Framework.
         */
        _dbContext.Entry(existingFuncionario).CurrentValues.SetValues(func);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    //Excluir
    [HttpDelete]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext.Funcionario is null) return NotFound();
        var funcionarioTemp = await _dbContext.Funcionario.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        _dbContext.Funcionario.Remove(funcionarioTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}

