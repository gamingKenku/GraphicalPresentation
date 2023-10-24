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
        Polygon ?polygon;

        double canvas_height;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isXValid = Double.TryParse(xTextBox.Text, out double x);
            bool isYValid = Double.TryParse(yTextBox.Text, out double y);

            if (!isXValid || !isYValid) 
            {
                MessageBox.Show("Некорректные данные.", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (!MovePolygon(x, y, canvas, polygon!))
            {
                MessageBox.Show("Фигура вышла за пределы экрана!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            };

            polygon!.InvalidateVisual();
        }

        private bool MovePolygon(double x, double y, Canvas canvas, Polygon polygon)
        {
            PointCollection new_points = new PointCollection();

            for (int i = 0; i < polygon.Points.Count; i++)
            {
                new_points.Add(new Point(polygon.Points[i].X + x, polygon.Points[i].Y - y));

                if (new_points.Last().X < 0 || new_points.Last().Y < 0 || new_points.Last().Y > canvas.ActualHeight || new_points.Last().X > canvas.ActualWidth)
                {
                    return false;
                }
            }

            polygon.Points.Clear();
            polygon.Points = new_points;

            return true;
        }

        private bool RotatePolygon(double angle_radians, Canvas canvas, Polygon polygon)
        {
            PointCollection new_points = new PointCollection();
            double angle_degrees = angle_radians * (Math.PI / 180);

            Point center = VertexCenter(polygon.Points.ToList());

            foreach (Point point in polygon.Points)
            {
                Point temp_point = new Point(point.X, point.Y);

                temp_point.X = temp_point.X - center.X;
                temp_point.Y = temp_point.Y - center.Y;

                temp_point.X = temp_point.X * Math.Cos(angle_degrees) + temp_point.Y * Math.Sin(angle_degrees);
                temp_point.Y = -temp_point.X * Math.Sin(angle_degrees) + temp_point.Y * Math.Cos(angle_degrees);

                temp_point.X = temp_point.X + center.X;
                temp_point.Y = temp_point.Y + center.Y;

                new_points.Add(temp_point);

                if (new_points.Last().X < 0 || new_points.Last().Y < 0 || new_points.Last().Y > canvas.ActualHeight || new_points.Last().X > canvas.ActualWidth)
                {
                    return false;
                }
            }

            polygon.Points.Clear();
            polygon.Points = new_points;

            return true;
        }

        private bool ScalePolygon(double x_multiplier, double y_multiplier, Canvas canvas, Polygon polygon)
        {
            PointCollection new_points = new PointCollection();

            Point center = VertexCenter(polygon.Points.ToList());

            foreach (Point point in polygon.Points)
            {
                Point temp_point = new Point(point.X, point.Y);

                temp_point.X = temp_point.X - center.X;
                temp_point.Y = temp_point.Y - center.Y;

                temp_point.X = temp_point.X * x_multiplier;
                temp_point.Y = temp_point.Y * y_multiplier;

                temp_point.X = temp_point.X + center.X;
                temp_point.Y = temp_point.Y + center.Y;

                new_points.Add(temp_point);

                if (new_points.Last().X < 0 || new_points.Last().Y < 0 || new_points.Last().Y > canvas.ActualHeight || new_points.Last().X > canvas.ActualWidth)
                {
                    return false;
                }
            }

            polygon.Points.Clear();
            polygon.Points = new_points;

            return true;
        }

        private Polygon GetDefaultFigure()
        {
            Polygon result = new Polygon();

            PointCollection points = new PointCollection()
            {
                new Point(0, canvas_height - 25),
                new Point(25, canvas_height),
                new Point(25, canvas_height - 15),
                new Point(125, canvas_height - 15),
                new Point(125, canvas_height),
                new Point(150, canvas_height - 25),
                new Point(125, canvas_height - 50),
                new Point(125, canvas_height - 35),
                new Point(85, canvas_height - 35),
                new Point(85, canvas_height - 85),
                new Point(100, canvas_height - 85),
                new Point(75, canvas_height - 110),
                new Point(50, canvas_height - 85),
                new Point(65, canvas_height - 85),
                new Point(65, canvas_height - 35),
                new Point(25, canvas_height - 35),
                new Point(25, canvas_height - 50)
            };

            result.Points = points;
            result.Stroke = Brushes.Black;
            result.Fill = Brushes.White;

            return result;
        }

        private void rotateButton_Click(object sender, RoutedEventArgs e)
        {
            bool angle_valid = Double.TryParse(rotateTextBox.Text, out double angle_radians);

            if (!angle_valid)
            {
                MessageBox.Show("Некорректные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!RotatePolygon(angle_radians, canvas, polygon!))
            {
                MessageBox.Show("Фигура вышла за пределы экрана!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            };

            polygon!.InvalidateVisual();
        }

        private void scaleButton_Click(object sender, RoutedEventArgs e)
        {
            bool isXValid = Double.TryParse(xScaleTextBox.Text, out double x_multiplier);
            bool isYValid = Double.TryParse(yScaleTextBox.Text, out double y_multiplier);

            if (!isXValid || !isYValid || x_multiplier == 0 || y_multiplier == 0)
            {
                MessageBox.Show("Некорректные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ScalePolygon(x_multiplier, y_multiplier, canvas, polygon!))
            {
                MessageBox.Show("Фигура вышла за пределы экрана!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            polygon!.InvalidateVisual();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            canvas_height = canvas.ActualHeight;

            polygon = GetDefaultFigure();
            canvas.Children.Add(polygon);
        }

        private Point VertexCenter(List<Point> tempPoints)
        {
            Point center = new Point(0, 0);
            for (int i = 0; i < tempPoints.Count; i++)
            {
                center.X += tempPoints[i].X;
                center.Y += tempPoints[i].Y;
            }
            center.X /= tempPoints.Count;
            center.Y /= tempPoints.Count;
            return center;
        }
    }
}
