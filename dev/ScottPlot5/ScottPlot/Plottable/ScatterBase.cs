﻿using Microsoft.Maui.Graphics;

namespace ScottPlot.Plottable;

public abstract class ScatterBase : IPlottable
{
    public float LineWidth = 1;
    public Color LineColor = Colors.Black;

    public float MarkerSize = 3;
    public Color MarkerColor = Colors.Black;

    protected abstract PointF[] GetPoints(PlotInfo plotInfo);

    public void Draw(ICanvas canvas, PlotInfo plotInfo)
    {
        canvas.ClipRectangle(plotInfo.DataRect.RectangleF);
        PointF[] points = GetPoints(plotInfo);

        canvas.StrokeSize = LineWidth;
        canvas.StrokeColor = LineColor;
        for (int i = 0; i < points.Length - 1; i++)
            canvas.DrawLine(points[i], points[i + 1]);

        canvas.FillColor = MarkerColor;
        for (int i = 0; i < points.Length; i++)
            canvas.FillCircle(points[i], MarkerSize);
    }
}
