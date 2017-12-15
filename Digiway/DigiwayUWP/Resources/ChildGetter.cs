using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace DigiwayUWP.Resources
{
    public static class ChildGetter
    {
            /// <summary>
            /// Return a child object of type T or null if it doesn't exist
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="depObj"></param>
            /// <returns></returns>
            public static T GetChildOfType<T>(DependencyObject depObj)
            where T : DependencyObject
            {
                if (depObj == null) return null;

                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);

                    var result = (child as T) ?? GetChildOfType<T>(child);
                    if (result != null) return result;
                }
                return null;
            }
    }
}
