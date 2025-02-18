using Microsoft.AspNetCore.Components;

#nullable enable
namespace MudBlazor
{
    public abstract class MudCategoryAxisChartBase : MudCategoryChartBase
    {
        protected const double HorizontalStartSpace = 30.0;
        protected const double HorizontalEndSpace = 30.0;
        protected const double VerticalStartSpace = 25.0;
        protected const double VerticalEndSpace = 25.0;

        protected const double BoundWidthDefault = 650.0;
        protected const double BoundHeightDefault = 350.0;
        protected double BoundWidth = 650.0;
        protected double BoundHeight = 350.0;

        /// <summary>
        /// The chart, if any, containing this component.
        /// </summary>
        [CascadingParameter]
        public MudChart? MudChartParent { get; set; }

        [CascadingParameter]
        public MudAxisChartOptions AxisChartOptions { get; set; } = new();

        protected void SetBounds()
        {
            BoundWidth = BoundWidthDefault;
            BoundHeight = BoundHeightDefault;

            if (MudChartParent != null && AxisChartOptions.MatchBoundsToSize == true)
            {
                if (MudChartParent.Width.EndsWith("px")
                    && MudChartParent.Height.EndsWith("px")
                    && double.TryParse(MudChartParent.Width.AsSpan(0, MudChartParent.Width.Length - 2), out var width)
                    && double.TryParse(MudChartParent.Height.AsSpan(0, MudChartParent.Height.Length - 2), out var height))
                {
                    BoundWidth = width;
                    BoundHeight = height;
                }
            }
        }
    }
}
