using Microsoft.AspNetCore.Components;

#nullable enable
namespace MudBlazor
{
    public abstract class MudTimeSeriesChartBase : MudChartBase
    {
        /// <summary>
        /// The series of values to display.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public List<TimeSeriesChartSeries> ChartSeries { get; set; } = [];

        /// <summary>
        /// A way to have minimum spacing between timestamp labels, default of 5 minutes.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public TimeSpan TimeLabelSpacing { get; set; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// A way to have the timestamp labels be rounded to the nearest spacing value. Default is false.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public bool TimeLabelSpacingRounding { get; set; }

        /// <summary>
        /// When TimeLabelSpacingRounding is true, 
        /// When true: move to allow rounding (which can result in gaps on either side of the chart).
        /// When false: move the labels inwards to be rounded to the label spacing.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public bool TimeLabelSpacingRoundingMoveSeries { get; set; }

        /// <summary>
        /// A way to specify datetime formats for timestamp labels, default of HH:mm.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public string TimeLabelFormat { get; set; } = "HH:mm";

        /// <summary>
        /// Specifies the title for the X axis.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public string? XAxisTitle { get; set; }

        /// <summary>
        /// Specifies the title for the Y axis.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public string? YAxisTitle { get; set; }
    }
}
