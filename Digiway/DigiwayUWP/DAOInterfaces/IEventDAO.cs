using DigiwayUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DAOInterfaces
{
    public interface IEventDAO
    {
        Task AddEvent(Event e);
        Task UpdateEvent(Event e);
        Task<ObservableCollection<Event>> GetEvents();
        Task<ObservableCollection<EventCategory>> GetEventCategories();
        Task<ObservableCollection<Company>> GetCompanies();
        Task DeleteEvent(Event e);
        Task SendNotification(Event e);
    }
}
