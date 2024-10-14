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
        public DbSet<Fornecedor> Forncecedores { get; set; }
    }
}
