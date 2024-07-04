using Esercitazione.Models;
using Esercitazione.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Esercitazione.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImpiegatoService _impiegatoService;
        private readonly IImpiegoService _impiegoService;

        public HomeController(ILogger<HomeController> logger, IImpiegatoService impiegatoService, IImpiegoService impiegoService)
        {
            _logger = logger;
            _impiegatoService = impiegatoService;
            _impiegoService = impiegoService;

        }

        public IActionResult Index()
        {
            return View(_impiegatoService.GetImpiegati);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
