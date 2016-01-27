using System;
using System.Windows;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public enum Resolutions { WVGA, WXGA, HD };

    public static class ResolutionHelper
    {
        private static bool IsWvga
        {
            get
            {
                return Application.Current.Host.Content.ScaleFactor == 100;
            }
        }

        private static bool IsWxga
        {
            get
            {
                return Application.Current.Host.Content.ScaleFactor == 160;
            }
        }

        private static bool IsHD
        {
            get
            {
                return Application.Current.Host.Content.ScaleFactor == 150;
            }
        }

        public static Resolutions CurrentResolution
        {
            get
            {
                if (IsWvga) return Resolutions.WVGA;
                if (IsWxga) return Resolutions.WXGA;
                if (IsHD) return Resolutions.HD;
                throw new InvalidOperationException("Unknown resolution");
            }
        }
    }
}
