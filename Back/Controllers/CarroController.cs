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

            return Created("Carro criado com sucesso. ", carro);
        }

        [HttpGet]
        public async Task<IActionResult> FiltrarProdutos(
        [FromQuery] string? marca,
        [FromQuery] string? modelo,
        [FromQuery] int? ano,
        [FromQuery] string? cor,
        [FromQuery] int pagina = 1,          // Padrão: primeira página
        [FromQuery] int tamanhoPagina = 10)  // Padrão: 10 itens por página
        {
            // Garante valores mínimos válidos para a paginação
            if (pagina < 1) pagina = 1;
            if (tamanhoPagina < 1) tamanhoPagina = 10;

            // 1. Consulta base
            IQueryable<Carro> consulta = _contexto.Produtos;

            // 2. Filtros Dinâmicos (Opcionais)
            if (!string.IsNullOrWhiteSpace(marca))
                consulta = consulta.Where(p => p.Marca.Contains(marca));

            if (!string.IsNullOrWhiteSpace(modelo))
                consulta = consulta.Where(p => p.Modelo.Contains(modelo));

            if (ano.HasValue)
                consulta = consulta.Where(p => p.Ano == ano.Value);

            if (!string.IsNullOrWhiteSpace(cor))
                consulta = consulta.Where(p => p.Cor.Contains(cor));

            // 3. Paginação (Calcula quantos registros pular e quantos pegar)
            var totalRegistros = await consulta.CountAsync(); // Total antes de paginar

            var itensPaginados = await consulta
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            // 4. Retorna os dados e metadados da paginação
            var resposta = new
            {
                TotalItens = totalRegistros,
                PaginaAtual = pagina,
                TamanhoPagina = tamanhoPagina,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / tamanhoPagina),
                Dados = itensPaginados
            };

            return Ok(resposta);
        }
    }

    //public async Task<IActionResult> GetCarros(int numeroPagina = 1, int quantidadePorPagina = 10)
    //  {
    // Pula os registros das páginas anteriores e pega apenas a quantidade da página atual
    // var a = await _context.Carros
    //    .Skip((numeroPagina - 1) * quantidadePorPagina)
    // .Take(quantidadePorPagina)
    //  .ToListAsync();

    // return Ok(a);

    // }
    //   public async Task<ActionResult<CarroController>> GetCarro(long id)
    //   {

    //      var Carro = await _context.Carros.FindAsync(id);

    //       if (Carro == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(Carro);
    // }

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
