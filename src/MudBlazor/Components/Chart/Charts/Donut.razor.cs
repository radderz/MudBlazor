using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

#nullable enable
namespace MudBlazor.Charts
{
    /// <summary>
    /// Represents a chart which displays values as ring shape.
    /// </summary>
    /// <seealso cref="Bar"/>
    /// <seealso cref="Line"/>
    /// <seealso cref="Pie"/>
    /// <seealso cref="StackedBar"/>
    /// <seealso cref="TimeSeries"/>
    [Obsolete("Use Pie instead with a CircleDonutRatio of 0.25. This will be removed in a future major version", false)]
    partial class Donut : MudCategoryChartBase
    {
        private const int Radius = 140;
        private const int RadiusInner = 120;
        private static double StrokeWidth => RadiusInner / 4;
        /// <summary>
        /// The chart, if any, containing this component.
        /// </summary>
        [CascadingParameter]
        public MudChart? MudChartParent { get; set; }

        private List<SvgCircle> _circles = [];
        private List<SvgLegend> _legends = [];
        private SvgCircle? _hoveredSegment;

        protected string? ParentWidth => MudChartParent?.Width;
        protected string? ParentHeight => MudChartParent?.Height;

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            _circles.Clear();
            _legends.Clear();

            if (InputData == null)
                return;

            double totalPercent = 0;
            double fullCircumference = 2 * Math.PI * RadiusInner;

            var normalizedData = GetNormalizedData();
            for (var i = 0; i < InputData.Length; i++)
            {
                var originalData = InputData[i];
                var data = normalizedData[i];

                var percent = data * 100;
                var reversePercent = 100 - percent;
                totalPercent += percent;

                var circle = new SvgCircle()
                {
                    Index = i,
                    CX = 0,
                    CY = 0,
                    Radius = RadiusInner,
                    StrokeDashArray = $"{ToS(fullCircumference * percent / 100)} {ToS(fullCircumference * reversePercent / 100)}",
                    StrokeDashOffset = fullCircumference * totalPercent / 100 - fullCircumference / 4, //  "- fullCircumference / 4" shifts the start to the top
                };

                // Calculate the midpoint angle (in radians)
                var midAngle = ((totalPercent - (percent / 2)) / 100 * 2 * Math.PI) - (Math.PI / 2);

                // Calculate the label's coordinates
                var midX = Math.Cos(midAngle) * RadiusInner;
                var midY = -Math.Sin(midAngle) * RadiusInner;

                circle.LabelX = midX;
                circle.LabelY = midY;
                circle.LabelXValue = originalData.ToString(CultureInfo.InvariantCulture);
                circle.LabelYValue = InputLabels.Length > i ? InputLabels[i] : string.Empty;

                _circles.Add(circle);

                var labels = i < InputLabels.Length ? InputLabels[i] : "";
                var legend = new SvgLegend()
                {
                    Index = i,
                    Labels = labels,
                    Data = data.ToString()
                };
                _legends.Add(legend);
            }
        }

        private void OnSegmentMouseOver(MouseEventArgs _, SvgCircle segment)
        {
            _hoveredSegment = segment;
        }

        private void OnSegmentMouseOut(MouseEventArgs _)
        {
            _hoveredSegment = null;
        }
    }
}
