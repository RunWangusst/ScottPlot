namespace WinForms_Demo.Demos;

partial class DraggableAxisSpans
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        formsPlot1 = new ScottPlot.WinForms.FormsPlot();
        panel1 = new Panel();
        lbPixelCoordinate = new Label();
        label3 = new Label();
        lbLocation = new Label();
        label1 = new Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // formsPlot1
        // 
        formsPlot1.DisplayScale = 1F;
        formsPlot1.Location = new Point(0, 55);
        formsPlot1.Name = "formsPlot1";
        formsPlot1.Size = new Size(800, 455);
        formsPlot1.TabIndex = 1;
        // 
        // panel1
        // 
        panel1.Controls.Add(lbPixelCoordinate);
        panel1.Controls.Add(label3);
        panel1.Controls.Add(lbLocation);
        panel1.Controls.Add(label1);
        panel1.Location = new Point(12, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(776, 49);
        panel1.TabIndex = 2;
        // 
        // lbPixelCoordinate
        // 
        lbPixelCoordinate.AutoSize = true;
        lbPixelCoordinate.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lbPixelCoordinate.ForeColor = Color.Red;
        lbPixelCoordinate.Location = new Point(476, 14);
        lbPixelCoordinate.Name = "lbPixelCoordinate";
        lbPixelCoordinate.Size = new Size(35, 17);
        lbPixelCoordinate.TabIndex = 3;
        lbPixelCoordinate.Text = "(0,0)";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(364, 14);
        label3.Name = "label3";
        label3.Size = new Size(106, 17);
        label3.TabIndex = 2;
        label3.Text = "Pixel Coordinate:";
        // 
        // lbLocation
        // 
        lbLocation.AutoSize = true;
        lbLocation.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lbLocation.ForeColor = Color.Red;
        lbLocation.Location = new Point(74, 14);
        lbLocation.Name = "lbLocation";
        lbLocation.Size = new Size(35, 17);
        lbLocation.TabIndex = 1;
        lbLocation.Text = "(0,0)";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(8, 14);
        label1.Name = "label1";
        label1.Size = new Size(60, 17);
        label1.TabIndex = 0;
        label1.Text = "Location:";
        // 
        // DraggableAxisSpans
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 510);
        Controls.Add(panel1);
        Controls.Add(formsPlot1);
        Name = "DraggableAxisSpans";
        Text = "DraggableAxisSpans";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ScottPlot.WinForms.FormsPlot formsPlot1;
    private Panel panel1;
    private Label label1;
    private Label lbLocation;
    private Label lbPixelCoordinate;
    private Label label3;
}
