using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class BirthdayPage : PhoneApplicationPage
    {
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (MessageBox.Show("Nghe mình hát đã " + Common.NameOfUser + " ơi...", "Piihya ra piihyara...", MessageBoxButton.OKCancel) != MessageBoxResult.Cancel)
            {
                return;
            }

            e.Cancel = true;

            base.OnBackKeyPress(e);
        }

        public BirthdayPage()
        {
            InitializeComponent();

            PlaySong();

            AnimateMaruko();
        }

        private void AnimateMaruko()
        {
            AnimationHelper.Instance.OpacityAnimation(ImageMarukoSingBigMouth, 1, 0, 1, 0, true);
            AnimationHelper.Instance.StartAnimation();
            AnimationHelper.Instance.OpacityAnimation(ImageMarukoSingSmallMouth, 0, 1, 1, 1, true);
            AnimationHelper.Instance.StartAnimation();
        }

        private void PlaySong()
        {
            MediaElementMarukoSong.Play();
        }
    }
}