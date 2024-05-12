using Microsoft.AspNetCore.Mvc;

namespace GestorDespedidasDeSoltero.Controllers
{
    public class ControladorDireccion : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
