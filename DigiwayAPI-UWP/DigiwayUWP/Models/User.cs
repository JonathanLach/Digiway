﻿using DigiwayUWP.DAOInterfaces;
using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string IBANAccount { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string TelNumber { get; set; }
        public int AccessRights { get; set; }
        public double Money { get; set; }

        public static User CurrentUser {get; set; }

        public virtual ICollection<UserCompany> Companies { get; set; }
        public virtual ICollection<ActionRecord> ActionRecords { get; set; }

        public static IUserDAO userService = new UserService();

        /// <summary>
        /// Get all the users from service
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<User>> GetUsers()
        {
            return await userService.GetUsers();
        }

        /// <summary>
        /// Update the user in the service
        /// </summary>
        /// <returns></returns>
        public async Task UpdateUser()
        {
            await DeserializerService<User>.CheckConnectivity();
            await userService.UpdateUser(this);
        }

        public async Task SetAuthentication()
        {
            await userService.SetAuthentication(this);
        }

        /// <summary>
        /// Get a user with the passed userName, if it exists.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static async Task<User> GetUserByUsername(string userName)
        {
            return await userService.getUserByUsername(userName);
        }

    }
}
