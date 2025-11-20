using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_editor.Shapes
{
    public class RectangleForm : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public RectangleForm(Point position, double width, double height)
        {
            Position = position;
            Width = width;
            Height = height;
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(
                (int)(Position.X - Width / 2),
                (int)(Position.Y - Height / 2),
                (int)Width,
                (int)Height
            );

            var fillBrush = new SolidBrush(Color.FromArgb((int)(Opacity * 255), FillColor));
            var strokePen = new Pen(StrokeColor, StrokeWidth);

            g.FillRectangle(fillBrush, rect);
            g.DrawRectangle(strokePen, rect);

            var dashPen = new Pen(Color.Red, 3);
            if (IsSelected)
            {
                dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(dashPen, rect);
            }

            fillBrush.Dispose();
            strokePen.Dispose();
            dashPen.Dispose();
        }

        public override bool Contains(Point point)
        {
            var rect = GetBounds();
            return rect.Contains(point);
        }

        public override Rectangle GetBounds()
        {
            return new Rectangle(
                (int)(Position.X - Width / 2),
                (int)(Position.Y - Height / 2),
                (int)Width,
                (int)Height
            );
        }
    }
}
