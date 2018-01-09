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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DataAccessObjects
{
    public class UserService : IUserDAO
    {
        private static string userURL = "api/users";
        private static string userByNicknameURL = userURL + "/username/";
        private static string tokenURL = "token";

        public async Task<ObservableCollection<User>> GetUsers()
        {
            return await DeserializerService<ObservableCollection<User>>.GetObjectFromService(userURL);
        }

        public async Task UpdateUser(User u)
        {
            HttpResponseMessage responseMessage = await ClientService.client.PutAsJsonAsync(userURL, u);
            if (responseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                throw new DAOConcurrencyException();
            }
        }

        public async Task<User> getUserByUsername(string userName)
        {
            return await DeserializerService<User>.GetObjectFromService(userByNicknameURL + userName);
        }

        public async Task SetAuthentication(User u)
        {
            TokenRequest tUser = new TokenRequest()
            {
                Username = u.Login,
                Password = u.Password
            };
            HttpResponseMessage responseMessage = await ClientService.client.PostAsJsonAsync(tokenURL, tUser);
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new UserNotFoundException();
            }
            if (responseMessage.StatusCode == HttpStatusCode.Forbidden || responseMessage.StatusCode >= HttpStatusCode.InternalServerError)
            {
                throw new DAOConnectionException();
            }
            var jsonresponse = await responseMessage.Content.ReadAsStringAsync();
            Token model = JsonConvert.DeserializeObject<Token>(jsonresponse);
            ClientService.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.TokenValue);
        }
    }
}
