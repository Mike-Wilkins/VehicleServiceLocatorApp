using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IVehicleServiceRepository
    {
        Task<VehicleService> Add(VehicleService vehicleService);
        Task<VehicleService> Delete(int id);
        VehicleService Update(VehicleService vehicleService);
        Task<VehicleService> GetService(int id);
        Task<IEnumerable<VehicleService>> GetAllServices(int? page);
        Task<IEnumerable<VehicleService>> GetSearchServices(string query);
    }
}
