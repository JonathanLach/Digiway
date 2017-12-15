using DigiwayUWP.Resources;
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
            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<EventsListPageViewModel>();
            SimpleIoc.Default.Register<PointsOfInterestPageViewModel>();
            SimpleIoc.Default.Register<ChangePasswordPageViewModel>();

            CustomNavigationService navigationPages = new CustomNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            navigationPages.Configure("MainPage", typeof(MainPage));
            navigationPages.Configure("AnalyticsPage", typeof(AnalyticsPage));
            navigationPages.Configure("ActionRecordsPage", typeof(ActionRecordsPage));
            navigationPages.Configure("EventsPage", typeof(EventsPage));
            navigationPages.Configure("ProfilePage", typeof(ProfilePage));
            navigationPages.Configure("LoginPage", typeof(LoginPage));
            navigationPages.Configure("HomePage", typeof(HomePage));
            navigationPages.Configure("EventsListPage", typeof(EventsListPage));
            navigationPages.Configure("PointsOfInterestPage", typeof(PointsOfInterestPage));
            navigationPages.Configure("ChangePasswordPage", typeof(ChangePasswordPage));
        }


        public MainPageViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public HomePageViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }

        public EventsPageViewModel Events
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EventsPageViewModel>();
            }
        }

        public ChangePasswordPageViewModel ChangePassword
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChangePasswordPageViewModel>();
            }
        }

        public LoginPageViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
            }
        }

        public EventsListPageViewModel EventsList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EventsListPageViewModel>();
            }
        }

        public ProfilePageViewModel Profile
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProfilePageViewModel>();
            }
        }

        public PointsOfInterestPageViewModel PointsOfInterest
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PointsOfInterestPageViewModel>();
            }
        }

        public ActionRecordsPageViewModel ActionRecords
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ActionRecordsPageViewModel>();
            }
        }
    }
}
