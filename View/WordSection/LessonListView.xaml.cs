using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View.WordSection
{
    public partial class LessonListView : PhoneApplicationPage
    {
        public LessonListView()
        {
            InitializeComponent();

            SetupLessonListLoadingAnimation();

            Loaded += LessonListView_Loaded;
        }

        private void SetupLessonListLoadingAnimation()
        {
            var moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(0, -90);
            moveAndFade.MoveAnimation.EndPoint = new Point(0, 0);
            moveAndFade.FadeAnimation.StartOpacity = 0;
            moveAndFade.FadeAnimation.EndOpacity = 1;
            moveAndFade.Easing = new CubicEase();
            ListLessons.ItemAddedAnimation = moveAndFade;

            moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(0, 0);
            moveAndFade.MoveAnimation.EndPoint = new Point(0, -90);
            moveAndFade.FadeAnimation.StartOpacity = 1;
            moveAndFade.FadeAnimation.EndOpacity = 0;
            moveAndFade.Easing = new CubicEase() { EasingMode = EasingMode.EaseOut };

            ListLessons.ItemRemovedAnimation = moveAndFade;
        }

        void LessonListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null) return;
            var lessonsList = new LessonsList();

            for (int i = 0; i < Common.NoOfTotalLessons; i++)
            {
                lessonsList.Lessons.Add(new Lesson(i + 1, i + 1 + string.Empty));
            }

            DataContext = lessonsList;

            if (Common.NoOfTotalLessons <= 0) return;

            ListLessons.BringIntoView((from lesson in lessonsList.Lessons
                                       where lesson.LessonNumber == (Common.CurrentWordLesson % 2 == 0 ? Common.CurrentWordLesson - 1 : Common.CurrentWordLesson)
                                       select lesson).FirstOrDefault());
        }

        //private void LongListSelectorLessons_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    if (ListLessons.SelectedItem == null)
        //        return;
        //    var fakeSelectedLesson = ((LongListSelector)sender).SelectedItem as Lesson;

        //    if (fakeSelectedLesson == null) return;
        //    NavigationService.Navigate(new Uri("/View/WordSection/WordList.xaml?LessonId=" + fakeSelectedLesson.LessonNumber, UriKind.Relative));
        //    Common.CurrentWordLesson = fakeSelectedLesson.LessonNumber;

        //    ListLessons.SelectedItem = null;
        //}

        private void UIElement_OnTap(object sender, GestureEventArgs e)
        {
            var grid = sender as Grid;
            if (grid == null) return;

            var lesson = grid.DataContext as Lesson;
            if (lesson == null) return;

            NavigationService.Navigate(new Uri("/View/WordSection/WordList.xaml?LessonId=" + lesson.LessonNumber, UriKind.Relative));
            Common.CurrentWordLesson = lesson.LessonNumber;
        }
    }
}