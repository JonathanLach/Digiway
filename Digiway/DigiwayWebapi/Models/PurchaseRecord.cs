using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class PurchaseRecord
    {
        [Key]
        [ScaffoldColumn(false)]
        public long PurchaseRecordId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public Event Event { get; set; }
        [ForeignKey("ActionRecord")]
        public long ActionRecordId { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }
        public virtual Product Product { get; set; }
    }
}
