using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class ActionRecord
    {
        [Key]
        public long ActionRecordId { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public virtual ICollection<TransferRecord> TransferRecords { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
