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
        /// When true: pad series to allow rounding with labels before and after the series start/end.
        /// When false: move the labels inwards to be rounded to the label spacing without changing the start/end time of the axis.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public bool TimeLabelSpacingRoundingPadSeries { get; set; }

        /// <summary>
        /// A way to specify datetime formats for timestamp labels, default of HH:mm.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public string TimeLabelFormat { get; set; } = "HH:mm";

        /// <summary>
        /// A way to specify datetime formats for timestamp labels used in datapoint marker labels, default of HH:mm.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        public string DataMarkerTooltipTimeLabelFormat { get; set; } = "HH:mm";

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

        /// <summary>
        /// Specifies the chart should take its bounds from the parent chart.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Chart.Behavior)]
        [Obsolete("Use MatchBoundsToSize from the MudChartParents AxisChartOptions.MatchBoundsToSize instead. This will be removed in a future major version.", false)]
        public bool MatchBoundsToSize { get; set; }
    }
}
