using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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
        public async Task<IActionResult> Index(int? page)
        {
            var vehicleServiceList = await _db.GetAllServices(page);
            return View(vehicleServiceList);
        }

        //GET: VehicleService/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //POST: VehicleService/Create
        public async Task<IActionResult> Create(VehicleService vehicleService, int? page)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var vehicleServiceLatLng = await _geocoding.ConvertPostcode(vehicleService);

            await _db.Add(vehicleServiceLatLng);
            var vehicleServiceList = await _db.GetAllServices(page);
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
        public async Task<IActionResult> DeleteService(int id, int? page)
        {
            await _db.Delete(id);
            var vehicleServiceList = await _db.GetAllServices(page);
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
        public async Task<IActionResult> Update(VehicleService vehicleService, int? page)
        {
            var vehicleServiceLatLng = await _geocoding.ConvertPostcode(vehicleService);

            _db.Update(vehicleServiceLatLng);
            var vehicleserviceList = await _db.GetAllServices(page);
            return View("Index", vehicleserviceList);
        }

      
        public async Task<IActionResult> Search(string query, int? page){

            var vehicleServiceList = await _db.GetSearchServices(query);

            var result = vehicleServiceList.Count();

            if (result == 0)
            {
                var serviceList = await _db.GetAllServices(page);
                return View("Index", serviceList);
            }

            return View("Index", vehicleServiceList);
        }
    }
}
