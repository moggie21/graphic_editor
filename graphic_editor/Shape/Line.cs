using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_editor.Shape
{
    public class Line : Shape
    {
        public Point EndPoint { get; set; }

        public Line(Point start, Point end)
        {
            Position = start;
            EndPoint = end;
        }
        public override void Draw(Graphics g)
        {
            var pen = new Pen(StrokeColor, StrokeWidth);

            g.DrawLine(pen, Position, EndPoint);

            if (IsSelected)
            {
                var dashPen = new Pen(Color.Black, 1);
                dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(dashPen, Position, EndPoint);
            }

            pen.Dispose();
            dashPen?.Dispose();
        }
        public override bool Contains(Point point)
        {
            var dist = DistanceToLine(point, Position, EndPoint);
            return dist <= 5;
            private double DistanceToLine(Point p, Point a, Point b)
        {
            double A = p.X - a.X;
            double B = p.Y - a.Y;
            double C = b.X - a.X;
            double D = b.Y - a.Y;

            double dot = A * C + B * D;
            double lenSq = C * C + D * D;
            double param = -1;
            if (lenSq != 0) param = dot / lenSq;

            double xx, yy;
            if (param < 0)
            {
                xx = a.X;
                yy = a.Y;
            }
            else if (param > 1)
            {
                xx = b.X;
                yy = b.Y;
            }
            else
            {
                xx = a.X + param * C;
                yy = a.Y + param * D;
            }

            double dx = p.X - xx;
            double dy = p.Y - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override Rectangle GetBounds()
        {
            int minX = Math.Min(Position.X, EndPoint.X);
            int minY = Math.Min(Position.Y, EndPoint.Y);
            int maxX = Math.Max(Position.X, EndPoint.X);
            int maxY = Math.Max(Position.Y, EndPoint.Y);

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
        }
    }
}
