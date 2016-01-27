using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class LongListSelectorHelper
    {
        /// <summary>
        /// Recursively get the item.
        /// </summary>
        /// <typeparam name="T">The item to get.</typeparam>
        /// <param name="parents">Parent container.</param>
        /// <param name="objectList">Item list</param>
        public static void GetItemsRecursive<T>(DependencyObject parents, ref List<T> objectList) where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parents);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parents, i);

                if (child is T)
                {
                    objectList.Add(child as T);
                }

                GetItemsRecursive<T>(child, ref objectList);
            }
        }
    }
}
