using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            TempData["mensaje"] = "Mensaje enviado del segundo Controller.";
            return RedirectToAction("Index", "Third");
        }

    }
}
