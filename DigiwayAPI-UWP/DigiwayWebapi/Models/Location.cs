using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigiwayWebapi.Models
{
    public class Location
    {

        [Key]
        [ScaffoldColumn(false)]
        public long LocationId { get; set; }

        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }

    }
}
