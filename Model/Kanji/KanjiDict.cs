namespace Hoc_tieng_Nhat_cung_Maruko.Model.Kanji
{
    public class KanjiDict
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public string TERM { get; set; }
        [NotNull]
        public string MEANING { get; set; }
        public int STROKECOUNT { get; set; }
        public string ONSOUND { get; set; }
        public string KUNSOUND { get; set; }
        public string EXAMPLES { get; set; }
        public string PATHDATA { get; set; }
        public int WordPriority;
        public int JLPTLEVEL { get; set; }
    }
}
