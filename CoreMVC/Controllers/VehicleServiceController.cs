using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class VehicleServiceController : Controller
    {
        private IVehicleServiceRepository _db;
        private IGeocodingRepository _geocoding;

        public VehicleServiceController(IVehicleServiceRepository db, IGeocodingRepository geocoding)
        {
            _db = db;
            _geocoding = geocoding;
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

            var vehicleServiceLatLng = await _geocoding.ConvertPostcode(vehicleService);

            await _db.Add(vehicleServiceLatLng);
            var vehicleServiceList = await _db.GetAllServices();
            return View("Index", vehicleServiceList);
        }

        //GET: VehicleService/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleService = await _db.GetService(id);
            return View(vehicleService);
        }
        //POST: VehicleService/Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _db.Delete(id);
            var vehicleServiceList = await _db.GetAllServices();
            return View("Index", vehicleServiceList);
        }

        //GET: VehicleService/Edit
        public async Task<IActionResult> Update(int id)
        {
            var updateVehicleService = await _db.GetService(id);
            return View(updateVehicleService);
        }

        //POST: VehicleService/Edit
        [HttpPost]
        public async Task<IActionResult> Update(VehicleService vehicleService)
        {
            var vehicleServiceLatLng = await _geocoding.ConvertPostcode(vehicleService);

            _db.Update(vehicleServiceLatLng);
            var vehicleserviceList = await _db.GetAllServices();
            return View("Index", vehicleserviceList);
        }
    }
}
