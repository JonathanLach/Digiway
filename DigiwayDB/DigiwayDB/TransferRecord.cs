using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class TransferRecord
    {
        [Key]
        public long TransferRecordId { get; set; }
        [Required]
        public double TransferedValue { get; set; }
        public long ActionRecordId { get; set; }
        [ForeignKey("ActionRecordId")]
        public ActionRecord ActionRecord { get; set; }
    }
}
