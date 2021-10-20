Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

Namespace Series_StackedBarChart

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a chart and add it to the form:
            Dim chart As ChartControl = New ChartControl()
            chart.Dock = DockStyle.Fill
            Me.Controls.Add(chart)
            ' Bind the chart to a data source:
            chart.DataSource = DataPoint.GetDataPoints()
            chart.SeriesTemplate.ChangeView(ViewType.StackedBar)
            chart.SeriesTemplate.SeriesDataMember = "Company"
            chart.SeriesTemplate.SetDataMembers("Product", "Income")
            ' Enable series point labels, specify their text pattern and position:
            chart.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
            chart.SeriesTemplate.Label.TextPattern = "${V}M"
            CType(chart.SeriesTemplate.Label, BarSeriesLabel).Position = BarSeriesLabelPosition.Center
            ' Customize series view settings (for example, bar width):
            Dim view As StackedBarSeriesView = CType(chart.SeriesTemplate.View, StackedBarSeriesView)
            view.BarWidth = 0.8
            ' Disable minor tickmarks on the x-axis:
            Dim diagram As XYDiagram = CType(chart.Diagram, XYDiagram)
            diagram.AxisX.Tickmarks.MinorVisible = False
            ' Add a chart title:
            chart.Titles.Add(New ChartTitle With {.Text = "Sales by Products"})
            ' Specify legend settings:
            chart.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside
        End Sub

        Public Class DataPoint

            Public Property Product As String

            Public Property Income As Double

            Public Property Company As String

            Public Sub New(ByVal product As String, ByVal income As Double, ByVal company As String)
                Me.Product = product
                Me.Income = income
                Me.Company = company
            End Sub

            Public Shared Function GetDataPoints() As List(Of DataPoint)
                Dim data As List(Of DataPoint) = New List(Of DataPoint) From {New DataPoint("Camera", 34.96, "DevAV North"), New DataPoint("Camcorder", 56.26, "DevAV North"), New DataPoint("Flash", 45.982, "DevAV North"), New DataPoint("Smartphone", 67.14, "DevAV North"), New DataPoint("Smart Watch", 51.23, "DevAV North"), New DataPoint("Television", 57.443, "DevAV North"), New DataPoint("Home Audio", 45.83, "DevAV North"), New DataPoint("Headphone", 51.23, "DevAV North"), New DataPoint("Camera", 56.48, "DevAV South"), New DataPoint("Camcorder", 35.123, "DevAV South"), New DataPoint("Flash", 36.16, "DevAV South"), New DataPoint("Smartphone", 39.1, "DevAV South"), New DataPoint("Smart Watch", 34.6, "DevAV South"), New DataPoint("Television", 56.16, "DevAV South"), New DataPoint("Home Audio", 35.38, "DevAV South"), New DataPoint("Headphone", 58.1, "DevAV South")}
                Return data
            End Function
        End Class
    End Class
End Namespace
