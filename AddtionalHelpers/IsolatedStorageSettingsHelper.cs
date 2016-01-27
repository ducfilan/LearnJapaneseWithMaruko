using System;
using System.IO.IsolatedStorage;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class AppSettings
    {
        // Our settings
        IsolatedStorageSettings settings;

        // The key names of our settings
        public const string UserAvatarSettingKeyName = "UserAvatarSetting";
        public const string UserNameSettingKeyName = "UserNameSetting";
        public const string UserStatusSettingKeyName = "UserStatusSetting";
        public const string UserDobSettingKeyName = "UserDOBSetting";
        public const string UserAlarmSettingKeyName = "UserAlarmSetting";
        public const string IsFirstTimeSettingKeyName = "IsFirstTimeSetting";
        public const string IsFirstTimeAccessWordListSettingKeyName = "IsFirstTimeAccessWordList";
        public const string PreviousAppVersion = "PreviousAppVersion";
        public const string IsFirstTimeAccessDictionaryDetailSettingKeyName = "IsFirstTimeAccessDictionaryDetail";
        public const string CurrentWordLessonSettingKeyName = "CurrentWordLessonSettingKeyName";
        public const string CurrentGrammarLessonSettingKeyName = "CurrentGrammarLessonSettingKeyName";
        public const string NoOfTotalLessonsSettingKeyName = "NoOfTotalLessonSetting";
        public const string NoOfLearntKanjisSettingKeyName = "NoOfLearntKanjis";
        public const string NoOfTotalKanjisSettingKeyName = "NoOfTotalKanjis";
        public const string NoOfLearntWordsSettingKeyName = "NoOfLearntWords";
        public const string NoOfTotalWordsSettingKeyName = "NoOfTotalWords";
        public const string NoOfTotalGrammarsSettingKeyName = "NoOfTotalGrammars";
        public const string LearningKanjisListSettingKeyName = "LearningKanjisList";
        public const string LearningHiraganasListSettingKeyName = "LearningHiraganasList";
        public const string LearningKatakanasListSettingKeyName = "LearningKatakanasList";
        public const string LearntWordIdsListSettingKeyName = "LearntWordIdsList";
        public const string LearntKanjIdsListSettingKeyName = "LearntKanjIdsList";
        public const string JvdefinitionsListSettingKeyName = "JvdefinitionsList";
        public const string GrammarsSettingKeyName = "Grammars";
        public const string KanjiDictWordsSettingKeyName = "KanjiDictWords";
        public const string HiraganasListSettingKeyName = "HiraganasList";
        public const string KatakanasListSettingKeyName = "KatakanasList";
        public const string LessonWordsSettingKeyName = "LessonWords";
        public const string JlptLevelSettingKeyName = "JlptLevelSettingKeyName";
         public const string DataTestSettingKeyName = "DataTestSettingKeyName";
       
        // The default value of our settings

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings()
        {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(key))
            {
                // If the value has changed
                if (settings[key] != value)
                {
                    // Store the new value
                    settings[key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(key, value);
                valueChanged = true;
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(key))
            {
                value = (T)settings[key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }


        /// <summary>
        /// Property to get and set a CheckBox Setting Key.
        /// </summary>
        //public bool CheckBoxSetting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<bool>(CheckBoxSettingKeyName, CheckBoxSettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(CheckBoxSettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}


        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        //public int ListBoxSetting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<int>(ListBoxSettingKeyName, ListBoxSettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(ListBoxSettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        //public bool RadioButton1Setting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<bool>(RadioButton1SettingKeyName, RadioButton1SettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(RadioButton1SettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        //public bool RadioButton2Setting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<bool>(RadioButton2SettingKeyName, RadioButton2SettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(RadioButton2SettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}

        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        //public bool RadioButton3Setting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<bool>(RadioButton3SettingKeyName, RadioButton3SettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(RadioButton3SettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}

        /// <summary>
        /// Property to get and set a Username Setting Key.
        /// </summary>
        //public string UsernameSetting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<string>(UsernameSettingKeyName, UsernameSettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(UsernameSettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}

        // <summary>
        // Property to get and set a Password Setting Key.
        // </summary>
        //public string PasswordSetting
        //{
        //    get
        //    {
        //        return GetValueOrDefault<string>(PasswordSettingKeyName, PasswordSettingDefault);
        //    }
        //    set
        //    {
        //        if (AddOrUpdateValue(PasswordSettingKeyName, value))
        //        {
        //            Save();
        //        }
        //    }
        //}
    }
}