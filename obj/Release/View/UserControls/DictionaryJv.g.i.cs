﻿#pragma checksum "D:\DATA\Documents\Visual Studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\UserControls\DictionaryJv.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FD8AC71E1B6C4617F75F5001649AB9F0"
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


namespace Hoc_tieng_Nhat_cung_Maruko.View.UserControls {
    
    
    public partial class DictionaryJv : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid GridDictionary;
        
        internal System.Windows.Controls.TextBox TextBoxSearch;
        
        internal Microsoft.Phone.Controls.LongListSelector ResultListBox;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/UserControls/DictionaryJv.xaml", System.UriKind.Relative));
            this.GridDictionary = ((System.Windows.Controls.Grid)(this.FindName("GridDictionary")));
            this.TextBoxSearch = ((System.Windows.Controls.TextBox)(this.FindName("TextBoxSearch")));
            this.ResultListBox = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("ResultListBox")));
        }
    }
}
