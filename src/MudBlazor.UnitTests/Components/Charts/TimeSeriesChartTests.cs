// Copyright (c) MudBlazor 2021
// MudBlazor licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System.Diagnostics;
using Bunit;
using FluentAssertions;
using MudBlazor.Charts;
using MudBlazor.UnitTests.Components;
using NUnit.Framework;

namespace MudBlazor.UnitTests.Charts
{
    public class TimeSeriesChartTests : BunitTest
    {
        const string TimeSeriesMarkupBasic = "<div class=\"mud-chart mud-chart-legend-bottom\" dir=\"ltr\"><svg class=\"mud-chart-line mud-ltr\" width=\"80%\" height=\"80%\" viewBox=\"0 0 800 350\"><g class=\"mud-charts-grid\"><g class=\"mud-charts-gridlines-yaxis\"><path stroke=\"#e0e0e0\" stroke-width=\"0.3\" d=\"M 80 325 L 720 325\"></path></g></g>\n    <g class=\"mud-charts-yaxis\"><text x='70' y='330' font-size='12px' text-anchor='end' dominant-baseline='auto'>1000</text></g>\n    <g class=\"mud-charts-xaxis\"><text x='80' y='348' font-size='12px' text-anchor='middle'>23:00</text><text x='400' y='348' font-size='12px' text-anchor='middle'>00:00</text><text x='720' y='348' font-size='12px' text-anchor='middle'>01:00</text></g>\n    <g class=\"mud-charts-line-series\"><path class=\"mud-chart-line\" blazor:onclick=\"1\" fill=\"none\" stroke=\"#2979FF\" stroke-opacity=\"1\" stroke-width=\"3\" d=\"M 80 325 L 293.3333333333333 325 L 506.66666666666663 325 L 720 325\"></path></g>\n\n    </svg><div class=\"mud-chart-legend\"><div class=\"mud-chart-legend-item\" blazor:onclick=\"2\" blazor:onclick:stopPropagation><span class=\"mud-chart-legend-marker\" style=\"background-color:#2979FF\"></span>\n                    <span class=\"mud-typography mud-typography-body2\">Series 1</span></div></div></div>";
        const string TimeSeriesMarkupMatchBounds = "<div class=\"mud-chart mud-chart-legend-bottom\" dir=\"ltr\"><svg class=\"mud-chart-line mud-ltr\" width=\"1000px\" height=\"400px\" viewBox=\"0 0 1000 400\"><g class=\"mud-charts-grid\"><g class=\"mud-charts-gridlines-yaxis\"><path stroke=\"#e0e0e0\" stroke-width=\"0.3\" d=\"M 80 375 L 920 375\"></path></g></g>\n    <g class=\"mud-charts-yaxis\"><text x='70' y='380' font-size='12px' text-anchor='end' dominant-baseline='auto'>1000</text></g>\n    <g class=\"mud-charts-xaxis\"><text x='80' y='398' font-size='12px' text-anchor='middle'>23:00</text><text x='500' y='398' font-size='12px' text-anchor='middle'>00:00</text><text x='920' y='398' font-size='12px' text-anchor='middle'>01:00</text></g>\n    <g class=\"mud-charts-line-series\"><path class=\"mud-chart-line\" blazor:onclick=\"1\" fill=\"none\" stroke=\"#2979FF\" stroke-opacity=\"1\" stroke-width=\"3\" d=\"M 80 375 L 360 375 L 640 375 L 920 375\"></path></g>\n\n    </svg><div class=\"mud-chart-legend\"><div class=\"mud-chart-legend-item\" blazor:onclick=\"2\" blazor:onclick:stopPropagation><span class=\"mud-chart-legend-marker\" style=\"background-color:#2979FF\"></span>\n                    <span class=\"mud-typography mud-typography-body2\">Series 1</span></div></div></div>";
        const string TimeSeriesMarkupTimeLabelSpacingRounding = "<div class=\"mud-chart mud-chart-legend-bottom\" dir=\"ltr\"><svg class=\"mud-chart-line mud-ltr\" width=\"80%\" height=\"80%\" viewBox=\"0 0 800 350\"><g class=\"mud-charts-grid\"><g class=\"mud-charts-gridlines-yaxis\"><path stroke=\"#e0e0e0\" stroke-width=\"0.3\" d=\"M 80 325 L 720 325\"></path></g></g>\n    <g class=\"mud-charts-yaxis\"><text x='70' y='330' font-size='12px' text-anchor='end' dominant-baseline='auto'>1000</text></g>\n    <g class=\"mud-charts-xaxis\"><text x='257.77777777777777' y='348' font-size='12px' text-anchor='middle'>00:00</text><text x='577.7777777777778' y='348' font-size='12px' text-anchor='middle'>01:00</text></g>\n    <g class=\"mud-charts-line-series\"><path class=\"mud-chart-line\" blazor:onclick=\"1\" fill=\"none\" stroke=\"#2979FF\" stroke-opacity=\"1\" stroke-width=\"3\" d=\"M 80 325 L 293.3333333333333 325 L 506.66666666666663 325 L 720 325\"></path></g>\n\n    </svg><div class=\"mud-chart-legend\"><div class=\"mud-chart-legend-item\" blazor:onclick=\"2\" blazor:onclick:stopPropagation><span class=\"mud-chart-legend-marker\" style=\"background-color:#2979FF\"></span>\n                    <span class=\"mud-typography mud-typography-body2\">Series 1</span></div></div></div>";
        const string TimeSeriesMarkupTimeLabelSpacingRoundingPadSeries = "<div class=\"mud-chart mud-chart-legend-bottom\" dir=\"ltr\"><svg class=\"mud-chart-line mud-ltr\" width=\"80%\" height=\"80%\" viewBox=\"0 0 800 350\"><g class=\"mud-charts-grid\"><g class=\"mud-charts-gridlines-yaxis\"><path stroke=\"#e0e0e0\" stroke-width=\"0.3\" d=\"M 80 325 L 720 325\"></path></g></g>\n    <g class=\"mud-charts-yaxis\"><text x='70' y='330' font-size='12px' text-anchor='end' dominant-baseline='auto'>1000</text></g>\n    <g class=\"mud-charts-xaxis\"><text x='80' y='348' font-size='12px' text-anchor='middle'>23:00</text><text x='293.33333333333337' y='348' font-size='12px' text-anchor='middle'>00:00</text><text x='506.6666666666667' y='348' font-size='12px' text-anchor='middle'>01:00</text><text x='720' y='348' font-size='12px' text-anchor='middle'>02:00</text></g>\n    <g class=\"mud-charts-line-series\"><path class=\"mud-chart-line\" blazor:onclick=\"1\" fill=\"none\" stroke=\"#2979FF\" stroke-opacity=\"1\" stroke-width=\"3\" d=\"M 106.66666666666666 325 L 266.6666666666667 325 L 426.66666666666663 325 L 586.6666666666666 325\"></path></g>\n\n    </svg><div class=\"mud-chart-legend\"><div class=\"mud-chart-legend-item\" blazor:onclick=\"2\" blazor:onclick:stopPropagation><span class=\"mud-chart-legend-marker\" style=\"background-color:#2979FF\"></span>\n                    <span class=\"mud-typography mud-typography-body2\">Series 1</span></div></div></div>";

        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void TimeSeriesChartBasicExample()
        {
            var time = new DateTime(2000, 1, 1);

            var comp = Context.RenderComponent<MudTimeSeriesChart>(parameters => parameters
                .Add(p => p.ChartSeries, [
                    new ()
                    {
                        Index = 0,
                        Name = "Series 1",
                        Data = new[] {-1, 0, 1, 2}.Select(x => new TimeSeriesChartSeries.TimeValue(time.AddHours(x), 1000)).ToList(),
                        IsVisible = true,
                        Type = TimeSeriesDisplayType.Line
                    }
                ])
                .Add(p => p.TimeLabelSpacing, TimeSpan.FromHours(1)));

            comp.Markup.Should().BeEquivalentTo(TimeSeriesMarkupBasic);
        }



