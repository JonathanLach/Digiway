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

namespace DigiwayUWP.ViewModels
{
    public class EventsListPageViewModel : INotifyPropertyChanged
    {
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
            
        public EventsListPageViewModel()
        {
            GetEvents();
        }

        private async void GetEvents()
        {
            Events = await Event.GetEvents();
        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
