using Back.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetRequiredSection("ConnectionStrings:DefaultConnection").Value!.ToString();
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();