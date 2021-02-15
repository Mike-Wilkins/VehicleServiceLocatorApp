using DataLayer.Models;
using Geocoding;
using Geocoding.Google;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GeocodingRepository : IGeocodingRepository
    {
        public async Task<VehicleService> ConvertPostcode(VehicleService vehicleService)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyBj8k95-RJyz0HNan_RcgS_-suLQVb7NzA" };
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync(vehicleService.Postcode);
            vehicleService.Latitude = addresses.First().Coordinates.Latitude;
            vehicleService.Longitude = addresses.First().Coordinates.Longitude;

            return vehicleService;
        }
    }
}
