﻿#pragma checksum "d:\data\documents\visual studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\Friendship.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "92CA6E1B2CB55E2789C7D2321C7BEE83"
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


namespace Hoc_tieng_Nhat_cung_Maruko.View {
    
    
    public partial class Friendship : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid GridLayoutFriendship;
        
        internal System.Windows.Controls.RowDefinition StatisticTable;
        
        internal System.Windows.Controls.RowDefinition MarukoImage;
        
        internal System.Windows.Controls.Grid GridMarukoImage;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/Friendship.xaml", System.UriKind.Relative));
            this.GridLayoutFriendship = ((System.Windows.Controls.Grid)(this.FindName("GridLayoutFriendship")));
            this.StatisticTable = ((System.Windows.Controls.RowDefinition)(this.FindName("StatisticTable")));
            this.MarukoImage = ((System.Windows.Controls.RowDefinition)(this.FindName("MarukoImage")));
            this.GridMarukoImage = ((System.Windows.Controls.Grid)(this.FindName("GridMarukoImage")));
        }
    }
}
