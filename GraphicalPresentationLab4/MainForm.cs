using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace GraphicalPresentationLab4
{
    public partial class MainForm : Form
    {
        Bitmap bitmap;
        Brush brush;
        Color color;
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
                                break;
                            }
                    }
                }
            }
            pictureBox1.Invalidate();
        }

        private void createObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm();

            createForm.ShowDialog();

            item = createForm.item;

            updateBitmap();
        }
    }

}