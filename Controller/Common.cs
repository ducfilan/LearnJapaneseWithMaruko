using System;
using System.Collections.Generic;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Model.Alphabet;
using Hoc_tieng_Nhat_cung_Maruko.Model.Grammar;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;

namespace Hoc_tieng_Nhat_cung_Maruko.Controller
{
    public class Common
    {
        static readonly AppSettings AppSettings = new AppSettings();

        public static LessonsList AllLessons { get; set; }

        public static GrammarList AllGrammars { get; set; }

        public static int CurrentWordLesson
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.CurrentWordLessonSettingKeyName, 1); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.CurrentWordLessonSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int CurrentGrammarLesson
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.CurrentGrammarLessonSettingKeyName, 1); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.CurrentGrammarLessonSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static List<int> LearntWordIdsList
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.LearntWordIdsListSettingKeyName, new List<int>()); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.LearntWordIdsListSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int JlptLevel
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.JlptLevelSettingKeyName, 5); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.JlptLevelSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static List<int> LearntKanjiIdsList
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.LearntKanjIdsListSettingKeyName, new List<int>()); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.LearntKanjIdsListSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static HashSet<KANJIDICTDB> CurrentLearningKanjisList
        {
            get { return AppSettings.GetValueOrDefault<HashSet<KANJIDICTDB>>(AppSettings.LearningKanjisListSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.LearningKanjisListSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static List<TestDataItem> DataTest
        {
            get { return AppSettings.GetValueOrDefault<List<TestDataItem>>(AppSettings.DataTestSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.DataTestSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static List<HIRAGANASDB> CurrentLearningHiraganaList
        {
            get { return AppSettings.GetValueOrDefault<List<HIRAGANASDB>>(AppSettings.LearningHiraganasListSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.LearningHiraganasListSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static List<KATAKANASDB> CurrentLearningKatakanaList
        {
            get { return AppSettings.GetValueOrDefault<List<KATAKANASDB>>(AppSettings.LearningKatakanasListSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.LearningKatakanasListSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int IsFirstTimeAccessWordList
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.IsFirstTimeAccessWordListSettingKeyName, 1); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.IsFirstTimeAccessWordListSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static string PreviousAppVersion
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.PreviousAppVersion, string.Empty); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.PreviousAppVersion, value);
                AppSettings.Save();
            }
        }

        public static int IsFirstTimeAccessDictionaryDetail
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.IsFirstTimeAccessDictionaryDetailSettingKeyName, 1); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.IsFirstTimeAccessDictionaryDetailSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int NoOfTotalLessons
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.NoOfTotalLessonsSettingKeyName, 1); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.NoOfTotalLessonsSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int NoOfTotalGrammars
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.NoOfTotalGrammarsSettingKeyName, 1); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.NoOfTotalGrammarsSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int NoOfTotalKanjis
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.NoOfTotalKanjisSettingKeyName, 0); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.NoOfTotalKanjisSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static int NoOfTotalWords
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.NoOfTotalWordsSettingKeyName, 0); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.NoOfTotalWordsSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static string NameOfUser
        {
            get { return AppSettings.GetValueOrDefault<string>(AppSettings.UserNameSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.UserNameSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static string StatusOfUser
        {
            get { return AppSettings.GetValueOrDefault(AppSettings.UserStatusSettingKeyName, ""); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.UserStatusSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static string AvatarOfUser
        {
            get { return AppSettings.GetValueOrDefault<string>(AppSettings.UserAvatarSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.UserAvatarSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static DateTime? DobOfUser
        {
            get { return AppSettings.GetValueOrDefault<DateTime?>(AppSettings.UserDobSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.UserDobSettingKeyName, value);
                AppSettings.Save();
            }
        }

        public static DateTime? AlarmOfUser
        {
            get { return AppSettings.GetValueOrDefault<DateTime?>(AppSettings.UserAlarmSettingKeyName, null); }
            set
            {
                AppSettings.AddOrUpdateValue(AppSettings.UserAlarmSettingKeyName, value);
                AppSettings.Save();
            }
        }
    }
}
