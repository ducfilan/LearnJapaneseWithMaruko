﻿#pragma checksum "D:\DATA\Documents\Visual Studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\SettingsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "98AB5CA82465B5FCB0A0B2BDA047A8C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Hoc_tieng_Nhat_cung_Maruko.View {
    
    
    public partial class SettingsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid GridAvatar;
        
        internal System.Windows.Media.ImageBrush ImageUserAvatarSettingPage;
        
        internal System.Windows.Controls.TextBox TextBoxName;
        
        internal Microsoft.Phone.Controls.DatePicker DatePickerDob;
        
        internal Microsoft.Phone.Controls.ListPicker ListPickerLevel;
        
        internal Microsoft.Phone.Controls.TimePicker TimePickerAlarm;
        
        internal Microsoft.Phone.Controls.ToggleSwitch ToggleSwitchAlarm;
        
        internal System.Windows.Controls.Button ButtonLoveAgain;
        
        internal System.Windows.Controls.Button ButtonDeleteStudyData;
        
        internal System.Windows.Controls.Button ButtonDeleteChatHistory;
        
        internal System.Windows.Controls.Button ButtonSave;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/SettingsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.GridAvatar = ((System.Windows.Controls.Grid)(this.FindName("GridAvatar")));
            this.ImageUserAvatarSettingPage = ((System.Windows.Media.ImageBrush)(this.FindName("ImageUserAvatarSettingPage")));
            this.TextBoxName = ((System.Windows.Controls.TextBox)(this.FindName("TextBoxName")));
            this.DatePickerDob = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("DatePickerDob")));
            this.ListPickerLevel = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("ListPickerLevel")));
            this.TimePickerAlarm = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("TimePickerAlarm")));
            this.ToggleSwitchAlarm = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("ToggleSwitchAlarm")));
            this.ButtonLoveAgain = ((System.Windows.Controls.Button)(this.FindName("ButtonLoveAgain")));
            this.ButtonDeleteStudyData = ((System.Windows.Controls.Button)(this.FindName("ButtonDeleteStudyData")));
            this.ButtonDeleteChatHistory = ((System.Windows.Controls.Button)(this.FindName("ButtonDeleteChatHistory")));
            this.ButtonSave = ((System.Windows.Controls.Button)(this.FindName("ButtonSave")));
        }
    }
}

