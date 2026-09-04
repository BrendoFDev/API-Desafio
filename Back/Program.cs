using Back.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var jwtKey = builder.Configuration["Jwt:Key"];
var key = Encoding.UTF8.GetBytes(jwtKey!);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };

    
    options.Events = new JwtBearerEvents
    {
        OnChallenge = async context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            var resposta = new
            {
                erro = "TokenExpirado",
                mensagem = "O seu token de acesso expirou. Por favor, faça login novamente ou atualize o token."
            };

            var json = JsonSerializer.Serialize(resposta);
            await context.Response.WriteAsync(json);
        }
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
            policy.WithOrigins("https://localhost:7227")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());
});

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetRequiredSection("ConnectionStrings:DefaultConnection").Value!.ToString();
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseNpgsql(connectionString);
});
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
  //  options.SuppressModelStateInvalidFilter = true;//isso
//});


var app = builder.Build();


app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//.RequireAuthorization();

app.Run();
