using DigiwayUWP.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private async void GetActionRecords()
        {
            ActionRecords = await ActionRecord.GetActionRecords();
        }

        private async void GetPurchaseRecords()
        {
            PurchaseRecords = await PurchaseRecord.GetPurchaseRecords();
        }

        private async void GetTransferRecords()
        {
            TransferRecords = await TransferRecord.GetTransferRecords();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            GetActionRecords();
            GetPurchaseRecords();
            GetTransferRecords();
        }

    }
}
