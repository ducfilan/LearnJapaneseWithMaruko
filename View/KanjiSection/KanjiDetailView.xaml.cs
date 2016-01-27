using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View.KanjiSection
{
    public partial class KanjiDetailView : PhoneApplicationPage
    {


        KANJIDICTDB _currentKanji;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string kanjiTerm;

            if (NavigationContext.QueryString.TryGetValue("KanjiTerm", out kanjiTerm))
            {
                var getKanjiCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
                {
                    CommandText = "SELECT * FROM KANJIDICTDB WHERE TERM = '" + kanjiTerm + "'"
                };

                DataContext = _currentKanji = getKanjiCommand.ExecuteQuery<KANJIDICTDB>().First();
            }
        }

        public KanjiDetailView()
        {
            InitializeComponent();
            Loaded += KanjiDetailView_Loaded;

        }
        //preXArray and preYArray are used to store the start point 
        //for each touch point. currently silverlight support 4 muliti-touch
        //here declare as 10 points for further needs. 
        double[] preXArray = new double[10];
        double[] preYArray = new double[10];

        /// <summary>
        /// Every touch action will rise this event handler. 
        /// </summary>
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(drawCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(drawCanvas);

            for (int i = 0; i < pointsNumber; i++)
            {
                if (pointCollection[i].Action == TouchAction.Down)
                {
                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
                if (pointCollection[i].Action == TouchAction.Move)
                {
                    var line = new Line
                    {
                        X1 = preXArray[i],
                        Y1 = preYArray[i],
                        X2 = pointCollection[i].Position.X,
                        Y2 = pointCollection[i].Position.Y,
                        Stroke = new SolidColorBrush(Colors.Purple),
                        StrokeThickness = 10,
                        StrokeStartLineCap = PenLineCap.Round,
                        StrokeEndLineCap = PenLineCap.Round,
                        Fill = new SolidColorBrush(Colors.Black)
                    };

                    drawCanvas.Children.Add(line);

                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
            }
        }

        void KanjiDetailView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private IEnumerable<string> ParsePathDataToPathList(string pathData)
        {
            return pathData.Split('§').ToList();
        }

        private void GridDrawing_OnTap(object sender, GestureEventArgs e)
        {
            //if (!PivotWordLesson.IsLocked)
            //{
            //    Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
            //    ButtonAddToLearningKanji.Content = "xóa";
            //    ButtonMarkAsMasteredKanji.Content = "trở về";
            //    PivotWordLesson.IsLocked = true;
            //}
            int pathOpacityBeginTime = 0;
            foreach (string pathData in ParsePathDataToPathList(_currentKanji.PATHDATA))
            {
                var path = new Path()
                {
                    Data = new StringToPathGeometryConverter().Convert(pathData),
                    Stroke = new SolidColorBrush(ColorHelper.ConvertStringToColor("#213140")),
                    StrokeThickness = 4,
                    Opacity = 0,
                    Margin = new Thickness(100, 80, 90, 90),
                    RenderTransform = new ScaleTransform()
                    {
                        ScaleX = 2.3,
                        ScaleY = 2.3
                    }
                };

                GridDrawing.Children.Add(path);
                AnimationHelper.Instance.OpacityAnimation(path, 0, 1, 2, pathOpacityBeginTime);
                AnimationHelper.Instance.StartAnimation();
                pathOpacityBeginTime += 2;
            }
        }

        private void ShareKanjiButton_OnClick(object sender, EventArgs e)
        {
            var shareStatusTask = new ShareLinkTask
            {
                Message = "Học tiếng Nhật cùng Maruko",
                Title = "Mình vừa mới học từ: " + _currentKanji.TERM + " từ phần mềm: Học tiếng nhật cùng Maruko",
                LinkUri = new Uri("http://www.windowsphone.com/s?appid=9733b6da-727e-412a-a1d4-48e9fc64990c", UriKind.Absolute)
            };

            shareStatusTask.Show();
        }

        private void ButtonAddToLearningKanji_OnTap(object sender, GestureEventArgs e)
        {
            if (Common.CurrentLearningKanjisList == null)
            {
                Common.CurrentLearningKanjisList = new HashSet<KANJIDICTDB>();
            }

            Common.CurrentLearningKanjisList.Add(_currentKanji);
            MessageBox.Show("Đã thêm vào danh sách đang học rồi " + Common.NameOfUser + " nhé!", "Xong rồiii", MessageBoxButton.OK);
        }

        private void ButtonMarkAsMasteredKanji_OnTap(object sender, GestureEventArgs e)
        {
            if (Common.LearntKanjiIdsList.Contains(_currentKanji.ID)) return;

            var tempLearntKanjiIdsList = Common.LearntKanjiIdsList;
            tempLearntKanjiIdsList.Add(_currentKanji.ID);
            Common.LearntKanjiIdsList = tempLearntKanjiIdsList;

            MessageBox.Show("Maruko biết là " + Common.NameOfUser + " thuộc rồi nhé!", "Xong rồiii", MessageBoxButton.OK);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {

            if (PivotWordLesson.IsLocked)
            {
                drawCanvas.Children.Clear();
                PivotWordLesson.IsLocked = false;
                Touch.FrameReported -= new TouchFrameEventHandler(Touch_FrameReported);
                ButtonAddToLearningKanji.Content = "thêm từ này để học";
                ButtonMarkAsMasteredKanji.Content = "đánh dấu đã thuộc";
                e.Cancel = false;
                base.OnBackKeyPress(e);
            }

        }
    }
}