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
    public partial class CreateObjectForm : Form
    {
        public ItemForDrawing? item;
        public CreateObjectForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.CheckInput();

            int object_type = objectTypeComboBox.SelectedIndex;

            switch (object_type)
            {
                case (int)ItemForDrawing.TypeOfObject.Rectangle:
                    {
                        Point start_coordinates = StringToPoint(coordinatesTextBox.Text);
                        Size size = StringToSize(sizeTextBox.Text);
                        item = new ItemForDrawing((int)ItemForDrawing.TypeOfObject.Rectangle, start_coordinates, size);
                        break;
                    }
                case (int)ItemForDrawing.TypeOfObject.Point:
                    {
                        Point start_coordinates = StringToPoint(coordinatesTextBox.Text);
                        item = new ItemForDrawing(start_coordinates);
                        break;
                    }
                case (int)ItemForDrawing.TypeOfObject.Line:
                    {
                        string[] data = coordinatesTextBox.Text.Split(" ");
                        Point start_coordiante = StringToPoint(data[0]);
                        Point end_coordinate = StringToPoint(data[1]);
                        item = new ItemForDrawing(start_coordiante, end_coordinate);
                        break;
                    }
                case (int)ItemForDrawing.TypeOfObject.Ellipse:
                    {
                        Point start_coordinates = StringToPoint(coordinatesTextBox.Text);
                        Size size = StringToSize(sizeTextBox.Text);
                        item = new ItemForDrawing((int)ItemForDrawing.TypeOfObject.Ellipse, start_coordinates, size);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
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
            if (objectTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип объекта.", "Ошибка");
                return false;
            }
            else
            {
                if (coordinatesTextBox.Text == "")
                {
                    MessageBox.Show("Введите координаты объекта.", "Ошибка");
                    return false;
                }
                else if (objectTypeComboBox.SelectedIndex > 1 && sizeTextBox.Text == "") 
                {
                    MessageBox.Show("Введите размеры объекта.", "Ошибка");
                    return false;
                }
            }
            
            return true;
        }
    }
}
