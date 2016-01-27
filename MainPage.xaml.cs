using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            InitializeApplicationBar();

            PanoramaMainPage.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"/Assets/UIImages/PanoramaBackground.png", UriKind.Relative)),
            };

            Loaded += MainPage_Loaded;

            FeedbackOverlayRate.VisibilityChanged += FeedbackOverlayRate_VisibilityChanged;
        }

        private void FeedbackOverlayRate_VisibilityChanged(object sender, EventArgs e)
        {
            if (ApplicationBar != null)
            {
                ApplicationBar.IsVisible = (FeedbackOverlayRate.Visibility != Visibility.Visible);
            }
        }

        private void InitializeApplicationBar()
        {
            ApplicationBar = new ApplicationBar
            {
                Mode = ApplicationBarMode.Minimized,
                Opacity = 0.8,
                IsVisible = true,
                IsMenuEnabled = true,
                BackgroundColor = ColorHelper.ConvertStringToColor("#009DC2")
            };

            var menuItemSettings = new ApplicationBarMenuItem
            {
                Text = "Cài đặt"
            };
            
            var menuItemAbout = new ApplicationBarMenuItem
            {
                Text = "Thông tin"
            };
            ApplicationBar.MenuItems.Add(menuItemSettings);
            ApplicationBar.MenuItems.Add(menuItemAbout);

            menuItemSettings.Click += menuItemSettings_Click;
            menuItemAbout.Click += (s, e) => NavigationService.Navigate(new Uri("/View/About.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ra khỏi đây à?", Common.NameOfUser + " ơi...", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                return;
            }

            e.Cancel = true;

            base.OnBackKeyPress(e);
        }

        void menuItemSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SettingsPage.xaml", UriKind.Relative));
        }

        void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }

        private void HubTileWords_OnTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/WordSection/LessonListView.xaml", UriKind.Relative));
        }

        private void HubTileGrammar_OnTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/GrammarSection/GrammarList.xaml", UriKind.Relative));
        }

        private void HubTileAlphabet_OnTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AlphabetSection/FuriganaList.xaml", UriKind.Relative));

        }

        private void HubTileKanji_OnTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/KanjiSection/KanjisListView.xaml", UriKind.Relative));
        }
        private void HubTileHangman_OnTap(object sender, GestureEventArgs e)
        {
            if (MessageBox.Show("Vẫn chưa ổn, chờ bản cập nhật nhé.") == MessageBoxResult.OK)
                return;
            
            NavigationService.Navigate(new Uri("/View/HangmanGame/GamePage.xaml", UriKind.Relative));
        }
      

        private void HubTileMusic_OnTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Music.xaml", UriKind.Relative));
        }
        private void HubTileTest_OnTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/TestSection/MainTest.xaml", UriKind.Relative));
        }
    }
}