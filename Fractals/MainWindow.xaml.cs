using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double canvas_width;
        double canvas_height;

        public MainWindow()
        {
            InitializeComponent();

            nestingLevelInput.Value = 0;
        }

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            if (nestingLevelInput.Value < 0 && nestingLevelInput.Value != null)
            {
                MessageBox.Show("Уровень вложенности не может быть меньше 0.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            canvas.Children.Clear();

            Point start = new Point()
            {
                X = canvas_width / 4,
                Y = canvas_height / 2,
            };

            Point end = new Point()
            {
                X = canvas_width - canvas_width / 4,
                Y = canvas_height / 2,
            };

            DrawDragon(start, end, (int) nestingLevelInput.Value!, canvas);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void DrawDragon(Point start, Point end, int depth_level, Canvas canvas)
        {
            if (depth_level > 0)
            {
                Point n = new Point()
                {
                    X = ((start.X + end.X) / 2) + ((end.Y - start.Y) / 2),
                    Y = ((start.Y + end.Y) / 2) - ((end.X - start.X) / 2),
                };

                DrawDragon(start, n, depth_level - 1, canvas);
                DrawDragon(end, n, depth_level - 1, canvas);
            }
            else
            {
                Line line = new Line()
                {
                    X1 = start.X,
                    Y1 = start.Y,
                    X2 = end.X,
                    Y2 = end.Y,
                    Stroke = Brushes.Black,
                };

                canvas.Children.Add(line);
            }
        }

        private void nestingLevelInput_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvas_width = canvas.ActualWidth;
            canvas_height = canvas.ActualHeight;
        }
    }
}
