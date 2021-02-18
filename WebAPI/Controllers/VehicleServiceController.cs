using DataLayer.Models;
using DataLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleServiceController : ControllerBase
    {
        private IApplicationDbContext _context;
        public VehicleServiceController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<VehicleService>> GetAllVehicleServices()
        {
            var vehicleServiceList = _context.VehicleServices.OrderBy(m => m.Id).ToList();
            return vehicleServiceList;
        }
    }
}
