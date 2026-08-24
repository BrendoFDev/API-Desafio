using Microsoft.EntityFrameworkCore;

namespace Back.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carro>(x =>
            {
                x.HasKey(c => c.Id);
                x.Property(c => c.Modelo).HasMaxLength(100);
                x.Property(c => c.Preco).HasMaxLength(100);
                x.Property(c => c.Ano);
                x.Property(c => c.Cor).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(x =>
            {
                x.HasKey(c => c.id);
                x.Property(c => c.Cpf).HasMaxLength(11);
                x.Property(c => c.dataDeCriacao);
                x.Property(c => c.Nome).HasMaxLength(100);
            });

            modelBuilder.Entity<Reserva>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.CarroId);
                x.Property(x => x.ClienteId);

                x.HasOne(reserva => reserva.cliente)
                 .WithMany(cliente => cliente.Reservas)
                 .HasForeignKey(reserva => reserva.ClienteId);

                x.HasOne(reserva => reserva.carro)
                 .WithMany(carro => carro.Reservas)
                 .HasForeignKey(reserva => reserva.CarroId);
            });
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
