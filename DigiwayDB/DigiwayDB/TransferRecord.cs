using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigiwayModel
{
    public class TransferRecord
    {
        public long TransferRecordId { get; set; }
        [Required]
        public double TransferedValue { get; set; }
        public ActionRecord ActionRecord { get; set; }
    }
}
