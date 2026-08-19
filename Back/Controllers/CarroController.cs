using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Created("", carro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarroController>> GetCarro(long id)
        {
            var Carro = await _context.Carros.FindAsync(id);

            if (Carro == null)
            {
                return NotFound();
            }

            return Ok(Carro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(long id, Carro carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        private bool CarroExists(long id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(long id)
        {
            var Carro2 = await _context.Carros.FindAsync(id);
            if (Carro2 == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(Carro2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
