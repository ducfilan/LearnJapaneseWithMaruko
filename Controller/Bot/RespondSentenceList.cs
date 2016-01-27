using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public class RespondSentenceList
    {
        public int respondSentenceType;
        public List<RespondSentence> respondSentences;

        public RespondSentenceList()
        {
            this.respondSentenceType = 0;
            this.respondSentences = new List<RespondSentence>();
        }
    }
}