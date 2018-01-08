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
    public class ActionRecord
    {
        public long ActionRecordId { get; set; }
        public DateTime RecordDate { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TransferRecord> TransferRecords { get; set; }
        public virtual ICollection<PurchaseRecord> PurchaseRecords { get; set; }

        private static IActionRecordDAO aService = new ActionRecordService();


        /// <summary>
        /// Call the web service to get all action records
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<ActionRecord>> GetActionRecords()
        {
            ObservableCollection<ActionRecord> recordsFound = await aService.GetActionRecords();
            var recordsKept = from record in recordsFound   where record.User.UserId == User.CurrentUser.UserId
                                                            where record.PurchaseRecords.Count == 0
                                                            where record.TransferRecords.Count == 0
                                                            select record;
            return new ObservableCollection<ActionRecord>(recordsKept);
        }

        /// <summary>
        /// Send a new action record to the service, added in data
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>

        public static async Task AddActionRecord(string description)
        {
            await DeserializerService<ActionRecord>.CheckConnectivity();
            ActionRecord newAction = new ActionRecord()
            {
                UserId = User.CurrentUser.UserId,
                RecordDate = DateTime.Today,
                Description = description,
                PurchaseRecords = null,
                TransferRecords = null
            };

            await aService.AddActionRecord(newAction);
        }

        public override string ToString()
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US");
            return RecordDate.GetDateTimeFormats('D', culture).GetValue(1) + " " + Description;
        }
    }
}
