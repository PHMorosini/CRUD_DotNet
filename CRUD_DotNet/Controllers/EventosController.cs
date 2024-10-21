using CRUD_DotNet.Context;
using CRUD_DotNet.Models;
using CRUD_DotNet.Services.Interfaces;
using CRUD_DotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CRUD_DotNet.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEstadoServices _estadoServices;
        public EventosController(ApplicationDbContext context,IEstadoServices estadoServices) 
        {
            _context = context;
            _estadoServices = estadoServices;
        }
        public IActionResult Index()
        {
            IEnumerable<Estado> estados;
            IEnumerable<Evento> eventos;
            eventos = _context.Eventos.ToList();
            estados = _estadoServices.GetEstados();

            EventosListViewModel eventosListViewModel = new EventosListViewModel
            {
                Eventos = eventos,
                //Estados = estados,
            };
            return View(eventosListViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var estados = _estadoServices.GetEstados();
            ViewBag.Estados = estados;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Evento evento)
        {

            if (ModelState.IsValid)
            {
                
                _context.Eventos.Add(evento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var estados = _estadoServices.GetEstados();
            ViewBag.Estados = estados;

            var evento = _context.Eventos.Find(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        [HttpPost]
        public IActionResult Update(int id,Evento evento)
        {
            
            if (ModelState.IsValid)
            {
               
                _context.Update(evento); ;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        [HttpPost]
        public IActionResult UpdateAtivo(int id, [FromBody] AtivoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var evento = _context.Eventos.Find(id); 
                if (evento != null)
                {
                    evento.Ativo = model.Ativo; 
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }

        public class AtivoViewModel
        {
            public bool Ativo { get; set; }
        }

    }
}
