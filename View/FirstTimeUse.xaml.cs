using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Alphabet;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;
using Hoc_tieng_Nhat_cung_Maruko.Model.Grammar;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Tasks;
using Reminder = Microsoft.Phone.Scheduler.Reminder;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class FirstTimeUse : PhoneApplicationPage
    {
        private DateTime? _tempUserDob;
        private int _tempMinnaLevel = -1;
        AppSettings appSettings = new AppSettings();
        readonly PhotoChooserTask _photoChooserTask = new PhotoChooserTask();
        public FirstTimeUse()
        {
            InitializeComponent();
            Loaded += FirstTimeUse_Loaded;
        }

        void FirstTimeUse_Loaded(object sender, RoutedEventArgs e)
        {
            SetPhotoChooserProps();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ra khỏi đây à?", "Còn chưa làm quen xong mà?", MessageBoxButton.OKCancel) != MessageBoxResult.Cancel)
            {
                return;
            }

            e.Cancel = true;

            base.OnBackKeyPress(e);
        }

        private void SetPhotoChooserProps()
        {
            _photoChooserTask.PixelHeight = 120;
            _photoChooserTask.PixelWidth = 120;
            _photoChooserTask.ShowCamera = true;
            _photoChooserTask.Completed += PhotoChooserTask_Completed;
        }

        private void PhotoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK) return;

            SaveSetUserAvatar(e.ChosenPhoto);
        }

        private void SaveSetUserAvatar(Stream streamChosenImage)
        {
            var bmpChosenPhoto = new BitmapImage();
            bmpChosenPhoto.SetSource(streamChosenImage);

            SaveBmpToIsolatedStorageHelper.SaveImage(streamChosenImage, "UserAvatar.jpg", 0, 100);

            Common.AvatarOfUser = "UserAvatar.jpg";

            ImageUserAvatar.ImageSource = bmpChosenPhoto;
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            _photoChooserTask.Show();
        }

        private void NavigateToItem(PivotItem item, string backgroundColor)
        {
            PivotIntroduction.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor(backgroundColor));
            PivotIntroduction.SelectedItem = item;
        }

        private void ButtonNextFromAvatarSelecting_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToItem(PivotItemNameOfUser, "#F2774B");
        }

        private void ButtonNextFromNameAsking_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToItem(PivotItemDobOfUser, "#2DCC70");
            if (TextBoxNameOfUser.Text.Trim() == string.Empty) return;

            Common.NameOfUser = TextBoxNameOfUser.Text;
        }

        private void ButtonNextFromMarukoIntroducing_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToItem(PivotItemAvatar, "#23A7F1");
        }

        private void PivotIntroduction_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PivotIntroduction.SelectedItem == PivotItemMarukoIntro)
            {
                PivotIntroduction.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("#9A12B4"));
            }
            else if (PivotIntroduction.SelectedItem == PivotItemAvatar)
            {
                PivotIntroduction.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("#23A7F1"));
            }
            else if (PivotIntroduction.SelectedItem == PivotItemNameOfUser)
            {
                PivotIntroduction.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("#F2774B"));
            }
            else if (PivotIntroduction.SelectedItem == PivotItemDobOfUser)
            {
                PivotIntroduction.Background = new SolidColorBrush(ColorHelper.ConvertStringToColor("#F4B251"));
            }
        }

        private void DatePickerUserDob_OnValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            _tempUserDob = Common.DobOfUser = e.NewDateTime;
        }

        private void ButtonNextFromMinnaLevelAsing_OnClick(object sender, RoutedEventArgs e)
        {
            //if (appSettings.GetValueOrDefault<string>(AppSettings.UserAvatarSettingKeyName, null) == null)
            //{
            //    NavigateToItem(PivotItemAvatar, "#23A7F1");
            //    return;
            //}

            if (!int.TryParse(TextBoxMinnaLevelOfUser.Text, out _tempMinnaLevel))
            {
                NavigateToItem(PivotItemMinnaLevelOfUser, "#23A7F1");
                TextBlockMinnaLevelAsking.Text = "Uii. Bạn nhập số bài vào chứ :( VD: 18";
                TextBlockMinnaLevelAsking.Foreground = new SolidColorBrush(ColorHelper.ConvertStringToColor("#FE0000"));
                MessageBox.Show("Bạn ơi, phải nhập số bài vào :( Chưa học thì bạn nhập 1 nhé.", "Nhập sai rồi", MessageBoxButton.OK);
                return;
            }

            Common.NoOfTotalLessons = 50; //TODO

            if (_tempMinnaLevel > Common.NoOfTotalLessons
                || _tempMinnaLevel <= 0)
            {
                TextBlockMinnaLevelAsking.Text = "Uii. Tớ chỉ dạy từ bài 1 đến bài " + Common.NoOfTotalLessons + " thôi nhé :(";
                TextBlockMinnaLevelAsking.Foreground = new SolidColorBrush(ColorHelper.ConvertStringToColor("#FE0000"));
                MessageBox.Show("Uii. Tớ chỉ dạy từ bài 1 đến bài " + Common.NoOfTotalLessons + " thôi nhé :(", "Quá bài rồi", MessageBoxButton.OK);
                _tempMinnaLevel = 1;
            }

            if (appSettings.GetValueOrDefault<string>(AppSettings.UserNameSettingKeyName, null) == null)
            {
                NavigateToItem(PivotItemNameOfUser, "#F2774B");
                TextBlockNameAsking.Text = "Uii. Sao bạn không cho mình biết tên vậy? :(";
                return;
            }

            if (appSettings.GetValueOrDefault(AppSettings.UserDobSettingKeyName, DateTime.Today).Year > 2010)
            {
                NavigateToItem(PivotItemDobOfUser, "#2DCC70");
                TextBlockDobAsking.Text = "Uii. Bạn kiểm tra lại ngày sinh kìa. Bị sai đó :P";
                return;
            }

            SetBirthdayAlarm();

            Common.CurrentWordLesson = _tempMinnaLevel;
            appSettings.AddOrUpdateValue(AppSettings.IsFirstTimeSettingKeyName, "yes");
            appSettings.Save();
            NavigationService.Navigate(new Uri("/View/SplashPage.xaml", UriKind.Relative));
        }

        private void SetBirthdayAlarm()
        {
            if (_tempUserDob == null) return;

            if (ScheduledActionService.Find("BirthdayAlarm") != null)
            {
                ScheduledActionService.Remove("BirthdayAlarm");
            }

            var birthday = Common.DobOfUser;
            var nowDateTime = DateTime.Now;
            if (birthday == null) return;
            var birthdayOfCurrentYear = new DateTime(nowDateTime.Year, birthday.Value.Month, birthday.Value.Day);
            int alarmYear = birthdayOfCurrentYear.Year;

            if (birthdayOfCurrentYear < DateTime.Now)
            {
                alarmYear++;
            }

            var reminder = new Reminder("BirthdayAlarm")
            {
                Title = "Reng reng...",
                Content = "Chúc mừng sinh nhật " + Common.NameOfUser + " nhé... Chạm vào đây để nhận quà sinh nhật của Maruko nhé.",
                BeginTime = new DateTime(alarmYear, birthdayOfCurrentYear.Month, birthdayOfCurrentYear.Day, 7, 0, 0),
                ExpirationTime = new DateTime(alarmYear, birthdayOfCurrentYear.Month, birthdayOfCurrentYear.Day, 23, 59, 59),
                RecurrenceType = RecurrenceInterval.Yearly,
                NavigationUri = new Uri("/View/BirthdayPage.xaml", UriKind.Relative)
            };

            // Register the reminder with the system.
            ScheduledActionService.Add(reminder);
        }

        private void ButtonNextFromDobAsking_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToItem(PivotItemMinnaLevelOfUser, "#F2774B");
        }
    }
}