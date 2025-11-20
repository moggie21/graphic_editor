using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_editor.Shapes
{
    public abstract class Shape
    {
        public Point Position { get; set; }
        public double Rotation { get; set; } = 0.0;
        public double Scale { get; set; } = 1.0;
        public Color FillColor { get; set; } = Color.White;
        public Color StrokeColor { get; set; } = Color.Black;
        public int StrokeWidth { get; set; } = 1;
        public float Opacity { get; set; } = 1.0f;
        public bool IsSelected { get; set; } = false;

        public abstract void Draw(Graphics g);
        public abstract bool Contains(Point point);
        public abstract Rectangle GetBounds();
    }
}
