﻿using DigiwayUWP.DAOInterfaces;
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
        private static string actionRecordsURL = "api/actionRecords";
        public async Task<ObservableCollection<ActionRecord>> GetActionRecords()
        {
            return await DeserializerService<ObservableCollection<ActionRecord>>.GetObjectFromService(actionRecordsURL);
        }

        public async Task AddActionRecord(ActionRecord ar)
        {
                await ClientService.client.PostAsJsonAsync(actionRecordsURL, ar);
        }
    }
}
