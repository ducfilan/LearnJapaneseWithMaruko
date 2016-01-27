namespace Hoc_tieng_Nhat_cung_Maruko.Model.Kanji
{
    public class KANJIDICTDB
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

        public override bool Equals(object obj)
        {
            var kanjidictdb = obj as KANJIDICTDB;
            return kanjidictdb != null && kanjidictdb.ID == this.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
