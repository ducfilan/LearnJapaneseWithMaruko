using Hoc_tieng_Nhat_cung_Maruko.Controller.Bot;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class WordUtility
    {
        public static bool CompareWord(string inputWord, Word myWord)
        {
            return inputWord.Equals(myWord.labelNoMark) || inputWord.Equals(myWord.labelHasMark);
        }

        public static bool StartsWith(string inputWord, Word myWord)
        {
            return inputWord.StartsWith(myWord.labelNoMark) || inputWord.StartsWith(myWord.labelHasMark);
        }

        public static bool EndsWith(string inputWord, Word myWord)
        {
            return inputWord.EndsWith(myWord.labelNoMark) || inputWord.EndsWith(myWord.labelHasMark);
        }

        public static string RemoveStartWords(string inputWord, Word myWord)
        {
            if (inputWord.StartsWith(myWord.labelNoMark))
            {
                return inputWord.Remove(0, myWord.labelNoMark.Length).Trim();
            }

            if (inputWord.StartsWith(myWord.labelHasMark))
            {
                return inputWord.Remove(0, myWord.labelHasMark.Length).Trim();
            }
            return inputWord.Trim();

        }

        public static string RemoveEndWords(string inputWord, Word myWord)
        {
            if (inputWord.EndsWith(myWord.labelNoMark))
            {
                return inputWord.Remove(inputWord.Length - myWord.labelNoMark.Length, myWord.labelNoMark.Length).Trim();
            }

            if (inputWord.EndsWith(myWord.labelHasMark))
            {
                return inputWord.Remove(inputWord.Length - myWord.labelHasMark.Length, myWord.labelHasMark.Length).Trim();
            }
            return inputWord.Trim();

        }

        public static string RemoveMarks(string inputWord)
        {
            if (inputWord.StartsWith("\""))
            {
                inputWord = inputWord.Remove(0, 1).Trim();
            }

            if (inputWord.EndsWith("\""))
            {
                inputWord = inputWord.Remove(inputWord.Length - 1, 1).Trim();
            }

            return inputWord.Trim();
        }
    }
}