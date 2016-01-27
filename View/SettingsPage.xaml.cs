using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Media.Imaging;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Alphabet;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Hoc_tieng_Nhat_cung_Maruko.View.UserControls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;
using Reminder = Microsoft.Phone.Scheduler.Reminder;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class SettingsPage
    {
        private DateTime? _tempUserDob;
        private DateTime? _tempLearningAlarmDateTime;
        private Stream _tempUserAvatarStream;

        PhotoChooserTask _photoChooserTask = new PhotoChooserTask();
        AppSettings _appSettings = new AppSettings();
        public SettingsPage()
        {
            InitializeComponent();

            InitializePhotoChooser();

            LoadSavedValues();
        }

        private void LoadSavedValues()
        {
            TextBoxName.Text = Common.NameOfUser;
            DatePickerDob.Value = Common.DobOfUser;
            TimePickerAlarm.Value = Common.AlarmOfUser;
            ListPickerLevel.SelectedItem = "Trình độ N" + Common.JlptLevel;

            LoadSavedUserAvatar();
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
                BeginTime =      new DateTime(alarmYear, birthdayOfCurrentYear.Month, birthdayOfCurrentYear.Day, 7, 0, 0),
                ExpirationTime = new DateTime(alarmYear, birthdayOfCurrentYear.Month, birthdayOfCurrentYear.Day, 23, 59, 59),
                RecurrenceType = RecurrenceInterval.Yearly,
                NavigationUri = new Uri("/View/BirthdayPage.xaml", UriKind.Relative)
            };

            // Register the reminder with the system.
            ScheduledActionService.Add(reminder);
        }

        private void SetLearningAlarm(bool? isAlarmEnable)
        {
            if (_tempLearningAlarmDateTime == null || isAlarmEnable != true) return;

            if (ScheduledActionService.Find("TimeToLearnJapanese") != null)
            {
                ScheduledActionService.Remove("TimeToLearnJapanese");
            }

            var nowDateTime = DateTime.Now;
            int alarmDay = _tempLearningAlarmDateTime < nowDateTime ? nowDateTime.Day + 1 : nowDateTime.Day;

            var reminder = new Reminder("TimeToLearnJapanese")
            {
                Title = "Reng reng...",
                Content = "Đến giờ học tiếng Nhật rồi " + Common.NameOfUser + " ơi...",
                BeginTime = new DateTime(nowDateTime.Year, nowDateTime.Month, alarmDay, _tempLearningAlarmDateTime.Value.Hour, _tempLearningAlarmDateTime.Value.Minute, 0),
                ExpirationTime = new DateTime(nowDateTime.Year, nowDateTime.Month, alarmDay, _tempLearningAlarmDateTime.Value.Hour + 2, _tempLearningAlarmDateTime.Value.Minute, 0),
                RecurrenceType = RecurrenceInterval.Daily,
                NavigationUri = new Uri("/View/SplashPage.xaml", UriKind.Relative)
            };

            ScheduledActionService.Add(reminder);
            string minute = _tempLearningAlarmDateTime.Value.Minute < 10
                ? "0" + _tempLearningAlarmDateTime.Value.Minute
                : _tempLearningAlarmDateTime.Value.Minute + "";
            MessageBox.Show(
                "Đến " + _tempLearningAlarmDateTime.Value.Hour + ":" + minute +
                " hàng ngày Maruko sẽ nhắc bạn học bài", "Maruko nhớ rồi...", MessageBoxButton.OK);
        }

        private void InitializePhotoChooser()
        {
            _photoChooserTask.PixelHeight = 120;
            _photoChooserTask.PixelWidth = 120;
            _photoChooserTask.ShowCamera = true;
            _photoChooserTask.Completed += PhotoChooserTask_Completed;
        }

        private void LoadSavedUserAvatar()
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

            ImageUserAvatarSettingPage.ImageSource = bmpDefaultAvatar;
        }

        private void GridAvatar_OnTap(object sender, GestureEventArgs e)
        {
            _photoChooserTask.Show();
        }

        private void PhotoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK) return;
            _tempUserAvatarStream = e.ChosenPhoto;
            SetTempUserAvatar(e.ChosenPhoto);
        }

        private void SetTempUserAvatar(Stream chosenPhotoStream)
        {
            var bmpChosenPhoto = new BitmapImage();
            if (_tempUserAvatarStream != null)
            {
                bmpChosenPhoto.SetSource(chosenPhotoStream);
            }
            ImageUserAvatarSettingPage.ImageSource = bmpChosenPhoto;
        }

        private void SaveUserAvatar(Stream streamChosenImage)
        {
            if (streamChosenImage == null) return;
            SaveBmpToIsolatedStorageHelper.SaveImage(streamChosenImage, "UserAvatar.jpg", 0, 100);
            Common.AvatarOfUser = "UserAvatar.jpg";
        }

        private void ButtonDeleteStudyData_OnTap(object sender, GestureEventArgs e)
        {
            if (
                MessageBox.Show("Nè. Bạn có chắc muốn xóa dữ liệu học tập không đó?", "Xác nhận xóa",
                    MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

            Common.CurrentWordLesson = 1;
            Common.LearntWordIdsList = Common.LearntKanjiIdsList = Common.LearntWordIdsList = new List<int>();
            Common.CurrentLearningHiraganaList = new List<HIRAGANASDB>();
            Common.CurrentLearningKanjisList = new HashSet<KANJIDICTDB>();
            Common.CurrentLearningKatakanaList = new List<KATAKANASDB>();
            Common.IsFirstTimeAccessWordList = 1;
            Common.IsFirstTimeAccessDictionaryDetail = 1;
        }

        private void ButtonSave_OnTap(object sender, GestureEventArgs e)
        {
            MessageBox.Show("Maruko nhớ hết thông tin bạn thay đổi rồi nhé!", "Giỏi không " + Common.NameOfUser + "?", MessageBoxButton.OK);
            NavigationService.GoBack();

            SaveInfo();

            SetLearningAlarm(ToggleSwitchAlarm.IsChecked);
            SetBirthdayAlarm();
        }

        private void SaveInfo()
        {
            Common.NameOfUser = TextBoxName.Text;
            Common.DobOfUser = _tempUserDob;
            Common.AlarmOfUser = _tempLearningAlarmDateTime;
            SaveUserAvatar(_tempUserAvatarStream);
            Common.JlptLevel = int.Parse(ListPickerLevel.SelectedItem.ToString().Remove(0, "Trình độ N".Length));
        }

        private void DatePickerDob_OnValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            _tempUserDob = e.NewDateTime;
        }

        private void ButtonLoveAgain_OnTap(object sender, GestureEventArgs e)
        {
            if (MessageBox.Show("Chúng ta lại làm quen từ đầu nhé?", "Quen lại từ đầu", MessageBoxButton.OKCancel) ==
                MessageBoxResult.Cancel)
                return;

            _appSettings.AddOrUpdateValue(AppSettings.IsFirstTimeSettingKeyName, "no");
            _appSettings.Save();

            MessageBox.Show("Quay về nơi lần đầu ta gặp nhau nhé. Hãy khởi động lại chương trình!", "Quen lại từ đầu", MessageBoxButton.OK);
        }

        private void TimePickerAlarm_OnValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            if (e.NewDateTime != null)
            {
                _tempLearningAlarmDateTime = e.NewDateTime;
            }
        }

        private void ButtonDeleteChatHistory_OnTap(object sender, GestureEventArgs e)
        {
            if (MessageBox.Show("Maruko xóa hết tin nhắn ha?", "Chắc chắn chưa " + Common.NameOfUser + "?", MessageBoxButton.OKCancel) ==
                MessageBoxResult.Cancel)
                return;

            var isf = IsolatedStorageFile.GetUserStoreForApplication();

            if (!isf.FileExists("conversationBotUser.xml")) return;
            isf.DeleteFile("conversationBotUser.xml");
            Conversation.Messages = null;
            Conversation.Messages = new ObservableCollection<ConversationViewMessage>();
        }
    }
}