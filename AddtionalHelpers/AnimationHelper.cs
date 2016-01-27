using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class AnimationHelper
    {
        private static AnimationHelper _instance;
        private static Storyboard _storyboard = new Storyboard();

        public static AnimationHelper Instance
        {
            get { return _instance ?? (_instance = new AnimationHelper()); }
        }

        public void OpacityAnimation(DependencyObject targetOject, double from, double to, int durationTimeInSecond, int beginTimeInSecond, bool isRepeatForever = false)
        {
            if (_storyboard.GetCurrentState() != ClockState.Stopped)
            {
                _storyboard.Stop();
                _storyboard.Children.Clear();
            }

            _storyboard.Stop();
            var doubleAnimationAppear = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(new TimeSpan(0, 0, 0, durationTimeInSecond)),
                BeginTime = new TimeSpan(0, 0, 0, beginTimeInSecond)
            };

            if (isRepeatForever)
            {
                doubleAnimationAppear.RepeatBehavior = RepeatBehavior.Forever;
            }

            Storyboard.SetTarget(doubleAnimationAppear, targetOject);
            Storyboard.SetTargetProperty(doubleAnimationAppear, new PropertyPath("(Opacity)"));
            _storyboard.Children.Add(doubleAnimationAppear);
        }
        public void ColorAnimation(DependencyObject targetOject, Color from, Color to, int durationTimeInSecond, int beginTimeInSecond)
        {
            if (_storyboard.GetCurrentState() != ClockState.Stopped)
            {
                _storyboard.Stop();
                _storyboard.Children.Clear();
            }

            var doubleAnimationAppear = new ColorAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, durationTimeInSecond)),
                BeginTime = new TimeSpan(0, 0, 0, beginTimeInSecond),
                AutoReverse = true
            };

            Storyboard.SetTarget(doubleAnimationAppear, targetOject);
            Storyboard.SetTargetProperty(doubleAnimationAppear, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            _storyboard.Children.Add(doubleAnimationAppear);
        }
        public void BackgroundColorAnimation(DependencyObject targetOject, Color from, Color to, int durationTimeInSecond, int beginTimeInSecond)
        {
            if (_storyboard.GetCurrentState() != ClockState.Stopped)
            {
                _storyboard.Stop();
                _storyboard.Children.Clear();
            }

            var doubleAnimationAppear = new ColorAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, durationTimeInSecond)),
                // FillBehavior = FillBehavior.HoldEnd,
                BeginTime = new TimeSpan(0, 0, 0, beginTimeInSecond)
            };

            Storyboard.SetTarget(doubleAnimationAppear, targetOject);
            Storyboard.SetTargetProperty(doubleAnimationAppear, new PropertyPath("(Grid.Background).(SolidColorBrush.Color)"));
            _storyboard.Children.Add(doubleAnimationAppear);
        }

        public void StartAnimation()
        {
            if (_storyboard.GetCurrentState() != ClockState.Stopped)
            {
                _storyboard.Stop();
            }
            
            _storyboard.Begin();
        }
    }
}
