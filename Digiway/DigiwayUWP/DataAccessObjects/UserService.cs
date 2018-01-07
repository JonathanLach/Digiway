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
        private static string companiesByUserURL = "api/companies/user";

        public async Task<ObservableCollection<User>> GetUsers()
        {
            return await DeserializerService<ObservableCollection<User>>.GetObjectFromService(userURL);
        }

        public async Task UpdateUser(User u)
        {
            await ClientService.client.PutAsJsonAsync(userURL, u);
        }

        public async Task<User> getUserByUsername(string userName)
        {
            return await DeserializerService<User>.GetObjectFromService(userByNicknameURL + userName);
        }
    }
}
