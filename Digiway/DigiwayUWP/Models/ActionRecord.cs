﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayWindows.Models
{
    public class ActionRecord
    {
        public DateTime RecordDate { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TransferRecord> TransferRecords { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}