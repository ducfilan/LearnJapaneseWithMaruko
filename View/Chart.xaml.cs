using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Test;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class Chart : PhoneApplicationPage
    {
        public Chart()
        {
            InitializeComponent();
            Loaded += Chart_Loaded;
        }

        void Chart_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            LoadCurrentLearningStatus();
        }


        public List<TestDataItem> Data { get { return Common.DataTest; } }
       
        private void LoadCurrentLearningStatus()
        {
            TextBlockCurrentLesson.Text = Common.CurrentWordLesson + "";
            TextBlockLearntKanjis.Text = Common.LearntKanjiIdsList.Count + "";
            TextBlockLeartWords.Text = Common.LearntWordIdsList.Count + "";
            if (Common.DataTest!=null){
                TextBlockTotalTest.Text = Common.DataTest.Count + "";
            }
            else
            {
                TextBlockTotalTest.Text = "0";
            }
           

            LoadLearningProgressBars();
        }

        private void LoadLearningProgressBars()
        {
            ProgressCurrentLesson.Width = ProgresNoOfsAllLesson.RenderSize.Width * Common.CurrentWordLesson / Common.NoOfTotalLessons;
            ProgressLearntKanjis.Width = ProgressNoOfAllKanjis.RenderSize.Width * Common.LearntKanjiIdsList.Count / Common.NoOfTotalKanjis;
        }
    }
}