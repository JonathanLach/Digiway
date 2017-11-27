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
    public class PurchaseRecordService
    {

        public async Task<ObservableCollection<PurchaseRecord>> GetPurchaseRecords()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync("api/purchaseRecords");
            var Jsonresponse = await ClientService.client.GetStringAsync("api/purchaseRecords");
            var purchaseRecordModel = JsonConvert.DeserializeObject<ObservableCollection<PurchaseRecord>>(Jsonresponse);
            return purchaseRecordModel;
        }
    }
}
