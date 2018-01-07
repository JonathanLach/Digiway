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


        public Event EventSelected { get; set; }
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

        public ObservableCollection<PointOfInterest> SavedPointsOfInterest { get; set; }

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

        private ICommand _savePOI;
        public ICommand SavePOI
        {
            get
            {
                if (_savePOI == null)
                {
                    _savePOI = new RelayCommand(() => SavePointsOfInterest());
                }
                return _savePOI;
            }
        }

        private ICommand _deletePOI;
        public ICommand DeletePOI
        {
            get
            {
                if (_deletePOI == null)
                {
                    _deletePOI = new RelayCommand(() => DeletePointsOfInterest());
                }
                return _deletePOI;
            }
        }

        public void DeletePointsOfInterest()
        {
            try
            {
                var POI = EventSelected.PointsOfInterest.Where(pi => pi.Name == PushpinTitle).FirstOrDefault();
                if (POI == null)
                {
                    throw new NoPushpinFoundException();
                }

                POI.ToBeRemoved = true;
                foreach (MapIcon mi in Pushpins)
                {
                    if (mi.Title == PushpinTitle)
                    {
                        Pushpins.Remove(mi);
                        break;
                    }
                }
            }
            catch (EventException e)
            {
                _dialogService.ShowMessage(e.Message, e.Title);
            }
        }

        private ICommand _cancelPOI;
        public ICommand CancelPOI
        {
            get
            {
                if (_cancelPOI == null)
                {
                    _cancelPOI = new RelayCommand(() => CancelPointsOfInterest());
                }
                return _cancelPOI;
            }
        }

        public void SavePointsOfInterest()
        {
            
            _navigationService.NavigateTo("EventsPage", EventSelected);
        }

        public void CancelPointsOfInterest()
        {
            if (SavedPointsOfInterest == null)
            {
                EventSelected.PointsOfInterest.Clear();
            }
            else
            {
                EventSelected.PointsOfInterest = SavedPointsOfInterest;
            }
            Pushpins.Clear();
            _navigationService.NavigateTo("EventsPage", EventSelected);
        }

        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public PointsOfInterestPageViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            Pushpins = new ObservableCollection<MapElement>();
        }

        public async Task MapDoubleClick(object sender, MapInputEventArgs e)
        {
            //Delete zoom behavior on doubleclick
            var camera = (MapControl)sender;
            var currentCamera = camera.ActualCamera;
            await camera.TrySetSceneAsync(MapScene.CreateFromCamera(currentCamera));
            //End of delete zoom behavior
            try
            {
                if (PushpinTitle == null || PushpinTitle == "")
                {
                    throw new EmptyFieldException("Title");
                }
                if (EventSelected.PointsOfInterest.Where(pi => pi.Name == PushpinTitle).FirstOrDefault() != null)
                {
                    throw new PushpinTitleTakenException();
                }
                MapIcon newPushpin = new MapIcon
                {
                    Location = e.Location,
                    ZIndex = 0,
                    NormalizedAnchorPoint = new Point(0.5, 1),
                    Title = PushpinTitle,
                };
                Pushpins.Add(newPushpin);
                EventSelected.PointsOfInterest.Add(new PointOfInterest()
                {
                    Latitude = e.Location.Position.Latitude,
                    Longitude = e.Location.Position.Longitude,
                    Name = PushpinTitle,
                    Description = null,
                    EventId = EventSelected.EventId,
                    ToBeRemoved = false,
                });
            } catch (EventException ex)
            {
                await _dialogService.ShowMessage(ex.Message, ex.Title);
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Pushpins.Clear();
            EventSelected = (Event)e.Parameter;
            if (EventSelected.PointsOfInterest == null)
            {
                EventSelected.PointsOfInterest = new ObservableCollection<PointOfInterest>();
            }
            else
            {
                SavedPointsOfInterest = new ObservableCollection<PointOfInterest>(EventSelected.PointsOfInterest);
                foreach (PointOfInterest p in EventSelected.PointsOfInterest)
                {
                    BasicGeoposition position = new BasicGeoposition()
                    {
                        Latitude = p.Latitude,
                        Longitude = p.Longitude
                    };
                    Pushpins.Add(new MapIcon()
                    {

                        Location = new Geopoint(position),
                        NormalizedAnchorPoint = new Point(0.5, 1),
                        Title = p.Name
                    });
                }
            }
        }
     }
}
