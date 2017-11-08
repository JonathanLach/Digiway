using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class Event
    {
        [Key]
        public long EventId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int ZIP { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public double TicketPrice { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [ForeignKey("CategoryId")]
        public long CategoryId { get; set; }
        public EventCategory EventCategory { get; set; }

        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

    }
}
