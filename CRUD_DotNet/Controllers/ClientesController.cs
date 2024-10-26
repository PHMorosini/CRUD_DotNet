using CRUD_DotNet.Context;
using CRUD_DotNet.Models;
using CRUD_DotNet.Services.Interfaces;
using CRUD_DotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CRUD_DotNet.Controllers.EventosController;

namespace CRUD_DotNet.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEstadoServices _estadoServices;



        public ClientesController(ApplicationDbContext context, IEstadoServices estadoServices)
        {
            _estadoServices = estadoServices;
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
            IEnumerable<Estado> estados;
            estados = _estadoServices.GetEstados();
            ViewBag.Estados = estados;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.ClienteId = id;
            IEnumerable<Estado> estados;
            estados = _estadoServices.GetEstados();
            ViewBag.Estados = estados;

            var cliente = _context.Clientes.Include(e => e.Eventos).FirstOrDefault(c => c.Id == id);

            var eventosDisponveis = _context.Eventos
                .Where(e => !cliente.Eventos.Contains(e))
                .Where(e => e.Ativo == true)
                .ToList();

            ViewBag.EventosDisponiveis = eventosDisponveis;
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            ViewBag.ClienteId = id;
            var eventosDisponveis = _context.Eventos
                .Where(e => !cliente.Eventos.Contains(e))
                .Where(e => e.Ativo == true)
                .ToList();

            ViewBag.EventosDisponiveis = eventosDisponveis;

            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }


        [HttpPost]
        public JsonResult AdicionarEventoCliente(int clienteId, int eventoId)
        {
            var cliente = _context.Clientes.Include(c => c.Eventos).FirstOrDefault(c => c.Id == clienteId);
            var evento = _context.Eventos.Find(eventoId);

            if (evento == null)
            {
                return Json(new { success = false, mensagem = "Evento não encontrado." });
            }

            if (!cliente.Eventos.Any(e => e.Id == evento.Id)) 
            {
                cliente.Eventos.Add(evento);
                _context.Update(cliente);
                _context.SaveChanges();

                return Json(new { success = true, mensagem = "Cliente adicionado ao evento com sucesso.", redirectUrl = Url.Action("Update", new { id = clienteId }) });

            }
            else
            {
                return Json(new { success = false, mensagem = "Cliente já está adicionado a este evento." });
            }
        }
        [HttpPost]
        public IActionResult UpdateAtivo(int id, [FromBody] AtivoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente != null)
                {
                    cliente.Ativo = model.Ativo;
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }

        //[HttpGet("Delete/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var cliente = _context.Clientes.Find(id);
        //    return View(cliente);
        //}

        //[HttpPost("Delete/{id}")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var cliente = _context.Clientes.Find(id);
        //    if (cliente == null)
        //    {
        //        return View("Error", new ErrorViewModel());
        //    }

        //    _context.Remove(cliente);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        public class AtivoViewModel
        {
            public bool Ativo { get; set; }
        }




    }
}
