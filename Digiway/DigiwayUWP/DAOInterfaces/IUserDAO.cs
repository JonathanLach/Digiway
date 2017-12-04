using DigiwayUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DAOInterfaces
{
    public interface IUserDAO
    {
        Task<ObservableCollection<User>> GetUsers();

        Task UpdateUser(User u);
    }
}
