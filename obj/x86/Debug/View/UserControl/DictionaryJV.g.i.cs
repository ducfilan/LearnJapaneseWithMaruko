﻿#pragma checksum "d:\data\documents\visual studio 2013\Projects\HocTiengNhatCungMaruko\Học tiếng Nhật cùng Maruko\View\UserControl\DictionaryJv.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8F2FFDD54BC00691AAAF4C8FEDD977F6"
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


namespace Hoc_tieng_Nhat_cung_Maruko.View.UserControl {
    
    
    public partial class DictionaryJv : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid GridDictionary;
        
        internal System.Windows.Controls.TextBox TxtUserMessage;
        
        internal System.Windows.Controls.Button ButtonTranslate;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/LearningJapaneseWithMaruko;component/View/UserControl/DictionaryJv.xaml", System.UriKind.Relative));
            this.GridDictionary = ((System.Windows.Controls.Grid)(this.FindName("GridDictionary")));
            this.TxtUserMessage = ((System.Windows.Controls.TextBox)(this.FindName("TxtUserMessage")));
            this.ButtonTranslate = ((System.Windows.Controls.Button)(this.FindName("ButtonTranslate")));
        }
    }
}

