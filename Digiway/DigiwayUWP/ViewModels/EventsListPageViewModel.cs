using DigiwayUWP.Models;
using DigiwayUWP.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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
    public class EventsListPageViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Event> _eventSelected;
        public ObservableCollection<Event> EventSelected
        {
            get
            {
                return _eventSelected;
            }
            set
            {
                if (_eventSelected != value)
                {
                    _eventSelected = value;
                    OnPropertyChanged("EventSelected");
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
                    OnPropertyChanged("Events");
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
                    _addNewEvent = new RelayCommand(() => AddEvent());
                }
                return _addNewEvent;
            }
        }

        public void AddEvent()
        {
            MainPage.panelFrame.Navigate(typeof(EventsPage));
        }

        private ICommand _editEvent;
        public ICommand EditEvent
        {
            get
            {
                if (_editEvent == null)
                {
                    _editEvent = new RelayCommand(() => EditEventSelected());
                }
                return _editEvent;
            }
        }

        public void EditEventSelected()
        {
            MainPage.panelFrame.Navigate(typeof(EventsPage), EventSelected);
        }

        private async void GetEvents()
        {
            Events = await Event.GetEvents();
        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            GetEvents();
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
