namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie
{
    public class KanjiInDict
    {
        public string KanjiWord
        { get; set; }
        public string KanjiMeaning
        { get; set; }
        public KanjiInDict() { }
        public KanjiInDict(string kanjiWord, string kanjiMeaning)
        {
            this.KanjiWord = kanjiWord;
            this.KanjiMeaning = kanjiMeaning;
        }
    }
}
