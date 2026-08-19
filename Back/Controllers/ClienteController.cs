using Back.Models
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
            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return Created("", cliente)
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteController>> GetCliente(long id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != Cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var Cliente2 = await _context.Cliente.FindAsync(id);
            if (Cliente2 == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(Cliente2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
