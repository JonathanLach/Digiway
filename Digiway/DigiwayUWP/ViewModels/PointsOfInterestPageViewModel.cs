using DigiwayUWP.DataAccessObjects;
using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class PointsOfInterestPageViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private ObservableCollection<PointOfInterest> PointsOfInterest { get; set; }
        private ObservableCollection<Geopoint> _pushpins;
        public ObservableCollection<Geopoint> Pushpins
        {
            get
            {
                return _pushpins;
            }
            set
            {
                _pushpins = value;
                RaisePropertyChanged("Pushpins");
            }
        }

        private INavigationService _navigationService;
    
        public PointsOfInterestPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void MapDoubleClick(object sender, MapInputEventArgs e)
        {
            MapIcon snPoint = new MapIcon
            {
                Location = e.Location,
                NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1),
                ZIndex = 0,
                Title = "Titre"
            };
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                PointsOfInterest = (ObservableCollection<PointOfInterest>)e.Parameter;
            }
            else
            {
                PointsOfInterest = new ObservableCollection<PointOfInterest>();
            }
        }
    }
}
