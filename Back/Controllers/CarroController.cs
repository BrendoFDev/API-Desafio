using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        public CarroController(Contexto context)
        {
            _context = context;
        }

        private readonly Contexto _context;


        [HttpPost]
        public async Task<ActionResult<CarroController>> PostCarro(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

            return Created("Carro criado com sucesso. ", carro);
        }

       [HttpGet]
    public async Task<IActionResult> GetCarros(
           [FromQuery] int pagina = 1,
           [FromQuery] int tamanhoPagina = 10,
           [FromQuery] string? marca = null,
           [FromQuery] string? modelo = null,
           [FromQuery] int? ano = null,
           [FromQuery] string? cor = null)
      {
            var query = _context.Carros.AsQueryable();

            
            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(c => EF.Functions.Like(c.Marca, $"%{marca}%"));
            }

            
            if (!string.IsNullOrEmpty(modelo))
            {
                query = query.Where(c => EF.Functions.Like(c.Modelo, $"%{modelo}%"));
            }

            
            if (ano.HasValue)
            {
                query = query.Where(c => c.Ano == ano.Value);
            }

            
            if (!string.IsNullOrEmpty(cor))
            {
                query = query.Where(c => EF.Functions.Like(c.Cor, $"%{cor}%"));
            }

            
            var carros = await query
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return Ok(carros);
        }
    



    [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(long id, [FromBody] CarroDTO requisicao)
        {
            try
            {

                var carro = await _context.Carros.FindAsync(id);

                if (carro == null)
                    return BadRequest("carro não existe.");

                if (!string.IsNullOrEmpty(requisicao.Cor))
                    carro.Cor = requisicao.Cor;
                if (!string.IsNullOrEmpty(requisicao.Modelo))
                    carro.Modelo = requisicao.Modelo;
                if (!string.IsNullOrEmpty(requisicao.Marca))
                    carro.Marca = requisicao.Marca;
                if (requisicao.Ano.HasValue)
                    carro.Ano = requisicao.Ano.Value;
                if (requisicao.Preco.HasValue)
                    carro.Preco = requisicao.Preco.Value;


                await _context.SaveChangesAsync();

                return Ok("Carro atualizado com sucesso");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
                {
                    return NotFound("Carro não encontrado.");
                }
                else
                {
                    throw;
                }
            }


        }

        private bool CarroExists(long id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(long id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound("Carro não encontrado.");

            // Verifica se existe alguma reserva para este carro
            bool possuiReserva = await _context.Reservas.AnyAsync(r => r.CarroId == id);

            if (possuiReserva)
            {
                return BadRequest("Não é possível remover o carro porque ele possui reservas vinculadas.");
            }

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
