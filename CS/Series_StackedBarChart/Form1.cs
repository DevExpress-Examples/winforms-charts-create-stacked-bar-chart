using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace Series_StackedBarChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl stackedBarChart = new ChartControl();

            // Create two stacked bar series.
            Series series1 = new Series("Series 1", ViewType.StackedBar);
            Series series2 = new Series("Series 2", ViewType.StackedBar);
            
            // Add points to them
            series1.Points.Add(new SeriesPoint("A", 10));
            series1.Points.Add(new SeriesPoint("B", 12));
            series1.Points.Add(new SeriesPoint("C", 14));
            series1.Points.Add(new SeriesPoint("D", 17));
            
            series2.Points.Add(new SeriesPoint("A", 15));
            series2.Points.Add(new SeriesPoint("B", 18));
            series2.Points.Add(new SeriesPoint("C", 25));
            series2.Points.Add(new SeriesPoint("D", 33));

            // Add both series to the chart.
            stackedBarChart.Series.AddRange(new Series[] { series1, series2 });

            // Access the view-type-specific options of the series.
            ((StackedBarSeriesView)series1.View).BarWidth = 0.8;

            // Access the type-specific options of the diagram.
            ((XYDiagram)stackedBarChart.Diagram).Rotated = true;

            // Hide the legend (if necessary).
            stackedBarChart.Legend.Visible = false;

            // Add a title to the chart (if necessary).
            stackedBarChart.Titles.Add(new ChartTitle());
            stackedBarChart.Titles[0].Text = "A Stacked Bar Chart";

            // Add the chart to the form.
            stackedBarChart.Dock = DockStyle.Fill;
            this.Controls.Add(stackedBarChart);
        }
    }
}