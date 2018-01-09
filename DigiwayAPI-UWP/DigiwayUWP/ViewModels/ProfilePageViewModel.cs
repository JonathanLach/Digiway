using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
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
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public ProfilePageViewModel(INavigationService navigationService = null, IDialogService dialogService = null)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

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
                RaisePropertyChanged("MoneyFormat");
            }
        }

        private double _moneyTransaction;
        public double MoneyTransaction
        {
            get
            {
                return _moneyTransaction;
            }

            set
            {
                _moneyTransaction = value;
                RaisePropertyChanged("MoneyTransaction");
            }
        }


        private ICommand _depositMoney;
        public ICommand DepositMoney
        {
            get
            {
                if (_depositMoney == null)
                {
                    _depositMoney = new RelayCommand(async () => await Deposit());
                }
                return _depositMoney;
            }
        }

        public ICommand _goBack;
        public ICommand GoBack
        {
            get
            {
                if (_goBack == null)
                {
                    _goBack = new RelayCommand(() => GoBackNavigation());
                }
                return _goBack;
            }
        }

        public void GoBackNavigation()
        {
            _navigationService.GoBack();
        }

        private ICommand _withdrawMoney;
        public ICommand WithdrawMoney
        {
            get
            {
                if (_withdrawMoney == null)
                {
                    _withdrawMoney = new RelayCommand(async () => await Withdraw());
                }
                return _withdrawMoney;
            }
        }

        public async Task Withdraw()
        {

            await _dialogService.ShowMessage("Are you sure you want to withdraw money?",
               "Confirmation",
               buttonConfirmText: "Yes", buttonCancelText: "No",
               afterHideCallback: async (confirmed) =>
               {
                   if (confirmed)
                   {
                       try
                       {

                           if(CurrentUser.Money - MoneyTransaction < 0)
                           {
                               throw new NotEnoughMoneyException();
                           }

                            CurrentUser.Money -= MoneyTransaction;
                            MoneyFormat = CurrentUser.Money + " €";
                            await TransferRecord.AddTransferRecord(-MoneyTransaction);
                            await CurrentUser.UpdateUser();
                            await _dialogService.ShowMessage("You withdrawed money from your user account", "Money Transfer");
                       }
                       catch (DAOException e)
                       {
                           await _dialogService.ShowMessage(e.Message, e.Title);
                           CurrentUser.Money += MoneyTransaction;
                           MoneyFormat = CurrentUser.Money + " €";
                       }
                       catch (NotEnoughMoneyException e)
                       {
                           await _dialogService.ShowMessage(e.Message, e.Title);
                       }
                   }
               });
        }

        public async Task Deposit()
        {
            await _dialogService.ShowMessage("Are you sure you want to deposit money?",
            "Confirmation",
            buttonConfirmText: "Yes", buttonCancelText: "No",
            afterHideCallback: async (confirmed) =>
            {
                if (confirmed)
                {

                    try
                    {
                        CurrentUser.Money += MoneyTransaction;
                        MoneyFormat = CurrentUser.Money + " €";
                        await TransferRecord.AddTransferRecord(MoneyTransaction);
                        await CurrentUser.UpdateUser();
                            await _dialogService.ShowMessage("You have made a deposit to your user account", "Money Transfer");
                    }
                    catch (DAOException e)
                    {
                        await _dialogService.ShowMessage(e.Message, e.Title);
                        CurrentUser.Money -= MoneyTransaction;
                        MoneyFormat = CurrentUser.Money + " €";
                    }
                }
            });
        }


        private ICommand _changePassword;
        public ICommand ChangePassword
        {
            get
            {
                if (_changePassword == null)
                {
                    _changePassword = new RelayCommand(() => ChangePasswordNavigation());
                }
                return _changePassword;
            }
        }

        public void ChangePasswordNavigation()
        {
            _navigationService.NavigateTo("ChangePasswordPage");
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentUser = User.CurrentUser;
            AddressFormat = CurrentUser.Address + ", " + CurrentUser.ZIP + " " + CurrentUser.City;
            MoneyFormat = CurrentUser.Money + " €";
        }
    }
}
