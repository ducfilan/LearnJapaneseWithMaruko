using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie
{
    public class JvDefinition
    {
        public KanjiInDict KanjiInDict
        { get; set; }
        public string Type
        { get; set; }
        public string Meaning
        { get; set; }
        public List<Example> Examples
        { get; set; }
        public JvDefinition(){}
        public JvDefinition(KanjiInDict kanjiInDict, string type, string meaning, List<Example> examples)
        {
            KanjiInDict = kanjiInDict;
            Type = type;
            Meaning = meaning;
            Examples = examples;
        }
    }
}
