using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;

namespace Hoc_tieng_Nhat_cung_Maruko.View.WordSection
{
    public enum HideOption
    {
        HideJap,
        HideVie,
        NoHide,
        HideSelectedWord
    };

    public partial class WordList : PhoneApplicationPage
    {
        private DispatcherTimer playTimer;
        private int _numQuestion;
        private CONVERSATIONDB _conversation;
        private List<Question> _questions;
        Lesson _lesson;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string lessonId;

            if (!NavigationContext.QueryString.TryGetValue("LessonId", out lessonId)) return;

            var getLessonWordsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM VOCABULARYDB WHERE LESSON = " + lessonId
            };

            _lesson = new Lesson()
            {
                LessonNumber = int.Parse(lessonId),
                ImagePath = lessonId,
                LessonWords = getLessonWordsCommand.ExecuteQuery<VOCABULARYDB>()
            };

            if (SliderNoOfQuestions != null && TextBlockNoOfQuestions != null)
                TextBlockNoOfQuestions.Text = (int)(SliderNoOfQuestions.Value * _numQuestion / 100) + "/" + _numQuestion + " câu hỏi";

            var getKaiwaCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM CONVERSATIONDB WHERE LESSON = " + _lesson.LessonNumber
            };

            _conversation = getKaiwaCommand.ExecuteQuery<CONVERSATIONDB>().First();
            KaiwaLayout.DataContext = _conversation;

            playTimer.Tick += playTimerTickEventHandler;
            playTimer.Start();
        }

        private void playTimerTickEventHandler(object sender, EventArgs e)
        {
            try
            {
                TimeSpan position = MediaKaiwa.Position;
                txtPosition.Text = position.ToString(@"hh\:mm\:ss");

                SliderSeekKaiwa.Value = position.TotalSeconds * 100 / MediaKaiwa.NaturalDuration.TimeSpan.TotalSeconds;
            }
            catch (FileNotFoundException) { }
            catch (Exception) { }
        }

        private void LongListSelectorWords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var foundList = (LongListSelector)sender;
            var vocabularyDict = foundList.SelectedItem as VOCABULARYDB;
            string term = string.Empty;
            if (vocabularyDict != null)
            {
                term = vocabularyDict.TERM;
            }

            UiElementHelper.SearchElement(foundList, term, HideOption.HideSelectedWord);
            LongListSelectorWords.SelectedItem = null;
        }

        public WordList()
        {
            InitializeComponent();
            Loaded += WordList_Loaded;
            //DataContext = lesson;
            playTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
            ListTestMode.SelectionChanged += (s, e) => initialize_Questions(ListTestMode.SelectedIndex);
        }

        void WordList_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _lesson;

            var bgCreateQuestion = new BackgroundWorker();
            bgCreateQuestion.DoWork += (s, a) =>
            {
                initialize_Questions(a.Argument as int?);
                _numQuestion = _questions.Count();
            };

            bgCreateQuestion.RunWorkerAsync(ListTestMode.SelectedIndex);

            if (Common.IsFirstTimeAccessWordList != 1) return;
            GridGuideUser.Visibility = Visibility.Visible;
            Common.IsFirstTimeAccessWordList = 0;
        }

        private void initialize_Questions(int? selectedIndexTestType)
        {
            _questions = new List<Question>();

            if (selectedIndexTestType == 0)
            {
                TermQuestion();
            }
            else
            {
                MeaningQuestion();
            }
        }

        //private void UpdateLearntWordIdsList()
        //{
        //    var newLearntWordIdsList = new List<int>(Common.LearntWordIdsList);
        //    newLearntWordIdsList.AddRange(_rightAnswerIdsList);
        //    Common.LearntWordIdsList = newLearntWordIdsList;
        //}

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as Pivot).SelectedItem == PivotItemConversion)
            {
                PivotWordLesson.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("#4FC7E3"));
            }
            else
            {
                PivotWordLesson.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("#E87E04"));
            }
            ApplicationBar.IsVisible = ((((Pivot)sender).SelectedIndex) == 0);
        }

        private void HideJapanese(object sender, EventArgs e)
        {
            UiElementHelper.SearchElement(LongListSelectorWords, "", HideOption.HideJap);
        }

        private void ShowAll(object sender, EventArgs e)
        {
            UiElementHelper.SearchElement(LongListSelectorWords, "", HideOption.NoHide);
        }

        private void HideVietnamese(object sender, EventArgs e)
        {
            UiElementHelper.SearchElement(LongListSelectorWords, "", HideOption.HideVie);
        }

        private void TapAndHoldGesture(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            var gridKanji = sender as Grid;
            if (gridKanji == null) return;
            if (gridKanji.DataContext == null)
                return;
            //gridKanji.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("F4D03E"));
            // UiElementHelper.ChangeColorSelect(gridKanji, ColorHelper.ConvertStringToColor("FFFFFF"), ColorHelper.ConvertStringToColor("F4D03E"));
            var selectedWord = gridKanji.DataContext as VOCABULARYDB;
            if (selectedWord != null) TextToSpeechHelper.SpeakJapaneseText(selectedWord.TERM);
        }

        private void TermQuestion()
        {
            foreach (var item in _lesson.LessonWords)
            {
                var temList = _lesson.LessonWords.ToList();
                var question = new Question {ID = item.ID, Term = item.TERM, RightAnswer = item.MEANING, timer = 50};

                var ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerA = ramdomItem.MEANING;
                temList.Remove(ramdomItem);
                ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerB = ramdomItem.MEANING;
                temList.Remove(ramdomItem);
                ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerC = ramdomItem.MEANING;
                temList.Remove(ramdomItem);
                ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerD = ramdomItem.MEANING;
                temList.Remove(ramdomItem);

                if (question.AnswerA != item.MEANING && question.AnswerB != item.MEANING && question.AnswerC != item.MEANING && question.AnswerD != item.MEANING)
                {

                    var answers = new List<int>(new[] { 1, 2, 3, 4 });
                    int answer = answers.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    switch (answer)
                    {
                        case 1:
                            question.AnswerA = item.MEANING;
                            break;
                        case 2:
                            question.AnswerB = item.MEANING;
                            break;
                        case 3:
                            question.AnswerC = item.MEANING;
                            break;
                        default:
                            question.AnswerD = item.MEANING;
                            break;
                    }
                }

                _questions.Add(question);
            }
        }

        private void MeaningQuestion()
        {
            foreach (var item in _lesson.LessonWords)
            {
                var temList = _lesson.LessonWords.ToList();
                var question = new Question { ID = item.ID, Term = item.MEANING };
                var ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerA = ramdomItem.TERM;
                temList.Remove(ramdomItem);
                ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerB = ramdomItem.TERM;
                temList.Remove(ramdomItem);
                ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerC = ramdomItem.TERM;
                temList.Remove(ramdomItem);
                ramdomItem = temList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                question.AnswerD = ramdomItem.TERM;
                temList.Remove(ramdomItem);

                if (question.AnswerA != item.TERM && question.AnswerB != item.TERM && question.AnswerC != item.TERM &&
                    question.AnswerD != item.TERM)
                {
                    var answers = new List<int>(new[] { 1, 2, 3, 4 });
                    int answer = answers.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    switch (answer)
                    {
                        case 1:
                            question.AnswerA = item.TERM;
                            break;
                        case 2:
                            question.AnswerB = item.TERM;
                            break;
                        case 3:
                            question.AnswerC = item.TERM;
                            break;
                        default:
                            question.AnswerD = item.TERM;
                            break;
                    }
                }

                question.RightAnswer = item.TERM;
                _questions.Add(question);
                question.timer = 50;
            }
        }

        private void GridGuideUser_OnTap(object sender, GestureEventArgs e)
        {
            GridGuideUser.Visibility = Visibility.Collapsed;
        }

        private void FlashCard_OnClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/WordSection/WordDetail.xaml?LessonId=" + _lesson.LessonNumber, UriKind.Relative));
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderNoOfQuestions != null && TextBlockNoOfQuestions != null)
                TextBlockNoOfQuestions.Text = (int)(SliderNoOfQuestions.Value * _numQuestion / 100) + "/" + _numQuestion + " câu hỏi";
        }

        private void ButtonWriting_OnTap(object sender, GestureEventArgs e)
        {
            var num = (int)(SliderNoOfQuestions.Value * _numQuestion / 100);
            PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
            NavigationService.Navigate(new Uri("/View/TestSection/TestWriting.xaml", UriKind.Relative));
        }

        private void ButtonReading_OnTap(object sender, GestureEventArgs e)
        {
            var num = (int)(SliderNoOfQuestions.Value * _numQuestion / 100);
            PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
            NavigationService.Navigate(new Uri("/View/TestSection/TestMultiChoice.xaml", UriKind.Relative));
        }

        private void ButtonListening_OnTap(object sender, GestureEventArgs e)
        {
            var num = (int)(SliderNoOfQuestions.Value * _numQuestion / 100);
            PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
            NavigationService.Navigate(new Uri("/View/TestSection/TestListening.xaml", UriKind.Relative));
        }

        private void ButtonPlayKaiwa_OnTap(object sender, GestureEventArgs e)
        {
            try
            {
                StoryboardPlayKaiwa.Begin();

                if (MediaKaiwa.CurrentState == MediaElementState.Playing)
                {
                    MediaKaiwa.Pause();
                    ImagePlayPause.Source = new BitmapImage(new Uri("/Assets/UIImages/playMedia.png", UriKind.Relative));
                }
                else
                {
                    ImagePlayPause.Source = new BitmapImage(new Uri("/Assets/UIImages/pauseMedia.png", UriKind.Relative));
                    MediaKaiwa.Play();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Không có Internet rùi :'(", "Huhu", MessageBoxButton.OK);
            }
            catch (Exception)
            { }
        }

        private void MediaKaiwa_MediaEnded(object sender, RoutedEventArgs e)
        {
            ImagePlayPause.Source = new BitmapImage(new Uri("/Assets/UIImages/playMedia.png", UriKind.Relative));
        }

        private void SliderSeekKaiwa_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!MediaKaiwa.CanSeek ||
                    !(Math.Abs(e.NewValue - e.OldValue) > 150/MediaKaiwa.NaturalDuration.TimeSpan.TotalSeconds)) return;

                var duration = MediaKaiwa.NaturalDuration.TimeSpan;
                int newPosition = (int)(duration.TotalSeconds / 100 * SliderSeekKaiwa.Value);
                MediaKaiwa.Position = new TimeSpan(0, 0, newPosition);
            }
            catch (Exception)
            {
            }
            
        }

        private void LongListSelectorWords_OnItemTap(object sender, ListBoxItemTapEventArgs e)
        {
            var foundList = (LongListSelector)sender;
            var vocabularyDict = foundList.SelectedItem as VOCABULARYDB;
            string term = string.Empty;
            if (vocabularyDict != null)
            {
                term = vocabularyDict.TERM;
            }

            UiElementHelper.SearchElement(foundList, term, HideOption.HideSelectedWord);
            LongListSelectorWords.SelectedItem = null;
        }

        private void HideBoard_OnTap(object sender, GestureEventArgs e)
        {
            var hideBoard = sender as Border;
            if (hideBoard == null) return;

            var animation = Resources["PerspectiveAnimation"] as RadPlaneProjectionAnimation;
            animation.Easing = new QuarticEase();
            animation.StartAngleX = 0;
            animation.EndAngleX = 0;
            animation.CenterX = 0;
            if (Grid.GetColumn(hideBoard) == 0)
            {
                Grid.SetColumn(hideBoard, 1);
                animation.StartAngleY = 180;
                animation.EndAngleY = 0;
            }
            else
            {
                Grid.SetColumn(hideBoard, 0);
                animation.StartAngleY = 180;
                animation.EndAngleY = 360;
                animation.CenterX = 1;
            }
            animation.CenterY = 0;

            animation.StartAngleZ = 0;
            animation.EndAngleZ = 0;
            animation.CenterZ = 0;
            animation.Axes = PerspectiveAnimationAxis.All;
            RadAnimationManager.Play(hideBoard, animation);
            //animation.Ended += (o, args) => hideBoard.Visibility = Visibility.Collapsed;
        }
    }
}