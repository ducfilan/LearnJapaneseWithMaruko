using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.Converters
{
    public class JvDictDefinitionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            /*
            var wordToShowInWordList = value as string;

            var regex = new Regex("¶\\(@\\w+\\)");
            if (wordToShowInWordList != null)
            {
                wordToShowInWordList = "¶" + wordToShowInWordList;
                wordToShowInWordList = regex.Replace(wordToShowInWordList, ",");
            }

            return wordToShowInWordList + string.Empty;
            */
            var wordToShowInWordList = string.Empty;
            var definitionString = value as string;
            if (definitionString == null) return wordToShowInWordList;
            var listDefinition = definitionString.Split('§');
            var definitions = new List<JvDefinition>();
            foreach (var item in listDefinition)
            {
                var kanji = new KanjiInDict();
                var jvDefinition = new JvDefinition();
                var jvExample = new Example();
                var jvListExample = new List<Example>();
                var definitionPart = item.Split('¶');
                foreach (string part in definitionPart)
                {
                    if (part.StartsWith("(@K)"))
                    {
                        kanji.KanjiWord = part.Substring("(@K)".Length);
                    }
                    else if (part.StartsWith("(@KM)"))
                    {
                        kanji.KanjiMeaning = part.Substring("(@KM)".Length);
                    }
                    else if (part.StartsWith("(@T)"))
                    {
                        jvDefinition.Type = part.Substring("(@T)".Length);
                    }
                    else if (part.StartsWith("(@M)"))
                    {
                        jvDefinition.Meaning = part.Substring("(@M)".Length);
                    }
                    else if (part.StartsWith("(@E)"))
                    {
                        jvExample.ExSentence = part.Substring("(@E)".Length);
                    }
                    else if (part.StartsWith("(@EM)"))
                    {
                        jvExample.ExMeaning = part.Substring("(@EM)".Length);
                        jvListExample.Add(jvExample);
                        jvExample = new Example();
                    }
                }
                jvDefinition.Examples = jvListExample;
                jvDefinition.KanjiInDict = kanji;
                definitions.Add(jvDefinition);
            }

            foreach (var definition in definitions)
            {
                if (definition.KanjiInDict.KanjiWord != null && definition.KanjiInDict.KanjiWord.Trim() != string.Empty)
                {
                    wordToShowInWordList += definition.KanjiInDict.KanjiWord + ": ";
                }

                wordToShowInWordList += definition.Meaning + "; ";
            }
            try
            {
                wordToShowInWordList = wordToShowInWordList.Remove(wordToShowInWordList.Length - 2, 1);
            }
            catch { }
            return wordToShowInWordList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
