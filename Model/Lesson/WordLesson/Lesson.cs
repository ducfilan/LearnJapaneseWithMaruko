using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson
{
    public class Lesson
    {
        public int LessonNumber { get; set; }
        public string ImagePath { get; set; }
        public List<VOCABULARYDB> LessonWords { get; set; }

        public Lesson()
        {
            LessonWords = new List<VOCABULARYDB>();
        }

        public Lesson(int lessonNumber, string imagePath)
        {
            LessonNumber = lessonNumber;
            ImagePath = imagePath;
        }
    }
}
