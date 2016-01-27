using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.Converters
{
    public class LengthConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            var len = (Int32) value;
            return len > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
