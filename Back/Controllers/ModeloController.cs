using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        public ModeloController(Contexto context)
        {
            _context = context;
        }

        private readonly Contexto _context;
        [HttpPost]
        public async Task<ActionResult<ModeloController>> PostModelo(ModeloDTO modelo)
        {
            var novoModelo = new Modelo
            {
                NomeModelo = modelo.NomeModelo,
                MarcaId = modelo.MarcaId
            };

            // 2. Adicionamos e salvamos no banco de dados
            _context.Modelos.Add(novoModelo);
            await _context.SaveChangesAsync();

            // 3. O SEGREDO ESTÁ AQUI: Mandamos o Entity Framework ir ao banco buscar a Marca atribuída
            await _context.Entry(novoModelo)
                          .Reference(m => m.Marca)
                          .LoadAsync();

            // 4. Agora que a propriedade 'Marca' está cheia, enviamos a resposta
            return CreatedAtAction("GetModelo", new { id = novoModelo.Id }, novoModelo);
        }
        [HttpGet]

        public async Task<ActionResult<Paginacao<ModeloDTO>>> GetModelo(
    [FromQuery] int paginaAtual = 1,
    [FromQuery] int tamanhoPagina = 10,
    [FromQuery] string? marca = null,
    [FromQuery] string? modelo = null
)
        {
            if (paginaAtual < 1) paginaAtual = 1;
            if (tamanhoPagina < 1) tamanhoPagina = 10;

            // O SEGREDO ESTÁ AQUI: Adicionamos o Include para carregar a Marca do banco de dados
            var query = _context.Modelos.Include(c => c.Marca).AsQueryable();

            // Filtro por Modelo (Caso queira reativar)
            if (!string.IsNullOrEmpty(modelo))
            {
                query = query.Where(c => c.NomeModelo.Contains(modelo));
            }

            // Filtro por Marca (Caso queira filtrar pelo nome da marca enviado na URL)
            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(c => c.Marca.NomeMarca.Contains(marca)); // Ajuste 'NomeMarca' para a propriedade real da sua classe Marca
            }

            var totalRegistro = await query.CountAsync();

            var items = await query
                .Skip((paginaAtual - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .Select(c => new ModeloDTO
                {
                    NomeModelo = c.NomeModelo,
                    MarcaId = c.MarcaId,
                    Marca = c.Marca // Mapeamos o objeto Marca completo para o DTO

                    // Se optou por exibir apenas o nome, usaria: 
                    // NomeMarca = c.Marca.NomeMarca
                })
                .ToListAsync();

            var resultado = new Paginacao<ModeloDTO>
            {
                Items = items,
                TotalRegistro = totalRegistro,
                PaginaAtual = paginaAtual,
                TamanhoPagina = tamanhoPagina
            };

            return Ok(resultado);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(int id, [FromBody] ModeloDTO requisicao)
        {
            try
            {

                var modelo = await _context.Modelos.FindAsync(id);

                if (modelo == null)
                    return BadRequest("Marca não existe.");

                if (!string.IsNullOrEmpty(requisicao.NomeModelo))
                    modelo.NomeModelo = requisicao.NomeModelo;

                await _context.SaveChangesAsync();

                return Ok("Modelo atualizado com sucesso");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
                {
                    return NotFound("Modelo não encontrado.");
                }
                else
                {
                    throw;
                }
            }
        }
        private bool ModeloExists(int id)
        {
            return _context.Modelos.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) return NotFound("Modelo não encontrado.");

            // Verifica se existe alguma reserva para este carro
            bool possuiCarros = await _context.Carros.AnyAsync(r => r.ModeloId == id);

            if (possuiCarros)
            {
                return BadRequest("Não é possível remover o modelo porque ele possui carros vinculados a ele.");
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

