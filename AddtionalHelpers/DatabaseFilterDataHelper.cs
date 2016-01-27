using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class DatabaseFilterDataHelper
    {
        static async Task<List<KANJIDICTDB>> GetJvDictData()
        {
            var selectKanjiQuery = SqLiteHelper.SqLiteAsyncConnection("Maruko.db3").Table<KANJIDICTDB>();

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
            var selectLessonWordQuery = SqLiteHelper.SqLiteAsyncConnection("Maruko.db3").Table<VOCABULARYDB>();
            var lessonWords = await selectLessonWordQuery.ToListAsync();

            Common.LessonWords = lessonWords;
        }

        public static List<string> FilterPathData(string data)
        {
            return data.Split('§').ToList();
        }
    }
}
