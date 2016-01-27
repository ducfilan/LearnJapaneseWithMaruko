namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.VieToJap
{
    public class VjDbWord
    {
        [PrimaryKey, AutoIncrement]
        public int DEF_ID { get; set; }
        public string TERM { get; set; }
        public string DEFINITION { get; set; }
    }
}
