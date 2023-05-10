using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using WebApplicationMVC.DataSource;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HelpController : Controller
    {
        private IConfiguration configuration;
        public HelpController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: HelpController
        public ActionResult Index()
        {
            using (var context = new UniversidadContext(configuration))
            {
                context.Database.EnsureCreated();
                var estudiante = new EstudianteModel { 
                    nombre = "Oscar",
                    apellidos = "Quispe"
                };
                context.estudianteModels.Add(estudiante);
                context.SaveChanges();
            };

            using (var context = new UniversidadContext(configuration))
            {
                context.Database.EnsureCreated();
                var estudiante = context.estudianteModels.Find(1);
            };

            using (var context = new UniversidadContext(configuration))
            {
                context.Database.EnsureCreated();
                var estudiante = context.estudianteModels.Find(1);
                estudiante.nombre = "Oscar Edmit";
                context.Update(estudiante);
                context.SaveChanges();
            };

            using (var context = new UniversidadContext(configuration))
            {
                context.Database.EnsureCreated();
                var estudiante = context.estudianteModels.Find(2);
                context.estudianteModels.Remove(estudiante);
                context.SaveChanges();

            }

            return View();
        }

        // GET: HelpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HelpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HelpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HelpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HelpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HelpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HelpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
