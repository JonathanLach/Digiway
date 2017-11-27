using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
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
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class EventsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        public Event EventSelected {get; set;}

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
                RaisePropertyChanged("Name");
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
                RaisePropertyChanged("Address");
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
                RaisePropertyChanged("City");
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
                RaisePropertyChanged("EventDatePicker");
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
                RaisePropertyChanged("TicketPrice");
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
                RaisePropertyChanged("ZIP");
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
                RaisePropertyChanged("Description");
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
                RaisePropertyChanged("Categories");
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
                _categorySelected = value;
                if (_categorySelected != null)
                {
                    RaisePropertyChanged("CategorySelected");
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
                RaisePropertyChanged("Companies");
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
                _companySelected = value;
                if (_companySelected != null)
                {
                    RaisePropertyChanged("CompanySelected");
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

        private ICommand _getPOIView;
        public ICommand GetPOIView
        {
            get
            {
                if (_getPOIView == null)
                {
                    _getPOIView = new RelayCommand(() => GetPointsOfInterestView());
                }
                return _getPOIView;
            }
        }

        public void GetPointsOfInterestView()
        {
            _navigationService.NavigateTo("PointsOfInterestPage");
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

            string actionDescription;

            if (EventSelected == null)
            {
                actionDescription = "Ajout nouvel événement: " + newEvent.Name;
                await newEvent.AddEvent();
            }
            else
            {
                actionDescription = "Edition de l'événement: " + newEvent.Name;
                newEvent.EventId = EventSelected.EventId;
                await newEvent.UpdateEvent();
            }
            await ActionRecord.AddActionRecord(actionDescription);
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            EventSelected = (Event)e.Parameter;
            if (EventSelected != null)
            {
                Name = EventSelected.Name;
                Address = EventSelected.Address;
                City = EventSelected.City;
                ZIP = EventSelected.ZIP;
                Description = EventSelected.Description;
                CompanySelected = EventSelected.Company;
                CategorySelected = EventSelected.EventCategory;
                TicketPrice = EventSelected.TicketPrice;
            }
        }

    }
}
