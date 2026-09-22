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

        [HttpGet]
        public async Task<ActionResult<Paginacao<ReservaDTO>>> GetReservas(
           [FromQuery] int paginaAtual = 1,
           [FromQuery] int tamanhoPagina = 10,
           [FromQuery] int? CarroId = null,
           [FromQuery] int? ClienteId = null,
           [FromQuery] int? Id = null)
        {
            if (paginaAtual < 1) paginaAtual = 1;
            if (tamanhoPagina < 1) tamanhoPagina = 10;
           
            var query = _context.Reservas.AsQueryable();


            if (!Id.HasValue)
            {

                query = query.Where(c => EF.Functions.Like(c.Id.ToString(), $"%{Id}%"));
            }


            if (!ClienteId.HasValue)
            {
                query = query.Where(c => EF.Functions.Like(c.ClienteId.ToString(), $"%{ClienteId}%"));
            }
            
            if (!CarroId.HasValue)
            {
                query = query.Where(c => EF.Functions.Like(c.CarroId.ToString(), $"%{CarroId}%"));
            }

            var totalRegistro = await query.CountAsync();


            var items = await query
                .Select(r => new ReservaDTO
                {
                    Id = r.Id,
                    ClienteId = r.ClienteId,
                    ClienteNome = r.cliente.Nome,

                    CarroId = r.CarroId,
                    ModeloNome = r.carro.Modelo.NomeModelo
                })
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            var resultado = new Paginacao<ReservaDTO>
            {
                Items = items,
                TotalRegistro = totalRegistro,
                PaginaAtual = paginaAtual,
                TamanhoPagina = tamanhoPagina
            };

            return Ok(resultado);
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

        [HttpGet("total")]
        public async Task<ActionResult<List<ReservaDTO>>> GetTotalReservas()
        {
            var totalReservas = await _context.Reservas
              


                .Select(r => new ReservaDTO
                {
                    Id = r.Id,
                    ClienteId = r.ClienteId,
                    ClienteNome = r.cliente.Nome,
 
                    CarroId = r.CarroId,
                    ModeloNome = r.carro.Modelo.NomeModelo
                })
                .ToListAsync();
            return Ok(totalReservas);
        }
    }
}
