using DigiwayUWP.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigiwayUWP.ViewModels
{
    public class EventsPageViewModel
    {
        private INavigationService _navigationService;
        private ICommand _addNewEvent;
        private ICommand AddNewEvent
        {
            get
            {
                _addNewEvent =  new RelayCommand(async () => await AddEvent());
                return _addNewEvent;
            }
        }


        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        private DateTime _eventDate;
        public DateTime EventDate
        {
            get
            {
                return _eventDate;
            }
            set
            {
                _eventDate = value;
                OnPropertyChanged("EventDate");
            }
        }

        private double _ticketPrice;
        public double TicketPrice
        {
            get
            {
                return _ticketPrice;
            }
            set
            {
                _ticketPrice = value;
                OnPropertyChanged("TicketPrice");
            }
        }

        private int _zip;
        public int ZIP
        {
            get
            {
                return _zip;
            }
            set
            {
                _zip = value;
                OnPropertyChanged("ZIP");
            } 
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        private ObservableCollection<EventCategory> _categories;
        public ObservableCollection<EventCategory> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }


        public EventsPageViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            GetEvents();
        }

        private async Task GetEvents()
        {
            Categories = await Event.GetEvents();
        }

        private async Task AddEvent()
        {
            Event newEvent = new Event()
            {
                Name = this.Name,
                Address = this.Address,
                City = this.City,
                Company = null,
                Description = this.Description,
                EventDate = this.EventDate,
                EventCategory = null,
                PointsOfInterest = null,
                PurchaseRecords = null,
                TicketPrice = 10,
                ZIP = 6000
            };
            await newEvent.AddEvent();
        }


        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
