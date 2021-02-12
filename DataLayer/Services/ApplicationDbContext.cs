using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<VehicleService> VehicleServices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
