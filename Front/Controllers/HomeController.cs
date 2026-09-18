using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Front.Atributos;

namespace Front.Controllers
{
    [ValidarSessao]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult clienteView()
        {
            return View();
        }
        public IActionResult reservaView()
        {
            return View();
        }
    }
}
