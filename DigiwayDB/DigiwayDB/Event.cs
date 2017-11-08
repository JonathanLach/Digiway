using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class Event
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public Company company { get; set; }
        public long CategoryId { get; set; }
        public EventCategory EventCategory { get; set; }

        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

    }
}
