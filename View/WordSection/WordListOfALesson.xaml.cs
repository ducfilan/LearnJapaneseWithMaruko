using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Vocabulary;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;
using TransitionElement = Microsoft.Phone.Controls.TransitionElement;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Resources;
using System.Windows.Media;
using Microsoft.Xna.Framework;
using System.Windows.Media.Imaging;
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

    public partial class WordListOfALesson : PhoneApplicationPage
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string lessonId;
            LoadSound("Assets/TestSounds/correct.wav", out _correctSound);
            LoadSound("Assets/TestSounds/wrong.wav", out _wrongSound);

            if (!NavigationContext.QueryString.TryGetValue("LessonId", out lessonId)) return;
            _lesson = Common.AllLessons.Lessons[int.Parse(lessonId) - 1];
            DataContext = _lesson;
            initialize_Questions();
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

        public WordListOfALesson()
        {
            InitializeComponent();
            Loaded += WordList_Loaded;
            //DataContext = lesson;
        }

        void WordList_Loaded(object sender, RoutedEventArgs e)
        {
            if (Common.IsFirstTimeAccessWordList != 1) return;
            GridGuideUser.Visibility = Visibility.Visible;
            Common.IsFirstTimeAccessWordList = 0;
        }

        private void SlideEffectTransition()
        {
            TransitionElement transitionElement = SlideTransitionElement("SlideRightFadeOut");
            var phoneApplicationPage = (PhoneApplicationPage)(((PhoneApplicationFrame)Application.Current.RootVisual)).Content;
            ITransition transition = transitionElement.GetTransition(phoneApplicationPage);
            transition.Completed += delegate { transition.Stop(); };
            transition.Begin();
        }

        private Boolean _isQuestionsFinished;
        private Boolean _hasStartedQuestions;
        private int _correctedQuestion;
        private int _secondsQuestion;
        private int _totalQuestions;

        private List<Question> _questions = new List<Question>();
        private Question _currentQuestion = new Question();

        private DispatcherTimer _timerQuestions;

        private SoundEffect _correctSound, _wrongSound;

        Lesson _lesson = new Lesson();

        private void initialize_Questions()
        {

            if (_questions.Count <= 0)
            {
                TermQuestion();
            }
            _totalQuestions = _questions.Count;
            txtCorrectImages.Text = "Đúng: " + _correctedQuestion + "/" + _totalQuestions;
            txtTotal.Text = "Bạn có thể kiểm tra " + _correctedQuestion + "/" + _totalQuestions + " câu hỏi!";
            _timerQuestions = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 1000)};
            _timerQuestions.Tick += timer_Tick_Questions;
        }
        void timer_Tick_Questions(object sender, EventArgs e)
        {
            _secondsQuestion++;
            int timeLeft = _currentQuestion.timer - _secondsQuestion;
            if (timeLeft > 0)
            {
                txtTimerImages.Text = "Thời gian còn lại: " + timeLeft;
            }
            else
            {
                _secondsQuestion = 0;
                if (_questions.Count > 0)
                {
                    _questions.RemoveAt(0);
                    if (_questions.Count > 0)
                    {
                        nextQuestion_Images();
                    }
                    else
                    {
                        StopQuestion();
                    }
                }
                else
                {
                    StopQuestion();
                }
            }
        }

        private List<int> _rightAnswerIdsList = new List<int>();

        private void CompareAnswers(object sender, String answer)
        {
            var foundList = (Border)sender;

           
            if (_currentQuestion.timer <= 1)
            {
                return;
            }
            _timerQuestions.Stop();
            if (answer.Equals(_currentQuestion.RightAnswer))
            {
                if (!Common.LearntWordIdsList.Contains(_currentQuestion.ID))
                {
                    _rightAnswerIdsList.Add(_currentQuestion.ID);
                }
                FrameworkDispatcher.Update();
                _correctSound.Play();
                _correctedQuestion++;
                txtCorrectImages.Text = "Đúng: " + _correctedQuestion + "/" + _totalQuestions;

                UiElementHelper.ChangeColorAnswer(foundList, ColorHelper.ConvertStringToColor("36D7B6"), ColorHelper.ConvertStringToColor("F4D03E"));

                _currentQuestion.timer = 1;
                _timerQuestions.Start();


            }
            else
            {
                FrameworkDispatcher.Update();
                _wrongSound.Play();
                _currentQuestion.timer = 1;
                _timerQuestions.Start();
                UiElementHelper.ChangeColorAnswer(foundList, ColorHelper.ConvertStringToColor("36D7B6"), ColorHelper.ConvertStringToColor("F32613"));


            }

        }
        private void UpdateLearntWordIdsList()
        {
            var newLearntWordIdsList = new List<int>(Common.LearntWordIdsList);
            newLearntWordIdsList.AddRange(_rightAnswerIdsList);
            Common.LearntWordIdsList = newLearntWordIdsList;
        }
        private List<TE> ShuffleList<TE>(List<TE> inputList)
        {
            var randomList = new List<TE>();

            var r = new Random();
            while (inputList.Count > 0)
            {
                int randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        private void LoadSound(String soundFilePath, out SoundEffect sound)
        {
            sound = null;
            try
            {
                StreamResourceInfo soundFileInfo = Application.GetResourceStream(new Uri(soundFilePath, UriKind.Relative));
                sound = SoundEffect.FromStream(soundFileInfo.Stream);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Couldn't load sound " + soundFilePath);
            }
        }
/*
        private void PauseQuestion()
        {
            _timerQuestions.Stop();
        }
*/

        private void ResumeQuestion()
        {
            _timerQuestions.Start();
        }

        private Boolean IsEverythingFinished()
        {
            return _isQuestionsFinished;
        }

        int _questionNumber;
        private void nextQuestion_Images()
        {
            TextBlockQuestionNumber.Text = (_questionNumber++).ToString(CultureInfo.InvariantCulture);
            _questions = ShuffleList(_questions);
            _currentQuestion = _questions.ElementAt(0);
            txtQuestionImages.Text = _currentQuestion.Term;
            txtTimerImages.Text = "Thời gian còn lại: " + _currentQuestion.timer;
            brA.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("36D7B6"));
            brB.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("36D7B6"));
            brC.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("36D7B6"));
            brD.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("36D7B6"));
            btnAAnswer.Text = _currentQuestion.AnswerA;
            btnBAnswer.Text = _currentQuestion.AnswerB;
            btnCAnswer.Text = _currentQuestion.AnswerC;
            btnDAnswer.Text = _currentQuestion.AnswerD;
        }

        private void StopQuestion()
        {
            _secondsQuestion = 0;
            _timerQuestions.Stop();
            _isQuestionsFinished = true;

            // PivotWordLesson.SelectedIndex = 1;

            if (IsEverythingFinished())
            {
                ShowGameFinished();
            }
        }
        private void ShowGameFinished()
        {
            UpdateLearntWordIdsList();
            PivotWordLesson.IsLocked = false;
            ButtonStartTest.Content = "Làm lại";
            int totalQuestion = _totalQuestions;
            float resultMark = ((float)_correctedQuestion / totalQuestion);
            DateTime now = DateTime.Now;
            var testResult = new TestDataItem(now.GetDateTimeFormats('d')[0], resultMark * 100);
            if (Common.DataTest == null)
            {
                Common.DataTest = new List<TestDataItem>();
            }
            var tempDataTest = Common.DataTest;
            tempDataTest.Add(testResult);
            Common.DataTest = tempDataTest;
            if (resultMark < 0.5)
            {
                txtTotal.Text = Common.NameOfUser + " chỉ đúng " + _correctedQuestion + "/" + _totalQuestions + ". Maruko buồn lắm!";
                TextBlockMarukoTalk.Text = "Sao thấp vậy trời ơi... Bạn chưa học bài phải không?";
                ImageMarukoTest.Source = new BitmapImage(new Uri("/Assets/UIImages/Maruko/cryloud.png", UriKind.Relative));
            }
            else if (resultMark < 0.7)
            {
                txtTotal.Text = Common.NameOfUser + " làm đúng " + _correctedQuestion + "/" + _totalQuestions + ". Không tốt lắm rùi!";
                TextBlockMarukoTalk.Text = "Khả năng của bạn phải làm được cao hơn chứ...";
                ImageMarukoTest.Source = new BitmapImage(new Uri("/Assets/UIImages/Maruko/dislike.png", UriKind.Relative));
            }
            else if (resultMark < 0.9)
            {
                txtTotal.Text = Common.NameOfUser + " làm đúng " + _correctedQuestion + "/" + _totalQuestions + ". Khá nhưng vẫn còn sai đó!";
                TextBlockMarukoTalk.Text = "Khá rồi! Nhưng chưa ổn lắm đâu. Cố gắng hơn nhé...";
                ImageMarukoTest.Source = new BitmapImage(new Uri("/Assets/UIImages/Maruko/good.png", UriKind.Relative));
            }
            else
            {
                txtTotal.Text = Common.NameOfUser + " làm đúng " + _correctedQuestion + "/" + _totalQuestions + ". Rất tốt!";
                TextBlockMarukoTalk.Text = "Vui quá " + Common.NameOfUser + " ơi. Giữ phong độ này nhé, Moahhh...";
                ImageMarukoTest.Source = new BitmapImage(new Uri("/Assets/UIImages/Maruko/hanhphuc.png", UriKind.Relative));
            }
            SlideEffectTransition();

            BorderWrapTest.Visibility = Visibility.Visible;

        }
        private void ButtonStartTest_OnTap(object sender, GestureEventArgs e)
        {
            Restart();
            SlideEffectTransition();
         
            BorderWrapTest.Visibility = Visibility.Collapsed;
            PivotWordLesson.IsLocked = true;

        }
        private SlideTransition SlideTransitionElement(string mode)
        {
            var slideTransitionMode = (SlideTransitionMode)Enum.Parse(typeof(SlideTransitionMode), mode, false);
            return new SlideTransition { Mode = slideTransitionMode };
        }

        private void Restart()
        {
            ButtonStartTest.Content = "Làm Lại";
            _isQuestionsFinished = false;
            _questionNumber = 0;

            _hasStartedQuestions = false;

            _correctedQuestion = 0;


            _secondsQuestion = 0;

            _totalQuestions = 0;

            txtCorrectImages.Text = "";

            txtTimerImages.Text = "";




            _timerQuestions.Stop();

            
            _currentQuestion = new Question();



            initialize_Questions();

            StartQuestion();
        }
        private void btnAAnswer_OnTap(object sender, GestureEventArgs e)
        {
            CompareAnswers(sender, btnAAnswer.Text);
        }
        private void btnBAnswer_OnTap(object sender, GestureEventArgs e)
        {
            CompareAnswers(sender, btnBAnswer.Text);
        }
        private void btnCAnswer_OnTap(object sender, GestureEventArgs e)
        {
            CompareAnswers(sender, btnCAnswer.Text);
        }
        private void btnDAnswer_OnTap(object sender, GestureEventArgs e)
        {
            CompareAnswers(sender, btnDAnswer.Text);
        }

        private void StartQuestion()
        {
            txtTimerImages.Text = "Thời gian còn lại: " + _currentQuestion.timer;
            _timerQuestions.Start();
            nextQuestion_Images();
            _hasStartedQuestions = true;
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PivotWordLesson.SelectedIndex == 1) // 
            {
                if (!_hasStartedQuestions)
                {
                    StartQuestion();
                }
                else if (!_isQuestionsFinished)
                {
                    ResumeQuestion();
                }
              
            }
            ApplicationBar.IsVisible = !((((Pivot)sender).SelectedIndex) == 1);
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

