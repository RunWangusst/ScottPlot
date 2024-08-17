using ScottPlot;
using ScottPlot.Plottables;

namespace WinForms_Demo.Demos;

public partial class DraggablePoints : Form, IDemoWindow
{
    public string Title => "Draggable Data Points";

    public string Description => "GUI events can be used to interact with data " +
        "drawn on the plot. This example shows how to achieve drag-and-drop behavior " +
        "for points of a scatter plot. Extra code may be added to limit how far points may be moved.";

    readonly double[] Xs = Generate.RandomAscending(10);
    readonly double[] Ys = Generate.RandomSample(10);
    readonly ScottPlot.Plottables.Scatter Scatter;
    int? IndexBeingDragged = null;

    public DraggablePoints()
    {
        InitializeComponent();

        Scatter = formsPlot1.Plot.Add.Scatter(Xs, Ys);
        Scatter.LineWidth = 2;
        Scatter.MarkerSize = 10;
        Scatter.Smooth = true;

        formsPlot1.MouseMove += FormsPlot1_MouseMove;
        formsPlot1.MouseDown += FormsPlot1_MouseDown;
        formsPlot1.MouseUp += FormsPlot1_MouseUp;
    }
    Marker nearestMarker = null;
    private void FormsPlot1_MouseDown(object? sender, MouseEventArgs e)
    {
        Pixel mousePixel = new(e.Location.X, e.Location.Y);
        Coordinates mouseLocation = formsPlot1.Plot.GetCoordinates(mousePixel);
        nearestMarker = formsPlot1.Plot.GetNearestMarker(mouseLocation, formsPlot1.Plot.LastRender) as Marker;
        DataPoint nearest = Scatter.Data.GetNearest(mouseLocation, formsPlot1.Plot.LastRender);
        IndexBeingDragged = nearest.IsReal ? nearest.Index : null;

        if (IndexBeingDragged.HasValue || null != nearestMarker)
        {
            formsPlot1.Interaction.Disable();
            formsPlot1.Interaction.IsEnabled = true;
        }
           
    }

    private void FormsPlot1_MouseUp(object? sender, MouseEventArgs e)
    {
        if (null == nearestMarker && !IndexBeingDragged.HasValue)
        {
            // 创建新的 marker
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = formsPlot1.Plot.GetCoordinates(mousePixel);
            var marker1 = formsPlot1.Plot.Add.Marker(mouseLocation.X, mouseLocation.Y);
            marker1.Size = 20;
            marker1.Shape = MarkerShape.OpenCircle;
            marker1.Color = ScottPlot.Color.FromHex("#FFB5C5");
            marker1.LineWidth = 2;
        }
        nearestMarker = null;
        IndexBeingDragged = null;
        formsPlot1.Interaction.Enable();
        formsPlot1.Refresh();
    }

    private void FormsPlot1_MouseMove(object? sender, MouseEventArgs e)
    {
        Pixel mousePixel = new(e.Location.X, e.Location.Y);
        Coordinates mouseLocation = formsPlot1.Plot.GetCoordinates(mousePixel);
        DataPoint nearest = Scatter.Data.GetNearest(mouseLocation, formsPlot1.Plot.LastRender);
        formsPlot1.Cursor = nearest.IsReal ? Cursors.Hand : Cursors.Arrow;

        if (IndexBeingDragged.HasValue)
        {
            Xs[IndexBeingDragged.Value] = mouseLocation.X;
            Ys[IndexBeingDragged.Value] = mouseLocation.Y;
            formsPlot1.Refresh();
        }
        else
        {
            if (null != nearestMarker)
            {
                nearestMarker.Location = new Coordinates(mouseLocation.X, mouseLocation.Y);
                formsPlot1.Refresh();
            }
        }
    }
}
