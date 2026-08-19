using Microsoft.EntityFrameworkCore;

namespace Back.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }

}
