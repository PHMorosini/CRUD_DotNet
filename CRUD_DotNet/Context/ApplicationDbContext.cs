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
                .HasOne(e => e.Estado)
                .WithMany(es => es.Eventos)
                .HasForeignKey(e => e.EstadoSigla)
                .HasPrincipalKey(es => es.Sigla);
        }
    }
   

}
