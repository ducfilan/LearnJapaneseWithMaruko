using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;
using Hoc_tieng_Nhat_cung_Maruko.Model.Kanji;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using Windows.UI;
using Hoc_tieng_Nhat_cung_Maruko.View.UserControls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class DetailViewDictionaryWord : PhoneApplicationPage
    {
        public DetailViewDictionaryWord()
        {
            InitializeComponent();
            var dw = (JVDEFINITIONSDB)PhoneApplicationService.Current.State["WordResult"];
            var word = WordHelper.ParseDefinition(dw);
            DataContext = word;
            Loaded += DetailViewDictionaryWord_Loaded;
        }

        void DetailViewDictionaryWord_Loaded(object sender, RoutedEventArgs e)
        {
            if (Common.IsFirstTimeAccessDictionaryDetail != 1) return;
            GridGuideUser.Visibility = Visibility.Visible;

            Common.IsFirstTimeAccessDictionaryDetail = 0;
        }
        
        private void TapAndHoldGesture(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            if (sender is TextBlock)
            {
                TextToSpeechHelper.SpeakJapaneseText((sender as TextBlock).Text);
                return;
            }
            TextToSpeechHelper.SpeakJapaneseText(((JvDictWord)PhoneApplicationService.Current.State["WordResult"]).Term);
        }

        private void TextBlockKanjiTerm_OnTap(object sender, GestureEventArgs e)
        {
            var textBlockKanji = sender as TextBlock;
            if (textBlockKanji == null || textBlockKanji.Text.Trim().Equals(string.Empty)) return;

            var getKanjiCmd = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM KANJIDICTDB WHERE "
            };


            foreach (char ch in textBlockKanji.Text.Where(WordHelper.IsKanjiChar).Distinct())
            {
                getKanjiCmd.CommandText += "TERM = '" + ch + "' OR ";
            }

            getKanjiCmd.CommandText = getKanjiCmd.CommandText.Substring(0, getKanjiCmd.CommandText.LastIndexOf("OR ", StringComparison.Ordinal));

            List<KANJIDICTDB> kanjisInWord = getKanjiCmd.ExecuteQuery<KANJIDICTDB>();

            if (kanjisInWord.Count == 0)
            {
                return;
            }

            if (kanjisInWord.Count == 1)
            {
                NavigationService.Navigate(new Uri("/View/KanjiSection/KanjiDetailView.xaml?KanjiTerm=" + kanjisInWord[0].TERM.Trim(), UriKind.Relative));
                return;
            }

            PhoneApplicationService.Current.State["KanjisFromDictionary"] = kanjisInWord;
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/View/KanjiSection/KanjisListView.xaml", UriKind.Relative));
        }

        private void GridGuideUser_OnTap(object sender, GestureEventArgs e)
        {
            GridGuideUser.Visibility = Visibility.Collapsed;
        }
    }
}