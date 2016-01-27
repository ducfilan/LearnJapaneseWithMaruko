using System;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Microsoft.Phone.Tasks;

namespace Hoc_tieng_Nhat_cung_Maruko.View.UserControls
{
    public partial class Friendship : UserControl
    {
        readonly PhotoChooserTask _photoChooserTask = new PhotoChooserTask();
        public Friendship()
        {
            InitializeComponent();
            Loaded+=Friendship_Loaded;
        }

        private void Friendship_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            StoryboardGreetingMaruko.Begin();
            LoadUserDataToUi();
        }

        private void LoadUserDataToUi()
        {
            LoadUserAvatar();
            LoadUserName();
            LoadCurrentLearningStatus();
        }

        private void LoadCurrentLearningStatus()
        {
            TextBlockCurrentLesson.Text = Common.CurrentWordLesson + "";
            TextBlockLearntKanjis.Text = Common.LearntKanjiIdsList.Count + "";
            TextBlockLeartWords.Text = Common.LearntWordIdsList.Count + "";
            TextBoxUserStataus.Text = Common.StatusOfUser + "";

            LoadLearningProgressBars();
        }

        private void LoadLearningProgressBars()
        {
            ProgressCurrentLesson.Width = ProgresNoOfsAllLesson.RenderSize.Width * Common.CurrentWordLesson / Common.NoOfTotalLessons;
            ProgressLearntKanjis.Width = ProgressNoOfAllKanjis.RenderSize.Width * Common.LearntKanjiIdsList.Count/ Common.NoOfTotalKanjis;
        }

        private void LoadUserName()
        {
            TextBlockNameOfUser.Text = Common.NameOfUser;
        }

        private void LoadUserAvatar()
        {
            var bmpDefaultAvatar = new BitmapImage(new Uri("/Assets/UIImages/default avatar.jpg", UriKind.Relative));

            if (!System.ComponentModel.DesignerProperties.IsInDesignTool)
            {
                using (var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (Common.AvatarOfUser != null)
                    {
                        using (var fileStream = myIsolatedStorage.OpenFile(Common.AvatarOfUser, FileMode.Open, FileAccess.Read))
                        {
                            bmpDefaultAvatar.SetSource(fileStream);
                        }
                    }
                }
            }

            ImageUserAvatar.ImageSource = bmpDefaultAvatar;
        }

        private void GridAvatar_OnTap(object sender, GestureEventArgs e)
        {

        }

        private void TextBoxUserStataus_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            Common.StatusOfUser = TextBoxUserStataus.Text;
        }

        private void ShareStatusButton_OnTap(object sender, GestureEventArgs e)
        {
            ShareHelper.ShareStatus(TextBoxUserStataus.Text);
        }

        private void Grid_Tap(object sender, GestureEventArgs e)
        {
            (System.Windows.Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame).Navigate(new Uri("/View/Chart.xaml", UriKind.Relative));

        }
    }
}
