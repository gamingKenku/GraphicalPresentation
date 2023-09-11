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
                авторПрограммыToolStripMenuItem.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
            textBox1.Visible = !textBox1.Visible;
            button1.Visible = !button1.Visible;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Лабораторная работа №1\nВерсия 1.0.0", "О программе");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                author_name = textBox1.Text;
                авторПрограммыToolStripMenuItem.Enabled = true;
            }
            else
            {
                author_name = textBox1.Text;
                авторПрограммыToolStripMenuItem.Enabled = false;
            }
        }

        private void авторПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Автор программы: " + author_name, "Об авторе");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}