using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        public ReservasController(Contexto context)
        {
            _context = context;
        }

        private readonly Contexto _context;
        [HttpPost]
        public async Task<ActionResult<ReservasController>> PostReserva(ReservaDTO requisicao)
        {


            var reserva = new Reserva
            {
                ClienteId = requisicao.ClienteId,
                CarroId = requisicao.CarroId
            };

            bool possuiReserva = await _context.Reservas.AnyAsync(r => r.ClienteId == requisicao.ClienteId && r.CarroId == requisicao.CarroId);
        

            bool ClienteExiste = await _context.Clientes.AnyAsync(r => r.id == requisicao.ClienteId);
            bool CarroExiste = await _context.Carros.AnyAsync(r => r.Id == requisicao.CarroId);

            if (!ClienteExiste)
            {
                return BadRequest("Cliente não existe, digite um ID válido");
            }

            if (!CarroExiste)
            {
                return BadRequest("Carro não existe, digite um ID válido");
            }

            if (possuiReserva)
            {
                return BadRequest("Essa reserva já existe");
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return Created("Reserva criada com sucesso", reserva);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservasController>> GetReserva(int id)
        {
            var Reserva = await _context.Reservas.FindAsync(id);

            if (Reserva == null)
            {
                return NotFound("Reserva não encontrado.");
            }

            return Ok(Reserva);
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reservas)
        {
            if (id != reservas.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                {
                    return NotFound("Reserva não encontrada.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Reserva atualizada com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var Reserva2 = await _context.Reservas.FindAsync(id);
            if (Reserva2 == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(Reserva2);
            await _context.SaveChangesAsync();

            return Ok("Reserva deletada com sucesso");
        }
    }
}
