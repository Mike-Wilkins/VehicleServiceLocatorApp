using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class VehicleServiceController : Controller
    {
        private IVehicleServiceRepository _db;

        public VehicleServiceController(IVehicleServiceRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var vehicleServiceList = await _db.GetAllServices();
            return View(vehicleServiceList);
        }

        //GET: VehicleService/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //POST: VehicleService/Create
        public async Task<IActionResult> Create(VehicleService vehicleService)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _db.Add(vehicleService);
            var vehicleServiceList = await _db.GetAllServices();
            return View("Index", vehicleServiceList);
        }

    }
}
