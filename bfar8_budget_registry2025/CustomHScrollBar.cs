using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bfar8_budget_registry2025
{
    public class CustomHScrollBar : UserControl
    {
        public event EventHandler Scroll;
        private int _value = 0;
        private int _maximum = 100;

        public int Value
        {
            get => _value;
            set
            {
                _value = Math.Max(0, Math.Min(value, _maximum));
                Invalidate();
                Scroll?.Invoke(this, EventArgs.Empty);
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = Math.Max(0, value);
                Invalidate();
            }
        }

        public CustomHScrollBar()
        {
            this.Height = 20;          // ← scrollbar thickness (you change this)
            this.BackColor = Color.LightGray;
            this.DoubleBuffered = true;

            this.MouseDown += (s, e) =>
            {
                Value = (int)((double)e.X / Width * Maximum);
            };
            this.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    Value = (int)((double)e.X / Width * Maximum);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int thumbWidth = Width / 5;
            int thumbX = (int)((double)Value / Maximum * (Width - thumbWidth));

            e.Graphics.FillRectangle(Brushes.Gray, thumbX, 2, thumbWidth, Height - 4);
        }
    }

}
