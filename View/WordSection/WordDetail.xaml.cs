using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View.WordSection
{
    public partial class WordDetail : PhoneApplicationPage
    {
        Lesson _lesson = new Lesson();
        private int _currentWord = 0;
        public WordDetail()
        {
            InitializeComponent();

            Loaded += WordDetail_Loaded;
        }

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

            DataContext = _lesson.LessonWords[0];
        }

        void WordDetail_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlockNumberOfWords.Text = _currentWord + 1 + "/" + _lesson.LessonWords.Count + string.Empty;
        }

        private void ButtonPrevWord_OnTap(object sender, GestureEventArgs e)
        {
            StoryboardPrevWord.Begin();
            if (_currentWord > 0)
            {
                DataContext = _lesson.LessonWords[--_currentWord];
                TextBlockNumberOfWords.Text = _currentWord + 1 + "/" + _lesson.LessonWords.Count + string.Empty;
            }
        }

        private void ButtonPlayWord_OnTap(object sender, GestureEventArgs e)
        {
            StoryboardPronounce.Begin();
            var vocabularydb = DataContext as VOCABULARYDB;
            if (vocabularydb != null)
            {
                string wordTerm = vocabularydb.TERM;

                TextToSpeechHelper.SpeakJapaneseText(wordTerm);
            }
        }

        private void ButtonNextWord_OnTap(object sender, GestureEventArgs e)
        {
            StoryboardNextWord.Begin();
            if (_currentWord < _lesson.LessonWords.Count - 1)
            {
                DataContext = _lesson.LessonWords[++_currentWord];
                TextBlockNumberOfWords.Text = _currentWord + 1 + "/" + _lesson.LessonWords.Count;
            }
        }

        private void GridCard_OnTap(object sender, GestureEventArgs e)
        {
            if (TextBlockWordTerm.Visibility == Visibility.Collapsed)
            {
                StoryboardFlipCard.Begin();
                StoryboardFlipCard.Completed += (o, args) =>
                {
                    TextBlockWordTerm.Visibility = Visibility.Visible;
                    TextBlockWordMeaning.Visibility = Visibility.Collapsed;
                };
            }
            else
            {
                StoryboardFlipCard.Begin();
                StoryboardFlipCard.Completed += (o, args) =>
                {
                    TextBlockWordTerm.Visibility = Visibility.Collapsed;
                    TextBlockWordMeaning.Visibility = Visibility.Visible;
                };
            }
        }

        private void GestureListener_OnFlick(object sender, FlickGestureEventArgs e)
        {
            if (e.Direction != System.Windows.Controls.Orientation.Horizontal) return;
            if (e.HorizontalVelocity < 0)
            {
                ButtonNextWord_OnTap(sender, null);
                return;
            }

            if (e.HorizontalVelocity > 0)
            {
                ButtonPrevWord_OnTap(sender, null);
            }
        }
    }
}