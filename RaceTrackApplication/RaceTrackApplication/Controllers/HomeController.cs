using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RaceTrackApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RaceTrackApplication.Data;
//using System.Web.Mvc;

namespace RaceTrackApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       
        private readonly IRepository _dataRepository;
       
        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            _dataRepository = repo;
        }

        public HomeController(IRepository repo)
        {
            _dataRepository = repo;
        }

        [HttpPost]
        public void AddCar()
        {
            this._dataRepository.AddVehicle(new Car());
        }

        [HttpPost]
        public void AddTruck()
        {
            this._dataRepository.AddVehicle(new Truck());
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCarData(Car car)
        {
            try
            {
                this._dataRepository.AddVehicle(car);
                return Json("sucess");
            }
            catch (Exception ex)
            {
                return Json("Not Success");
            }
        }

        [HttpPost]
        public IActionResult AddVehicleToTrack(Track data)
        {
            try
            {
                this._dataRepository.AddVehicleToTrack(data);
                return Json("sucess");
            }
            catch (Exception ex)
            {
                return Json("Not Success");
            }
        }

        [HttpPost]
        public IActionResult AddTruckData(Truck truck)
        {
            try
            {
                this._dataRepository.AddVehicle(truck);
                return Json("sucess");
            }
            catch (Exception ex)
            {
                return Json("Not Success");
            }
        }

        [HttpGet]
        public JsonResult GetVehiclesData()
        {
            var vehicles = this._dataRepository.GetVehicles();
            if (!vehicles.Any())
                return Json("No Vehicles Found");
            return Json(vehicles);
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
