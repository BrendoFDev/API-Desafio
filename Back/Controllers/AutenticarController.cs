using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Back.Models;
using Back.DTO_s;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace Back.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly Contexto _context;

        public AutenticarController(IConfiguration configuration, Contexto context)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous] 
        public async Task<IActionResult> Login([FromBody] UserDTO login)
        {
            
            var usuario = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);

            if (usuario == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
               new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Email, usuario.Email)]),
                // Expires = DateTime.UtcNow.AddDay(7),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            Response.Cookies.Append("X-Access-Token", tokenString, new CookieOptions
            {
                HttpOnly = true, 
                Secure = true,   
                SameSite = SameSiteMode.Strict, 
                Expires = DateTimeOffset.UtcNow.AddDays(7) 
            });


            return Ok(new { token = tokenString });
            


        }

    
    }
}
