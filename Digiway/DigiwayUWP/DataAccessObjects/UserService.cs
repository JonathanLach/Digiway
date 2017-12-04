using DigiwayUWP.DAOInterfaces;
using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public class UserService : IUserDAO
    {
        private static string userURL = "api/users";
        private static string userByNicknameURL = userURL + "/username/";
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

        public async Task<User> getUserByUsername(string userName)
        {
            HttpResponseMessage responseMessage = await ClientService.client.GetAsync(userByNicknameURL + userName);
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new UserNotFoundException();
            }
            else
            {
                var Jsonresponse = await ClientService.client.GetStringAsync(userByNicknameURL + userName);
                var UserModel = JsonConvert.DeserializeObject<User>(Jsonresponse);
                return UserModel;
            }
        }
    }
}
