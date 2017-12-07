using DigiwayUWP.Models;
using DigiwayUWP.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class EventsListPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Event _eventSelected;
        public Event EventSelected
        {
            get
            {
                return _eventSelected;
            }
            set
            {
                _eventSelected = value;
                if (_eventSelected != null)
                {
                    RaisePropertyChanged("EventSelected");
                }
            }
        }

        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> Events
        {
            get
            {
                return _events;
            }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    RaisePropertyChanged("Events");
                }
            }
        }

        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public EventsListPageViewModel(INavigationService navigationService = null, IDialogService dialogService = null)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        private ICommand _addNewEvent;
        public ICommand AddNewEvent
        {
            get
            {
                if (_addNewEvent == null)
                {
                    _addNewEvent = new RelayCommand(() => AddEvent());
                }
                return _addNewEvent;
            }
        }

        private ICommand _editEvent;
        public ICommand EditEvent
        {
            get
            {
                if (_editEvent == null)
                {
                    _editEvent = new RelayCommand(async () => await EditEventSelected());
                }
                return _editEvent;
            }
        }

        public void AddEvent()
        {
            _navigationService.NavigateTo("EventsPage");
        }

        public async Task EditEventSelected()
        {
            if (EventSelected != null)
            {
                _navigationService.NavigateTo("EventsPage", EventSelected);
            }
            else
            {
                await _dialogService.ShowMessage("No event selected", "Selection error");
            }
        }

        private async void GetEvents()
        {
            Events = await Event.GetEvents();
            foreach(Event e in Events)
            {
                IFormatProvider culture = new CultureInfo("en-US");
                e.FormattedDate = e.EventDate.ToString("dddd dd MMMM yyyy", culture);
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            GetEvents();
        }

    }
}
