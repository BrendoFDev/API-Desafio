using Back.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

var app = builder.Build();

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();