using DigiwayUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.DAOInterfaces
{
    public interface ITransferRecordDAO
    {
        Task<ObservableCollection<TransferRecord>> GetTransferRecords();
        Task AddTransferRecord(TransferRecord tr);
    }
}
