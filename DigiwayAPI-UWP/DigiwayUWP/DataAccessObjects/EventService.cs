using DigiwayUWP.DAOInterfaces;
using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public class EventService : IEventDAO
    {
        private static string eventURL = "api/events";
        private static string futureEventsURL = eventURL + "/incoming/";
        private static string eventDeleteURL = eventURL+ "/id/";
        private static string eventCategoryURL = "api/eventCategories";
        private static string companyURL = "api/companies";

        public async Task AddEvent(Event e)
        {
            await ClientService.client.PostAsJsonAsync(eventURL, e);
        }

        public async Task UpdateEvent(Event e)
        {
            HttpResponseMessage responseMessage = await ClientService.client.PutAsJsonAsync(eventURL, e);
            if (responseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                throw new DAOConcurrencyException();
            }
        }

        public async Task DeleteEvent(Event e)
        {
            HttpResponseMessage responseMessage = await ClientService.client.DeleteAsync(eventDeleteURL + e.EventId);
            if (responseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                throw new DAOConcurrencyException();
            }
        }

        public async Task<ObservableCollection<Event>> GetEvents()
        {
            return await DeserializerService<ObservableCollection<Event>>.GetObjectFromService(eventURL);
        }

        public async Task<ObservableCollection<Event>> GetFutureEvents()
        {
            return await DeserializerService<ObservableCollection<Event>>.GetObjectFromService(futureEventsURL);
        }

        public async Task<ObservableCollection<EventCategory>> GetEventCategories()
        {
            return await DeserializerService<ObservableCollection<EventCategory>>.GetObjectFromService(eventCategoryURL);
        }

        public async Task<ObservableCollection<Company>> GetCompanies()
        {
            return await DeserializerService<ObservableCollection<Company>>.GetObjectFromService(companyURL);
        }
    }
}
