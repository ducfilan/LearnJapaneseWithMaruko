using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using ImageTools.IO.Gif;
using ImageTools;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class SplashPage
    {
        BackgroundWorker _bgCopyFile = new BackgroundWorker();

        public SplashPage()
        {
            InitializeComponent();

            _bgCopyFile.DoWork += _bgCopyFile_DoWork;
            _bgCopyFile.RunWorkerCompleted += _bgCopyFile_RunWorkerCompleted;

            Loaded += SplashPagexaml_Loaded;
        }

        void _bgCopyFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CalculateAdditionNumbers();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        void _bgCopyFile_DoWork(object sender, DoWorkEventArgs e)
        {
            AddFileToIsolatedStorageHelper.CopyFileToIsolatedStorage("Assets/Maruko.db3", "Maruko.db3");
            AddFileToIsolatedStorageHelper.CopyFileToIsolatedStorage("Assets/MarukoDict.db3", "MarukoDict.db3");
        }

        public void DispatchInvoke(Action a)
        {
            if (Dispatcher == null)
                a();
            else
                Dispatcher.BeginInvoke(a);
        }

        private void ShowLoadingIcon()
        {
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();

            ImageToolName.Source = new ExtendedImage { UriSource = new Uri("loading_animation.gif", UriKind.Relative) };
            //Local animated gif image binding with ImageTools

            DataContext = this;
            ImageToolName.Start();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ra khỏi đây à?", "Vừa mới làm quen xong mà?", MessageBoxButton.OKCancel) != MessageBoxResult.Cancel)
            {
                return;
            }

            e.Cancel = true;

            base.OnBackKeyPress(e);
        }

        private static void CalculateAdditionNumbers()
        {
            var cmd = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"));

            //Total lesson
            if (Common.NoOfTotalLessons == 1)
            {
                cmd.CommandText = @"SELECT COUNT(DISTINCT(LESSON)) AS NUM FROM VOCABULARYDB";

                Common.NoOfTotalLessons = cmd.ExecuteQuery<NumberCount>().First().NUM;

            }

            //Total Grammars
            if (Common.NoOfTotalGrammars == 1)
            {
                cmd.CommandText = @"SELECT COUNT(DISTINCT(LESSON)) AS NUM FROM GRAMMARSDB";

                Common.NoOfTotalGrammars = cmd.ExecuteQuery<NumberCount>().First().NUM;
            }

            //Collect neccessary numbers
            if (Common.NoOfTotalKanjis == 0)
            {
                cmd.CommandText = @"SELECT COUNT(ID) AS NUM FROM KANJIDICTDB";

                Common.NoOfTotalKanjis = cmd.ExecuteQuery<NumberCount>().First().NUM;
            }

            if (Common.NoOfTotalWords == 0)
            {
                cmd.CommandText = @"SELECT COUNT(ID) AS NUM FROM VOCABULARYDB";

                Common.NoOfTotalWords = cmd.ExecuteQuery<NumberCount>().First().NUM;
            }
        }

        void SplashPagexaml_Loaded(object sender, RoutedEventArgs e)
        {
            ShowLoadingIcon();

            var tips = new[]
            {
                "Để học tốt tiếng Nhật bạn phải thật chăm chỉ đó!",
                "Chữ Hán là cực kì quan trọng nếu bạn muốn đọc tài liệu tiếng Nhật!",
                "Hãy học từ mới mỗi ngày!",
                "Luyện nói hằng ngày để nâng cao phản xạ trong hội thoại nhé!",
                "Không cần học nhiều 1 lần, hãy duy trì đều đặn việc học sẽ có hiệu quả hơn đó bạn!"
            };

            TextBlockTips.Text = tips[new Random().Next(tips.Count())];

            NavigationService.RemoveBackEntry();

            _bgCopyFile.RunWorkerAsync();
        }
    }

    public class NumberCount
    {
        public int NUM { get; set; }
    }
}