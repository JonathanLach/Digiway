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
    public class ActionRecordService : IActionRecordDAO
    {
        public static string actionRecordsURL = "api/actionRecords";
        public async Task<ObservableCollection<ActionRecord>> GetActionRecords()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(actionRecordsURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(actionRecordsURL);
            var actionRecordModel = JsonConvert.DeserializeObject<ObservableCollection<ActionRecord>>(Jsonresponse);
            return actionRecordModel;
        }

        public async Task AddActionRecord(ActionRecord ar)
        {
                await ClientService.client.PostAsJsonAsync(actionRecordsURL, ar);
        }
    }
}
