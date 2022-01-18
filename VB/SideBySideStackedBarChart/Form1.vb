Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

' ...
Namespace SideBySideStackedBarChart

    Public Partial Class Form1
        Inherits Form

        Private chart As ChartControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new chart.
            chart = New ChartControl()
            chart.Dock = DockStyle.Fill
            Me.Controls.Add(chart)
            ' Bind the chart to a data source.
            ' Specify data members that the series template uses to
            ' obtain series names, arguments, and values.
            chart.DataSource = GetChartData()
            chart.SeriesTemplate.SeriesDataMember = "Month"
            chart.SeriesTemplate.ArgumentDataMember = "Section"
            chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Value"})
            ' Assign the Side-by-Side Stacked Bar series view to generated series.
            Dim view As SideBySideStackedBarSeriesView = New SideBySideStackedBarSeriesView()
            chart.SeriesTemplate.View = view
            view.BarWidth = 0.6
            'Enable point labels and format their text.
            chart.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
            chart.SeriesTemplate.Label.TextPattern = "{V}"
            ' Customize axes.
            Dim diagram As XYDiagram = TryCast(chart.Diagram, XYDiagram)
            diagram.AxisX.Tickmarks.MinorVisible = False
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
            AddHandler chart.BoundDataChanged, AddressOf Chart_BoundDataChanged
        End Sub

        Private Sub Chart_BoundDataChanged(ByVal sender As Object, ByVal e As EventArgs)
            For Each series As Series In chart.Series
                If series.Points.Count > 0 Then
                    Dim row As DataRowView = TryCast(series.Points(0).Tag, DataRowView)
                    CType(series.View, ISupportStackedGroup).StackedGroup = row("Group")
                End If
            Next
        End Sub

        Public Function GetChartData() As DataTable
            Dim table As DataTable = New DataTable()
            table.Columns.Add("Month", GetType(String))
            table.Columns.Add("Section", GetType(String))
            table.Columns.Add("Value", GetType(Integer))
            table.Columns.Add("Group", GetType(Integer))
            table.Rows.Add(New Object() {"January", "Section1", 10, 1})
            table.Rows.Add(New Object() {"January", "Section2", 20, 1})
            table.Rows.Add(New Object() {"February", "Section1", 20, 1})
            table.Rows.Add(New Object() {"February", "Section2", 30, 2})
            table.Rows.Add(New Object() {"March", "Section1", 15, 2})
            table.Rows.Add(New Object() {"March", "Section2", 25, 1})
            Return table
        End Function
    End Class
End Namespace
