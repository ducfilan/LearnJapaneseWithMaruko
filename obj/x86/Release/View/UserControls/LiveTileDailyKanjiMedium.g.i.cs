﻿#pragma checksum "d:\data\documents\visual studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\UserControls\LiveTileDailyKanjiMedium.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A9721BE9C5826CAC1252857304760B95"
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
    
    
    public partial class LiveTileDailyKanjiMedio : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock txtTitle;
        
        internal System.Windows.Controls.TextBlock txtContent;
        
        internal System.Windows.Controls.Image imgIcon;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/UserControls/LiveTileDailyKanjiMedium." +
                        "xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtTitle = ((System.Windows.Controls.TextBlock)(this.FindName("txtTitle")));
            this.txtContent = ((System.Windows.Controls.TextBlock)(this.FindName("txtContent")));
            this.imgIcon = ((System.Windows.Controls.Image)(this.FindName("imgIcon")));
        }
    }
}

