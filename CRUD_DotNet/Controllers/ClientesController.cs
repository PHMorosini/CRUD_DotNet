using CRUD_DotNet.Context;
using CRUD_DotNet.Models;
using CRUD_DotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DotNet.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> clientes;
            clientes = _context.Clientes.ToList();

            ClientesListViewModel clienteListViewModel = new ClientesListViewModel 
            {
                Clientes = clientes,
            };
            return View(clienteListViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }

            return View(cliente);
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost("Update/{id}")]
        public IActionResult Update(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return View(cliente);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return View("Error", new ErrorViewModel());
            }

            _context.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
