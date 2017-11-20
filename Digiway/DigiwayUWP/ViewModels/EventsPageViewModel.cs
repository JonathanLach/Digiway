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
using Windows.UI.Xaml.Controls;

namespace DigiwayUWP.ViewModels
{
    public class EventsPageViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigationService;

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

        private DatePicker _eventDatePicker;
        public DatePicker EventDatePicker
        {
            get
            {
                return _eventDatePicker;
            }
            set
            {
                _eventDatePicker = value;
                OnPropertyChanged("EventDatePicker");
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
                if (_categories == value)
                {
                    return;
                }
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private EventCategory _categorySelected;
        public EventCategory CategorySelected
        {
            get
            {
                return _categorySelected;
            }
            set
            {
                if (_categorySelected != value)
                {
                    _categorySelected = value;
                    OnPropertyChanged("CategorySelected");
                }
            }
        }

        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get
            {
                return _companies;
            }
            set
            {
                if (_companies == value)
                {
                    return;
                }
                _companies = value;
                OnPropertyChanged("Companies");
            }
        }

        private Company _companySelected;
        public Company CompanySelected
        {
            get
            {
                return _companySelected;
            }
            set
            {
                if (_companySelected != value)
                {
                    _companySelected = value;
                    OnPropertyChanged("CompanySelected");
                }
            }
        }

        private ICommand _addNewEvent;
        public ICommand AddNewEvent
        {
            get
            {
                if (_addNewEvent == null)
                {
                    _addNewEvent = new RelayCommand(async () => await AddEvent());
                }
                return _addNewEvent;
            }
        }

        public EventsPageViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            GetEventCategories();
            GetCompanies();
        }

        private async void GetEventCategories()
        {
            Categories = await EventCategory.GetEventCategories();
        }

        private async void GetCompanies()
        {
            Companies = await Event.GetCompanies();
        }

        private async Task AddEvent()
        {
            Event newEvent = new Event()
            {
                Name = this.Name,
                Address = this.Address,
                City = this.City,
                Description = this.Description,
                EventDate = Convert.ToDateTime(EventDatePicker),
                EventCategoryId = this.CategorySelected.EventCategoryId,
                CompanyId = this.CompanySelected.CompanyId,
                PointsOfInterest = null,
                PurchaseRecords = null,
                TicketPrice = this.TicketPrice,
                ZIP = this.ZIP
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
