using DataLayer.Models;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IGeocodingRepository
    {
        Task<VehicleService> ConvertPostcode(VehicleService vehicleService);
    }
}
