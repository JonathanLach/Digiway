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
    public class UserService
    {
        public async Task<ObservableCollection<User>> GetUsers()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync("api/users");
            var Jsonresponse = await ClientService.client.GetStringAsync("api/users");
            var UserModel = JsonConvert.DeserializeObject<ObservableCollection<User>>(Jsonresponse);
            return UserModel;
        }

        public async Task UpdateUser(User u)
        {
            await ClientService.client.PutAsJsonAsync("api/users", u);
        }
    }
}
