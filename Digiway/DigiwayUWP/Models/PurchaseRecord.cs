﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayUWP.Models
{
    public class PurchaseRecord
    {
        public long PurchaseRecordId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Event Event { get; set; }
        public ActionRecord ActionRecord { get; set; }
        public Product Product { get; set; }
    }
}
