using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace Back.Models
{
    public class Autenticar
    {
            private readonly AppDbContext _context;
            private readonly IConfiguration _configuration;

            public AuthService(AppDbContext context, IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            public async Task<string?> ValidarEGerarTokenAsync(string email, string senha)
            {
                // Busca o usuário no banco usando EF Core
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

                if (usuario == null) return null;

                // Define as claims (informações do usuário no token)
                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Role, usuario.Cargo)
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(2), // Tempo de validade
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token); // Serializa o token
            }
        }


    }

