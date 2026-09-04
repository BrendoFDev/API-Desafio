using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public MarcaController(Contexto context)
        {
            _context = context;
        }

        private readonly Contexto _context;
        [HttpPost]
        public async Task<ActionResult<MarcaController>> PostMarca(Marca marca)
        {

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return Created("Marca criado com sucesso. ", marca);
        }
        [HttpGet]

        public async Task<ActionResult<Paginacao<Marca>>> GetMarca(
           [FromQuery] int paginaAtual = 1,
           [FromQuery] int tamanhoPagina = 10,
           [FromQuery] string? NomeMarca = null
           

           )
            {

                if (paginaAtual < 1) paginaAtual = 1;
                if (tamanhoPagina < 1) tamanhoPagina = 10;
                var query = _context.Marcas.AsQueryable();


                if (!string.IsNullOrEmpty(NomeMarca))
                {
                  query = query.Where(c => EF.Functions.Like(c.NomeMarca, $"%{NomeMarca}%"));
                }



            var totalRegistro = await query.CountAsync();


            var items = await query
                .Select(c => new Marca
                {
                    NomeMarca = c.NomeMarca,
                    Id= c.Id
             

                })
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            var resultado = new Paginacao<Marca>
            {
                Items = items,
                TotalRegistro = totalRegistro,
                PaginaAtual = paginaAtual,
                TamanhoPagina = tamanhoPagina
            };

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, [FromBody] MarcaDTO requisicao)
        {
            try
            {

                var marca = await _context.Marcas.FindAsync(id);

                if (marca == null)
                    return BadRequest("Marca não existe.");

                if (!string.IsNullOrEmpty(requisicao.NomeMarca))
                    marca.NomeMarca = requisicao.NomeMarca;
                

                await _context.SaveChangesAsync();

                return Ok("Marca atualizado com sucesso");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
                {
                    return NotFound("Marca não encontrada.");
                }
                else
                {
                    throw;
                }
            }
        }
        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return NotFound("Marca não encontrada.");

           
            bool possuiModelo = await _context.Modelos.AnyAsync(r => r.MarcaId == id);

            if (possuiModelo)
            {
                return BadRequest("Não é possível remover a marca porque ele possui modelos vinculados a ela.");
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
