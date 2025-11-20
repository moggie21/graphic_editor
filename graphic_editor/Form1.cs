using graphic_editor.Managers;
using graphic_editor.Shapes;

namespace graphic_editor
{
    public partial class Form1 : Form
    {
        private Canvas canvas;
        private ToolManager toolManager;
        private bool isDrawing = false;
        private Point startPoint;
        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas();
            toolManager = new ToolManager();

            canvas.AddShape(new Circle(new Point(500, 100), 30)
            {
                FillColor = Color.Blue,
                StrokeColor = Color.LightBlue,
                StrokeWidth = 2,
                Opacity = 0.8f
            });
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            canvas.Draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolManager.CurrentTool == "Select")
            {
                canvas.SelectShape(e.Location);
                Invalidate();
            }
            else
            {
                isDrawing = true;
                startPoint = e.Location;
                canvas.ClearTemporaryShape();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && toolManager.CurrentTool != "Select")
            {
                canvas.ClearTemporaryShape();

                var tempShape = CreateShapeFromPoints(startPoint, e.Location);
                if (tempShape != null)
                {
                    tempShape.StrokeColor = toolManager.CurrentColor;
                    tempShape.StrokeWidth = toolManager.CurrentStrokeWidth;
                    tempShape.Opacity = 0.5f; 
                    canvas.TemporaryShape = tempShape;
                    Invalidate(); 
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && toolManager.CurrentTool != "Select")
            {
                isDrawing = false;

                canvas.ClearTemporaryShape();

                var shape = CreateShapeFromPoints(startPoint, e.Location);
                if (shape != null)
                {
                    shape.StrokeColor = toolManager.CurrentColor;
                    shape.StrokeWidth = toolManager.CurrentStrokeWidth;
                    canvas.AddShape(shape);
                    Invalidate();
                }
            }
        }

        private Shape CreateShapeFromPoints(Point start, Point end)
        {
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);

            switch (toolManager.CurrentTool)
            {
                case "Circle":
                    return new Circle(start, Math.Max(width, height) / 2.0);
                case "Rectangle":
                    return new RectangleForm(start, width, height);
                case "Line":
                    return new Line(start, end);
                default:
                    return null;
            }
        }
    }
}
