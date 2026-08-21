using Back.DTO_s;
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
        public async Task<IActionResult> PutCarro(long id, [FromBody] CarroDTO requisicao)
        {
            try
            {

                var carro = await _context.Carros.FindAsync(id);

                if (carro == null)
                    return BadRequest("carro não existe");

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

                return Ok("Carro criado com sucesso\n" + carro);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
                {
                    return NotFound("Carro não encontrado");
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
