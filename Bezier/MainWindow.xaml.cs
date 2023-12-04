using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Bezier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PointCollection anchor_points;
        private Ellipse preview_point;
        double t_step = 0.001;
        Path? bezier_path;

        public MainWindow()
        {
            InitializeComponent();

            anchor_points = new PointCollection();

            preview_point = new Ellipse()
            {
                Visibility = Visibility.Hidden,
                Stroke = Brushes.Gray,
                Fill = Brushes.White,
                Width = 10,
                Height = 10,
                Opacity = 0.5,
            };

            Panel.SetZIndex(preview_point, 1);
        }

        private void DrawBezier(PointCollection anchor_points, StreamGeometryContext context, double t_step)
        {
            for (double t = 0; t <= 1; t += t_step)
            {
                context.LineTo(GetBezierPoint(anchor_points, t), true, false);
            }
        }

        private Point GetBezierPoint(PointCollection anchor_points, double t)
        {
            int n = anchor_points.Count - 1;

            double res_x = 0, res_y = 0;

            foreach (Point p in anchor_points)
            {
                int i = anchor_points.IndexOf(p);
                double c = BinomialCoeff(n, i);

                res_x += p.X * c * Math.Pow(1 - t, n - i) * Math.Pow(t, i);
                res_y += p.Y * c * Math.Pow(1 - t, n - i) * Math.Pow(t, i);
            }

            return new Point(res_x, res_y);
        }

        private double BinomialCoeff(int n, int i)
        {
            return Factorial(n) / (Factorial(i) * Factorial(n - i));
        }

        private int Factorial(int n)
        {
            if (n < 0) throw new ArgumentException();

            int res = 1;

            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }

            return res;
        }

        private void UpdatePreviewPoint(Point point)
        {
            Canvas.SetLeft(preview_point, point.X - preview_point.Width / 2);
            Canvas.SetTop(preview_point, point.Y - preview_point.Height / 2);
        }

        private void AddPoint()
        {
            Point bezier_point = new Point()
            {
                X = Canvas.GetLeft(preview_point) + preview_point.Width / 2,
                Y = Canvas.GetTop(preview_point) + preview_point.Height / 2,
            };

            anchor_points.Add(bezier_point);

            Ellipse point_mark = new Ellipse()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                Width = 10,
                Height = 10
            };
            Canvas.SetLeft(point_mark, Canvas.GetLeft(preview_point));
            Canvas.SetTop(point_mark, Canvas.GetTop(preview_point));

            canvas.Children.Add(point_mark);
        }

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            if (anchor_points.Count < 2)
            {
                MessageBox.Show("Количество опорных точек не должно быть меньше двух.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            canvas.Children.Remove(bezier_path);

            StreamGeometry bezier = new StreamGeometry();

            using (StreamGeometryContext context = bezier.Open())
            {
                context.BeginFigure(anchor_points[0], false, false);

                DrawBezier(anchor_points, context, t_step);
            }

            bezier_path = new Path() 
            {
                Data = bezier,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };

            canvas.Children.Add(bezier_path);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            anchor_points.Clear();

            canvas.Children.Add(preview_point);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(preview_point);

            canvas.MouseMove -= canvas_MouseMove;
            canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown;
        }

        private void placePointsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (placePointstoggleButton.IsChecked == true)
            {
                canvas.MouseMove += canvas_MouseMove;
                canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown;
            }
            else
            {
                canvas.MouseMove -= canvas_MouseMove;
                canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown;
                preview_point.Visibility = Visibility.Hidden;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            preview_point.Visibility = canvas.IsMouseOver ? Visibility.Visible : Visibility.Hidden;

            UpdatePreviewPoint(e.GetPosition(canvas));
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddPoint();
        }

        private void border_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            preview_point.Visibility = Visibility.Hidden;
        }
    }
}