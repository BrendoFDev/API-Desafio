using Back.DTO_s;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class FotoCarroController : ControllerBase
{
    public FotoCarroController(Contexto context)
    {
        _context = context;
    }
    private readonly Contexto _context;

    [HttpPost]
    public async Task<ActionResult<FotoCarro>> EnviarFoto([FromForm] FotoCarro foto,[FromForm] int carroId)
    {


        if (foto.Conteudo == null || foto.Conteudo.Length == 0)
        {
            return BadRequest("Nenhum arquivo foi enviado.");
        }

        bool CarroExiste = await _context.Carros.AnyAsync(r => r.Id == carroId);

        if (!CarroExiste)
        {
            return NotFound("Id inválido, por favor digite um ID existente");
        }

        using (var memoryStream = new MemoryStream())
        {
            await foto.Conteudo.CopyToAsync(memoryStream);

            foto.FotoBytes = memoryStream.ToArray();
        }
        var novaFotoCarro = new FotoCarro
        {
            CarroId = foto.CarroId,
            Conteudo = foto.Conteudo, // Salva o array de bytes na propriedade correspondente
            FotoBytes = foto.FotoBytes,
            Carro = null

        };

        _context.FotoCarros.Add(novaFotoCarro);
        await _context.SaveChangesAsync();
        return Ok(new
        {
            mensagem = "Foto recebida e convertida com sucesso!",
            tamanhoBytes = foto.FotoBytes.Length
        });
    }


    private bool FotoExiste(int id)
    {
        return _context.FotoCarros.Any(e => e.Id == id);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutFotoCarro(int id,  FotoCarroDTO requisicao)
    {
        try
        {
            var foto = await _context.FotoCarros.FindAsync(id);

            if (foto == null)
            {
                return BadRequest("Foto não existente.");
            }

            if (requisicao.FotoBytes == null || requisicao.FotoBytes.Length == 0)

            {
                using (var memoryStream = new MemoryStream())
                {
                    await requisicao.Conteudo.CopyToAsync(memoryStream);
               
                    requisicao.FotoBytes = memoryStream.ToArray();
                }

                foto.FotoBytes = requisicao.FotoBytes;
            }
      

            await _context.SaveChangesAsync();

            return Ok("Foto atualizado com sucesso");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FotoExiste(id))
            {
                return NotFound("Foto não encontrada.");
            }
            else
            {
                throw;
            }
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFotoCarro(int id)
    {
        var foto = await _context.FotoCarros.FindAsync(id);

        if (foto == null) { 
            return NotFound("Foto não encontrado.");
        }

        _context.FotoCarros.Remove(foto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}



