using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult Index()
        {
            var mensaje = "";
            if (TempData.ContainsKey("mensaje"))
            {
                mensaje = TempData["mensaje"].ToString();
            } else
            {
                mensaje = "No hubo mensaje";
            }
            ViewData["mensaje"] = mensaje;

            return View();
        }
    }
}
