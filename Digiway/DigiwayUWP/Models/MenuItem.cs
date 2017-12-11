using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DigiwayUWP.Models
{
    public class MenuItem
    {
        public Symbol Icon { get; set; }
        public string Name { get; set; }
        public string PageType { get; set; }

        public static List<MenuItem> GetMainItems()
        {
            var items = new List<MenuItem>();
            items.Add(new MenuItem() { Icon = Symbol.Home, Name = "Home", PageType = "HomePage" });
            items.Add(new MenuItem() { Icon = Symbol.Calendar, Name = "Events", PageType = "EventsListPage" });
            items.Add(new MenuItem() { Icon = Symbol.Account, Name = "Profile", PageType = "ProfilePage" });
            items.Add(new MenuItem() { Icon = Symbol.List, Name = "Action Records", PageType = "ActionRecordsPage" });
            items.Add(new MenuItem() { Icon = Symbol.Globe, Name = "Analytics", PageType = "AnalyticsPage" });
            return items;
        }
    }
}
