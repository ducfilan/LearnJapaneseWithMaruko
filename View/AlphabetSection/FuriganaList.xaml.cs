using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Alphabet;
using Microsoft.Phone.Controls;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using System;
using Microsoft.Phone.Shell;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;

namespace Hoc_tieng_Nhat_cung_Maruko.View.AlphabetSection
{
    public partial class FuriganaList : PhoneApplicationPage
    {
        private int _numQuestion;
        private List<Question> _questions = new List<Question>();

        public FuriganaList()
        {
            InitializeComponent();
            Loaded += FuriganaList_Loaded;
        }

        void FuriganaList_Loaded(object sender, RoutedEventArgs e)
        {
            if (LongListSelectorKatakanas.ItemsSource == null)
            {
                var getHiraganasCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
                {
                    CommandText = "SELECT * FROM HIRAGANASDB"
                };

                LongListSelectorHiraganas.ItemsSource = getHiraganasCommand.ExecuteQuery<HIRAGANASDB>();
            }

            if (LongListSelectorKatakanas.ItemsSource == null)
            {
                var getKatakanasCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
                {
                    CommandText = "SELECT * FROM KATAKANASDB"
                };
                LongListSelectorKatakanas.ItemsSource = getKatakanasCommand.ExecuteQuery<KATAKANASDB>();
            }
        }

        int i; //Giang oi. Dat ten the nay a???
        private void initialize_Questions()
        {
            if (RbHiraganaButton.IsChecked == true)
            {
                GenerateHiraganaQuestions();
            }
            else
            {
                GenerateKatakanaQuestions();
            }
        }

        private void Pivot_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PivotWordLesson.SelectedIndex == 2)
            {
                initialize_Questions();
                _numQuestion = _questions.Count();
                if (slider1 != null && textBlock1 != null)
                    textBlock1.Text = (int)(slider1.Value * _numQuestion / 100) + "/" + _numQuestion + " câu hỏi";
            }
        }

        private void TapAndHoldGesture(object sender, GestureEventArgs e)
        {
            var gridFurigana = sender as Grid;
            if (gridFurigana == null) return;
            if (gridFurigana.DataContext == null)
                return;

            if (gridFurigana.DataContext is HIRAGANASDB)
            {
                var selectedWord = gridFurigana.DataContext as HIRAGANASDB;
                TextToSpeechHelper.SpeakJapaneseText(selectedWord.TERM);
            }
            else if (gridFurigana.DataContext is KATAKANASDB)
            {
                var selectedWord = gridFurigana.DataContext as KATAKANASDB;
                TextToSpeechHelper.SpeakJapaneseText(selectedWord.TERM);
            }
        }

        private void GenerateKatakanaQuestions()
        {
            _questions = new List<Question>();

            var listQuestions = LongListSelectorKatakanas.ItemsSource.Cast<KATAKANASDB>();

            foreach (var item in listQuestions)
            {
                var temList = new Stack<KATAKANASDB>(listQuestions.OrderBy(x => Guid.NewGuid()).Take(4));

                var question = new Question
                {
                    ID = item.ID,
                    Term = item.TERM,
                    AnswerA = temList.Pop().MEANING,
                    AnswerB = temList.Pop().MEANING,
                    AnswerC = temList.Pop().MEANING,
                    AnswerD = temList.Pop().MEANING
                };

                if (question.AnswerA == item.MEANING ||
                    question.AnswerB == item.MEANING ||
                    question.AnswerC == item.MEANING ||
                    question.AnswerD == item.MEANING)
                {
                    //Do nothing YEAHHHHHH
                }
                else
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

                question.RightAnswer = item.MEANING;
                _questions.Add(question);
                question.timer = 7;
            }
        }
        private void GenerateHiraganaQuestions()
        {
            _questions = new List<Question>();

            var listQuestions = LongListSelectorHiraganas.ItemsSource.Cast<HIRAGANASDB>();

            foreach (var item in listQuestions)
            {
                var temList = new Stack<HIRAGANASDB>(listQuestions.OrderBy(x => Guid.NewGuid()).Take(4));

                var question = new Question
                {
                    ID = item.ID,
                    Term = item.TERM,
                    AnswerA = temList.Pop().MEANING,
                    AnswerB = temList.Pop().MEANING,
                    AnswerC = temList.Pop().MEANING,
                    AnswerD = temList.Pop().MEANING
                };

                if (question.AnswerA == item.MEANING ||
                    question.AnswerB == item.MEANING ||
                    question.AnswerC == item.MEANING ||
                    question.AnswerD == item.MEANING)
                {
                    //Do nothing YEAHHHHHH
                }
                else
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

                question.RightAnswer = item.MEANING;
                _questions.Add(question);
                question.timer = 7;
            }

        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider1 != null && textBlock1 != null)
                textBlock1.Text = (int)(slider1.Value * _numQuestion / 100) + "/" + _numQuestion + " câu hỏi";
        }

        private void ButtonWriting_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            initialize_Questions();
            var num = (int)(slider1.Value * _numQuestion / 100);
            PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
            NavigationService.Navigate(new Uri("/View/TestSection/TestWriting.xaml", UriKind.Relative));
        }

        private void ButtonReading_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            initialize_Questions();
            var num = (int)(slider1.Value * _numQuestion / 100);
            PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
            NavigationService.Navigate(new Uri("/View/TestSection/TestMultiChoice.xaml", UriKind.Relative));
        }

        private void ButtonListening_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            initialize_Questions();
            var num = (int)(slider1.Value * _numQuestion / 100);
            PhoneApplicationService.Current.State["question"] = _questions.Take(num).ToList();
            NavigationService.Navigate(new Uri("/View/TestSection/TestListening.xaml", UriKind.Relative));
        }
    }
}