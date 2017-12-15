using DigiwayUWP.DAOInterfaces;
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
        public decimal TransferedValue { get; set; }
        public long ActionRecordId { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }

        private static ITransferRecordDAO tService = new TransferRecordService();

        /// <summary>
        /// Get all the transfer records from the service
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<TransferRecord>> GetTransferRecords()
        {
            ObservableCollection<TransferRecord> recordsFound = await tService.GetTransferRecords();
            var recordsKept = from record in recordsFound
                              where record.ActionRecord.User.UserId == User.CurrentUser.UserId
                              select record;
            return new ObservableCollection<TransferRecord>(recordsKept);
        }

        public override string ToString()
        {
            return ActionRecord + " " + TransferedValue;
        }

        /// <summary>
        /// Add a transfer record with a fixed model
        /// </summary>
        /// <param name="moneyTransfered"></param>
        /// <returns></returns>
        public static async Task AddTransferRecord(decimal moneyTransfered)
        {
            ActionRecord aRecord = new ActionRecord()
            {
                RecordDate = DateTime.Today,
                UserId = User.CurrentUser.UserId,
                PurchaseRecords = null,
            };
            TransferRecord newRecord = new TransferRecord()
            {
                TransferedValue = moneyTransfered,
                ActionRecord = aRecord
            };
            aRecord.Description = (moneyTransfered > 0) ? "Money deposit: " : "Money Withdraw: ";
            await tService.AddTransferRecord(newRecord);
        }
    }
}
