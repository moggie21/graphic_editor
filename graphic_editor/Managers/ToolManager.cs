using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphic_editor.Managers
{
    public class ToolManager
    {
        public string CurrentTool { get; set; } = "Select";
        public Color CurrentColor { get; set; } = Color.Black;
        public int CurrentStrokeWidth { get; set; } = 2;

        public void SetTool(string tool)
        {
            CurrentTool = tool;
        }

        public void SetColor(Color color)
        {
            CurrentColor = color;
        }

        public void SetStrokeWidth(int width)
        {
            CurrentStrokeWidth = width;
        }
    }
}
