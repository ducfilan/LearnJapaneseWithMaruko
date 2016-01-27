namespace Hoc_tieng_Nhat_cung_Maruko.Model.Test
{
    public class Question
    {
        public int ID { get; set; }
        public string Term { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string UserAnswer { get; set; }

        public string RightAnswer { get; set; }
        public int timer { get; set; }
    }

    
}
