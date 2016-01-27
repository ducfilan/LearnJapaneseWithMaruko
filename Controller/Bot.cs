namespace Hoc_tieng_Nhat_cung_Maruko.Controller
{
    public class ZBot
    {
        public static string BotAnswer(string inputText)
        {
            string answer = "Xin nhỗi bạn hỏi khó quá mình chịu luôn rồi :'(";

            inputText = RemoveSigns(inputText);

            if (inputText.Contains("la ai"))
            {
                answer = "Là người rất thông minh :-D";
            }

            if (inputText.Contains("co nguoi yeu chua"))
            {
                answer = "Vẫn còn FA dài dài hehee";
            }

            return answer;
        }


        private static readonly string[] VietnameseSigns =
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string RemoveSigns(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return str;
        }
    }
}
