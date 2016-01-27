using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class ColorHelper
    {
        public static Color ConvertStringToColor(string hex)
        {
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                start = 2;
            }

            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
