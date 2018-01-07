using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigiwayUWP.ViewModels
{
    public class HomePageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        private ICommand _eventsManagerNav;
        public ICommand EventsManagerNav
        {
            get
            {
                if (_eventsManagerNav == null)
                {
                    _eventsManagerNav = new RelayCommand(() => EventsManagerNavigation());
                }
                return _eventsManagerNav;
            }
        }
        private ICommand _analyticsNav;
        public ICommand AnalyticsNav
        {
            get
            {
                if (_analyticsNav == null)
                {
                    _analyticsNav = new RelayCommand(() => AnalyticsNavigation());
                }
                return _analyticsNav;
            }
        }
        private ICommand _actionRecordsNav;
        public ICommand ActionRecordsNav
        {
            get
            {
                if (_actionRecordsNav == null)
                {
                    _actionRecordsNav = new RelayCommand(() => ActionRecordsNavigation());
                }
                return _actionRecordsNav;
            }
        }
        private ICommand _profileNav;
        public ICommand ProfileNav
        {
            get
            {
                if (_profileNav == null)
                {
                    _profileNav = new RelayCommand(() => ProfileNavigation());
                }
                return _profileNav;
            }
        }
        
        public void ProfileNavigation()
        {
            _navigationService.NavigateTo("ProfilePage");
        }

        public void ActionRecordsNavigation()
        {
            _navigationService.NavigateTo("ActionRecordsPage");
        }

        public void EventsManagerNavigation()
        {
            _navigationService.NavigateTo("EventsListPage");
        }

        public void AnalyticsNavigation()
        {
            _navigationService.NavigateTo("AnalyticsPage");
        }
    }

}
