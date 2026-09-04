using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

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
        public async Task<ActionResult> PostCarro(CarroDTO carro2)
        {

            Carro carro = new Carro() {Preco=carro2.Preco,ModeloId=carro2.ModeloId,MarcaId=carro2.MarcaId,Cor=carro2.Cor ,Ano=carro2.Ano, };

     
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

         
            var carroSalvoComRelacionamentos = await _context.Carros
                .Include(c => c.Modelo)
                    .ThenInclude(m => m.Marca)
                .FirstOrDefaultAsync(c => c.Id == carro.Id);

        
            return Created("Carro criado com sucesso.", carroSalvoComRelacionamentos);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarrosPaginados(
    [FromQuery] string? termoBusca,
    [FromQuery] int pagina = 1,
    [FromQuery] int itensPorPagina = 10,
    [FromQuery] string? marca = null,
    [FromQuery] string? modelo = null,
    [FromQuery] int? ano = null,
    [FromQuery] string? cor = null)
        {
            if (pagina < 1) pagina = 1;
            int quantidadeParaPular = (pagina - 1) * itensPorPagina;

            var query = _context.Carros
                .Include(c => c.Modelo)
                    .ThenInclude(m => m.Marca)
                .AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                termoBusca = termoBusca.Trim();
                query = query.Where(c =>
                    c.Modelo.NomeModelo.Contains(termoBusca) ||
                    c.Modelo.Marca.NomeMarca.Contains(termoBusca)
                );
            }

            
            if (!string.IsNullOrWhiteSpace(marca))
                query = query.Where(c => c.Modelo.Marca.NomeMarca.Contains(marca.Trim()));

            if (!string.IsNullOrWhiteSpace(modelo))
                query = query.Where(c => c.Modelo.NomeModelo.Contains(modelo.Trim()));

            if (ano.HasValue)
                query = query.Where(c => c.Ano == ano.Value);

            if (!string.IsNullOrWhiteSpace(cor))
                query = query.Where(c => c.Cor.Contains(cor.Trim())); 

            query = query.OrderBy(c => c.Id);

            var totalRegistros = await query.CountAsync();

            var itens = await query
                .Skip(quantidadeParaPular)
                .Take(itensPorPagina)
                .Select(c => new
                {
                    CarroId = c.Id,
                    c.Ano,
                    c.ModeloId,
                    ModeloNome = c.Modelo.NomeModelo,
                    c.Modelo.MarcaId, 
                    MarcaNome = c.Modelo.Marca.NomeMarca
                })
                .ToListAsync();

            return Ok(new
            {
                TotalItens = totalRegistros,
                PaginaAtual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / itensPorPagina),
                Dados = itens
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, [FromBody] CarroDTO requisicao)
        {
            try
            {

                var carro = await _context.Carros.FindAsync(id);

                if (carro == null)
                    return BadRequest("carro não existe.");

                if (!string.IsNullOrEmpty(requisicao.Cor))
                    carro.Cor = requisicao.Cor;
             //   if (!string.IsNullOrEmpty(requisicao.Modelo))
             //       carro.Modelo = requisicao.Modelo;
             //   if (!string.IsNullOrEmpty(requisicao.Marca))
             //       carro.Marca = requisicao.Marca;
               // if (requisicao.Ano.HasValue)
                 //   carro.Ano = requisicao.Ano.Value;
              //  if (requisicao.Preco.HasValue)
             //       carro.Preco = requisicao.Preco.Value;


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

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
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
