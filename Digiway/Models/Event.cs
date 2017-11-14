using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayWindows.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public DateTime EventDate { get; set; }
        public double TicketPrice { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public EventCategory EventCategory { get; set; }

        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

    }
}
