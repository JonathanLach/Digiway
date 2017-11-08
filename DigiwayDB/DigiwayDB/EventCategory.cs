using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class EventCategory
    {
        public long EventCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }
}
}
