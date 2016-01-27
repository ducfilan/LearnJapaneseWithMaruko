namespace Hoc_tieng_Nhat_cung_Maruko.Model.Alphabet
{
    public class HIRAGANASDB
    {
        [PrimaryKey, NotNull, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public string TERM { get; set; }
        [NotNull]
        public string MEANING { get; set; }
    }
}
