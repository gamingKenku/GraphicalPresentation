namespace GraphicalPresentationLab3
{
    public partial class Form1 : Form
    {
        enum WeightOfLine : int { Five = 5, Ten = 10 };

        Pen pen;
        Brush brush;
        int[] dash_pattern = new int[2] { 2, 2 };

        public Form1()
        {
            InitializeComponent();

            pen = new Pen(Color.Black, (int)WeightOfLine.Ten);
            brush = Brushes.Aquamarine;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = new Rectangle(10, 10, 100, 100);

            graphics.Clear(Color.White);
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void íåïğåğûâíàÿToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ïóíêòèğíàÿToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void öâåòÔîíàToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void öâåòËèíèèÎáâîäêèToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}