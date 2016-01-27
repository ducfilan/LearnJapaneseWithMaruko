using System;
using System.Collections.Generic;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;

namespace Hoc_tieng_Nhat_cung_Maruko.View.HangmanGame
{
    public class WordsList
    {
        List<string> _wordList = new List<string>();
        string _currentWord = "";

        public WordsList()
        {
            ReadWordFromDictionary();
        }
    

        /// <summary>
        /// Read words from dictionary
        /// </summary>
        public void ReadWordFromDictionary()
        {



            foreach (var item in Common.AllLessons.Lessons)
            {
                foreach (var item2 in item.LessonWords)
                {
                    _wordList.Add(WordHelper.Convert(item2.TERM.ToString(),WordHelper.Mode.Romaji));
                }
              
            }
                 
              
        }

        public int MaximumWordLength
        {
            get; set;
        }

        /// <summary>
        /// Returns a word of set "Length"
        /// </summary>        
        public string Word
        {
            get
            {
                if (_currentWord == "")
                    _currentWord = GetWordOfLength(MaximumWordLength);

                return _currentWord;
            }

            set { _currentWord = value; }
        }

        /// <summary>
        /// Returns a word of given length. If length is 0 or less than 0 then word of any length is returned
        /// </summary>
        /// <param name="length">Lngth of word. To return word of any length, pass 0 or any number less than 0</param>
        /// <returns></returns>
        private string GetWordOfLength(int length)
        {
            int minWordLength = (length <= 3) ? 3 : (length <= 6) ? 4 : 6;
            bool validWord = false;
            Random random = new Random();
            do
            {
                int index = random.Next(_wordList.Count);
                string s = _wordList[index];
                if ((s.Length <= length && s.Length >= minWordLength )|| length <= 0) return _wordList[index];
                validWord = false;
            }
            while (!validWord);

            // Default is to return en empty string
            return "";
        }
    }
}
