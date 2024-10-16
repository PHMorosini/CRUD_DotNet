using CRUD_DotNet.Context;
using CRUD_DotNet.Models;
using CRUD_DotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DotNet.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventosController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Evento> eventos;
            eventos = _context.Eventos.ToList();

            EventosListViewModel eventosListViewModel = new EventosListViewModel
            {
                Eventos = eventos,
            };
            return View(eventosListViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Eventos.Add(evento);
                _context.SaveChanges();
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
