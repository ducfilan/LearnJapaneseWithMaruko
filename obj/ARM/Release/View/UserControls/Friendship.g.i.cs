﻿#pragma checksum "D:\DATA\Documents\Visual Studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\UserControls\Friendship.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "74CB3AAB8AEF93E7413544A6632BB5EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Hoc_tieng_Nhat_cung_Maruko.View.UserControls {
    
    
    public partial class Friendship : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard StoryboardGreetingMaruko;
        
        internal System.Windows.Controls.Grid GridLayoutFriendship;
        
        internal System.Windows.Controls.RowDefinition StatisticTable;
        
        internal System.Windows.Controls.RowDefinition MarukoImage;
        
        internal System.Windows.Controls.Grid GridUserInfo;
        
        internal System.Windows.Controls.Grid GridAvatar;
        
        internal System.Windows.Media.ImageBrush ImageUserAvatar;
        
        internal System.Windows.Controls.TextBox TextBoxUserStataus;
        
        internal System.Windows.Controls.Button ShareStatusButton;
        
        internal System.Windows.Controls.TextBlock TextBlockNameOfUser;
        
        internal System.Windows.Controls.Grid GridStatistics;
        
        internal System.Windows.Controls.TextBlock TextBlockCurrentLesson;
        
        internal System.Windows.Shapes.Rectangle ProgresNoOfsAllLesson;
        
        internal System.Windows.Shapes.Rectangle ProgressCurrentLesson;
        
        internal System.Windows.Controls.TextBlock TextBlockLearntKanjis;
        
        internal System.Windows.Shapes.Rectangle ProgressNoOfAllKanjis;
        
        internal System.Windows.Shapes.Rectangle ProgressLearntKanjis;
        
        internal System.Windows.Controls.TextBlock TextBlockLeartWords;
        
        internal System.Windows.Controls.Grid GridMarukoImage;
        
        internal System.Windows.Controls.Grid grid;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/UserControls/Friendship.xaml", System.UriKind.Relative));
            this.StoryboardGreetingMaruko = ((System.Windows.Media.Animation.Storyboard)(this.FindName("StoryboardGreetingMaruko")));
            this.GridLayoutFriendship = ((System.Windows.Controls.Grid)(this.FindName("GridLayoutFriendship")));
            this.StatisticTable = ((System.Windows.Controls.RowDefinition)(this.FindName("StatisticTable")));
            this.MarukoImage = ((System.Windows.Controls.RowDefinition)(this.FindName("MarukoImage")));
            this.GridUserInfo = ((System.Windows.Controls.Grid)(this.FindName("GridUserInfo")));
            this.GridAvatar = ((System.Windows.Controls.Grid)(this.FindName("GridAvatar")));
            this.ImageUserAvatar = ((System.Windows.Media.ImageBrush)(this.FindName("ImageUserAvatar")));
            this.TextBoxUserStataus = ((System.Windows.Controls.TextBox)(this.FindName("TextBoxUserStataus")));
            this.ShareStatusButton = ((System.Windows.Controls.Button)(this.FindName("ShareStatusButton")));
            this.TextBlockNameOfUser = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockNameOfUser")));
            this.GridStatistics = ((System.Windows.Controls.Grid)(this.FindName("GridStatistics")));
            this.TextBlockCurrentLesson = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockCurrentLesson")));
            this.ProgresNoOfsAllLesson = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgresNoOfsAllLesson")));
            this.ProgressCurrentLesson = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgressCurrentLesson")));
            this.TextBlockLearntKanjis = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockLearntKanjis")));
            this.ProgressNoOfAllKanjis = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgressNoOfAllKanjis")));
            this.ProgressLearntKanjis = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgressLearntKanjis")));
            this.TextBlockLeartWords = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockLeartWords")));
            this.GridMarukoImage = ((System.Windows.Controls.Grid)(this.FindName("GridMarukoImage")));
            this.grid = ((System.Windows.Controls.Grid)(this.FindName("grid")));
        }
    }
}

