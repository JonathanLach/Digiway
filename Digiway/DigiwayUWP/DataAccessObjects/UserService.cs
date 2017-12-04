using DigiwayUWP.DAOInterfaces;
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
    public class UserService : IUserDAO
    {
        public static string userURL = "api/users";
        public async Task<ObservableCollection<User>> GetUsers()
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(userURL);
            var Jsonresponse = await ClientService.client.GetStringAsync(userURL);
            var UserModel = JsonConvert.DeserializeObject<ObservableCollection<User>>(Jsonresponse);
            return UserModel;
        }

        public async Task UpdateUser(User u)
        {
            await ClientService.client.PutAsJsonAsync(userURL, u);
        }
    }
}
