using Best_Practices.Infraestructure.Factories;
using Best_Practices.Models;
using Best_Practices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Best_Practices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleService _vehicleService;

        public HomeController(IVehicleService vehicleService, ILogger<HomeController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            // se usa el servicio y repositorio (no singleton directo)
            model.Vehicles = _vehicleService.GetVehicles();

            string error = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = error;

            return View(model);
        }

        // mejor practica: modificar estado con POST
        [HttpPost]
        public IActionResult AddMustang()
        {
            _vehicleService.AddVehicle(new FordMustangCreator());
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult AddExplorer()
        {
            _vehicleService.AddVehicle(new FordExplorerCreator());
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult AddEscape()
        {
            _vehicleService.AddVehicle(new FordEscapeCreator());
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                _vehicleService.StartEngine(id);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {
            try
            {
                _vehicleService.AddGas(id);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                _vehicleService.StopEngine(id);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
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
