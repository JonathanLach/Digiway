using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public static class DeserializerService<T>
    {
        public static async Task<T> getObjectModelAsync (HttpResponseMessage responseMessage)
        {
            var Jsonresponse = await responseMessage.Content.ReadAsStringAsync();
            var Model = JsonConvert.DeserializeObject<T>(Jsonresponse);
            return Model;
        } 
    }
}
