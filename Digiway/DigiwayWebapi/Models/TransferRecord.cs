using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayWebapi.Models
{
    public class TransferRecord
    {
        [Key]
        [ScaffoldColumn(false)]
        public long TransferRecordId { get; set; }
        [Required]
        public decimal TransferedValue { get; set; }
        public long ActionRecordId { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }
    }
}
