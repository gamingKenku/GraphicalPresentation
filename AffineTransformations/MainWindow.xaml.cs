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
using System.Text.RegularExpressions;

namespace AffineTransformations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Regex numeric_regex = new Regex("[^0-9]+");
        Regex float_regex = new Regex(@"^\-?[0-9]+(?:\.[0-9]+)?$");

        public MainWindow()
        {
            InitializeComponent();

            Polygon figure = GetDefaultFigure();
            canvas.Children.Add(figure);
        }

        private void ValidateNumeric(object sender, TextCompositionEventArgs e)
        {
            e.Handled = numeric_regex.IsMatch(e.Text);
        }

        private void moveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool MovePolygon(int x, int y, Canvas canvas, Polygon polygon)
        {
            PointCollection new_points = new PointCollection();

            for (int i = 0; i < polygon.Points.Count; i++)
            {
                new_points.Add(new Point(polygon.Points[i].X + x, polygon.Points[i].Y + y));

                if (new_points.Last().X < 0 || new_points.Last().Y < 0 || new_points.Last().Y > canvas.ActualHeight || new_points.Last().X > canvas.ActualWidth)
                {
                    return false;
                }
            }

            return true;
        }

        private Polygon GetDefaultFigure()
        {
            Polygon result = new Polygon();
            PointCollection points = new PointCollection()
            {
                new Point(100, 100),
                new Point(125, 125),
                new Point(125, 110),
                new Point(225, 110),
                new Point(225, 125),
                new Point(250, 100),
                new Point(225, 75),
                new Point(225, 90),
                new Point(185, 90),
                new Point(185, 40),
                new Point(200, 40),
                new Point(175, 15),
                new Point(150, 40),
                new Point(165, 40),
                new Point(165, 90),
                new Point(125, 90),
                new Point(125, 75)
            };
            result.Points = points;
            result.Stroke = Brushes.Black;
            result.Fill = Brushes.White;

            return result;
        }

        private void rotateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void scaleButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
