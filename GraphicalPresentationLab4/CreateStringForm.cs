using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalPresentationLab4
{
    public partial class CreateStringForm : Form
    {
        public ItemForDrawing? item;
        public CreateStringForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.CheckInput();

            Point start_coordinates = StringToPoint(coordinatesTextBox.Text);
            item = new ItemForDrawing(start_coordinates, stringTextBox.Text);

            this.Close();
        }

        private Point StringToPoint(string coord)
        {
            int[] data = Array.ConvertAll(coord.Trim().Split(","), int.Parse);

            return new Point(data[0], data[1]);
        }

        private Size StringToSize(string size)
        {
            int[] data = Array.ConvertAll(size.Trim().Split(","), int.Parse);

            return new Size(data[0], data[1]);
        }

        private bool CheckInput()
        {
            if (coordinatesTextBox.Text == "")
            {
                MessageBox.Show("Введите координаты строки.", "Ошибка");
                return false;
            }
            else if (stringTextBox.Text == "")
            {
                MessageBox.Show("Введите текст строки.", "Ошибка");
                return false;
            }

            return true;
        }
    }
}