        [Test]
        public void TimeSeriesChartMatchBounds()
        {
            var time = new DateTime(2000, 1, 1);

            var comp = Context.RenderComponent<MudTimeSeriesChart>(parameters => parameters
                .Add(p => p.ChartSeries, [
                    new ()
                    {
                        Index = 0,
                        Name = "Series 1",
                        Data = new[] {-1, 0, 1, 2}.Select(x => new TimeSeriesChartSeries.TimeValue(time.AddHours(x), 1000)).ToList(),
                        IsVisible = true,
                        Type = TimeSeriesDisplayType.Line
                    }
                ])
                .Add(p => p.TimeLabelSpacing, TimeSpan.FromHours(1))
                .Add(p => p.Width, "1000px")
                .Add(p => p.Height, "400px")
                .Add(p => p.MatchBoundsToSize, true));

            comp.Markup.Should().BeEquivalentTo(TimeSeriesMarkupMatchBounds);
        }

        [Test]
        public void TimeSeriesChartTimeLabelSpacingRounding()
        {
            var time = new DateTime(2000, 1, 1);

            var comp = Context.RenderComponent<MudTimeSeriesChart>(parameters => parameters
                .Add(p => p.ChartSeries, [
                    new ()
                    {
                        Index = 0,
                        Name = "Series 1",
                        Data = new[] {-1, 0, 1, 2}.Select(x => new TimeSeriesChartSeries.TimeValue(time.AddHours(x).AddMinutes(10), 1000)).ToList(),
                        IsVisible = true,
                        Type = TimeSeriesDisplayType.Line
                    }
                ])
                .Add(p => p.TimeLabelSpacing, TimeSpan.FromHours(1))
                .Add(p => p.TimeLabelSpacingRounding, true));

            comp.Markup.Should().BeEquivalentTo(TimeSeriesMarkupTimeLabelSpacingRounding);
        }

