using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        public ClienteController(Contexto context)
        {
            _context = context;
        }

        private readonly Contexto _context;

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return Created("Cliente encontrado", cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteController>> GetCliente(int id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null)
            {
                return NotFound("Não existe nenhum cliente");
            }

            return Ok("Cliente encontrado"+Cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteDTO requisicao)
        {
           //if (id != requisicao.id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(requisicao).State = EntityState.Modified;

            try
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (!string.IsNullOrEmpty(requisicao.nome))
                    cliente.nome = requisicao.nome;
                if (!string.IsNullOrEmpty(requisicao.cpf))
                    cliente.cpf = requisicao.cpf;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound("Cliente não encontrado");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var Cliente2 = await _context.Clientes.FindAsync(id);
            if (Cliente2 == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _context.Clientes.Remove(Cliente2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
