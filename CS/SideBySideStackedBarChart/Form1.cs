using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace SideBySideStackedBarChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl stackedBarChart = new ChartControl();

            // Create four side-by-side stacked bar series.
            Series series1 = new Series("Series 1", ViewType.SideBySideStackedBar);
            Series series2 = new Series("Series 2", ViewType.SideBySideStackedBar);
            Series series3 = new Series("Series 3", ViewType.SideBySideStackedBar);
            Series series4 = new Series("Series 4", ViewType.SideBySideStackedBar);

            // Add points to them
            series1.Points.Add(new SeriesPoint("A", 10));
            series1.Points.Add(new SeriesPoint("B", 12));
            series1.Points.Add(new SeriesPoint("C", 14));
            series1.Points.Add(new SeriesPoint("D", 17));

            series2.Points.Add(new SeriesPoint("A", 15));
            series2.Points.Add(new SeriesPoint("B", 18));
            series2.Points.Add(new SeriesPoint("C", 25));
            series2.Points.Add(new SeriesPoint("D", 33));

            series3.Points.Add(new SeriesPoint("A", 11));
            series3.Points.Add(new SeriesPoint("B", 13));
            series3.Points.Add(new SeriesPoint("C", 15));
            series3.Points.Add(new SeriesPoint("D", 18));

            series4.Points.Add(new SeriesPoint("A", 16));
            series4.Points.Add(new SeriesPoint("B", 19));
            series4.Points.Add(new SeriesPoint("C", 26));
            series4.Points.Add(new SeriesPoint("D", 34));

            // Add all series to the chart.
            stackedBarChart.Series.AddRange(new Series[] { series1, series2, series3, series4 });

            // Group the first two series under the same stack.
            ((SideBySideStackedBarSeriesView)series1.View).StackedGroup = 0;
            ((SideBySideStackedBarSeriesView)series2.View).StackedGroup = 0;

            // Access the type-specific options of the diagram.
            ((XYDiagram)stackedBarChart.Diagram).EnableAxisXZooming = true;

            // Hide the legend (if necessary).
            stackedBarChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add a title to the chart (if necessary).
            stackedBarChart.Titles.Add(new ChartTitle());
            stackedBarChart.Titles[0].Text = "A Side-By-Side Stacked Bar Chart";
            stackedBarChart.Titles[0].WordWrap = true;

            // Add the chart to the form.
            stackedBarChart.Dock = DockStyle.Fill;
            this.Controls.Add(stackedBarChart);
        }

    }
}