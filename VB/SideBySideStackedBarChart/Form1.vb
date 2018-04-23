Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace SideBySideStackedBarChart
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Create a new chart.
            Dim stackedBarChart As New ChartControl()

            ' Create four side-by-side stacked bar series.
            Dim series1 As New Series("Series 1", ViewType.SideBySideStackedBar)
            Dim series2 As New Series("Series 2", ViewType.SideBySideStackedBar)
            Dim series3 As New Series("Series 3", ViewType.SideBySideStackedBar)
            Dim series4 As New Series("Series 4", ViewType.SideBySideStackedBar)

            ' Add points to them
            series1.Points.Add(New SeriesPoint("A", 10))
            series1.Points.Add(New SeriesPoint("B", 12))
            series1.Points.Add(New SeriesPoint("C", 14))
            series1.Points.Add(New SeriesPoint("D", 17))

            series2.Points.Add(New SeriesPoint("A", 15))
            series2.Points.Add(New SeriesPoint("B", 18))
            series2.Points.Add(New SeriesPoint("C", 25))
            series2.Points.Add(New SeriesPoint("D", 33))

            series3.Points.Add(New SeriesPoint("A", 11))
            series3.Points.Add(New SeriesPoint("B", 13))
            series3.Points.Add(New SeriesPoint("C", 15))
            series3.Points.Add(New SeriesPoint("D", 18))

            series4.Points.Add(New SeriesPoint("A", 16))
            series4.Points.Add(New SeriesPoint("B", 19))
            series4.Points.Add(New SeriesPoint("C", 26))
            series4.Points.Add(New SeriesPoint("D", 34))

            ' Add all series to the chart.
            stackedBarChart.Series.AddRange(New Series() { series1, series2, series3, series4 })

            ' Group the first two series under the same stack.
            CType(series1.View, SideBySideStackedBarSeriesView).StackedGroup = 0
            CType(series2.View, SideBySideStackedBarSeriesView).StackedGroup = 0

            ' Access the type-specific options of the diagram.
            CType(stackedBarChart.Diagram, XYDiagram).EnableAxisXZooming = True

            ' Hide the legend (if necessary).
            stackedBarChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

            ' Add a title to the chart (if necessary).
            stackedBarChart.Titles.Add(New ChartTitle())
            stackedBarChart.Titles(0).Text = "A Side-By-Side Stacked Bar Chart"
            stackedBarChart.Titles(0).WordWrap = True

            ' Add the chart to the form.
            stackedBarChart.Dock = DockStyle.Fill
            Me.Controls.Add(stackedBarChart)
        End Sub

    End Class
End Namespace