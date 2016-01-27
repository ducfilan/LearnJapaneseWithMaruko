using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Grammar;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Hoc_tieng_Nhat_cung_Maruko.View.GrammarSection
{
    public partial class GrammarDetail : PhoneApplicationPage
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string grammarId;

            if (NavigationContext.QueryString.TryGetValue("GrammarId", out grammarId))
            {

                var getGrammarsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
                {
                    CommandText = "SELECT * FROM GRAMMARSDB WHERE LESSON = " + grammarId
                };

                var _lesson = new Grammar()
                {
                    LessonNo = int.Parse(grammarId),
                    ImagePath = grammarId,
                    LessonGrammars = getGrammarsCommand.ExecuteQuery<GRAMMARSDB>()
                };


                DataContext = _lesson;
                LongListSelectorGrammar.ItemsSource = _lesson.LessonGrammars;
            }
        }

        public GrammarDetail()
        {
            InitializeComponent();
        }
    }
}