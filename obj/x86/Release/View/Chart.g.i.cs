﻿#pragma checksum "D:\DATA\Documents\Visual Studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\Chart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1E32735A05B1A6754EC4E70522773B8D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AmCharts.Windows.QuickCharts;
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
    
    
    public partial class Chart : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentGrid;
        
        internal AmCharts.Windows.QuickCharts.SerialChart chart1;
        
        internal System.Windows.Controls.Grid GridStatistics;
        
        internal System.Windows.Controls.TextBlock TextBlockCurrentLesson;
        
        internal System.Windows.Shapes.Rectangle ProgresNoOfsAllLesson;
        
        internal System.Windows.Shapes.Rectangle ProgressCurrentLesson;
        
        internal System.Windows.Controls.TextBlock TextBlockLearntKanjis;
        
        internal System.Windows.Shapes.Rectangle ProgressNoOfAllKanjis;
        
        internal System.Windows.Shapes.Rectangle ProgressLearntKanjis;
        
        internal System.Windows.Controls.TextBlock TextBlockLeartWords;
        
        internal System.Windows.Controls.TextBlock TextBlockTotalTest;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/Chart.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentGrid = ((System.Windows.Controls.Grid)(this.FindName("ContentGrid")));
            this.chart1 = ((AmCharts.Windows.QuickCharts.SerialChart)(this.FindName("chart1")));
            this.GridStatistics = ((System.Windows.Controls.Grid)(this.FindName("GridStatistics")));
            this.TextBlockCurrentLesson = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockCurrentLesson")));
            this.ProgresNoOfsAllLesson = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgresNoOfsAllLesson")));
            this.ProgressCurrentLesson = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgressCurrentLesson")));
            this.TextBlockLearntKanjis = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockLearntKanjis")));
            this.ProgressNoOfAllKanjis = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgressNoOfAllKanjis")));
            this.ProgressLearntKanjis = ((System.Windows.Shapes.Rectangle)(this.FindName("ProgressLearntKanjis")));
            this.TextBlockLeartWords = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockLeartWords")));
            this.TextBlockTotalTest = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockTotalTest")));
        }
    }
}

