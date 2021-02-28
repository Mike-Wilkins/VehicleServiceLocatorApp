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
        [RegularExpression("^([A-Z]{1,2})([0-9][0-9A-Z]?) ([0-9])([ABDEFGHJLNPQRSTUWXYZ]{2})$", ErrorMessage = "Postcode not recognised")]
        public string Postcode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

       


    }
}
