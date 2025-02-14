
using Microsoft.AspNetCore.Components;

namespace MudBlazor;

#nullable enable
/// <summary>
/// Represents a graphic display of data values in a line, bar, stacked bar, pie, heat map, or donut shape.
/// </summary>
public partial class MudChart
{

    /// <summary>
    /// Specifies the chart should take its bounds from the parent chart.
    /// </summary>
    [Parameter]
    [Category(CategoryTypes.Chart.Behavior)]
    public bool MatchBoundsToSize { get; set; }
}
