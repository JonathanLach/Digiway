using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace DigiwayUWP.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(HomePage));
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            DigiwayView.IsPaneOpen = !DigiwayView.IsPaneOpen;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == HomeButton || e.OriginalSource == HomeButton2) {
                contentFrame.Navigate(typeof(HomePage));
            }
            else if (e.OriginalSource == ProfileButton || e.OriginalSource == ProfileButton2)
            {
                contentFrame.Navigate(typeof(ProfilePage));
            }
            else if (e.OriginalSource == EventsButton || e.OriginalSource == EventsButton2)
            {
                contentFrame.Navigate(typeof(EventsPage));
            }
            else if (e.OriginalSource == ActionRecordsButton || e.OriginalSource == ActionRecordsButton2)
            {
                contentFrame.Navigate(typeof(ActionRecordsPage));
            }
            else if (e.OriginalSource == AnalyticsButton || e.OriginalSource == AnalyticsButton2)
            {
                contentFrame.Navigate(typeof(AnalyticsPage));
            }
        }
    }
}
