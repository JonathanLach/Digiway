using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class TransferRecord
    {
        public long TransferRecordId { get; set; }
        public double TransferedValue { get; set; }
        public long ActionRecordId { get; set; }
        public ActionRecord ActionRecord { get; set; }
    }
}
