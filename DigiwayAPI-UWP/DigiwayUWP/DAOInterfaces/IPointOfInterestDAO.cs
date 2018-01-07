using DigiwayUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DAOInterfaces
{
    public interface IPointOfInterestDAO
    {
        Task AddPOI(PointOfInterest pointOfInterest);
        Task UpdatePOI(PointOfInterest pointOfInterest);
        Task DeletePOI(PointOfInterest poi);
        Task<ObservableCollection<PointOfInterest>> GetPOIByEvent(Event e);
    }
}
