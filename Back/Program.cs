using Back.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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