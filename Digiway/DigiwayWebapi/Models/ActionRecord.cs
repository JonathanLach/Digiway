using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class ActionRecord
    {
        [Key]
        [ScaffoldColumn(false)]
        public long ActionRecordId { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        public virtual User User { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TransferRecord> TransferRecords { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
