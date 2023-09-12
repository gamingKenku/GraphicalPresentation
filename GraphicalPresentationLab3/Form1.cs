using System.Drawing.Drawing2D;

namespace GraphicalPresentationLab3
{
    public partial class Form1 : Form
    {
        DashStyle lineType;
        int lineWeight;

        Color pen_color;
        Color brush_color;

        Pen pen;
        Brush brush;
        float[] dot_pattern = new float[2] { 2, 2 };

        public Form1()
        {
            InitializeComponent();

            lineType = DashStyle.Solid;
            lineWeight = 5;

            pen_color = Color.Black;
            brush_color = Color.Aqua;

            pen = new Pen(pen_color, (int)lineWeight);
            brush = new SolidBrush(brush_color);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = new Rectangle(10, 10, 100, 100);

            graphics.Clear(Color.White);
            brush = new SolidBrush(brush_color);

            pen = new Pen(pen_color)
            {
                DashStyle = lineType,
                Width = lineWeight
            };


            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(PointToScreen(e.Location));
            }
        }

        private void uninterruptedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineType = DashStyle.Solid;

            this.Refresh();
        }

        private void dottedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineType = DashStyle.Dot;

            this.Refresh();
        }

        private void fiveWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineWeight = 5;

            this.Refresh();
        }

        private void tenWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineWeight = 10;

            this.Refresh();
        }

        private void fifteenWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineWeight = 15;

            this.Refresh();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brushColorDialog.ShowDialog() == DialogResult.OK)
            {
                brush_color = brushColorDialog.Color;
            }

            this.Refresh();
        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (penColorDialog.ShowDialog() == DialogResult.OK)
            {
                pen_color = penColorDialog.Color;
            }

            this.Refresh();
        }
    }
}