using System;
using System.Collections;
using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public class WordsList : IEnumerator, IEnumerable
    {
        public int wordType;
        public List<Word> words;
        int position = -1;

        public WordsList()
        {
            this.wordType = 0;
            this.words = new List<Word>();
        }

        public Word GetWordById(int id)
        {
            foreach (Word word in words)
            {
                if (word.id == id)
                {
                    return word;
                }
            }

            throw new Exception("Word not existed");
        }

        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < words.Count);
        }

        //IEnumerable
        public void Reset()
        { position = -1; }

        //IEnumerable
        public Word Current
        {
            get
            {
                try
                {
                    return words[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
}