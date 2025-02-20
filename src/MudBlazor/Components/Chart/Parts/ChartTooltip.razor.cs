using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MudBlazor.Charts
{
    public partial class ChartTooltip
    {
        [Parameter, EditorRequired] public string Title { get; set; } = string.Empty;
        [Parameter] public string Subtitle { get; set; } = string.Empty;
        [Parameter, EditorRequired] public double X { get; set; }
        [Parameter, EditorRequired] public double Y { get; set; }
        [Parameter] public string Color { get; set; } = "darkgrey";

        private ElementReference? _hoverTextTitle = null;
        private double _boxWidth = -1;

        private class BBox
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var bboxTitle = await JSRuntime.InvokeAsync<BBox>("mudGetSvgBBox", _hoverTextTitle);

                _boxWidth = Math.Max(bboxTitle.Width, 30) + 10; // Minimum width for the text of 30px with 10px padding (5px each side)

                StateHasChanged();
            }
        }
    }
}
