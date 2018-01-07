using DigiwayUWP.DAOInterfaces;
using DigiwayUWP.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Models
{
    public class PointOfInterest
    {
        public long PointOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public long EventId { get; set; }
        public virtual Event Event { get; set; }
        public bool ToBeRemoved { get; set; }

        public static IPointOfInterestDAO pService = new PointOfInterestService();


        public async Task AddPOI()
        {
            await pService.AddPOI(this);
        }

        public async Task UpdatePOI()
        {
            await pService.UpdatePOI(this);
        }

        public static async Task<ObservableCollection<PointOfInterest>> GetPOIByEvent(Event e)
        {
            return await pService.GetPOIByEvent(e);
        }

        public async Task DeletePOI()
        {
            await pService.DeletePOI(this);
        }
    }
}
