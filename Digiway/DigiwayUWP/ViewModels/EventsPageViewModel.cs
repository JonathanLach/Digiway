using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class EventsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public Event EventSelected { get; set; }

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

        private DateTimeOffset _eventDatePicker;
        public DateTimeOffset EventDatePicker
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

        public ObservableCollection<PointOfInterest> PointsOfInterest { get; set; }

        private string _zip;
        public string ZIP
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
            try
            {
                VerificationEvent();
                if (EventSelected == null)
                {
                    throw new NotCreatedEventException();
                }
                EventSelected.Address = Address;
                EventSelected.City = City;
                EventSelected.Company = CompanySelected;
                EventSelected.Description = Description;
                EventSelected.EventDate = EventDatePicker.DateTime;
                EventSelected.Name = Name;
                EventSelected.PointsOfInterest = PointsOfInterest;
                EventSelected.TicketPrice = (decimal)TicketPrice;
                EventSelected.ZIP = ZIP;
                EventSelected.EventCategory = CategorySelected;
                _navigationService.NavigateTo("PointsOfInterestPage", EventSelected);
            }
            catch(EventException e)
            {
                _dialogService.ShowMessage(e.Message, e.Title);
            }
        }

        public EventsPageViewModel(INavigationService navigationService = null, IDialogService dialogService = null)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

        }

        private void VerificationEvent()
        {
            if (EventDatePicker.DateTime < DateTime.Today)
            {
                throw new AnteriorEventDateException();
            }
            if (CompanySelected == null)
            {
                throw new NoCompanySelectedException();
            }
            if (CategorySelected == null)
            {
                throw new NoCategorySelectedException();
            }
            if (TicketPrice < 0)
            {
                throw new NegativePriceException();
            }
            if (Name == null || Name == "")
            {
                throw new EmptyFieldException("Name");
            }
            if (Address == null || Address == "")
            {
                throw new EmptyFieldException("Address");
            }
            if (ZIP == null || ZIP == "")
            {
                throw new EmptyFieldException("ZIP");
            }
            if (ZIP.Length != 4 || !IsDigit(ZIP))
            {
                throw new NotBelgianEventException();
            }
            if (City == null || City == "")
            {
                throw new EmptyFieldException("City");
            }
        }

        private bool IsDigit(string s)
        {
            return Regex.IsMatch(s, @"^\d+$");
        }

        private async Task AddEvent()
        {

            try
            {
                VerificationEvent();
                Event newEvent = new Event()
                {
                    Name = this.Name,
                    Address = this.Address,
                    City = this.City,
                    Description = this.Description,
                    EventDate = EventDatePicker.DateTime,
                    EventCategoryId = CategorySelected.EventCategoryId,
                    CompanyId = CompanySelected.CompanyId,
                    PointsOfInterest = PointsOfInterest,
                    PurchaseRecords = null,
                    TicketPrice = (decimal)this.TicketPrice,
                    ZIP = this.ZIP
                };

                string actionDescription;

                if (EventSelected == null)
                {
                    actionDescription = "Ajout nouvel événement: " + newEvent.Name;
                    await newEvent.AddEvent();
                    await _dialogService.ShowMessage("Event Added!", "Event Manager");
                }
                else
                {
                    actionDescription = "Edition de l'événement: " + newEvent.Name;
                    newEvent.EventId = EventSelected.EventId;
                    foreach (PointOfInterest p in newEvent.PointsOfInterest)
                    {
                        if (p.ToBeRemoved)
                        {
                            await p.DeletePOI();
                        }
                        else
                        {
                            await p.UpdatePOI();
                        }
                    }
                    await newEvent.UpdateEvent();
                    await _dialogService.ShowMessage("Event Modified!", "Event Manager");
                }
                await ActionRecord.AddActionRecord(actionDescription);
                _navigationService.NavigateTo("EventsListPage");
            } catch (EventException e)
            {
                await _dialogService.ShowMessage(e.Message, e.Title);
            }
        }

        private async Task GetCompanies()
        {
            Companies = await Event.GetCompanies();
        }

        private async Task GetCategories()
        {
            Categories = await EventCategory.GetEventCategories();
        }


        public async Task OnNavigatedTo(NavigationEventArgs e)
        {
            Name = "";
            EventDatePicker.ToLocalTime();
            Address = "";
            City = "";
            ZIP = "";
            Description = "";
            TicketPrice = 0;
            try
            {
                await GetCompanies();
                await GetCategories();
                EventSelected = (Event)e.Parameter;
                if (EventSelected != null)
                {
                    Name = EventSelected.Name;
                    EventDatePicker = EventSelected.EventDate;
                    Address = EventSelected.Address;
                    City = EventSelected.City;
                    ZIP = EventSelected.ZIP;
                    Description = EventSelected.Description;
                    CompanySelected = Companies.Where(u => u.CompanyId == EventSelected.CompanyId).First();
                    CategorySelected = Categories.Where(u => u.EventCategoryId == EventSelected.EventCategoryId).First();
                    TicketPrice = decimal.ToDouble(EventSelected.TicketPrice);
                    PointsOfInterest = new ObservableCollection<PointOfInterest>(EventSelected.PointsOfInterest);
                }
                else
                {
                    EventDatePicker = DateTime.Today;
                    PointsOfInterest = null;
                }
            }
            catch (DAOConnectionException ex)
            {
                await _dialogService.ShowMessage(ex.Message, ex.Title);
                _navigationService.NavigateTo("EventsListPage");
            }
        }

    }
}
