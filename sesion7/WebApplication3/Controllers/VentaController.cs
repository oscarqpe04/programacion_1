using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class VentaController : Controller
    {
        protected IConfiguration configuration;
        public VentaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            using(var _contextDB = new ApplicationContext(configuration))
            {
                var ventas = _contextDB.ventasCollection.ToList();
                return View(ventas);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VentaModel venta)
        {
            if (ModelState.IsValid)
            {
                using (var _contextDB = new ApplicationContext(configuration))
                {
                    _contextDB.ventasCollection.Add(venta);
                    _contextDB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(venta);
            }
        }

        public IActionResult Actualizar(int id)
        {
            var venta = new VentaModel();
            using (var _contextDB = new ApplicationContext(configuration))
            {
                venta = _contextDB.ventasCollection.Find(id);
            }
            return View(venta);
        }

        [HttpPost]
        public IActionResult Actualizar(VentaModel venta)
        {
            if (ModelState.IsValid)
            {
                using (var _contextDB = new ApplicationContext(configuration))
                {
                    _contextDB.Entry(venta).State = EntityState.Modified;
                    _contextDB.SaveChanges();
                }
                return RedirectToAction("Index");
            } else
            {
                return View(venta);
            }
        }
    }
}
