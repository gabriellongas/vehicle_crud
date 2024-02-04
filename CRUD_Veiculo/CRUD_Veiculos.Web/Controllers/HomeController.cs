using CRUD_Veiculos.Web.API.Interface;
using CRUD_Veiculos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Veiculos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            var lista = _apiClient.GetAll();
            ViewBag.ListaVeiculos = lista;

            return View(lista);
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
