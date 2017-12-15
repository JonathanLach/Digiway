using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class EventCategory
    {
        public long EventCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        private static EventService eService = new EventService();


        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Get all event categories from the web service
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<EventCategory>> GetEventCategories()
        {
            return await eService.GetEventCategories();
        }
    }
}
