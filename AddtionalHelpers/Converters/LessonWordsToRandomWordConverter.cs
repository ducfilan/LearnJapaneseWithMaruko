using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.Converters
{
    public class LessonWordsToRandomWordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var wordsOfLesson = (List<VOCABULARYDB>) value;

            var randomWord = wordsOfLesson.ElementAt(new Random().Next(wordsOfLesson.Count));
            
            return "Bạn đã biết từ: " + randomWord.TERM + ": " + randomWord.MEANING + " chưa?";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
