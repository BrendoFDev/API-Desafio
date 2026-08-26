using System.ComponentModel.DataAnnotations;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Contexto _context;
        public UserController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {


            bool emailExiste = await _context.Users.AnyAsync(r => r.Email.ToLower() == user.Email.ToLower());

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                return BadRequest("O nome de usuário é obrigatório.");
            }

            if (user.Username.Length >= 50)
            {
                return BadRequest("O nome de usuário deve possuir no máximo 50 caracteres.");
            }

            var emailChecker = new EmailAddressAttribute();
            if (string.IsNullOrWhiteSpace(user.Email) || !emailChecker.IsValid(user.Email))
            {
                return BadRequest("O formato do e-mail digitado é inválido.");
            }
                
            if (string.IsNullOrWhiteSpace(user.Senha) || user.Senha.Length < 6)
            {
                return BadRequest("A senha deve ter no mínimo 6 caracteres.");
            }

            var regexSenha = new Regex(@"^(?=.*[A-Z])(?=.*\d).+$");
            if (!regexSenha.IsMatch(user.Senha))
            {
                return BadRequest("A senha deve conter pelo menos 1 letra maiúscula e 1 número.");
            }


            if (emailExiste)
            {
                return BadRequest("Este Email já está cadastrado no sistema.");
            }
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Created("Usuário criado com sucesso", user);

        }

    }
}
