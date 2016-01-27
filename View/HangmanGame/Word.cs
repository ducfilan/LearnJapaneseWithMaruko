using System;

namespace Hoc_tieng_Nhat_cung_Maruko.View.HangmanGame
{
    public class Word
    {
        WordsList _list = new WordsList();

        public Word() 
        {
        }

        /// <summary>
        /// Returns current word in use. If there is no word in use, returns a new word from dictionary
        /// </summary>
        public string CurrentWord
        {
            get { return _list.Word; }
            set { _list.Word = value; }
        }

        /// <summary>
        /// Length of word to generate
        /// </summary>
        public int MaximumWordLength
        {
            get { return _list.MaximumWordLength; }
            set { _list.MaximumWordLength = value; }
        }

        public int WordLength
        {
            get { return _list.Word.Length; }
        }

        /// <summary>
        /// Checks the first character toCheck string with the generated word. If any of the position matches, it returns the position number
        /// </summary>
        /// <param name="toCheck"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsStringInWord(string toCheck, ref int [] position)
        {
            bool ret = false;
            for (int i = 0; i < position.Length; i++)
                position[i] = -1;

            if (CurrentWord.Contains(toCheck))
            {
                int pos = 0;
                for (int i = 0; i < CurrentWord.Length; i++)
                {
                    if (Char.Equals(CurrentWord[i], toCheck[0]))
                    {
                        position[pos++] = i;
                        ret = true;
                    }
                }
            }

            return ret;
        }

    }
}
