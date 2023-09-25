using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace GraphicalPresentationLab4
{
    public partial class MainForm : Form
    {
        Bitmap bitmap;
        Brush brush;
        Color color;
        Font font = new Font("Arial", 16);
        int weight_of_line;

        ItemForDrawing? item;

        public MainForm()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = bitmap;
            // pictureBox1.BackgroundImageLayout = ImageLayout.None;

            brush = Brushes.Black;
            color = Color.Black;
            font = new Font("Arial", 16);
            weight_of_line = 10;
        }
        private void updateBitmap()
        {
            if (item != null)
            {
                Pen pen = new Pen(brush, weight_of_line);

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    switch (item.type_of_object)
                    {
                        case ((int)ItemForDrawing.TypeOfObject.Point):
                            {
                                bitmap.SetPixel(item.start_coordinate.X, item.start_coordinate.Y, color);
                                break;
                            }
                        case ((int)ItemForDrawing.TypeOfObject.Line):
                            {
                                g.DrawLine(pen, item.start_coordinate, item.end_coordinate);
                                break;
                            }
                        case ((int)ItemForDrawing.TypeOfObject.Rectangle):
                            {
                                Rectangle rectangle = new Rectangle(item.start_coordinate, item.size);
                                g.DrawRectangle(pen, rectangle);
                                break;
                            }
                        case ((int)ItemForDrawing.TypeOfObject.Ellipse):
                            {
                                Rectangle rectangle = new Rectangle(item.start_coordinate, item.size);
                                g.DrawEllipse(pen, rectangle);
                                break;
                            }
                        case ((int)ItemForDrawing.TypeOfObject.String):
                            {
                                g.DrawString(item.text, font, brush, item.start_coordinate);
                                break;
                            }
                    }
                }
            }
            pictureBox1.Invalidate();
        }

        private void createObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateObjectForm createForm = new CreateObjectForm();

            createForm.ShowDialog();

            item = createForm.item;

            updateBitmap();
        }

        private void createStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateStringForm createForm = new CreateStringForm();
            
            createForm.ShowDialog();

            item = createForm.item;

            updateBitmap();
        }
    }

}