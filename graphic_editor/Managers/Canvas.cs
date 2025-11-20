using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using graphic_editor.Shapes;

namespace graphic_editor.Managers
{
    public class Canvas
    {
        public List<Shape> Shapes { get; private set; } = new List<Shape>();
        public Shape SelectedShape { get; set; } = null;

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void RemoveShape(Shape shape)
        {
            Shapes.Remove(shape);
            if (SelectedShape == shape)
                SelectedShape = null;
        }

        public void Draw(Graphics g)
        {
            foreach (var shape in Shapes)
            {
                shape.Draw(g);
            }
        }

        public Shape SelectShape(Point point)
        {
            for (int i = Shapes.Count - 1; i >= 0; i--)
            {
                if (Shapes[i].Contains(point))
                {
                    if (SelectedShape != null)
                        SelectedShape.IsSelected = false;

                    SelectedShape = Shapes[i];
                    SelectedShape.IsSelected = true;
                    return SelectedShape;
                }
            }

            if (SelectedShape != null)
            {
                SelectedShape.IsSelected = false;
                SelectedShape = null;
            }

            return null;
        }
    }
}
