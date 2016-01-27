using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    class WordHelper
    {
        public enum Mode
        {
            Hiragana,
            Katakana,
            Romaji
        }

        public static string RemoveSpecialCharacters(string str)
        {
            var sb = new StringBuilder();
            var specialCharacters = new[]
           {
               '!',
               '.',
               '?',
               '"',
               ')',
               '(',
               '#',
               '\'',
               '+', 
               '。',
               '！',
               '＠',
               '＃',
               '＄',
               '％',
               '＾',
               '＆',
               '＊',
               '（',
               '）',
               '＿',
               '＋',
               '？',
               '＞',
               '＜',
               '：',
               '”',
               '｜',
               '「',
               '」',
               '￥',
               '’',
               '；',
               '・',
               '、',
               '-',
               ' ',
               '~',
               '～',
               '/',
               '\\'
           };

            foreach (char c in str.Where(c => !specialCharacters.Contains(c)))
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static bool IsKanjiChar(char japChar)
        {
            return japChar >= 0x4E00 && japChar <= 0x9FBF;
        }

        public static bool IsUpper(string inputText)
        {
            return inputText.All(char.IsUpper);
        }

        public static string Convert(string text, Mode convertMode)
        {
            text = text.ToLower();
            if (_database == null)
            {
                GetDatabase();
            }
            string roma = string.Empty;
            string hira = string.Empty;
            string kata = string.Empty;

            foreach (string row in _database)
            {
                var split = row.Split('@');
                roma = split[0];
                hira = split[1];
                kata = split[2];

                switch (convertMode)
                {
                    case Mode.Romaji:
                        text = text.Replace(hira, roma);
                        text = text.Replace(kata, roma.ToUpper());
                        break;
                    case Mode.Hiragana:
                        text = text.Replace(roma, hira);
                        break;
                    case Mode.Katakana:
                        text = text.Replace(roma, kata);
                        break;
                }
            }

            return text;
        }
        private static List<string> _database;
        private static void GetDatabase()
        {
            _database = new List<string>();
            using (var sr = new System.IO.StreamReader("Assets/Database.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string splitMe = sr.ReadLine();
                    _database.Add(splitMe);
                }
            }
        }
        public static JvDictWord ParseDefinition(JVDEFINITIONSDB jvDbWord)
        {

            var jvWord = new JvDictWord();
            jvWord.Term = jvDbWord.TERM;
            var listDefinition = jvDbWord.DEFINITION.Split('§');
            var jvListDefinition = new List<JvDefinition>();
            foreach (var item in listDefinition)
            {
                var kanji = new KanjiInDict();
                var jvDefinition = new JvDefinition();
                var jvExample = new Example();
                var jvListExample = new List<Example>();
                var definitionPart = item.Split('¶');
                for (int i = 0; i < definitionPart.Length; i++)
                {
                    if (definitionPart[i].StartsWith("(@K)"))
                    {
                        kanji.KanjiWord = definitionPart[i].Substring("(@K)".Length);
                    }
                    else if (definitionPart[i].StartsWith("(@KM)"))
                    {
                        kanji.KanjiMeaning = definitionPart[i].Substring("(@KM)".Length);
                    }
                    else if (definitionPart[i].StartsWith("(@T)"))
                    {
                        jvDefinition.Type = definitionPart[i].Substring("(@T)".Length);
                    }
                    else if (definitionPart[i].StartsWith("(@M)"))
                    {
                        jvDefinition.Meaning = definitionPart[i].Substring("(@M)".Length);
                    }
                    else if (definitionPart[i].StartsWith("(@E)"))
                    {
                        jvExample.ExSentence = definitionPart[i].Substring("(@E)".Length);
                    }
                    else if (definitionPart[i].StartsWith("(@EM)"))
                    {
                        jvExample.ExMeaning = definitionPart[i].Substring("(@EM)".Length);
                        jvListExample.Add(jvExample);
                        jvExample = new Example();
                    }
                }
                jvDefinition.Examples = jvListExample;
                jvDefinition.KanjiInDict = kanji;
                jvListDefinition.Add(jvDefinition);
            }
            jvWord.level = 0;
            jvWord.Definitions = jvListDefinition;

            return jvWord;

        }
    }
}
