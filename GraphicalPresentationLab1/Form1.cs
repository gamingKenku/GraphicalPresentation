namespace GraphicalPresentationLab1
{
    public partial class Form1 : Form
    {
        string author_name = "";

        public Form1()
        {
            InitializeComponent();

            if (author_name == "")
            {
                ��������������ToolStripMenuItem.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
            textBox1.Visible = !textBox1.Visible;
            button1.Visible = !button1.Visible;
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "������������ ������ �1\n������ 1.0.0", "� ���������");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                author_name = textBox1.Text;
                ��������������ToolStripMenuItem.Enabled = true;
            }
            else
            {
                author_name = textBox1.Text;
                ��������������ToolStripMenuItem.Enabled = false;
            }
        }

        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "����� ���������: " + author_name, "�� ������");
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}