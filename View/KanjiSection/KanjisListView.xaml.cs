using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;
using Telerik.Windows.Controls;

namespace Hoc_tieng_Nhat_cung_Maruko.View.KanjiSection
{
    public partial class KanjisListView : PhoneApplicationPage
    {
        List<KANJIDICTDB> _kanjisFromDictionary;
        List<KANJIDICTDB> _levelKanjiWord;
        private int _numQuestion;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("KanjisFromDictionary"))
            {
                _kanjisFromDictionary = (List<KANJIDICTDB>)PhoneApplicationService.Current.State["KanjisFromDictionary"];
                PhoneApplicationService.Current.State.Remove("KanjisFromDictionary");
            }
            base.OnNavigatedTo(e);
        }

        public KanjisListView()
        {
            InitializeComponent();

            InitializeKanjiListAnimation();

            Loaded += KanjisListView_Loaded;
        }

        private void InitializeKanjiListAnimation()
        {
            var moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(500, 0);
            moveAndFade.MoveAnimation.EndPoint = new Point(0, 0);
            moveAndFade.FadeAnimation.StartOpacity = 0;
            moveAndFade.FadeAnimation.EndOpacity = 1;
            moveAndFade.Easing = new CubicEase();
            ListAllKanjis.ItemAddedAnimation = moveAndFade;

            moveAndFade = new RadMoveAndFadeAnimation();
            moveAndFade.MoveAnimation.StartPoint = new Point(0, 0);
            moveAndFade.MoveAnimation.EndPoint = new Point(500, 0);
            moveAndFade.FadeAnimation.StartOpacity = 1;
            moveAndFade.FadeAnimation.EndOpacity = 0;
            moveAndFade.Easing = new CubicEase() { EasingMode = EasingMode.EaseOut };
            ListAllKanjis.ItemRemovedAnimation = moveAndFade;
        }

        void KanjisListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (Common.CurrentLearningKanjisList == null || Common.CurrentLearningKanjisList.Count == 0)
            {
                TextBlockEmptyTemplate.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockEmptyTemplate.Visibility = Visibility.Collapsed;
                LongListMultiSelectorLearningWords.ItemsSource = Common.CurrentLearningKanjisList.ToList();
            }

            if (_kanjisFromDictionary != null)
            {
                ListAllKanjis.ItemsSource = _kanjisFromDictionary;
                return;
            }

            if (_levelKanjiWord != null) return;

            var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE JLPTLEVEL = " + Common.JlptLevel
            };

            _levelKanjiWord = getGrammarsCommand.ExecuteQuery<KANJIDICTDB>();

            PivotItemAllWords.Header = "trình độ N" + Common.JlptLevel;

            ListAllKanjis.ItemsSource = _levelKanjiWord;

            SetupAllWordApplicationBar();
        }

        private void TextBoxSearchKanji_TextChanged(object sender, TextChangedEventArgs e)
        {
            FullTextSearch();
        }

        private void FullTextSearch()
        {
            string inputValue = TextBoxSearchKanji.Text;
            string inputValueRemovedSign = TextBoxSearchKanji.Text;
            VietnameseSignsHelper.RemoveSigns(ref inputValueRemovedSign);

            if (string.IsNullOrEmpty(inputValue.Trim()))
            {
                //ListAllKanjis.ItemsSource = null;
                ListAllKanjis.ItemsSource = _levelKanjiWord;
                return;
            }

            var getKanjiCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE UPPER(MEANING) LIKE '" + inputValue.ToUpper() + "%' " +
                              " OR UPPER(MEANING) LIKE '" + inputValueRemovedSign.ToUpper() + "%' "
            };

            //ListAllKanjis.ItemsSource = null;
            ListAllKanjis.ItemsSource = getKanjiCommand.ExecuteQuery<KANJIDICTDB>();

        }

        private List<Question> _questions = new List<Question>();

        private void initialize_Questions()
        {

            if (RbKanjiButton.IsChecked == true)
            {
                KanjiQuestion();
            }
            else
            {
                HanvietQuestion();
            }
        }

        private void ClearButton_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.TextBoxSearchKanji.Text = "";
            this.TextBoxSearchKanji.Focus();
        }

        private void Pivot_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PivotWordLesson.SelectedIndex == 0)
            {
                if (ListAllKanjis.IsCheckModeActive)
                {
                    ListAllKanjis.IsCheckModeActive = false; // Will also update the Application Bar
                }
                else
                {
                    SetupAllWordApplicationBar();
                }
            }
            if (PivotWordLesson.SelectedIndex == 1)
            {
                if (LongListMultiSelectorLearningWords.IsSelectionEnabled)
                {
                    LongListMultiSelectorLearningWords.IsSelectionEnabled = false; // Will also update the Application Bar
                }
                else
                {
                    SetupAllWordApplicationBar();
                }

            }
            if (PivotWordLesson.SelectedIndex == 2)
            {
                initialize_Questions();
                _numQuestion = _questions.Count();
                if (slider1 != null && textBlock1 != null)
                    textBlock1.Text = (int)(slider1.Value * _numQuestion / 100) + "/" + _numQuestion + " câu hỏi";
            }

        }

        private void ButtonStartTest_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Common.CurrentLearningKanjisList == null || Common.CurrentLearningKanjisList.Count < 4)
            {
                textBlock1.Text = "Bạn phải học ít nhất 4 từ!";
            }
            else
            {

                initialize_Questions();
                var num = (int)(slider1.Value * _numQuestion / 100);
                PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
                NavigationService.Navigate(new Uri("/View/TestSection/TestMultiChoice.xaml", UriKind.Relative));
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var fe = sender as FrameworkElement;
            if (fe != null)
            {
                var selectedKanji = fe.DataContext as KANJIDICTDB;

                if (selectedKanji != null)
                {
                    PhoneApplicationService.Current.State["SelectedKanjiInList"] = selectedKanji;
                    NavigationService.Navigate(new Uri("/View/KanjiSection/KanjiDetailView.xaml?KanjiTerm=" + selectedKanji.TERM, UriKind.Relative));
                }

                // ListAllKanjis.SelectedItem = null;
            }
        }
        void ClearApplicationBar()
        {
            if (ApplicationBar == null)
            {
                ApplicationBar = new ApplicationBar();
                return;
            }
            while (ApplicationBar.Buttons.Count > 0)
            {
                ApplicationBar.Buttons.RemoveAt(0);
            }

            while (ApplicationBar.MenuItems.Count > 0)
            {
                ApplicationBar.MenuItems.RemoveAt(0);
            }
        }

        ApplicationBarIconButton _selectAllword;
        ApplicationBarIconButton _addToLearning;
        ApplicationBarIconButton _removeFromLearning;
        ApplicationBarMenuItem level5;
        ApplicationBarMenuItem level4;
        ApplicationBarMenuItem level3;
        ApplicationBarMenuItem level2;
        ApplicationBarMenuItem level0;


        /// <summary>
        /// Resets the application bar
        /// </summary>
        private void CreateApplicationBarItems()
        {
            if (_selectAllword == null)
            {
                _selectAllword = new ApplicationBarIconButton
                {
                    IconUri = new Uri("/Assets/UIImages/AppBar/showall.png", UriKind.RelativeOrAbsolute),
                    Text = "chọn"
                };
                _selectAllword.Click += OnAllWordSelectClick;
            }
            if (_addToLearning == null)
            {
                _addToLearning = new ApplicationBarIconButton
                {
                    IconUri = new Uri("/Assets/UIImages/AppBar/new.png", UriKind.RelativeOrAbsolute),
                    Text = "Thêm"
                };
                _addToLearning.Click += OnAddWordClick;
            }

            if (_removeFromLearning == null)
            {
                _removeFromLearning = new ApplicationBarIconButton
                {
                    IconUri = new Uri("/Assets/UIImages/AppBar/delete.png", UriKind.RelativeOrAbsolute),
                    Text = "Xóa"
                };
                _removeFromLearning.Click += OnRemoveWordClick;
            }
            if (level2 == null)
            {
                level2 = new ApplicationBarMenuItem { Text = "trình độ N2" };
                level2.Click += OnLevel2Tap;
                level3 = new ApplicationBarMenuItem { Text = "trình độ N3" };
                level3.Click += OnLevel3Tap;
                level4 = new ApplicationBarMenuItem { Text = "trình độ N4" };
                level4.Click += OnLevel4Tap;
                level5 = new ApplicationBarMenuItem { Text = "trình độ N5" };
                level5.Click += OnLevel5Tap;
                level0 = new ApplicationBarMenuItem { Text = "tất cả chữ" };
                level0.Click += OnLevel0Tap;
            }
        }

        private void OnLevel0Tap(object sender, EventArgs e)
        {
            var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB"
            };

            _levelKanjiWord = getGrammarsCommand.ExecuteQuery<KANJIDICTDB>();

            PivotItemAllWords.Header = "tất cả chữ";
            FullTextSearch();
        }

        private void OnLevel5Tap(object sender, EventArgs e)
        {
            var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE JLPTLEVEL = 5"
            };

            _levelKanjiWord = getGrammarsCommand.ExecuteQuery<KANJIDICTDB>();

            PivotItemAllWords.Header = "trình độ N5";
            FullTextSearch();
            Common.JlptLevel = 5;
        }

        private void OnLevel4Tap(object sender, EventArgs e)
        {
            var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE JLPTLEVEL = 4"
            };

            _levelKanjiWord = getGrammarsCommand.ExecuteQuery<KANJIDICTDB>();

            PivotItemAllWords.Header = "trình độ N4";
            FullTextSearch();
            Common.JlptLevel = 4;
        }

        private void OnLevel3Tap(object sender, EventArgs e)
        {
            var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE JLPTLEVEL = 3"
            };

            _levelKanjiWord = getGrammarsCommand.ExecuteQuery<KANJIDICTDB>();

            PivotItemAllWords.Header = "trình độ N3";
            FullTextSearch();
            Common.JlptLevel = 3;
        }

        private void OnLevel2Tap(object sender, EventArgs e)
        {
            var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE JLPTLEVEL = 2"
            };

            _levelKanjiWord = getGrammarsCommand.ExecuteQuery<KANJIDICTDB>();

            PivotItemAllWords.Header = "trình độ N2";
            FullTextSearch();
            Common.JlptLevel = 2;
        }

        private void SetupAllWordApplicationBar()
        {
            CreateApplicationBarItems();
            ClearApplicationBar();
            if (ListAllKanjis.IsCheckModeActive)
            {
                ApplicationBar.Buttons.Add(_addToLearning);
            }
            else if (LongListMultiSelectorLearningWords.IsSelectionEnabled)
            {
                ApplicationBar.Buttons.Add(_removeFromLearning);
            }
            else
            {
                ApplicationBar.Buttons.Add(_selectAllword);
            }

            if (PivotWordLesson.SelectedIndex == 0)
            {
                ApplicationBar.MenuItems.Add(level2);
                ApplicationBar.MenuItems.Add(level3);
                ApplicationBar.MenuItems.Add(level4);
                ApplicationBar.MenuItems.Add(level5);
                ApplicationBar.MenuItems.Add(level0);
            }
            ApplicationBar.IsVisible = true;
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
        }

        void UpdateAllWordApplicationBar()
        {
            if (((ListAllKanjis.CheckedItems != null) && (ListAllKanjis.CheckedItems.Count > 0)) || ((LongListMultiSelectorLearningWords.SelectedItems != null) && (LongListMultiSelectorLearningWords.SelectedItems.Count > 0)))
            {
                ApplicationBar.Mode = ApplicationBarMode.Default;
            }
            _addToLearning.IsEnabled = ((ListAllKanjis.CheckedItems != null) && (ListAllKanjis.CheckedItems.Count > 0));
            _removeFromLearning.IsEnabled = ((LongListMultiSelectorLearningWords.SelectedItems != null) && (LongListMultiSelectorLearningWords.SelectedItems.Count > 0));
        }

        void OnAllWordSelectClick(object sender, EventArgs e)
        {
            if (PivotWordLesson.SelectedIndex == 0)
            {
                ListAllKanjis.IsCheckModeActive = true;
            }
            else
            {
                LongListMultiSelectorLearningWords.EnforceIsSelectionEnabled = true;
            }
            PivotWordLesson.IsLocked = true;
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (ListAllKanjis.IsCheckModeActive)
            {
                ListAllKanjis.IsCheckModeActive = false;
                PivotWordLesson.IsLocked = false;
                e.Cancel = true;
            }
        }

        private void OnLearningwordSelector_IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetupAllWordApplicationBar();
        }

        void OnAddWordClick(object sender, EventArgs e)
        {
            if (Common.CurrentLearningKanjisList == null)
            {
                Common.CurrentLearningKanjisList = new HashSet<KANJIDICTDB>();
            }

            foreach (KANJIDICTDB kanji in ListAllKanjis.CheckedItems)
            {
                Common.CurrentLearningKanjisList.Add(kanji);
            }

            LongListMultiSelectorLearningWords.ItemsSource = Common.CurrentLearningKanjisList.ToList();
            if (Common.CurrentLearningKanjisList != null || Common.CurrentLearningKanjisList.Count > 0)
            {
                TextBlockEmptyTemplate.Visibility = Visibility.Collapsed;
            }
            ListAllKanjis.IsCheckModeActive = false;
            ListAllKanjis.CheckedItems.Clear();

            PivotWordLesson.IsLocked = false;
        }

        void OnRemoveWordClick(object sender, EventArgs e)
        {
            var selectedKanjisList = ListAllKanjis.CheckedItems;
            if (selectedKanjisList == null) return;

            if (Common.CurrentLearningKanjisList == null)
            {
                Common.CurrentLearningKanjisList = new HashSet<KANJIDICTDB>();
            }
            else
            {
                foreach (KANJIDICTDB kanji in LongListMultiSelectorLearningWords.SelectedItems)
                {

                    Common.CurrentLearningKanjisList.Remove(kanji);

                }

                LongListMultiSelectorLearningWords.ItemsSource = null;
                LongListMultiSelectorLearningWords.ItemsSource = Common.CurrentLearningKanjisList.ToList();
                if (Common.CurrentLearningKanjisList == null || Common.CurrentLearningKanjisList.Count == 0)
                {
                    TextBlockEmptyTemplate.Visibility = Visibility.Visible;
                }
                LongListMultiSelectorLearningWords.EnforceIsSelectionEnabled = false;
                PivotWordLesson.IsLocked = false;
            }
        }

        private void OnLearningwordSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAllWordApplicationBar();
        }

        private void KanjiQuestion()
        {
            if (Common.CurrentLearningKanjisList == null ||
                Common.CurrentLearningKanjisList.Count < 4) return;

            _questions = new List<Question>();

            foreach (var item in Common.CurrentLearningKanjisList)
            {
                var temList = new Stack<KANJIDICTDB>(Common.CurrentLearningKanjisList.OrderBy(x => Guid.NewGuid()).Take(4));
                var question = new Question
                {
                    ID = item.ID,
                    Term = item.TERM,
                    AnswerA = temList.Pop().MEANING,
                    AnswerB = temList.Pop().MEANING,
                    AnswerC = temList.Pop().MEANING,
                    AnswerD = temList.Pop().MEANING,
                    RightAnswer = item.MEANING,
                    timer = 50
                };

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

        private void HanvietQuestion()
        {
            _questions = new List<Question>();

            foreach (var item in Common.CurrentLearningKanjisList)
            {
                var temList = Common.CurrentLearningKanjisList.ToList();
                Question question = new Question { ID = item.ID, Term = item.MEANING };
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

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider1 != null && textBlock1 != null)
                textBlock1.Text = (int)(slider1.Value * _numQuestion / 100) + "/" + _numQuestion + " câu hỏi";
        }

        private void ListAllKanjis_OnIsCheckModeActiveChanged(object sender, IsCheckModeActiveChangedEventArgs e)
        {
            SetupAllWordApplicationBar();
        }

        private void ListAllKanjis_OnItemCheckedStateChanged(object sender, ItemCheckedStateChangedEventArgs e)
        {
            UpdateAllWordApplicationBar();   
        }
    }
}