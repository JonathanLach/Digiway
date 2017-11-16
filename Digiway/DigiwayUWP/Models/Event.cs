using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class Event
    {
        public long EventId { get; set; }
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

        public async Task AddEvent()
        {
            EventService eService = new EventService();
            await eService.AddEvent(this);
        }

        public static async Task<ObservableCollection<EventCategory>> GetEvents()
        {
            EventService eService = new EventService();
            return await eService.GetEvents();
        }
    }
}
