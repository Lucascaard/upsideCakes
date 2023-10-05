
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;
using upsideCakes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Cliente cliente)
        {
            var existingCliente = await _dbContext.Funcionario.FindAsync(cliente._id);
            if (existingCliente is null) return NotFound();
            _dbContext.Entry(existingCliente).CurrentValues.SetValues(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok();
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