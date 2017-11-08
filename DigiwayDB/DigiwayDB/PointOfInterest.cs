using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class PointOfInterest
    {
        [Key]
        public long PointOfInterestId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public long EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
