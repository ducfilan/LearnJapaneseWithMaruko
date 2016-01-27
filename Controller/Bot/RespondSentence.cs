namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public enum LoaiCauTraLoi
    {
        traLoiKhongHieuY = 1
    }

    public class RespondSentence
    {
        public int id { get; set; }
        public string respondVN { get; set; }
        public string respondJP { get; set; }

        public RespondSentence(int id, string respondVN, string respondJP)
        {
            this.id = id;
            this.respondVN = respondVN;
            this.respondJP = respondJP;
        }
    }
}