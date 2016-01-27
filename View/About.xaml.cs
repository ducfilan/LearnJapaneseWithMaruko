using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Hoc_tieng_Nhat_cung_Maruko.View
{
    public partial class About : PhoneApplicationPage
    {


        public About()
        {
            InitializeComponent();

            Loaded += About_Loaded;
        }

        void About_Loaded(object sender, RoutedEventArgs e)
        {
            DrawPolylines();
        }

        private void DrawPolylines()
        {
            var descriptionPanelWidth = StackPanelDescription.ActualWidth;
            int noOfLines = (int)descriptionPanelWidth / 20 + 1;

            for (int i = 0; i < noOfLines; i++)
            {
                var line = new Polyline()
                {
                    Points = new PointCollection()
                    {
                        new Point(20,0),
                        new Point(10,10),
                        new Point(0,0)
                    },
                    Fill = new SolidColorBrush(ColorHelper.ConvertStringToColor("#F2F1EF"))
                };

                StackPanelDescription.Children.Add(line);
            }
        }
    }
}