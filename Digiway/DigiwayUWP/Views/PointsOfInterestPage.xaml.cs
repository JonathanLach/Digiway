using DigiwayUWP.Models;
using DigiwayUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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
    public sealed partial class PointsOfInterestPage : Page
    {
        public PointsOfInterestPage()
        {
            this.InitializeComponent();
            hamburgerMenuControl.ItemsSource = MenuItem.GetMainItems();
        }

        public PointsOfInterestPageViewModel Vm {
            get
            {
                return (PointsOfInterestPageViewModel)DataContext;
            }
        }

        private void OnMenuItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;
            Frame.Navigate(menuItem.PageType);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BasicGeoposition namurPosition = new BasicGeoposition()
            {
                Latitude = 50.4667,
                Longitude = 4.8667
            };
            Geopoint mapCenter = new Geopoint(namurPosition);
            Map.Center = mapCenter;
        }
    }
}
