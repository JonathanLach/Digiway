using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class TransferRecord
    {
        public long TransferRecordId { get; set; }
        public double TransferedValue { get; set; }
        public ActionRecord ActionRecord { get; set; }
    }
}
