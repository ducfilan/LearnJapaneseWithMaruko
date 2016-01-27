using System.Threading;
using System.Threading.Tasks;
using Hoc_tieng_Nhat_cung_Maruko.Model.Dictionary.JapToVie;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using System.ComponentModel;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Hoc_tieng_Nhat_cung_Maruko.View.UserControls
{
    public partial class DictionaryJv : System.Windows.Controls.UserControl
    {
        public List<JvDictWord> JvDictWords;

        public DictionaryJv()
        {
            InitializeComponent();

            Loaded += (sender, args) => ResultListBox.ItemsSource = FullTextSearch();
        }

        private void ClearButton_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.TextBoxSearch.Text = "";
            this.TextBoxSearch.Focus();
        }

        private async void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = TextBoxSearch.Text;

            var searchingTask = Task.Delay(500);
            ResultListBox.ItemsSource = await searchingTask.ContinueWith(task => FullTextSearch(keyword));
        }

        private List<JVDEFINITIONSDB> FullTextSearch(string keyword = "")
        {
            if (keyword.Equals(string.Empty))
            {
                var getJvDictCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("MarukoDict.db3"))
                {
                    CommandText = "SELECT * FROM JVDEFINITIONSDB LIMIT 200"
                };
                return getJvDictCommand.ExecuteQuery<JVDEFINITIONSDB>();
            }

            string s = WordHelper.Convert(WordHelper.RemoveSpecialCharacters(keyword.Trim()), WordHelper.Mode.Hiragana);

            var getJvCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("MarukoDict.db3"))
            {
                CommandText = "SELECT * FROM JVDEFINITIONSDB  WHERE TERM MATCH '" + s + "*'"
            };

            return getJvCommand.ExecuteQuery<JVDEFINITIONSDB>();
        }

        private void UIElement_OnTap(object sender, GestureEventArgs e)
        {
            var border = sender as Border;
            if (border == null) return;

            var selectedWord = border.DataContext as JVDEFINITIONSDB;

            PhoneApplicationService.Current.State["WordResult"] = selectedWord;
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/View/DetailViewDictionaryWord.xaml", UriKind.Relative));
        }
    }
}
