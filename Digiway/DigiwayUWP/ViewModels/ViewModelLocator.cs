﻿using DigiwayUWP.Views;
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
            SimpleIoc.Default.Register<AnalyticsPageViewModel>();
            SimpleIoc.Default.Register<ActionRecordsPageViewModel>();
            SimpleIoc.Default.Register<EventsPageViewModel>();
            SimpleIoc.Default.Register<ProfilePageViewModel>();
            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<EventsListPageViewModel>();
            SimpleIoc.Default.Register<PointsOfInterestPageViewModel>();

            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);
            navigationPages.Configure("AnalyticsPage", typeof(AnalyticsPage));
            navigationPages.Configure("ActionRecordsPage", typeof(ActionRecordsPage));
            navigationPages.Configure("EventsPage", typeof(EventsPage));
            navigationPages.Configure("ProfilePage", typeof(ProfilePage));
            navigationPages.Configure("LoginPage", typeof(LoginPage));
            navigationPages.Configure("HomePage", typeof(HomePage));
            navigationPages.Configure("EventsListPage", typeof(EventsListPage));
            navigationPages.Configure("PointsOfInterestPage", typeof(PointsOfInterestPage));
        }

        public EventsPageViewModel Events
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EventsPageViewModel>();
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
