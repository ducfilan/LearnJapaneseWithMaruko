using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Test
{
    public class TestDataItem
    {
      
        public string cat1 { get; set; }
        public float val3 { get; set; }

        public TestDataItem()
        { }

        public TestDataItem(string cat1, float val3)
        {
            this.cat1 = cat1;
            this.val3 = val3;
        }
    }
}
