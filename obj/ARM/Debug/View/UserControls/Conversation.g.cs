﻿#pragma checksum "d:\data\documents\visual studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\UserControls\Conversation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A3F98A1CC00F65F6039693E4ECEE7E1"
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
    
    
    public partial class Conversation : System.Windows.Controls.UserControl {
        
        internal System.Windows.DataTemplate SelectingTemplate;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.LongListSelector LongListSelectorMessages;
        
        internal Microsoft.Phone.Controls.PhoneTextBox TxtUserMessage;
        
        internal System.Windows.Controls.Button ButtonSendMessage;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/UserControls/Conversation.xaml", System.UriKind.Relative));
            this.SelectingTemplate = ((System.Windows.DataTemplate)(this.FindName("SelectingTemplate")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.LongListSelectorMessages = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("LongListSelectorMessages")));
            this.TxtUserMessage = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("TxtUserMessage")));
            this.ButtonSendMessage = ((System.Windows.Controls.Button)(this.FindName("ButtonSendMessage")));
        }
    }
}

