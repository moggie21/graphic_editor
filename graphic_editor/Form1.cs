using graphic_editor.Managers;
using graphic_editor.Shapes;

namespace graphic_editor
{
    public partial class Form1 : Form
    {
        private Canvas canvas;
        private bool isDrawing = false;
        private Point startPoint;
        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas();
            canvas.AddShape(new Circle(new Point(100, 100), 30)
            {
                FillColor = Color.Blue,
                StrokeColor = Color.Black,
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
            if (e.Button == MouseButtons.Left)
            {
                canvas.SelectShape(e.Location);
                Invalidate();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}
