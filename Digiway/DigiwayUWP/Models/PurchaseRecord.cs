using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class PurchaseRecord
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Event Event { get; set; }
        public virtual ActionRecord ActionRecord { get; set; }
        public virtual Product Product { get; set; }

        private static PurchaseRecordService pService = new PurchaseRecordService();

        public static async Task<ObservableCollection<PurchaseRecord>> GetPurchaseRecords()
        {
            ObservableCollection<PurchaseRecord> recordsFound = await pService.GetPurchaseRecords();
            var recordsKept = from record in recordsFound
                              where record.ActionRecord.User.UserId == User.CurrentUser.UserId
                              select record;
            return new ObservableCollection<PurchaseRecord>(recordsKept);
        }

        public override string ToString()
        {
            return ActionRecord + " " + Quantity + " " + UnitPrice;
        }
    }
}
