using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Grammar;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View.GrammarSection
{
    public partial class GrammarList : PhoneApplicationPage
    {
        public GrammarList()
        {
            InitializeComponent();

            SetupLessonListLoadingAnimation();
            
            Loaded += GrammarList_Loaded;
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
        void GrammarList_Loaded(object sender, RoutedEventArgs e)
        {
            if (ListLessons.ItemsSource != null) return;

            var fakeGrammarsList = new List<Grammar>();

            for (int i = 0; i < Common.NoOfTotalGrammars; i++)
            {
                fakeGrammarsList.Add(
                    new Grammar()
                    {
                        ImagePath = i + 1 + string.Empty,
                        LessonGrammars = null,
                        LessonNo = i + 1
                    }
                );
            }

            ListLessons.ItemsSource = fakeGrammarsList;

            if (Common.NoOfTotalGrammars <= 0) return;

            ListLessons.BringIntoView((from lesson in ListLessons.ItemsSource as List<Grammar>
                                       where lesson.LessonNo == (Common.CurrentGrammarLesson % 2 == 0 ? Common.CurrentGrammarLesson -1 : Common.CurrentGrammarLesson)
                                       select lesson).FirstOrDefault());
        }

        //private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ListLessons.SelectedItem == null)
        //        return;

        //    var fakeSelectedLesson = ((LongListSelector)sender).SelectedItem as Grammar;

        //    if (fakeSelectedLesson != null)
        //    {
        //        Common.CurrentGrammarLesson = fakeSelectedLesson.LessonNo;
        //        NavigationService.Navigate(new Uri("/View/GrammarSection/GrammarDetail.xaml?GrammarId=" + fakeSelectedLesson.LessonNo, UriKind.Relative));
        //    }

        //    ListLessons.SelectedItem = null;
        //}

        private void UIElement_OnTap(object sender, GestureEventArgs e)
        {
            var grid = sender as Grid;
            if (grid == null) return;

            var lesson = grid.DataContext as Grammar;
            if (lesson == null) return;

            NavigationService.Navigate(new Uri("/View/GrammarSection/GrammarDetail.xaml?GrammarId=" + lesson.LessonNo, UriKind.Relative));
            Common.CurrentGrammarLesson = lesson.LessonNo;
        }
    }
}