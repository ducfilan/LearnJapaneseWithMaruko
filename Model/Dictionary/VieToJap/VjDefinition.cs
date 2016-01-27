using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.VieToJap
{
    public class VjDefinition
    {
        public Kanji Kanji
        { get; set; }
        public string Type
        { get; set; }
        public string Meaning
        { get; set; }
        public List<Example> Examples
        { get; set; }
        public VjDefinition(){}
        public VjDefinition(Kanji kanji, string type, string meaning, List<Example> examples)
        {
            Kanji = kanji;
            Type = type;
            Meaning = meaning;
            Examples = examples;
        }
    }
}
