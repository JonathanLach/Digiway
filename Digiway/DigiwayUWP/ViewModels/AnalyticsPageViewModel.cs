using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DigiwayUWP.ViewModels
{
    public class AnalyticsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ImageBrush _imageShown;
        public ImageBrush ImageShown
        {
            get
            {
                return _imageShown;
            }
            set
            {
                _imageShown = value;
                RaisePropertyChanged("ImageShown");
            }
        }

        public AnalyticsPageViewModel()
        {
        }
    }
}
