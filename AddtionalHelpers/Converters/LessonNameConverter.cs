using System;
using System.Globalization;
using System.Windows.Data;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.Converters
{
    public class LessonNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lessonNumber = (int)value;

            return "Bài " + lessonNumber;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
