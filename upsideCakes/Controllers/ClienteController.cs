/*
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
    [Route("cliente")]
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
            if (cliente == null)
                return BadRequest("Dados inválidos");

            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return Created("Cadastrado com sucesso", cliente);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            var clientes = await _dbContext.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Buscar(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Alterar(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest("Dados inválidos");

            var clienteExistente = await _dbContext.Clientes.FindAsync(id);
            if (clienteExistente == null)
                return NotFound("Cliente não encontrado");

            _dbContext.Entry(clienteExistente).CurrentValues.SetValues(cliente);
            await _dbContext.SaveChangesAsync();

            return Ok("Cliente alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado");

            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();

            return Ok($"Cliente com ID {id} excluído com sucesso.");
        }
    }
}
*/