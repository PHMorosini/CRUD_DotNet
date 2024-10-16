using CRUD_DotNet.Models;

namespace CRUD_DotNet.ViewModels
{
    public class EventosListViewModel
    { 
       public IEnumerable<Evento> Eventos { get; set; }
       public IEnumerable<Cliente> ClientesEvento { get; set; }
       public IEnumerable<Estado> Estados { get; set; }


    }
}
