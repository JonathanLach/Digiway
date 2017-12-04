using DigiwayUWP.DAOInterfaces;
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
        public string Hashcode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IBANAccount { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public int TelNumber { get; set; }
        public int AccessRights { get; set; }
        public double Money { get; set; }

        public static User CurrentUser {get; set; }

        public virtual ICollection<UserCompany> Companies { get; set; }
        public virtual ICollection<ActionRecord> ActionRecords { get; set; }
        public virtual ICollection<Friendship> Friends { get; set; }

        public static IUserDAO userService = new UserService();

        public static async Task<ObservableCollection<User>> GetUsers()
        {
            return await userService.GetUsers();
        }

        public async Task UpdateUser()
        {
            await userService.UpdateUser(this);
        }


    }
}
