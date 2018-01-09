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
    public class PointOfInterestService : IPointOfInterestDAO
    {
        private static string poiURL = "api/pointsofinterest";
        private static string poiPointOfInterestURL = poiURL + "/id/";
        private static string poiByEventURL = poiURL + "/eventid/";

        public async Task AddPOI(PointOfInterest poi)
        {
            await ClientService.client.PostAsJsonAsync(poiURL, poi);
        }

        public async Task UpdatePOI(PointOfInterest poi)
        {
            HttpResponseMessage responseMessage = await ClientService.client.PutAsJsonAsync(poiURL, poi);
            if (responseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                throw new DAOConcurrencyException();
            }
        }

        public async Task<ObservableCollection<PointOfInterest>> GetPOIByEvent(Event e)
        {
            return await DeserializerService<ObservableCollection<PointOfInterest>>.GetObjectFromService(poiByEventURL + e.EventId);
        }

        public async Task DeletePOI(PointOfInterest poi)
        {
            HttpResponseMessage responseMessage = await ClientService.client.DeleteAsync(poiPointOfInterestURL + poi.PointOfInterestId);
            if (responseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                throw new DAOConcurrencyException();
            }
        }
    }
}