        [Test]
        public void TimeSeriesChartTimeLabelSpacingRoundingPadSeries()
        {
            var time = new DateTime(2000, 1, 1);

            var comp = Context.RenderComponent<MudTimeSeriesChart>(parameters => parameters
                .Add(p => p.ChartSeries, [
                    new ()
                    {
                        Index = 0,
                        Name = "Series 1",
                        Data = new[] {-1, 0, 1, 2}.Select(x => new TimeSeriesChartSeries.TimeValue(time.AddHours(x).AddMinutes(10), 1000)).ToList(),
                        IsVisible = true,
                        Type = TimeSeriesDisplayType.Line
                    }
                ])
                .Add(p => p.TimeLabelSpacing, TimeSpan.FromHours(1))
                .Add(p => p.TimeLabelSpacingRounding, true)
                .Add(p => p.TimeLabelSpacingRoundingPadSeries, true));

            comp.Markup.Should().BeEquivalentTo(TimeSeriesMarkupTimeLabelSpacingRoundingPadSeries);
        }

        [Test]
        public void TimeSeriesChartEmptyData()
        {
            var comp = Context.RenderComponent<TimeSeries>();
            comp.Markup.Should().Contain("mud-chart-line");
        }

        [Test]
        public void TimeSeriesChartLabelFormats()
        {
            var time = new DateTime(2000, 1, 1);
            var format = "dd/MM HH:mm";

            var comp = Context.RenderComponent<MudTimeSeriesChart>(parameters => parameters
                .Add(p => p.ChartSeries, new List<TimeSeriesChartSeries>() {
                    new TimeSeriesChartSeries()
                    {
                        Index = 0,
                        Name = "Series 1",
                        Data = new[] {-1, 0, 1, 2}.Select(x => new TimeSeriesChartSeries.TimeValue(time.AddDays(x), 1000)).ToList(),
                        IsVisible = true,
                        LineDisplayType = LineDisplayType.Line
                    }
                })
                .Add(p => p.TimeLabelSpacing, TimeSpan.FromDays(1))
                .Add(p => p.TimeLabelFormat, format));

            for (var i = -1; i < 2; i++)
            {
                var expectedTimeString = time.AddDays(i).ToString(format);
                comp.Markup.Should().Contain(expectedTimeString);
            }
        }
    }
}
