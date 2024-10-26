using CRUD_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DotNet.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Fornecedor> Forncecedores { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Evento>()
                .Property(e => e.Ativo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Ativo)
                .HasDefaultValue(true)
                ;
            modelBuilder.Entity<Cliente>()
                .Property(c => c.EhEstudante)
                .HasColumnName("Estudante")
                .HasDefaultValue(false)
                ;
            modelBuilder.Entity<Cliente>()
                .Property(c => c.DoaSangue)
                .HasColumnName("DoadorDeSangue")
                .HasDefaultValue(false)
                ;
            modelBuilder.Entity<Cliente>()
                .Property(c => c.CriadoEm)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
   

}
