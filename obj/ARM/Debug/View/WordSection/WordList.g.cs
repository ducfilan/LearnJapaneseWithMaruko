﻿#pragma checksum "d:\data\documents\visual studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\WordSection\WordList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "706A8BC7A7826ECF10B876AFAE1BF43A"
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
using Microsoft.Phone.Shell;
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


namespace Hoc_tieng_Nhat_cung_Maruko.View.WordSection {
    
    
    public partial class WordList : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock TextBlockLessonNo;
        
        internal Microsoft.Phone.Controls.Pivot PivotWordLesson;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemAllWords;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.LongListSelector LongListSelectorWords;
        
        internal System.Windows.Controls.Grid GridGuideUser;
        
        internal System.Windows.Controls.Image ImageMarukoGuide;
        
        internal System.Windows.Controls.TextBlock TextBlockMarukoGuideSpeech;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemTest;
        
        internal System.Windows.Controls.TextBlock TextBlockQuestionNumber;
        
        internal System.Windows.Controls.TextBlock txtQuestionImages;
        
        internal System.Windows.Controls.Grid GridAnswers;
        
        internal System.Windows.Controls.Border brA;
        
        internal System.Windows.Controls.TextBlock btnAAnswer;
        
        internal System.Windows.Controls.Border brB;
        
        internal System.Windows.Controls.TextBlock btnBAnswer;
        
        internal System.Windows.Controls.Border brC;
        
        internal System.Windows.Controls.TextBlock btnCAnswer;
        
        internal System.Windows.Controls.Border brD;
        
        internal System.Windows.Controls.TextBlock btnDAnswer;
        
        internal System.Windows.Controls.StackPanel TitlePanelTrailers;
        
        internal System.Windows.Controls.TextBlock txtCorrectImages;
        
        internal System.Windows.Controls.TextBlock txtTimerImages;
        
        internal System.Windows.Controls.Border BorderWrapTest;
        
        internal System.Windows.Controls.TextBlock txtTotal;
        
        internal System.Windows.Controls.Image ImageMarukoTest;
        
        internal System.Windows.Controls.TextBlock TextBlockMarukoTalk;
        
        internal System.Windows.Controls.Button ButtonStartTest;
        
        internal Microsoft.Phone.Shell.ApplicationBar WordBar;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton HideJapButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton ShowAllButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton HideVieButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/WordSection/WordList.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TextBlockLessonNo = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockLessonNo")));
            this.PivotWordLesson = ((Microsoft.Phone.Controls.Pivot)(this.FindName("PivotWordLesson")));
            this.PivotItemAllWords = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemAllWords")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.LongListSelectorWords = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("LongListSelectorWords")));
            this.GridGuideUser = ((System.Windows.Controls.Grid)(this.FindName("GridGuideUser")));
            this.ImageMarukoGuide = ((System.Windows.Controls.Image)(this.FindName("ImageMarukoGuide")));
            this.TextBlockMarukoGuideSpeech = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockMarukoGuideSpeech")));
            this.PivotItemTest = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemTest")));
            this.TextBlockQuestionNumber = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockQuestionNumber")));
            this.txtQuestionImages = ((System.Windows.Controls.TextBlock)(this.FindName("txtQuestionImages")));
            this.GridAnswers = ((System.Windows.Controls.Grid)(this.FindName("GridAnswers")));
            this.brA = ((System.Windows.Controls.Border)(this.FindName("brA")));
            this.btnAAnswer = ((System.Windows.Controls.TextBlock)(this.FindName("btnAAnswer")));
            this.brB = ((System.Windows.Controls.Border)(this.FindName("brB")));
            this.btnBAnswer = ((System.Windows.Controls.TextBlock)(this.FindName("btnBAnswer")));
            this.brC = ((System.Windows.Controls.Border)(this.FindName("brC")));
            this.btnCAnswer = ((System.Windows.Controls.TextBlock)(this.FindName("btnCAnswer")));
            this.brD = ((System.Windows.Controls.Border)(this.FindName("brD")));
            this.btnDAnswer = ((System.Windows.Controls.TextBlock)(this.FindName("btnDAnswer")));
            this.TitlePanelTrailers = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanelTrailers")));
            this.txtCorrectImages = ((System.Windows.Controls.TextBlock)(this.FindName("txtCorrectImages")));
            this.txtTimerImages = ((System.Windows.Controls.TextBlock)(this.FindName("txtTimerImages")));
            this.BorderWrapTest = ((System.Windows.Controls.Border)(this.FindName("BorderWrapTest")));
            this.txtTotal = ((System.Windows.Controls.TextBlock)(this.FindName("txtTotal")));
            this.ImageMarukoTest = ((System.Windows.Controls.Image)(this.FindName("ImageMarukoTest")));
            this.TextBlockMarukoTalk = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockMarukoTalk")));
            this.ButtonStartTest = ((System.Windows.Controls.Button)(this.FindName("ButtonStartTest")));
            this.WordBar = ((Microsoft.Phone.Shell.ApplicationBar)(this.FindName("WordBar")));
            this.HideJapButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("HideJapButton")));
            this.ShowAllButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("ShowAllButton")));
            this.HideVieButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("HideVieButton")));
        }
    }
}
