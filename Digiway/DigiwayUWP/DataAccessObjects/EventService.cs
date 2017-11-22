using DigiwayUWP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public class EventService
    {

        public async Task AddEvent(Event e)
        {
            await ClientService.client.PostAsJsonAsync("api/events", e);
        }

        public async Task<ObservableCollection<Event>> GetEvents()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync("api/events");
            var Jsonresponse = await ClientService.client.GetStringAsync("api/events");
            var EventModel = JsonConvert.DeserializeObject<ObservableCollection<Event>>(Jsonresponse);
            return EventModel;
        }

        public async Task<ObservableCollection<EventCategory>> GetEventCategories()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync("api/eventCategories");
            var Jsonresponse = await ClientService.client.GetStringAsync("api/eventCategories");
            var CategoryModel = JsonConvert.DeserializeObject<ObservableCollection<EventCategory>>(Jsonresponse);
            return CategoryModel;
        }

        public async Task<ObservableCollection<Company>> GetCompanies()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync("api/companies");
            var Jsonresponse = await ClientService.client.GetStringAsync("api/companies");
            var CompanyModel = JsonConvert.DeserializeObject<ObservableCollection<Company>>(Jsonresponse);
            return CompanyModel;
        }

    }
}
