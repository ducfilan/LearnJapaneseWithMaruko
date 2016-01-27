using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    class ApproximatString
    {
        string s;
        int i, j, k, loi, saiSo;
        public ApproximatString(string nhap)
        {
            s = nhap.ToLower();
            saiSo = (int)Math.Round(s.Length * 0.3);
        }
        public int GetLevel()
        {
            return loi;
        }
        public bool Compare(string s1)
        {
            s1 =s1.ToLower();
            if (s1.Contains(s))
            {
                loi = 0;
                return true;
            }
            if (s1.Length < (s.Length - saiSo) || s1.Length > (s.Length + saiSo))
                return false;
            i = j = loi = 0;
            while (i < s.Length && j < s1.Length)
            {
                if (s[i] != s1[j])
                {
                    loi++;
                    for (k = 1; k <= saiSo; k++)
                    {
                        if ((i + k < s.Length) && s[i + k] == s1[j])
                        {
                            i += k;
                            loi += k - 1;
                            break;
                        }
                        if ((j + k >= s1.Length) || s[i] != s1[j + k]) continue;
                        j += k;
                        loi += k - 1;
                        break;
                    }
                }
                i++;
                j++;
            }
            loi += s.Length - i + s1.Length - j;
            if (loi <= saiSo)
                return true;
            return false;
        }
    }
}
