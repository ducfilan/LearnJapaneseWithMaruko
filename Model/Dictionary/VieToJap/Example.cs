namespace Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.VieToJap
{
    public class Example
    {
        public string Word {
            get { return ExSentence + ": " + ExMeaning; }
        }

        public string ExSentence { get; set; }
        public string ExMeaning { get; set; }

        public Example()
        {
            
        }

        public Example(string exSentence, string exMeaning)
        {
            ExSentence = exSentence;
            ExMeaning = exMeaning;
        }
    }
}
