using DigiwayUWP.DataAccessObjects;
using DigiwayUWP.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class MainPageViewModel
    {

        public User CurrentUser { get; set; }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentUser = (User)e.Parameter;
        }
    }
}
