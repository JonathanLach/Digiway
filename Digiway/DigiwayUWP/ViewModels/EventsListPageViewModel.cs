﻿using DigiwayUWP.Models;
using DigiwayUWP.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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

        public EventsListPageViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
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
                    _editEvent = new RelayCommand(() => EditEventSelected());
                }
                return _editEvent;
            }
        }

        public void AddEvent()
        {
            _navigationService.NavigateTo("EventsPage");
        }

        public void EditEventSelected()
        {
            if (EventSelected != null)
            {
                _navigationService.NavigateTo("EventsPage", EventSelected);
            }
        }

        private async void GetEvents()
        {
            Events = await Event.GetEvents();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            GetEvents();
        }

    }
}