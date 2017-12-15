using DigiwayUWP.Resources;
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
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _menuItemCommand;
        public ICommand MenuItemCommand
        {
            get
            {
                if (_menuItemCommand == null)
                {
                    _menuItemCommand = new RelayCommand<ItemClickEventArgs>(OnMenuClick);
                }
                return _menuItemCommand;
            }
        }

        private void OnMenuClick(ItemClickEventArgs args)
        {
            MenuItem item = (MenuItem)args.ClickedItem;
            _navigationService.NavigateTo(item.PageType);
        }

        private MenuItem _selectedItem;
        public MenuItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                if (_menuItems == value)
                {
                    return;
                }
                _menuItems = value;
                RaisePropertyChanged("MenuItems");
            }
        }

        public HomePage HomePage { get; set; }

        private INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItems = new ObservableCollection<MenuItem>(MenuItem.GetMainItems());
            HomePage = new HomePage();
        }
    }
}
