using CRUD_DotNet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_DotNet.ViewModels
{
    public class ClientesListViewModel
    {
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<SelectListItem> Estados { get; set; }
    }
}
