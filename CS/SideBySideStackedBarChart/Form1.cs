using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace SideBySideStackedBarChart {
    public partial class Form1 : Form {
        ChartControl chart;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            chart = new ChartControl();
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            // Bind the chart to a data source.
            // Specify data members that the series template uses to
            // obtain series names, arguments, and values.
            chart.DataSource = GetChartData();
            chart.SeriesTemplate.SeriesDataMember = "Month";
            chart.SeriesTemplate.ArgumentDataMember = "Section";
            chart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            // Assign the Side-by-Side Stacked Bar series view to generated series.
            SideBySideStackedBarSeriesView view = new SideBySideStackedBarSeriesView();
            chart.SeriesTemplate.View = view;
            view.BarWidth = 0.6;

            //Enable point labels and format their text.
            chart.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chart.SeriesTemplate.Label.TextPattern = "{V}";

            // Customize axes.
            XYDiagram diagram = chart.Diagram as XYDiagram;
            diagram.AxisX.Tickmarks.MinorVisible = false;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;

            chart.BoundDataChanged += Chart_BoundDataChanged;
        }

        private void Chart_BoundDataChanged(object sender, EventArgs e) {
            foreach (Series series in chart.Series) {
                if (series.Points.Count > 0) {
                    DataRowView row = series.Points[0].Tag as DataRowView;
                    ((ISupportStackedGroup)series.View).StackedGroup = row["Group"];
                }
            }
        }

        public DataTable GetChartData() {
            DataTable table = new DataTable();
            table.Columns.Add("Month", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("Value", typeof(int));
            table.Columns.Add("Group", typeof(int));

            table.Rows.Add(new object[] { "January", "Section1", 10, 1 });
            table.Rows.Add(new object[] { "January", "Section2", 20, 1 });
            table.Rows.Add(new object[] { "February", "Section1", 20, 1 });
            table.Rows.Add(new object[] { "February", "Section2", 30, 2 });
            table.Rows.Add(new object[] { "March", "Section1", 15, 2 });
            table.Rows.Add(new object[] { "March", "Section2", 25, 1 });
            return table;
        }
    }
}