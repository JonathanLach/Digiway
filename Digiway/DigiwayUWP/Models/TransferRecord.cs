using System;
using System.Collections.Generic;
using System.Text;

namespace DigiwayUWP.Models
{
    public class TransferRecord
    {
        public double TransferedValue { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }
    }
}
