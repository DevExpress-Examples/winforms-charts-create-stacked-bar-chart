Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace Series_StackedBarChart
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a new chart.
			Dim stackedBarChart As New ChartControl()

			' Create two stacked bar series.
			Dim series1 As New Series("Series 1", ViewType.StackedBar)
			Dim series2 As New Series("Series 2", ViewType.StackedBar)

			' Add points to them
			series1.Points.Add(New SeriesPoint("A", 10))
			series1.Points.Add(New SeriesPoint("B", 12))
			series1.Points.Add(New SeriesPoint("C", 14))
			series1.Points.Add(New SeriesPoint("D", 17))

			series2.Points.Add(New SeriesPoint("A", 15))
			series2.Points.Add(New SeriesPoint("B", 18))
			series2.Points.Add(New SeriesPoint("C", 25))
			series2.Points.Add(New SeriesPoint("D", 33))

			' Add both series to the chart.
			stackedBarChart.Series.AddRange(New Series() { series1, series2 })

			' Access the view-type-specific options of the series.
			CType(series1.View, StackedBarSeriesView).BarWidth = 0.8

			' Access the type-specific options of the diagram.
			CType(stackedBarChart.Diagram, XYDiagram).Rotated = True

			' Hide the legend (if necessary).
			stackedBarChart.Legend.Visible = False

			' Add a title to the chart (if necessary).
			stackedBarChart.Titles.Add(New ChartTitle())
			stackedBarChart.Titles(0).Text = "A Stacked Bar Chart"

			' Add the chart to the form.
			stackedBarChart.Dock = DockStyle.Fill
			Me.Controls.Add(stackedBarChart)
		End Sub
	End Class
End Namespace