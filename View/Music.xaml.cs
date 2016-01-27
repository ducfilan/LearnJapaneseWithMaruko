using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class Music : PhoneApplicationPage
    {
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            WebBrowser.GoBack();

            base.OnBackKeyPress(e);
        }

        public Music()
        {
            InitializeComponent();
            WebBrowser.Loaded += WebBrowser_Loaded;
        }

        void WebBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("http://m.mp3.zing.vn/top-100/bai-hat-Nhat-Ban/IWZ9Z08Z.html", UriKind.Absolute), null, "User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)");
        }
    }
}