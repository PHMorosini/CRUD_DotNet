using CRUD_DotNet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_DotNet.ViewModels
{
    public class EventosListViewModel
    { 
       public IEnumerable<Evento> Eventos { get; set; }
       public IEnumerable<Cliente> ClientesEvento { get; set; }
       public IEnumerable<SelectListItem> Estados { get; set; }
      // public IEnumerable<Estado> Estados { get; set; }

    }
}
