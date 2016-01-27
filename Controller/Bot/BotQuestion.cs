using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public class BotQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Hint { get; set; }

        public bool IsCorrect = false;
    }
}
