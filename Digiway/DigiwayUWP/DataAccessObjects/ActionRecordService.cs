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
    public class ActionRecordService
    {

        public async Task<ObservableCollection<ActionRecord>> GetActionRecords()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync("api/actionRecords");
            var Jsonresponse = await ClientService.client.GetStringAsync("api/actionRecords");
            var actionRecordModel = JsonConvert.DeserializeObject<ObservableCollection<ActionRecord>>(Jsonresponse);
            return actionRecordModel;
        }

        public async Task AddActionRecord(ActionRecord ar)
        {
                await ClientService.client.PostAsJsonAsync("api/actionRecords", ar);
        }
    }
}
