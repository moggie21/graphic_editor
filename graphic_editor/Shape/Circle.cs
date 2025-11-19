using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_editor.Shape
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(Point position, double radius)
        {
            Position = position;
            Radius = radius;
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(
                (int)(Position.X - Radius),
                (int)(Position.Y - Radius),
                (int)(Radius * 2),
                (int)(Radius * 2)
            );

            var fillBrush = new SolidBrush(Color.FromArgb((int)(Opacity * 255), FillColor));
            var strokePen = new Pen(StrokeColor, StrokeWidth);

            g.FillEllipse(fillBrush, rect);
            g.DrawEllipse(strokePen, rect);

            if (IsSelected)
            {
                var dashPen = new Pen(Color.Black, 1);
                dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawEllipse(dashPen, rect);
            }

            fillBrush.Dispose();
            strokePen.Dispose();
            dashPen?.Dispose();
        }

        public override bool Contains(Point point)
        {
            var dx = point.X - Position.X;
            var dy = point.Y - Position.Y;
            return Math.Sqrt(dx * dx + dy * dy) <= Radius;
        }

        public override Rectangle GetBounds()
        {
            return new Rectangle(
                (int)(Position.X - Radius),
                (int)(Position.Y - Radius),
                (int)(Radius * 2),
                (int)(Radius * 2)
            );
        }
    }
}
