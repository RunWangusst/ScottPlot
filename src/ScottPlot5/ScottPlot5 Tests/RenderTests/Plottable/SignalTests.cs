﻿namespace ScottPlotTests.RenderTests.Plottable;

internal class SignalTests
{
    [Test]
    public void Test_Signal_HorizontalLine()
    {
        // https://github.com/ScottPlot/ScottPlot/issues/2933
        // https://github.com/ScottPlot/ScottPlot/pull/2935

        double[] data = new double[10_000];
        double[] sin = Generate.Sin(data.Length / 10);
        Array.Copy(sin, 0, data, 0, sin.Length);
        Array.Copy(sin, 0, data, data.Length - sin.Length, sin.Length);

        ScottPlot.Plot plt = new();
        var sig = plt.Add.Signal(data);
        sig.LineStyle.AntiAlias = false;
        plt.Grids.Clear();
        plt.SaveTestImage();
    }

    [Test]
    public void Test_Signal_VerticalGap()
    {
        // https://github.com/ScottPlot/ScottPlot/issues/2933
        // https://github.com/ScottPlot/ScottPlot/pull/2935

        double[] data = Generate.Sin(10_000, oscillations: 100);
        for (int i = (int)(data.Length * .3); i < (int)(data.Length * .7); i++)
        {
            data[i] = data[i] + 10;
        }

        ScottPlot.Plot plt = new();
        var sig = plt.Add.Signal(data);
        sig.LineStyle.AntiAlias = false;
        plt.Grids.Clear();
        plt.SaveTestImage();
    }
}
