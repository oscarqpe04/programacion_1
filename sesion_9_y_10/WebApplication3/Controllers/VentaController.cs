using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Service;

namespace WebApplication3.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IVentaService _ventaService;

        public VentaController(IVentaRepository ventaRepository, IVentaService ventaService)
        {
            _ventaRepository = ventaRepository;
            _ventaService = ventaService;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewData["categorias"] = "Hola mundo";
            var ventas = _ventaRepository.ObtenerTodos();
            return View(ventas);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(VentaModel venta)
        {
            if (ModelState.IsValid)
            {
                _ventaService.RealizarVenta(venta);
                return RedirectToAction("Index");
            }
            else
            {
                return View(venta);
            }
        }
        [Authorize]
        public IActionResult Actualizar(int id)
        {
            var venta = new VentaModel();
            venta = _ventaRepository.ObtenerPorID(id);
            return View(venta);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Actualizar(VentaModel venta)
        {
            if (ModelState.IsValid)
            {
                _ventaRepository.ActualizarVenta(venta);
                return RedirectToAction("Index");
            } else
            {
                return View(venta);
            }
        }
    }
}
