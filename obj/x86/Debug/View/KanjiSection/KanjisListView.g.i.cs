﻿#pragma checksum "D:\DATA\Documents\Visual Studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\KanjiSection\KanjisListView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B336FC10402F71911682C04CF31096BB"
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


namespace Hoc_tieng_Nhat_cung_Maruko.View.KanjiSection {
    
    
    public partial class KanjisListView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot PivotWordLesson;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemAllWords;
        
        internal System.Windows.Controls.Grid GridDictionary;
        
        internal System.Windows.Controls.TextBox TextBoxSearchKanji;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector LongListMultiSelectorAllWords;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemLearningKanjisLists;
        
        internal System.Windows.Controls.TextBlock TextBlockEmptyTemplate;
        
        internal Microsoft.Phone.Controls.LongListMultiSelector LongListMultiSelectorLearningWords;
        
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
        
        internal System.Windows.Controls.TextBlock TxtTotal;
        
        internal System.Windows.Controls.Image ImageMarukoTest;
        
        internal System.Windows.Controls.TextBlock TextBlockMarukoTalk;
        
        internal System.Windows.Controls.Button ButtonStartTest;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/KanjiSection/KanjisListView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PivotWordLesson = ((Microsoft.Phone.Controls.Pivot)(this.FindName("PivotWordLesson")));
            this.PivotItemAllWords = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemAllWords")));
            this.GridDictionary = ((System.Windows.Controls.Grid)(this.FindName("GridDictionary")));
            this.TextBoxSearchKanji = ((System.Windows.Controls.TextBox)(this.FindName("TextBoxSearchKanji")));
            this.LongListMultiSelectorAllWords = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("LongListMultiSelectorAllWords")));
            this.PivotItemLearningKanjisLists = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemLearningKanjisLists")));
            this.TextBlockEmptyTemplate = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockEmptyTemplate")));
            this.LongListMultiSelectorLearningWords = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("LongListMultiSelectorLearningWords")));
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
            this.TxtTotal = ((System.Windows.Controls.TextBlock)(this.FindName("TxtTotal")));
            this.ImageMarukoTest = ((System.Windows.Controls.Image)(this.FindName("ImageMarukoTest")));
            this.TextBlockMarukoTalk = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockMarukoTalk")));
            this.ButtonStartTest = ((System.Windows.Controls.Button)(this.FindName("ButtonStartTest")));
        }
    }
}

