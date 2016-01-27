using System;
using System.Collections.Generic;
using System.Linq;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Vocabulary;
using Microsoft.Phone.Controls;

namespace Hoc_tieng_Nhat_cung_Maruko.View.WordSection
{
    public partial class LessonList : PhoneApplicationPage
    {
        private bool _isScrolledToCurrentLesson;
        public LessonList()
        {
            InitializeComponent();
            if (Common.AllLessons == null)
            {
                //Split lesson
                Common.AllLessons = new LessonsList();
                Common.SplitLessons();
            }
            var lessonsList = new LessonsList();

            for (int i = 0; i < Common.NoOfTotalLessons; i++)
            {
                lessonsList.Lessons.Add(new Lesson(i + 1, i + 1 + string.Empty));
            }

            DataContext = lessonsList;

            Loaded += LessonListView_Loaded;
        }

        void LessonListView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Common.AllLessons.Lessons.Count <= 0) return;
            _isScrolledToCurrentLesson = false;
            LongListSelectorLessons.ItemRealized += LongListSelectorLessons_ItemRealized;
        }

        void LongListSelectorLessons_ItemRealized(object sender, ItemRealizationEventArgs e)
        {
            var lessonsList = DataContext as LessonsList;
            if (lessonsList != null)
                if (!_isScrolledToCurrentLesson)
                {
                    if (Common.CurrentWordLesson > 4)
                    {
                        LongListSelectorLessons.ScrollTo((from lesson in lessonsList.Lessons where lesson.LessonNumber == Common.CurrentWordLesson select lesson).FirstOrDefault());
                    }
                    _isScrolledToCurrentLesson = true;
                }
        }

        private void LongListSelectorLessons_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (LongListSelectorLessons.SelectedItem == null)
                return;
            var fakeSelectedLesson = ((LongListSelector)sender).SelectedItem as Lesson;
            var selectedLesson =
                (from lesson in Common.AllLessons.Lessons
                 where fakeSelectedLesson != null && lesson.LessonNumber == fakeSelectedLesson.LessonNumber
                 select lesson).First();
            if (selectedLesson == null) return;
            NavigationService.Navigate(new Uri("/View/WordSection/WordListOfALesson.xaml?LessonId=" + selectedLesson.LessonNumber, UriKind.Relative));
            Common.CurrentWordLesson = selectedLesson.LessonNumber;

            LongListSelectorLessons.SelectedItem = null;
        }

        private void OnFailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }

        private void OnAdReceived(object sender, GoogleAds.AdEventArgs e)
        {

        }
    }
}