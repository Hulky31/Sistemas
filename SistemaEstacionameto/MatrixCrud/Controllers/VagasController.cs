using MatrixCrud.Data;
using MatrixCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatrixCrud.Controllers
{
    public class VagasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VagasController(ApplicationDbContext context)
        { 
           this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<EstacionamentoModel> estacionamentos = _context.Estacionamento;

            return View(estacionamentos);
        }

        public IActionResult Cadastrar() 
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Cadastrar(EstacionamentoModel estacionamento)
        {
            if (ModelState.IsValid)
            {
                _context.Estacionamento.Add(estacionamento);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? Id) 
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            EstacionamentoModel estacionamento = _context.Estacionamento.FirstOrDefault(x => x.Id == Id);
            if (estacionamento == null)
            {
                return NotFound();
            }

            return View(estacionamento); 
        }

        [HttpGet]
        public IActionResult Excluir(int? Id)
        {
            if (ModelState.IsValid)
            {
                EstacionamentoModel estacionamento = _context.Estacionamento.FirstOrDefault(x => x.Id == Id);
                _context.Estacionamento.Remove(estacionamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EstacionamentoModel estacionamento)
        {
            if (ModelState.IsValid)
            {
                _context.Estacionamento.Update(estacionamento);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(estacionamento);
        }

        //[HttpPost]
        //public IActionResult Excluir(EstacionamentoModel estacionamento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Estacionamento.Remove(estacionamento);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(estacionamento);
        //}

       
       
    }
}
