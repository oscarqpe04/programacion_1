using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var estudiantes = new List<Estudiante>
            {
                new Estudiante { nombre = "Pepito", apellido="Torres", edad=23},
                new Estudiante {nombre="Pepe", apellido = "Torres", edad=23}
            };

            ViewData["estudiantes"] = estudiantes;
            ViewData["titulo"] = "Lista de estudiantes";
            ViewData["total"] = estudiantes.Count;
            HttpContext.Session.SetString("Usuario", "Oscar");
            HttpContext.Session.SetString("Email", "oscar@example.com");
            return View();
        }

        public IActionResult Privacy()
        {
            var estudiantes = new List<Estudiante>
            {
                new Estudiante { nombre = "Pepito", apellido="Torres", edad=23},
                new Estudiante {nombre="Pepe", apellido = "Torres", edad=23}
            };

            ViewBag.estudiantes = estudiantes;
            ViewBag.titulo = "Lista de estudiantes";
            ViewBag.total = estudiantes.Count;
            return View();
        }

        public IActionResult Cookies()
        {
            HttpContext.Response.Cookies.Append("user_id", "123");
            HttpContext.Response.Cookies.Append("user_token", "asdasdasd");

            return View();
        }

        public IActionResult SessionPage()
        {
            ViewBag.usuario = HttpContext.Session.GetString("Usuario");
            ViewBag.email = HttpContext.Session.GetString("Email");
            return View("Session");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}