using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayWindows.Models
{
    public class PointOfInterest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Event Event { get; set; }
    }
}
