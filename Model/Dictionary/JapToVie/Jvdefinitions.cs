namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie
{
    public class JVDEFINITIONSDB
    {
        [PrimaryKey, AutoIncrement]
        public int DEF_ID { get; set; }
        public string TERM { get; set; }
        public string DEFINITION { get; set; }
        public int level { get; set; }
    }
}
