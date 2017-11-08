using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class PurchaseRecord
    {
        public long PurchaseRecordId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; }
        public long ActionRecordId { get; set; }
        public ActionRecord ActionRecord { get; set; }
        public long ProductId { get; set; }
        public Product product { get; set; }
    }
}
