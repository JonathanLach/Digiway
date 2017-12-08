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
        private static string eventCategoryURL = "api/eventCategories";
        private static string companyURL = "api/companies";

        public async Task AddEvent(Event e)
        {
            await ClientService.client.PostAsJsonAsync(eventURL, e);
        }

        public async Task UpdateEvent(Event e)
        {
            await ClientService.client.PutAsJsonAsync(eventURL, e);
        }

        public async Task DeleteEvent(Event e)
        {
            await ClientService.client.DeleteAsync(eventURL + "/" + e.EventId);
        }

        public async Task<ObservableCollection<Event>> GetEvents()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(eventURL);
            return await DeserializerService<ObservableCollection<Event>>.getObjectModelAsync(responseMessage);
        }

        public async Task<ObservableCollection<EventCategory>> GetEventCategories()
        {

            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(eventCategoryURL);
            if (responseMessage.StatusCode == HttpStatusCode.Forbidden || responseMessage.StatusCode >= HttpStatusCode.InternalServerError)
            {
                throw new DAOConnectionException();
            }
            else
            {
                return await DeserializerService<ObservableCollection<EventCategory>>.getObjectModelAsync(responseMessage);
            }
        }

        public async Task<ObservableCollection<Company>> GetCompanies()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(companyURL);
            if (responseMessage.StatusCode == HttpStatusCode.Forbidden || responseMessage.StatusCode >= HttpStatusCode.InternalServerError)
            {
                throw new DAOConnectionException();
            }
            else
            {
                return await DeserializerService<ObservableCollection<Company>>.getObjectModelAsync(responseMessage);
            }
        }

    }
}
