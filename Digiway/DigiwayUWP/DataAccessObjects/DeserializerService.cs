using DigiwayUWP.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public static class DeserializerService<T>
    {
        private static async Task<T> GetObjectModelAsync (HttpResponseMessage responseMessage)
        {
            var Jsonresponse = await responseMessage.Content.ReadAsStringAsync();
            var Model = JsonConvert.DeserializeObject<T>(Jsonresponse);
            return Model;
        } 

        public static async Task<T> GetObjectFromService(string requestUri)
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(requestUri);
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new UserNotFoundException();
            }
            else if (responseMessage.StatusCode == HttpStatusCode.Forbidden || responseMessage.StatusCode >= HttpStatusCode.InternalServerError)
            {
                throw new DAOConnectionException();
            }
            else
            {
                return await GetObjectModelAsync(responseMessage);
            }
        }
    }
}
