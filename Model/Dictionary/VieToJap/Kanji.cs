namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.VieToJap
{
    public class Kanji
    {
        public string KanjiWord
        { get; set; }
        public string KanjiMeaning
        { get; set; }
        public Kanji() { }
        public Kanji(string kanjiWord, string kanjiMeaning)
        {
            this.KanjiWord = kanjiWord;
            this.KanjiMeaning = kanjiMeaning;
        }
    }
}
