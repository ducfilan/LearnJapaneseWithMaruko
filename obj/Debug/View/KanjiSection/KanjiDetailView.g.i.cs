﻿#pragma checksum "d:\data\documents\visual studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\KanjiSection\KanjiDetailView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "98B41D359E78C02B648B729A57B2DB56"
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
    
    
    public partial class KanjiDetailView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.Pivot PivotWordLesson;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemKanjiDetail;
        
        internal System.Windows.Controls.TextBlock TextBlockKanjiTerm;
        
        internal System.Windows.Controls.TextBlock TextBlockOnSound;
        
        internal System.Windows.Controls.TextBlock TextBlockKunSound;
        
        internal System.Windows.Controls.TextBlock TextBlockExample;
        
        internal Microsoft.Phone.Controls.PivotItem PivotItemStrokeOrder;
        
        internal System.Windows.Controls.Grid GridDrawing;
        
        internal System.Windows.Controls.Grid GridDrawKanji;
        
        internal System.Windows.Controls.TextBlock TextBlockNumberOfStrokes;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/KanjiSection/KanjiDetailView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.PivotWordLesson = ((Microsoft.Phone.Controls.Pivot)(this.FindName("PivotWordLesson")));
            this.PivotItemKanjiDetail = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemKanjiDetail")));
            this.TextBlockKanjiTerm = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockKanjiTerm")));
            this.TextBlockOnSound = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockOnSound")));
            this.TextBlockKunSound = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockKunSound")));
            this.TextBlockExample = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockExample")));
            this.PivotItemStrokeOrder = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("PivotItemStrokeOrder")));
            this.GridDrawing = ((System.Windows.Controls.Grid)(this.FindName("GridDrawing")));
            this.GridDrawKanji = ((System.Windows.Controls.Grid)(this.FindName("GridDrawKanji")));
            this.TextBlockNumberOfStrokes = ((System.Windows.Controls.TextBlock)(this.FindName("TextBlockNumberOfStrokes")));
        }
    }
}

