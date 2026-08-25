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


            bool cpfExiste = await _context.Clientes.AnyAsync(r => r.Cpf == cliente.Cpf);

            

            if (cpfExiste)
            {
               return BadRequest("Este CPF já está cadastrado no sistema.");
            }
            string cpfLimpo = cliente.Cpf.Replace(".", "").Replace("-", "").Trim();

           
            if (!cpfLimpo.All(char.IsDigit) || cpfLimpo.Length != 11)
            {
                return BadRequest("CPF inválido... ");
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Created("Cliente criado com sucesso", cliente);

        }
       

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteController>> GetCliente(int id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null)
            {
                return NotFound("Não existe nenhum cliente");
            }

            return Ok(Cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteDTO requisicao)
        {

            try
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (!string.IsNullOrEmpty(requisicao.Nome))
                    cliente.Nome = requisicao.Nome;
                if (!string.IsNullOrEmpty(requisicao.Cpf))
                    cliente.Cpf = requisicao.Cpf;
                await _context.SaveChangesAsync();

                return Ok("Cliente atualizado com sucesso");
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


        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.id == id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);
            if (Cliente == null) return NotFound("Cliente não encontrado.");

            bool possuiReserva = await _context.Reservas.AnyAsync(r => r.ClienteId == id);

            if (possuiReserva)
            {
                return BadRequest("Não é possível remover o carro porque ele possui reservas vinculadas.");
            }

            _context.Clientes.Remove(Cliente);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
