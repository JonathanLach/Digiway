using DigiwayUWP.DataAccessObjects;
using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using DigiwayUWP.Resources;
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

        public static int organisatorAccess = 7;

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
            string hashedPassword = PasswordHasher.HashPassword(Password);
            try
            {
                User u = await User.GetUserByUsername(Login);
                if (u.Password == hashedPassword)
                {
                    if (u.AccessRights == organisatorAccess)
                    {
                        User.CurrentUser = u;
                        User.CurrentUser.Password = hashedPassword;
                        await User.CurrentUser.SetAuthentication();
                        await ActionRecord.AddActionRecord("Logged in");
                        _navigationService.NavigateTo("MainPage");
                    }
                    else
                    {
                        throw new AccessNotGrantedException();
                    }
                }
                else
                {
                    throw new IncorrectPasswordException();
                }
            }
            catch(DAOConnectionException e)
            {
                await _dialogService.ShowMessage(e.Message, e.Title);
            }
            catch (LoginException e)
            {
                await _dialogService.ShowMessage(e.Message, e.Title);
            }
        }
    }
}
