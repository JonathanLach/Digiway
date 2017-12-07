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
        private static string transferRecordURL = "api/transferRecords";
        public async Task<ObservableCollection<TransferRecord>> GetTransferRecords()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(transferRecordURL);
            return await DeserializerService<ObservableCollection<TransferRecord>>.getObjectModelAsync(responseMessage);
        }

        public async Task AddTransferRecord(TransferRecord tr)
        {
            await ClientService.client.PostAsJsonAsync(transferRecordURL, tr);
        }
    }
}
