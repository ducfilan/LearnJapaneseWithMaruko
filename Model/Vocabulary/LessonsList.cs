﻿using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Vocabulary
{
    public class LessonsList
    {
        public List<Lesson> Lessons { get; set; }

        public LessonsList()
        {
            Lessons = new List<Lesson>();
        }
    }
}
