using CRUD_DotNet.Context;
using CRUD_DotNet.Models;
using CRUD_DotNet.Services.Interfaces;

namespace CRUD_DotNet.Services
{
    public class EstadoServices : IEstadoServices
    {
        private readonly ApplicationDbContext _context;

        public EstadoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Estado> GetEstados()
        {
            return _context.Estados.ToList();
        }
    }
}
