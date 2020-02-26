using System;
using System.Collections.Generic;
using System.Windows;

using WpfAppNetCore.SqlData.frame;
using WpfAppNetCore.SqlData.util;
using System.Collections.Specialized;
using LiveCharts;
using LiveCharts.Wpf;


namespace DataGridBinding
{
    /// <summary>
    /// ChartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChartWindow : Window
    {
        public ChartWindow()
        {
            InitializeComponent();
            ShowPieChart();
            ShowCartesian();
        }

        private void ShowPieChart() {
            SeriesCollection sc = lvc_pie_chart.Series;
            FulFillData(sc);
        }

        private void ShowCartesian() {
            SeriesCollection sc = lvc_cartesian_chart.Series;
            AxesCollection ac = lvc_cartesian_chart.AxisX;

            AxesCollection ay = lvc_cartesian_chart.AxisY;
            Axis axisY = new Axis();

            ay.Add(axisY);

            App app = (App)Application.Current;

            MemberCollection members = app.MembersViewModel.Members;
            ChartValues<double> values = new ChartValues<double>();
            Axis axis = new Axis();
            axis.Title = "X title";
            axis.MinWidth = 50;
            ColumnSeries columnSeries = new ColumnSeries {
                Title = "Cartesian",
                Values = values,
            };

            //string[] labelValues = new string[members.Count];
            List<string> labelValues = new List<string>();

            foreach (Member member in members)
            {
                values.Add(member.BindInsto);
                labelValues.Add(member.BindName);

            }
            sc.Add(columnSeries);
            axis.Labels = labelValues;
            axis.Position = AxisPosition.LeftBottom;
            //axis.SetRange(0,2);
            //axis.MinValue = 0;
            //axis.MaxValue = 3;
            axis.IsMerged = true;
            axis.Separator = new Separator() { 
                Step = 1
            };

            Formatter = value => value.ToString("N");
            //axis.LabelFormatter = Formatter;


            ac.Add(axis);
            
        }

        public Func<double, string> Formatter { get; set; }


        private void FulFillData(SeriesCollection sc)
        {
            App app = (App)Application.Current;
            MemberCollection members = app.MembersViewModel.Members;
            foreach (Member member in members)
            {
                sc.Add(new PieSeries
                {
                    Title = member.BindName,
                    Values = new ChartValues<double> { member.BindInsto },
                    DataLabels = true
                });
            }
        }
    }
}
