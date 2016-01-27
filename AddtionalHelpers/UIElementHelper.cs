using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;
using Hoc_tieng_Nhat_cung_Maruko.View.WordSection;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public static class UiElementHelper
    {
        public static T FindFirst<T>(DependencyObject parentElement, string controlName) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;

            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);

                if (child is T && (((FrameworkElement)child).Name).Equals(controlName))
                {
                    return (T)child;
                }

                var result = FindFirst<T>(child, controlName);
                if (result != null)
                    return result;
            }
            return null;
        }

        public static void SearchElement(DependencyObject targetedControl, string term, HideOption option)
        {
            var count = VisualTreeHelper.GetChildrenCount(targetedControl);
            if (count <= 0) return;
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetedControl, i);

                if (child is Border && (((FrameworkElement)child).Name).Trim().Equals("HideBoard"))
                {
                    var targetedElement = (Border)child;

                    if (option == HideOption.NoHide)
                    {
                        targetedElement.Opacity = 0;
                        return;
                    }

                    if (option == HideOption.HideVie)
                    {
                        targetedElement.Opacity = 1;
                        Grid.SetColumn(targetedElement, 1);
                        return;
                    }

                    if (option == HideOption.HideJap)
                    {
                        targetedElement.Opacity = 1;
                        Grid.SetColumn(targetedElement, 0);
                        return;
                    }

                    var vocabularyDict = targetedElement.DataContext as VOCABULARYDB;
                    if (vocabularyDict != null && vocabularyDict.TERM == term)
                    {
                        if (targetedElement.Opacity < 1)
                        {
                            AnimationHelper.Instance.OpacityAnimation(targetedElement, 0, 1, 1, 0);
                            AnimationHelper.Instance.StartAnimation();
                        }
                        else
                        {
                            AnimationHelper.Instance.OpacityAnimation(targetedElement, 1, 0, 1, 0);
                            AnimationHelper.Instance.StartAnimation();
                        }

                        return;
                    }
                }
                else
                {
                    SearchElement(child, term, option);
                }
            }
        }
        public static void ChangeColorAnswer(DependencyObject targetedControl, Color from, Color to)
        {

            var targetedElement = (Border)targetedControl;
            if (targetedElement.Background != new SolidColorBrush(to))
            {
                AnimationHelper.Instance.ColorAnimation(targetedElement, from, to, 300, 0);
                AnimationHelper.Instance.StartAnimation();

            }
            else
            {
                AnimationHelper.Instance.ColorAnimation(targetedElement, from, to, 300, 0);
                AnimationHelper.Instance.StartAnimation();
            }




        }
        public static void ChangeColorSelect(DependencyObject targetedControl, Color from, Color to)
        {

            var targetedElement = (Grid)targetedControl;
            if (targetedElement.Background != new SolidColorBrush(to))
            {
                AnimationHelper.Instance.BackgroundColorAnimation(targetedElement, from, to, 300, 0);
                AnimationHelper.Instance.StartAnimation();

            }
            else
            {
                AnimationHelper.Instance.BackgroundColorAnimation(targetedElement, from, to, 300, 0);
                AnimationHelper.Instance.StartAnimation();
            }




        }
        public static List<T> FindAllName<T>(DependencyObject parentElement, string controlName) where T : DependencyObject
        {
            var childList = new List<T>();
            var childrenCount = VisualTreeHelper.GetChildrenCount(parentElement);
            if (childrenCount == 0)
                return childList;

            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child is FrameworkElement && (((FrameworkElement)child).Name).Equals(controlName))
                {
                    childList.Add((T)child);
                }

                childList.AddRange(FindAllName<T>(child, controlName));
            }

            return childList;
        }
    }
}
