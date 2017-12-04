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
    public class TransferRecordService : ITransferRecordDAO
    {
        public static string transferRecordURL = "api/transferRecords";
        public async Task<ObservableCollection<TransferRecord>> GetTransferRecords()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(transferRecordURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(transferRecordURL);
            var TransferRecordModel = JsonConvert.DeserializeObject<ObservableCollection<TransferRecord>>(Jsonresponse);
            return TransferRecordModel;
        }

        public async Task AddTransferRecord(TransferRecord tr)
        {
            await ClientService.client.PostAsJsonAsync(transferRecordURL, tr);
        }
    }
}
