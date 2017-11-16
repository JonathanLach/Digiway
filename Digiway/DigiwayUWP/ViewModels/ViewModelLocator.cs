using DigiwayUWP.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<AnalyticsPageViewModel>();
            SimpleIoc.Default.Register<ActionRecordsPageViewModel>();
            SimpleIoc.Default.Register<EventsPageViewModel>();
            SimpleIoc.Default.Register<ProfilePageViewModel>();

            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);
            navigationPages.Configure("MainPage", typeof(MainPage));
            navigationPages.Configure("AnalyticsPage", typeof(AnalyticsPage));
            navigationPages.Configure("ActionRecordsPage", typeof(ActionRecordsPage));
            navigationPages.Configure("EventsPage", typeof(EventsPage));
            navigationPages.Configure("ProfilePage", typeof(ProfilePage));
        }

        public MainPageViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }
        public EventsPageViewModel Events
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EventsPageViewModel>();
            }
        }
    }
}
