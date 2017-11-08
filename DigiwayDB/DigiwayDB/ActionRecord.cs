using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayModel
{
    public class ActionRecord
    {
        public long ActionRecordId { get; set; }
        public DateTime RecordDate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<TransferRecord> TransferRecords { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
