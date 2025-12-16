using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

public class RoundedPanel : Panel
{
    private int borderRadius = 20;
    private int borderSize = 2;
    private Color borderColor = Color.Black;
    private Color backColorCustom = Color.White;

    [Category("Appearance")]
    public int BorderRadius
    {
        get => borderRadius;
        set { borderRadius = value; Invalidate(); }
    }

    [Category("Appearance")]
    public int BorderSize
    {
        get => borderSize;
        set { borderSize = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BorderColor
    {
        get => borderColor;
        set { borderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color PanelColor
    {
        get => backColorCustom;
        set { backColorCustom = value; Invalidate(); }
    }

    public RoundedPanel()
    {
        this.BackColor = Color.Transparent;
        this.Resize += (s, e) => Invalidate();
    }

    private GraphicsPath GetPath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        float curve = radius * 2F;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curve, curve, 180, 90);
        path.AddArc(rect.Right - curve, rect.Y, curve, curve, 270, 90);
        path.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curve, curve, curve, 90, 90);
        path.CloseFigure();

        return path;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
        Rectangle rectBorder = new Rectangle(0, 0, Width - 1, Height - 1);

        using (GraphicsPath path = GetPath(rect, borderRadius))
        using (SolidBrush brush = new SolidBrush(backColorCustom))
        using (Pen pen = new Pen(borderColor, borderSize))
        {
            // Fill panel
            e.Graphics.FillPath(brush, path);

            // Draw border
            if (borderSize > 0)
                e.Graphics.DrawPath(pen, path);

            this.Region = new Region(path);
        }
    }
}
