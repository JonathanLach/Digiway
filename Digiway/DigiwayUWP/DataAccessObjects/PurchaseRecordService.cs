using DigiwayUWP.DAOInterfaces;
using DigiwayUWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public class PurchaseRecordService : IPurchaseRecordDAO
    {
        public static string purchaseRecordURL = "api/purchaseRecords";
        public async Task<ObservableCollection<PurchaseRecord>> GetPurchaseRecords()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(purchaseRecordURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(purchaseRecordURL);
            var purchaseRecordModel = JsonConvert.DeserializeObject<ObservableCollection<PurchaseRecord>>(Jsonresponse);
            return purchaseRecordModel;
        }
    }
}
