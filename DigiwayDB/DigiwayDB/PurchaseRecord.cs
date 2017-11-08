using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class PurchaseRecord
    {
        [Key]
        public long PurchaseRecordId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; }
        public long ActionRecordId { get; set; }
        [ForeignKey("ActionRecordId")]
        public ActionRecord ActionRecord { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }
    }
}
