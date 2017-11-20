using DigiwayUWP.DataAccessObjects;
using DigiwayUWP.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigiwayUWP.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _loginError;
        public string LoginError
        {
            get
            {
                return _loginError;
            }
            set
            {
                _loginError = value;
                OnPropertyChanged("LoginError");
            }
        }


        private ICommand _signIn;
        public ICommand SignIn
        {
            get
            {
                if (_signIn == null)
                {
                    _signIn = new RelayCommand(async () => await Connection());
                }
                return _signIn;
            }
        }

        private INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeHttpClient();
        }

        public async Task InitializeHttpClient()
        {
            await ClientService.RunAsync();
        }


        public async Task Connection()
        {
            ObservableCollection<User> users = await User.GetUsers();
            foreach (User u in users)
            {
                if (u.Login == Login && u.Password == Password)
                {
                    _navigationService.NavigateTo("MainPage");
                }
                else
                {
                    LoginError = "Login ou mot de passe incorrect";
                }
            }
        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


 
}
