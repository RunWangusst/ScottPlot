using ScottPlot;
using ScottPlot.Plottables;

namespace WinForms_Demo.Demos;

public partial class DraggableAxisSpans : Form, IDemoWindow
{
    public string Title => "Draggable Axis Spans";

    public string Description => "Demonstrates how to create a mouse-interactive " +
        "axis span that can be resized or dragged";

    AxisSpanUnderMouse? SpanBeingDragged = null;

    public DraggableAxisSpans()
    {
        InitializeComponent();

        // place axis spans on the plot
        formsPlot1.Plot.Add.Signal(Generate.Sin());
        formsPlot1.Plot.Add.Signal(Generate.Cos());

        //formsPlot1.Menu.Add

        var vs = formsPlot1.Plot.Add.VerticalSpan(.23, .78);
        vs.IsDraggable = true;
        vs.IsResizable = true;

        var hs = formsPlot1.Plot.Add.HorizontalSpan(23, 42);
        hs.IsDraggable = true;
        hs.IsResizable = true;

        formsPlot1.Refresh();

        formsPlot1.Menu.AddSeparator();

        formsPlot1.Menu.Add("Add HorizontalSpan", (formsplot1) =>
        {
            // 获取鼠标点击位置
            var hs = formsPlot1.Plot.Add.HorizontalSpan(30, 42);
            hs.LegendText = $"HorizontalSpan{new Random().Next(100)}";
            hs.IsDraggable = true;
            hs.IsResizable = true;
            formsplot1.Refresh();
        });
        formsPlot1.Menu.Add("Add VerticalSpan", (formsplot1) =>
        {
            var vs = formsPlot1.Plot.Add.VerticalSpan(.4, .6);
            vs.LegendText = $"VerticalSpan{new Random().Next(100)}";
            vs.IsDraggable = true;
            vs.IsResizable = true;
            formsplot1.Refresh();
        });

        formsPlot1.Menu.Add("Remove Span", (formsplot1) =>
        {
            if(null != thingUnderMouse)
            {
                formsPlot1.Plot.Remove(thingUnderMouse.Span);
                formsplot1.Refresh();
            }
        });

        // use events for custom mouse interactivity
        formsPlot1.MouseDown += FormsPlot1_MouseDown;
        formsPlot1.MouseUp += FormsPlot1_MouseUp;
        formsPlot1.MouseMove += FormsPlot1_MouseMove;
    }

    AxisSpanUnderMouse thingUnderMouse;
    private void FormsPlot1_MouseDown(object? sender, MouseEventArgs e)
    {
        thingUnderMouse = GetSpanUnderMouse(e.X, e.Y);
        if (thingUnderMouse is not null)
        {
            UpdateInformations(thingUnderMouse, thingUnderMouse.MouseStart);
            SpanBeingDragged = thingUnderMouse;

            if (e.Button == MouseButtons.Right) return;

            formsPlot1.Interaction.Disable(); // disable panning while dragging
        }
    }

    private void UpdateInformations(AxisSpanUnderMouse currentSpan, Coordinates coordinates)
    {
        this.lbLocation.Text = $"Min: {currentSpan.OriginalRange.Min}, Max: {currentSpan.OriginalRange.Max}";
        this.lbPixelCoordinate.Text = $"Start: {coordinates.X}, End: {coordinates.Y}";
    }

    private void FormsPlot1_MouseUp(object? sender, MouseEventArgs e)
    {
        SpanBeingDragged = null;
        formsPlot1.Interaction.Enable(); // enable panning
        formsPlot1.Refresh();
    }

    private void FormsPlot1_MouseMove(object? sender, MouseEventArgs e)
    {
        if (SpanBeingDragged is not null)
        {
            // currently dragging something so update it
            Coordinates mouseNow = formsPlot1.Plot.GetCoordinates(e.X, e.Y);
            SpanBeingDragged.DragTo(mouseNow);
            formsPlot1.Refresh();
            UpdateInformations(SpanBeingDragged, mouseNow);
        }
        else
        {
            // not dragging anything so just set the cursor based on what's under the mouse
            var spanUnderMouse = GetSpanUnderMouse(e.X, e.Y);
            if (spanUnderMouse is null) Cursor = Cursors.Default;
            else if (spanUnderMouse.IsResizingHorizontally) Cursor = Cursors.SizeWE;
            else if (spanUnderMouse.IsResizingVertically) Cursor = Cursors.SizeNS;
            else if (spanUnderMouse.IsMoving) Cursor = Cursors.SizeAll;

            if (null != spanUnderMouse)
            {
                UpdateInformations(spanUnderMouse, spanUnderMouse.MouseStart);
            }
        }
    }

    private AxisSpanUnderMouse? GetSpanUnderMouse(float x, float y)
    {
        CoordinateRect rect = formsPlot1.Plot.GetCoordinateRect(x, y, radius: 10);

        foreach (AxisSpan span in formsPlot1.Plot.GetPlottables<AxisSpan>().Reverse())
        {
            AxisSpanUnderMouse? spanUnderMouse = span.UnderMouse(rect);
            if (spanUnderMouse is not null)
                return spanUnderMouse;
        }

        return null;
    }
}
