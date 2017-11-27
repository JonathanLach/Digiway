using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class TransferRecord
    {
        public double TransferedValue { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }

        private static TransferRecordService pService = new TransferRecordService();

        public static async Task<ObservableCollection<TransferRecord>> GetTransferRecords()
        {
            ObservableCollection<TransferRecord> recordsFound = await pService.GetTransferRecords();
            var recordsKept = from record in recordsFound
                              where record.ActionRecord.User.UserId == User.CurrentUser.UserId
                              select record;
            return new ObservableCollection<TransferRecord>(recordsKept);
        }

        public override string ToString()
        {
            return ActionRecord + " " + TransferedValue;
        }
    }
}
