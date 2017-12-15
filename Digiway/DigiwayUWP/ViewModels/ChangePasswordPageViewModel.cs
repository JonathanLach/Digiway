using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using DigiwayUWP.Resources;
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
    public class ChangePasswordPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public ChangePasswordPageViewModel(INavigationService navigationService = null, IDialogService dialogService = null)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        private string _actualPassword;
        public string ActualPassword
        {
            get
            {
                return _actualPassword;
            }
            set
            {
                _actualPassword = value;
                RaisePropertyChanged("ActualPassword");
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                RaisePropertyChanged("NewPassword");
            }
        }

        private string _confirmation;
        public string Confirmation
        {
            get
            {
                return _confirmation;
            }
            set
            {
                _confirmation = value;
                RaisePropertyChanged("Confirmation");
            }
        }


        private ICommand _cancelChange;
        public ICommand CancelChange
        {
            get
            {
                if (_cancelChange == null)
                {
                    _cancelChange = new RelayCommand(() => CancelPasswordChange());
                }
                return _cancelChange;
            }
        }

        private ICommand _changePassword;
        public ICommand ChangePassword
        {
            get
            {
                if (_changePassword == null)
                {
                    _changePassword = new RelayCommand(async () => await ModifyPassword());
                }
                return _changePassword;
            }
        }

        public async Task ModifyPassword()
        {
            try
            {
                verificationPasswords();
                User.CurrentUser.Password = PasswordHasher.HashPassword(NewPassword);
                await User.CurrentUser.UpdateUser();
                await _dialogService.ShowMessage("Password changed!", "Confirmation");
                _navigationService.GoBack();
            }
            catch (PasswordChangeException e)
            {
                await _dialogService.ShowMessage(e.Message, e.Title);
            }
        }

        private void verificationPasswords()
        {
            if (User.CurrentUser.Password != PasswordHasher.HashPassword(ActualPassword))
            {
                throw new WrongPasswordException();
            }
            if (NewPassword != Confirmation)
            {
                throw new NoMatchPasswordException();
            }
        }

        public void CancelPasswordChange()
        {
            _navigationService.GoBack();
        }
    }
}
