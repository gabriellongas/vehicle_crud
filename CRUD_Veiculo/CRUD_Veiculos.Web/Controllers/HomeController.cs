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

        public IActionResult Create()
        {
            return View(new Veiculo());
        }

        public IActionResult AdicionarVeiculo(Veiculo veiculo)
        {
            _apiClient.Create(veiculo);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var veiculo = _apiClient.GetById(id);

            return View(veiculo);
        }

        public IActionResult EditarVeiculo(Veiculo veiculo)
        {
            _apiClient.Update(veiculo);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var veiculo = _apiClient.GetById(id);

            return View(veiculo);
        }

        public IActionResult Delete(int id)
        {
            _apiClient.Delete(id);

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
