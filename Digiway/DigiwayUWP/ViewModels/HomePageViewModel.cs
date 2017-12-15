using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.ViewModels
{
    public class HomePageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }

}
