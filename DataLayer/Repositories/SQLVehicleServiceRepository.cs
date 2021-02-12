using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SQLVehicleServiceRepository : IVehicleServiceRepository
    {
        private IApplicationDbContext _context;

        public SQLVehicleServiceRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleService> Add(VehicleService vehicleService)
        {
            _context.VehicleServices.Add(vehicleService);
            await _context.SaveChangesAsync();
            return vehicleService;
        }

        public async Task<VehicleService> Delete(int id)
        {
            var vehicleService = await _context.VehicleServices.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.VehicleServices.Remove(vehicleService);
            await _context.SaveChangesAsync();
            return vehicleService;
        }

        public async Task<IEnumerable<VehicleService>> GetAllServices()
        {
            var vehicleServiceList = await _context.VehicleServices.OrderBy(m => m.Id).ToListAsync();
            return vehicleServiceList;
        }

        public async Task<VehicleService> GetService(int id)
        {
            var vehicleService = await _context.VehicleServices.Where(m => m.Id == id).FirstOrDefaultAsync();
            return vehicleService;
        }

        public VehicleService Update(VehicleService vehicleService)
        {
            var vehicleServiceUpdate = _context.VehicleServices.Attach(vehicleService);
            vehicleServiceUpdate.State = EntityState.Modified;
            _context.SaveChanges();
            return vehicleService;
        }
    }
}
