using DigiwayUWP.DAOInterfaces;
using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class Event
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public DateTime EventDate { get; set; }
        public string FormattedDate { get; set; }
        public decimal TicketPrice { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public long EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }

        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

        private static IEventDAO eService = new EventService();

        /// <summary>
        /// Call the service to add a new event
        /// </summary>
        /// <returns></returns>
        public async Task AddEvent()
        {
            await eService.AddEvent(this);
        }

        /// <summary>
        /// Get all the events from the web service
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<Event>> GetEvents()
        {
            return await eService.GetEvents();
        }

        /// <summary>
        /// Update the event with new values to the service
        /// </summary>
        /// <returns></returns>
        public async Task UpdateEvent()
        {
            await eService.UpdateEvent(this);
        }

        /// <summary>
        /// Get all companies available in service
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<Company>> GetCompanies()
        {
            return await eService.GetCompanies();
        }

        public override string ToString()
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US");
            return Name + "\t" + EventDate.GetDateTimeFormats('D', culture).GetValue(1) + "\t" + EventCategory;
        }

        /// <summary>
        /// Delete the event from the service
        /// </summary>
        /// <returns></returns>
        public async Task DeleteEvent()
        {
            await eService.DeleteEvent(this);
        }

        public async Task SendNotification()
        {
            await eService.SendNotification(this);
        }
    }
}