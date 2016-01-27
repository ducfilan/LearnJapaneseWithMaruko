using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Grammar
{
    public class Grammar
    {
        public int LessonNo { get; set; }
        public string ImagePath { get; set; }
        public List<GRAMMARSDB> LessonGrammars { get; set; }
    }
}
