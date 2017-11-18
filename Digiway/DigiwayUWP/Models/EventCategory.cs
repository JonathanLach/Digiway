using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class EventCategory
    {
        public long EventCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
