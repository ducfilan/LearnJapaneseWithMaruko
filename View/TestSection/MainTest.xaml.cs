using System;
using System.Collections.Generic;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Hoc_tieng_Nhat_cung_Maruko.View.TestSection
{
    public partial class MainTest : PhoneApplicationPage
    {
        public MainTest()
        {
            InitializeComponent();
        }

        private List<Question> _questions = new List<Question>();

        private void GenerateQuestions()
        {
            _questions = new List<Question>();

            var getExamCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM EXAMDB WHERE LESSON <= " + Common.CurrentWordLesson + " LIMIT 30"
            };

            var exam = getExamCommand.ExecuteQuery<EXAMDB>();

            foreach (var item in exam)
            {
                var question = new Question
                {
                    ID = item.ID,
                    Term = item.QUESTION,
                    AnswerA = item.ANSWERA,
                    AnswerB = item.ANSWERB,
                    AnswerC = item.ANSWERC,
                    AnswerD = item.ANSWERD
                };

                switch (item.CORRECT)
                {
                    case "1":
                        question.RightAnswer = item.ANSWERA;
                        break;
                    case "2":
                        question.RightAnswer = item.ANSWERB;
                        break;
                    case "3":
                        question.RightAnswer = item.ANSWERC;
                        break;
                    default:
                        question.RightAnswer = item.ANSWERD;
                        break;
                }
                question.timer = 50;
                _questions.Add(question);
            }
        }
        private void initialize_Questions()
        {
            if (_questions.Count <= 0)
            {
                GenerateQuestions();
            }
        }

        private void ButtonStartTest_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            initialize_Questions();
            PhoneApplicationService.Current.State["question"] = _questions;
            NavigationService.Navigate(new Uri("/View/TestSection/TestMultiChoice.xaml", UriKind.Relative));
        }
    }
}
