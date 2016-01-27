﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Resources;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class TestWriting : PhoneApplicationPage
    {
        public TestWriting()
        {
            InitializeComponent();
            initialize_Questions();
           
            Loaded += TestWriting_Loaded;
            
        }

        void TestWriting_Loaded(object sender, RoutedEventArgs e)
        {
            txtAnswer.Focus();
            Task.Delay(100).Wait();
             this.StartQuestion();
        }

        private Boolean _isQuestionsFinished = false;

        private Boolean _hasStartedQuestions = false;

        private int _correctedQuestion = 0;

        private int _secondsQuestion = 0;

        private int _totalQuestions = 0;

        private List<int> _rightAnswerIdsList = new List<int>();

        private List<Question> _questions = new List<Question>();
        private List<Question> _saveQuestions = new List<Question>();
        private List<Question> _wrongQuestions = new List<Question>();
        private Question _currentQuestion = new Question();

        private System.Windows.Threading.DispatcherTimer _timerQuestions;


        private void initialize_Questions()
        {

            if (_questions.Count <= 0)
            {
                _questions = PhoneApplicationService.Current.State["question"] as List<Question>;
                //  GenerateQuestions();
            }
            _totalQuestions = _questions.Count;
            txtCorrect.Text = "Đúng: " + _correctedQuestion + "/" + _totalQuestions;
            //TxtTotal.Text = "" + _correctedQuestion + "/" + _totalQuestions;
            _timerQuestions = new System.Windows.Threading.DispatcherTimer();
            _timerQuestions.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 500 Milliseconds
            _timerQuestions.Tick += new EventHandler(timer_Tick_Questions);
        }
        private void initialize_TryAgainQuestions()
        {

            if (_wrongQuestions.Count > 0)
            {
                foreach (var question in _wrongQuestions)
                {
                    question.timer = 50;
                    question.UserAnswer = "";
                }

                _questions = _wrongQuestions;
                //  GenerateQuestions();
            }
            _wrongQuestions = new List<Question>();
            _totalQuestions = _questions.Count;
            txtCorrect.Text = "Đúng: " + _correctedQuestion + "/" + _totalQuestions;
            //TxtTotal.Text = "" + _correctedQuestion + "/" + _totalQuestions;
            _timerQuestions = new System.Windows.Threading.DispatcherTimer();
            _timerQuestions.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 500 Milliseconds
            _timerQuestions.Tick += new EventHandler(timer_Tick_Questions);
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
                if (string.IsNullOrEmpty(_currentQuestion.UserAnswer))
                {
                    _wrongQuestions.Add(_currentQuestion);
                }
                _saveQuestions.Add(_currentQuestion);
                _secondsQuestion = 0;
                if (_questions.Count > 0)
                {
                    _questions.RemoveAt(0);
                    if (_questions.Count > 0)
                    {
                        this.nextQuestion_Images();
                    }
                    else
                    {
                        this.StopQuestion();
                    }
                }
                else
                {
                    this.StopQuestion();
                }
            }
        }
        private void CompareAnswers(object sender, String answer)
        {
            txtQuestionImages.Text = _currentQuestion.Term + "\n" + _currentQuestion.RightAnswer;
            _currentQuestion.UserAnswer = answer;
            if (_currentQuestion.timer <= 1)
            {

                return;
            }
            _timerQuestions.Stop();
            if (answer.Equals(_currentQuestion.Term))
            {
                if (!Common.LearntKanjiIdsList.Contains(_currentQuestion.ID))
                {
                    _rightAnswerIdsList.Add(_currentQuestion.ID);
                }
                _correctedQuestion++;
                txtCorrect.Text = "Đúng: " + _correctedQuestion + "/" + _totalQuestions;

                UiElementHelper.ChangeColorAnswer(brA, ColorHelper.ConvertStringToColor("FFFAF0"), ColorHelper.ConvertStringToColor("F4D03E"));

                _currentQuestion.timer = 2;
                _timerQuestions.Start();


            }
            else
            {
                _wrongQuestions.Add(_currentQuestion);
                _currentQuestion.timer = 2;
                _timerQuestions.Start();
                UiElementHelper.ChangeColorAnswer(brA, ColorHelper.ConvertStringToColor("FFFAF0"), ColorHelper.ConvertStringToColor("F32613"));


            }

        }
        private List<E> ShuffleList<E>(List<E> inputList)
        {
            var randomList = new List<E>();

            var r = new Random();
            while (inputList.Count > 0)
            {
                int randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
       


        private void StartQuestion()
        {
            txtTimerImages.Text = "Thời gian còn lại: " + _currentQuestion.timer;
            _timerQuestions.Start();
            this.nextQuestion_Images();
            _hasStartedQuestions = true;
        }


        private Boolean IsEverythingFinished()
        {
            return _isQuestionsFinished;
        }

        int _questionNumber = 1;

        private void nextQuestion_Images()
        {
            TextBlockQuestionNumber.Text = (_questionNumber++).ToString();
            _questions = ShuffleList<Question>(_questions);
            _currentQuestion = _questions.ElementAt<Question>(0);
            UiElementHelper.ChangeColorAnswer(Term, ColorHelper.ConvertStringToColor("FFFFFF"), ColorHelper.ConvertStringToColor("F4D03E"));
            TextToSpeechHelper.SpeakJapaneseText(_currentQuestion.Term);
            txtQuestionImages.Text = "";
            txtAnswer.Text = "";
            txtTimerImages.Text = "Thời gian còn lại: " + _currentQuestion.timer;


        }

        private void StopQuestion()
        {
            _secondsQuestion = 0;
            _timerQuestions.Stop();
            _isQuestionsFinished = true;

            // PivotWordLesson.SelectedIndex = 1;

            if (this.IsEverythingFinished())
            {
                this.ShowGameFinished();
            }
        }

        private void ShowGameFinished()
        {
            //  ButtonStartTest.Content = "Làm lại";

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
            CustomMessageBox msgBox = new CustomMessageBox();
            var btn2 = "";
            if (_wrongQuestions.Count > 0)
            {
                btn2 = "Làm lại câu sai";
            }
            if (resultMark < 0.5)
            {
                var message = Common.NameOfUser + " chỉ đúng " + _correctedQuestion + "/" + _totalQuestions + ". Maruko buồn lắm!";
                var marukoMessage = "Sao thấp vậy trời ơi... Bạn chưa học bài phải không?";
                msgBox = CustomMessageBox.Show(message, marukoMessage, "/Assets/UIImages/Maruko/cryloud.png", "Kết quả test", "Làm lại", btn2);

            }
            else if (resultMark < 0.7)
            {
                var message = Common.NameOfUser + " làm đúng " + _correctedQuestion + "/" + _totalQuestions + ". Không tốt lắm rùi!";
                var marukoMessage = "Khả năng của bạn phải làm được cao hơn chứ...";
                msgBox = CustomMessageBox.Show(message, marukoMessage, "/Assets/UIImages/Maruko/dislike.png", "Kết quả test", "Làm lại", btn2);

            }
            else if (resultMark < 0.9)
            {
                var message = Common.NameOfUser + " làm đúng " + _correctedQuestion + "/" + _totalQuestions + ". Khá nhưng vẫn còn sai đó!";
                var marukoMessage = "Khá rồi! Nhưng chưa ổn lắm đâu. Cố gắng hơn nhé...";
                msgBox = CustomMessageBox.Show(message, marukoMessage, "/Assets/UIImages/Maruko/good.png", "Kết quả test", "Làm lại", btn2);

            }
            else
            {
                var message = Common.NameOfUser + " làm đúng " + _correctedQuestion + "/" + _totalQuestions + ". Rất tốt!";
                var marukoMessage = "Vui quá " + Common.NameOfUser + " ơi. Giữ phong độ này nhé, Moahhh...";
                msgBox = CustomMessageBox.Show(message, marukoMessage, "/Assets/UIImages/Maruko/hanhphuc.png", "Kết quả test", "Làm lại", btn2);

            }
            msgBox.Closed += msgBox_Closed;
        }

        void msgBox_Closed(object sender, MessageBoxEventArgs e)
        {
            if (e.Result.ToString() == "6")
            {
                Restart();
                _wrongQuestions = _saveQuestions;
                _saveQuestions = new List<Question>();
                initialize_TryAgainQuestions();
                this.StartQuestion();
            }
            if (e.Result.ToString() == "7")
            {
                Restart();
                _saveQuestions = new List<Question>();
                initialize_TryAgainQuestions();
                this.StartQuestion();
            }

        }
        private void Restart()
        {
            _isQuestionsFinished = false;
            _questionNumber = 1;

            _hasStartedQuestions = false;

            _correctedQuestion = 0;

            _secondsQuestion = 0;

            _totalQuestions = 0;

            txtCorrect.Text = "";

            txtTimerImages.Text = "";

            _timerQuestions.Stop();
            txtAnswer.Focus();
            _currentQuestion = new Question();

          
        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (!_isQuestionsFinished)
            {
                _timerQuestions.Stop();
                if (MessageBox.Show("Bạn muốn dừng kiểm tra à?", "Kết thúc test?", MessageBoxButton.OKCancel) !=
                    MessageBoxResult.Cancel)
                {
                    return;
                }

                e.Cancel = true;
                _timerQuestions.Start();
                base.OnBackKeyPress(e);
            }


        }

        private void txtAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                this.CompareAnswers(sender, txtAnswer.Text);
                txtAnswer.Focus();
            }
        }

        private void btnTerm_OnTap(object sender, GestureEventArgs e)
        {
            txtAnswer.Focus();
            UiElementHelper.ChangeColorAnswer(Term, ColorHelper.ConvertStringToColor("FFFFFF"), ColorHelper.ConvertStringToColor("F4D03E"));
            TextToSpeechHelper.SpeakJapaneseText(_currentQuestion.Term);
            
        }
    }
}