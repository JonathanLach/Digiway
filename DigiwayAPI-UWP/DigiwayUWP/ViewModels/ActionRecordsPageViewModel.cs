using DigiwayUWP.Exceptions;
using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace DigiwayUWP.ViewModels
{
    public class ActionRecordsPageViewModel : ViewModelBase
    {
        private ObservableCollection<ActionRecord> _actionRecords;
        public ObservableCollection<ActionRecord> ActionRecords
        {
            get
            {
                return _actionRecords;
            }
            set
            {
                _actionRecords = value;
                if (_actionRecords != null)
                {
                    RaisePropertyChanged("ActionRecords");
                }
            }
        }

        private ObservableCollection<PurchaseRecord> _purchaseRecords;
        public ObservableCollection<PurchaseRecord> PurchaseRecords
        {
            get
            {
                return _purchaseRecords;
            }
            set
            {
                _purchaseRecords = value;
                if (_purchaseRecords != null)
                {
                    RaisePropertyChanged("PurchaseRecords");
                }
            }
        }

        private ObservableCollection<TransferRecord> _transferRecords;
        public ObservableCollection<TransferRecord> TransferRecords
        {
            get
            {
                return _transferRecords;
            }
            set
            {
                _transferRecords = value;
                if (_transferRecords != null)
                {
                    RaisePropertyChanged("TransferRecords");
                }
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

        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public ActionRecordsPageViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        private async Task GetActionRecords()
        {
            ActionRecords = await ActionRecord.GetActionRecords();
        }

        private async Task GetPurchaseRecords()
        {
            PurchaseRecords = await PurchaseRecord.GetPurchaseRecords();
        }

        private async Task GetTransferRecords()
        {
            TransferRecords = await TransferRecord.GetTransferRecords();
        }

        public async Task OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                await GetActionRecords();
                await GetPurchaseRecords();
                await GetTransferRecords();
            }
            catch (DAOConnectionException ex)
            {
                await _dialogService.ShowMessage(ex.Message, ex.Title);
                _navigationService.NavigateTo("HomePage");
            }
        }

    }
}
