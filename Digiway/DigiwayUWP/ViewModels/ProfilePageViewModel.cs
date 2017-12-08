using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
                RaisePropertyChanged("MoneyFormat");
            }
        }

        private decimal _moneyTransaction;
        public decimal MoneyTransaction
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
            if (CurrentUser.Money - MoneyTransaction >= 0)
            {
                CurrentUser.Money -= MoneyTransaction;
                MoneyFormat = CurrentUser.Money + " €";
                await TransferRecord.AddTransferRecord(-MoneyTransaction);
                await CurrentUser.UpdateUser();
            }
        }

        public async Task Deposit()
        {
            CurrentUser.Money += MoneyTransaction;
            MoneyFormat = CurrentUser.Money + " €";
            await TransferRecord.AddTransferRecord(MoneyTransaction);
            await CurrentUser.UpdateUser();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentUser = User.CurrentUser;
            AddressFormat = CurrentUser.Address + ", " + CurrentUser.ZIP + " " + CurrentUser.City;
            MoneyFormat = CurrentUser.Money + " €";
        }
    }
}
