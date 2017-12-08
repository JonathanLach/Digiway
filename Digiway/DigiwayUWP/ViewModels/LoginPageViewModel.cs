using DigiwayUWP.DataAccessObjects;
using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
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
    public class LoginPageViewModel : ViewModelBase, INotifyPropertyChanged
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
                RaisePropertyChanged("Login");
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
                RaisePropertyChanged("Password");
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
        private IDialogService _dialogService;

        public LoginPageViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            InitializeHttpClient();
        }

        public async Task InitializeHttpClient()
        {
            await ClientService.RunAsync();
        }


        public async Task Connection()
        {
            string hashedPassword = HashPassword(Password);
            try
            {
                User u = await User.GetUserByUsername(Login);
                if (u.Password == hashedPassword)
                {
                    User.CurrentUser = u;
                    await ActionRecord.AddActionRecord("Logged in");
                    _navigationService.NavigateTo("HomePage");
                }
                else
                {
                    throw new IncorrectPasswordException();
                }
            }
            catch (LoginException e)
            {
                await _dialogService.ShowMessage(e.Message, e.Title);
            }
        }

        public static String HashPassword(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA512.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

    }
}
