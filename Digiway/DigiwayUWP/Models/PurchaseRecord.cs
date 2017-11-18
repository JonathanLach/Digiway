using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayUWP.Models
{
    public class PurchaseRecord
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Event Event { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }
        public virtual Product Product { get; set; }
    }
}
