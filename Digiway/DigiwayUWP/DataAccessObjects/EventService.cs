using DigiwayUWP.DAOInterfaces;
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
    public class EventService : IEventDAO
    {
        public static string eventURL = "api/events";
        public static string eventCategoryURL = "api/eventCategories";
        public static string companyURL = "api/companies";

        public async Task AddEvent(Event e)
        {
            await ClientService.client.PostAsJsonAsync(eventURL, e);
        }

        public async Task UpdateEvent(Event e)
        {
            await ClientService.client.PutAsJsonAsync(eventURL, e);
        }

        public async Task<ObservableCollection<Event>> GetEvents()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(eventURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(eventURL);
            var EventModel = JsonConvert.DeserializeObject<ObservableCollection<Event>>(Jsonresponse);
            return EventModel;
        }

        public async Task<ObservableCollection<EventCategory>> GetEventCategories()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(eventCategoryURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(eventCategoryURL);
            var CategoryModel = JsonConvert.DeserializeObject<ObservableCollection<EventCategory>>(Jsonresponse);
            return CategoryModel;
        }

        public async Task<ObservableCollection<Company>> GetCompanies()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(companyURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(companyURL);
            var CompanyModel = JsonConvert.DeserializeObject<ObservableCollection<Company>>(Jsonresponse);
            return CompanyModel;
        }

    }
}
