using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class VehicleService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Required]
        public string Postcode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

       
    }
}
