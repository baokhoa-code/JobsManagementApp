using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace JobsManagementApp.ViewModel;


[ObservableObject]
public partial class MainViewModel
{
    public MainViewModel()
    {

        // you could convert any IEnumerable to a pie series collection
        var data1 = new double[] { 2, 4, 1 };

        // Series = data.AsLiveChartsPieSeries(); this could be enough in some cases 
        // but you can customize the series properties using the following overload: 

        Series1 = data1.AsLiveChartsPieSeries((value, series) =>
        {
            // here you can configure the series assigned to each value.
            series.Name = $"Lam viec {value}";
            series.DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255));
            series.DataLabelsSize = 12;
            series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle;
            series.DataLabelsFormatter = p => $"{p.StackedValue.Share:P2}";
        });
        Series2 = new ISeries[]
       {
             new LineSeries<double>
            {
                Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                Fill = null
            },
              new LineSeries<double>
            {
                Values = new double[] { 1, 6, 5, 4, 6, 1, 3 },
                Fill = null
            },
               new LineSeries<double>
            {
                Values = new double[] { 6, 5, 4, 4, 3, 1, 2 },
                Fill = null,
                DataLabelsSize = 12,
                DataLabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),

            },
       };
        // this is an equivalent and more verbose syntax. 
        // Series = new ISeries[]
        // {
        //     new PieSeries<double> { Values = new double[] { 2 }, Name = "Slice 1" },
        //     new PieSeries<double> { Values = new double[] { 4 }, Name = "Slice 2" },
        //     new PieSeries<double> { Values = new double[] { 1 }, Name = "Slice 3" },
        //     new PieSeries<double> { Values = new double[] { 4 }, Name = "Slice 4" },
        //     new PieSeries<double> { Values = new double[] { 3 }, Name = "Slice 5" }
        // };
    }

    public IEnumerable<ISeries> Series1 { get; set; }
    public IEnumerable<ISeries> Series2 { get; set; }
}