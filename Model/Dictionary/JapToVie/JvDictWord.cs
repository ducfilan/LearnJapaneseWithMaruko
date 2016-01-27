using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie
{
    public class JvDictWord
    {
        public string Term { get; set; }
        public List<JvDefinition> Definitions { get; set; }
        public int level;
    }
}
