using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;

namespace Hoc_tieng_Nhat_cung_Maruko
{
    public class DatabaseFilterDataHelper
    {
        static async Task<List<KanjiDict>> GetJvDictData()
        {
            var selectKanjiQuery = SqLiteHelper.SqLiteConnection("JapVie.db3").Table<KanjiDict>();

            var kanjiList = await selectKanjiQuery.ToListAsync();

            return kanjiList;
        }

        public static void LoadKanjiData()
        {
            var kanjiList = GetJvDictData().ConfigureAwait(false);

            Common.KanjiDictWords = kanjiList.GetAwaiter().GetResult();
        }

        public static async void LoadLessonWordData()
        {
            var selectLessonWordQuery = SqLiteHelper.SqLiteConnection("JapVie.db3").Table<VocabularyDict>();
            var lessonWords = await selectLessonWordQuery.ToListAsync();

            Common.LessonWords = lessonWords;
        }

        public static List<string> FilterPathData(string data)
        {
            return data.Split('§').ToList();
        }
    }
}
