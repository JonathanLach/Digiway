using DigiwayUWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public class EventService
    {
        HttpClient client;

        public EventService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http///localhost:50222/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AddEvent(Event e)
        {
            StringContent newEvent = new StringContent(JsonConvert.SerializeObject(e));
            HttpResponseMessage response = await client.PostAsync("api/events", newEvent);
            
        }

        public async Task<ObservableCollection<EventCategory>> GetEvents()
        {
            HttpResponseMessage response = await client.GetAsync("api/eventCategories");
            ObservableCollection<EventCategory> result = null;
            if (response.IsSuccessStatusCode)
            {
                string httpResponseBody;
                httpResponseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ObservableCollection<EventCategory>>(httpResponseBody);
            }
            return result;
        }
        
    }
}
