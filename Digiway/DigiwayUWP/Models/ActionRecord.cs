﻿using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class ActionRecord
    {
        public DateTime RecordDate { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TransferRecord> TransferRecords { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

        private static ActionRecordService aService = new ActionRecordService();

        public static async Task<ObservableCollection<ActionRecord>> GetActionRecords()
        {
            ObservableCollection<ActionRecord> recordsFound = await aService.GetActionRecords();
            var recordsKept = from record in recordsFound   where record.User.UserId == User.CurrentUser.UserId
                                                            where record.PurchaseRecords.Count == 0
                                                            where record.TransferRecords.Count == 0
                                                            select record;
            return new ObservableCollection<ActionRecord>(recordsKept);
        }

        public async Task AddActionRecord()
        {
            await aService.AddActionRecord(this);
        }

        public override string ToString()
        {
            return RecordDate + " " + Description;
        }
    }
}
