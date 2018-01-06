using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class PointOfInterest
    {
        [Key]
        [ScaffoldColumn(false)]
        public long PointOfInterestId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public long EventId { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }

        [JsonProperty("event")]
        [NotMapped]
        public virtual Event GetEventProxy
        {
            get
            {
                return Event;
            }
        }
    }
}
