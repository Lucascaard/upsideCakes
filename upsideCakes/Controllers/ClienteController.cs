
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;

namespace upsideCakes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly UpsideCakesDbContext _dbContext;

        public ClienteController(UpsideCakesDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Cliente cliente)
        {
            if (cliente == null) return BadRequest("Dados inválidos");
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return Created("Cliente cadastrado com sucesso", cliente);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            var Cliente = await _dbContext.Cliente.ToListAsync();
            return Ok(Cliente);
        }

        [HttpGet()]
        [Route("buscar/{_id}")]
        public async Task<ActionResult<Cliente>> Buscar(int _id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            var clienteLista = await _dbContext.Cliente.FindAsync(_id);
            if (clienteLista is null) return NotFound();

            return clienteLista;
        }

        [HttpDelete()]
        [Route("excluir/{_id}")]
        public async Task<ActionResult> Excluir(int _id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Cliente is null) return NotFound();

            var clienteDeletar = await _dbContext.Cliente.FindAsync(_id);
            if (clienteDeletar is null) return NotFound();

            _dbContext.Cliente.Remove(clienteDeletar);
            await _dbContext.SaveChangesAsync();
            return Ok($"Cliente com id {_id} excluido com sucesso. ");
        }
    }

}