﻿using DigiwayUWP.DataAccessObjects;
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
        public int ZIP { get; set; }
        public string City { get; set; }
        public DateTime EventDate { get; set; }
        public double TicketPrice { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public long EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }

        public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

        private static EventService eService = new EventService();

        public async Task AddEvent()
        {
            await eService.AddEvent(this);
        }

        public static async Task<ObservableCollection<Event>> GetEvents()
        {
            return await eService.GetEvents();
        }

        public async Task UpdateEvent()
        {
            await eService.UpdateEvent(this);
        }

        public static async Task<ObservableCollection<Company>> GetCompanies()
        {
            return await eService.GetCompanies();
        }

        public override string ToString()
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US");
            return Name + "\t" + EventDate.GetDateTimeFormats('D', culture).GetValue(1) + "\t" + EventCategory;
        }
    }
}