using System.Diagnostics.Metrics;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

#nullable enable
namespace MudBlazor.Charts
{
    /// <summary>
    /// Represents a chart which displays values as a percentage of a circle.
    /// </summary>
    /// <seealso cref="Bar"/>
    /// <seealso cref="Donut"/>
    /// <seealso cref="Line"/>
    /// <seealso cref="StackedBar"/>
    /// <seealso cref="TimeSeries"/>
    partial class Pie : MudCategoryChartBase
    {
        private const int Radius = 140;

        /// <summary>
        /// The chart, if any, containing this component.
        /// </summary>
        [CascadingParameter]
        public MudChart? MudChartParent { get; set; }

        private List<SvgPath> _paths = [];
        private List<SvgLegend> _legends = [];
        private SvgPath? _hoveredSegment;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            _paths.Clear();
            _legends.Clear();

            if (InputData == null)
                return;

            var normalizedData = GetNormalizedData();
            double cumulativeRadians = Math.PI / 2; // Start at 90 degrees
            for (var i = 0; i < normalizedData.Length; i++)
            {
                var originalData = InputData[i];
                var data = normalizedData[i];
                var startx = Math.Cos(cumulativeRadians);
                var starty = Math.Sin(cumulativeRadians);
                cumulativeRadians += 2 * Math.PI * data;
                var endx = Math.Cos(cumulativeRadians);
                var endy = Math.Sin(cumulativeRadians);
                var largeArcFlag = data > 0.5 ? 1 : 0;
                var path = new SvgPath()
                {
                    Index = i,
                    Data = $"M {ToS(startx * Radius)} {ToS(starty * Radius)} A {Radius} {Radius} 0 {ToS(largeArcFlag)} 1 {ToS(endx * Radius)} {ToS(endy * Radius)} L 0 0"
                };

                // Calculate the midpoint angle
                var midAngle = cumulativeRadians - Math.PI * data;

                // Calculate the midpoint coordinates at half the radius
                var midX = Math.Cos(midAngle) * Radius / 2;
                var midY = Math.Sin(midAngle) * Radius / 2;

                path.LabelX = midX;
                path.LabelY = midY;
                path.LabelXValue = originalData.ToString(CultureInfo.InvariantCulture);
                path.LabelYValue = InputLabels.Length > i ? InputLabels[i] : string.Empty;

                _paths.Add(path);
            }

            for (var i = 0; i < normalizedData.Length; i++)
            {
                var percent = normalizedData[i] * 100;
                var labels = i < InputLabels.Length ? InputLabels[i] : "";
                var legend = new SvgLegend()
                {
                    Index = i,
                    Labels = labels,
                    Data = ToS(Math.Round(percent, 1))
                };
                _legends.Add(legend);
            }
        }

        private void OnSegmentMouseOver(MouseEventArgs _, SvgPath segment)
        {
            _hoveredSegment = segment;
        }

        private void OnSegmentMouseOut(MouseEventArgs _)
        {
            _hoveredSegment = null;
        }
    }
}