/*
        private void PronounceWord_Click(object sender, RoutedEventArgs e)
        {
            
        }
*/

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
        private void tu_Click(object sender, RoutedEventArgs e)
        {
            TermQuestion();
        }

        private void nghia_Click(object sender, RoutedEventArgs e)
        {
            MeaningQuestion();
        }
        private void TermQuestion()
        {
            _questions = new List<Question>();
            foreach (var item in _lesson.LessonWords)
            {
                var temList = _lesson.LessonWords.ToList();
                Question question = new Question();
                question.ID = item.ID;
                question.Term = item.TERM;
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

                question.RightAnswer = item.MEANING;
                _questions.Add(question);
                question.timer = 5;

            }
        }
        private void MeaningQuestion()
        {
            _questions = new List<Question>();
            foreach (var item in _lesson.LessonWords)
            {
                var temList = _lesson.LessonWords.ToList();
                Question question = new Question();
                question.ID = item.ID;
                question.Term = item.MEANING;
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
                question.timer = 5;
            }
        }

        private void GridGuideUser_OnTap(object sender, GestureEventArgs e)
        {
            GridGuideUser.Visibility = Visibility.Collapsed;
        }

        private void OnAdReceived(object sender, GoogleAds.AdEventArgs e)
        {

        }

        private void OnFailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }
    }
}