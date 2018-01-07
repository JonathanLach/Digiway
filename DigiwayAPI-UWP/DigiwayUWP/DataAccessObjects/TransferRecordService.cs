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
            return await DeserializerService<ObservableCollection<TransferRecord>>.GetObjectFromService(transferRecordURL);
        }

        public async Task AddTransferRecord(TransferRecord tr)
        {
            await ClientService.client.PostAsJsonAsync(transferRecordURL, tr);
        }
    }
}
