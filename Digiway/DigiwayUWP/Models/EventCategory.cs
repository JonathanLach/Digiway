using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayWindows.Models
{
    public class EventCategory
    {
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }
}
}
