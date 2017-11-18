using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class PointOfInterest
    {
        public long PointOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public virtual Event Event { get; set; }
    }
}
