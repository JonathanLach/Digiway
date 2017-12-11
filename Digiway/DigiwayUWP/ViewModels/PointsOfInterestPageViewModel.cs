using DigiwayUWP.DataAccessObjects;
using DigiwayUWP.Exceptions;
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
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class PointsOfInterestPageViewModel : ViewModelBase, INotifyPropertyChanged
    {


        private ObservableCollection<PointOfInterest> PointsOfInterest { get; set; }
        private ObservableCollection<MapElement> _pushpins;
        public ObservableCollection<MapElement> Pushpins
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

        private string _pushpinTitle;
        public string PushpinTitle
        {
            get
            {
                return _pushpinTitle;
            }
            set
            {
                _pushpinTitle = value;
                RaisePropertyChanged("PushpinTitle");
            }
        }

        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public PointsOfInterestPageViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            Pushpins = new ObservableCollection<MapElement>();
        }

        public void MapDoubleClick(object sender, MapInputEventArgs e)
        {
            try
            {
                if (PushpinTitle == null || PushpinTitle == "")
                {
                    throw new EmptyFieldException("Title");
                }
                MapIcon newPushpin = new MapIcon
                {
                    Location = e.Location,
                    ZIndex = 0,
                    NormalizedAnchorPoint = new Point(0.5, 1),
                    Title = PushpinTitle,
                };
                Pushpins.Add(newPushpin);
            } catch (EmptyFieldException ex)
            {
                _dialogService.ShowMessage(ex.Message, ex.Title);
            }
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
