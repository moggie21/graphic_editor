using graphic_editor.Managers;

namespace graphic_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            var toolPanel = new Panel();
            toolPanel.Size = new Size(100, 450);
            toolPanel.Location = new Point(0, 0);
            toolPanel.BackColor = Color.LightGray;

            var selectBtn = new Button { Text = "Select", Size = new Size(90, 30), Location = new Point(5, 10) };
            var circleBtn = new Button { Text = "Circle", Size = new Size(90, 30), Location = new Point(5, 50) };
            var rectBtn = new Button { Text = "Rectangle", Size = new Size(90, 30), Location = new Point(5, 90) };
            var lineBtn = new Button { Text = "Line", Size = new Size(90, 30), Location = new Point(5, 130) };

            selectBtn.Click += (s, e) => toolManager.SetTool("Select");
            circleBtn.Click += (s, e) => toolManager.SetTool("Circle");
            rectBtn.Click += (s, e) => toolManager.SetTool("Rectangle");
            lineBtn.Click += (s, e) => toolManager.SetTool("Line");

            toolPanel.Controls.AddRange(new Control[] { selectBtn, circleBtn, rectBtn, lineBtn });
            this.Controls.Add(toolPanel);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
