using DigiwayUWP.Models;
using DigiwayUWP.ViewModels;
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
    public sealed partial class EventsListPage
    {
        public EventsListPage()
        {
            this.InitializeComponent();
            hamburgerMenuControl.ItemsSource = MenuItem.GetMainItems();
        }

        private void AddEventClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventsPage));
        }

        private void OnMenuItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;
            Frame.Navigate(menuItem.PageType);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((EventsListPageViewModel)DataContext).OnNavigatedTo(e);
        }
    }
}
