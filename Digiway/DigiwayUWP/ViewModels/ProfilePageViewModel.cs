using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        private User _currentUser;
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }

            set
            {
                _currentUser = value;
            }
        }

        private string _addressFormat;
        public string AddressFormat
        {
            get
            {
                return _addressFormat;
            }

            set
            {
                _addressFormat = value;
            }
        }

        private string _moneyFormat;
        public string MoneyFormat
        {
            get
            {
                return _moneyFormat;
            }

            set
            {
                _moneyFormat = value;
            }
        }


        public void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentUser = User.CurrentUser;
            AddressFormat = CurrentUser.Address + ", " + CurrentUser.ZIP + " " + CurrentUser.City;
            MoneyFormat = CurrentUser.Money + " €";
        }
    }
}
