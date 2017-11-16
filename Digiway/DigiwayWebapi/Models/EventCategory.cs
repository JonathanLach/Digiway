using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class EventCategory
    {
        public long EventCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
