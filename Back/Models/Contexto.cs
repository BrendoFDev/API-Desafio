using Back.DTO_s;
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

            // Configuração da Entidade Carro
            modelBuilder.Entity<Carro>(x =>
            {
                x.HasKey(c => c.Id);
               // x.Property(c => c.ModeloNome).HasMaxLength(100); // Evite usar o mesmo nome da propriedade de navegação 'Modelo' se houver um campo de texto.
                x.Property(c => c.Preco).HasMaxLength(100);
                x.Property(c => c.Ano);
                x.Property(c => c.Cor).HasMaxLength(50);
            });

            // Configuração da Entidade Modelo
            modelBuilder.Entity<Modelo>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.NomeModelo);
            });

            // Configuração da Entidade Marca
            modelBuilder.Entity<Marca>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.NomeMarca);
            });

            // Relacionamento: Modelo -> Marca (Muitos para Um)
            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Marca)
                .WithMany()
                .HasForeignKey(m => m.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento: Carro -> Marca (Muitos para Um)
            modelBuilder.Entity<Carro>()
                .HasOne(c => c.Marca)
                .WithMany(m => m.Carros)
                .HasForeignKey(c => c.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento: Carro -> Modelo (Muitos para Um)
            modelBuilder.Entity<Carro>()
                .HasOne(c => c.Modelo)
                .WithMany(mo => mo.Carros)
                .HasForeignKey(c => c.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento: FotoCarro -> Carro (Muitos para Um)
            modelBuilder.Entity<FotoCarro>()
                .HasOne<Carro>()
                .WithMany()
                .HasForeignKey(f => f.CarroId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração da Entidade Cliente
            modelBuilder.Entity<Cliente>(x =>
            {
                x.HasKey(c => c.id);
                x.Property(c => c.Cpf).HasMaxLength(11);
                x.Property(c => c.dataDeCriacao);
                x.Property(c => c.Nome).HasMaxLength(100);
            });

            // Configuração da Entidade Reserva e seus Relacionamentos
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

            // Configuração da Entidade User
            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(x => x.Id);

                x.Property(x => x.Email)
                    .HasMaxLength(100)
                    .IsRequired();

                x.HasIndex(x => x.Email)
                    .IsUnique();

                x.Property(x => x.Username)
                    .HasMaxLength(100);

                x.HasIndex(x => x.Username)
                    .IsUnique();

                x.Property(x => x.Senha)
                    .HasMaxLength(100);
            });
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Modelo> Modelos {get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}
