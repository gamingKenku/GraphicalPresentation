using System.Configuration;
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
        private List<Ellipse> placed_points;
        private Ellipse? dragged_point;

        double t_step = 0.001;
        Path? bezier_path;
        bool is_dragging;

        public MainWindow()
        {
            InitializeComponent();

            is_dragging = false;

            anchor_points = new PointCollection();
            placed_points = new List<Ellipse>();

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

        private Path GetBezierPath(PointCollection anchor_points, double t_step)
        {
            StreamGeometry bezier = new StreamGeometry();

            using (StreamGeometryContext context = bezier.Open())
            {
                context.BeginFigure(anchor_points[0], false, false);

                DrawBezier(anchor_points, context, t_step);
            }

            Path bezier_path = new Path()
            {
                Data = bezier,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };

            return bezier_path;
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
            Panel.SetZIndex(point_mark, 1);

            canvas.Children.Add(point_mark);
            placed_points.Add(point_mark);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            anchor_points.Clear();
            placed_points.Clear();

            canvas.Children.Add(preview_point);
            ClearCanvasEvents();
            preview_point.Visibility = Visibility.Hidden;

            placePointsToggleButton.IsChecked = false;
            deletePointsToggleButton.IsChecked = false;
            movePointsToggleButton.IsChecked = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(preview_point);
        }

        private void canvas_MouseMove_Place(object sender, MouseEventArgs e)
        {
            preview_point.Visibility = canvas.IsMouseOver ? Visibility.Visible : Visibility.Hidden;

            UpdatePreviewPoint(e.GetPosition(canvas));
        }

        private void canvas_MouseLeftButtonDown_Place(object sender, MouseButtonEventArgs e)
        {
            AddPoint();

            canvas.Children.Remove(bezier_path);
            bezier_path = GetBezierPath(anchor_points, t_step);
            canvas.Children.Add(bezier_path);
        }

        private void canvas_MouseMove_Delete(object sender, MouseEventArgs e)
        {
            Ellipse? point_under_mouse = GetEllipseByPoint(e.GetPosition(canvas));

            foreach (Ellipse point_mark in placed_points)
            {
                point_mark.Fill = point_mark == point_under_mouse ? Brushes.Black : Brushes.White;
            }
        }

        private void canvas_MouseLeftButtonDown_Delete(object sender, MouseButtonEventArgs e)
        {
            Ellipse? point_under_mouse = GetEllipseByPoint(e.GetPosition(canvas));

            if (point_under_mouse == null) return;

            int index = placed_points.IndexOf(point_under_mouse);

            canvas.Children.Remove(point_under_mouse);

            anchor_points.RemoveAt(index);
            placed_points.RemoveAt(index);

            if (anchor_points.Count == 0) return;

            canvas.Children.Remove(bezier_path);
            bezier_path = GetBezierPath(anchor_points, t_step);
            canvas.Children.Add(bezier_path);
        }

        private void canvas_MouseMove_Move(object sender, MouseEventArgs e)
        {
            Ellipse? point_under_mouse = GetEllipseByPoint(e.GetPosition(canvas));

            foreach (Ellipse point_mark in placed_points)
            {
                point_mark.Fill = point_mark == point_under_mouse ? Brushes.Black : Brushes.White;
            }
            
            if (is_dragging && dragged_point != null)
            {
                Canvas.SetLeft(dragged_point, e.GetPosition(canvas).X - dragged_point.Width / 2);
                Canvas.SetTop(dragged_point, e.GetPosition(canvas).Y - dragged_point.Height / 2);

                int index = placed_points.IndexOf(dragged_point);
                anchor_points[index] = new Point(e.GetPosition(canvas).X, e.GetPosition(canvas).Y);

                canvas.Children.Remove(bezier_path);
                bezier_path = GetBezierPath(anchor_points, t_step);
                canvas.Children.Add(bezier_path);
            }
        }

        private void canvas_MouseLeftButtonDown_Move(object sender, MouseButtonEventArgs e)
        {
            Ellipse? point_under_mouse = GetEllipseByPoint(e.GetPosition(canvas));

            if (point_under_mouse == null) return;

            is_dragging = true;
            dragged_point = point_under_mouse;
            dragged_point.Fill = Brushes.Black;
        }

        private void canvas_MouseLeftButtonUp_Move(object sender, MouseButtonEventArgs e)
        {
            is_dragging = false;
            dragged_point = null;
        }

        private void border_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            preview_point.Visibility = Visibility.Hidden;
        }

        private void modeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ClearCanvasEvents();
            preview_point.Visibility = Visibility.Hidden;

            if (placePointsToggleButton.IsChecked == true && sender == placePointsToggleButton)
            {
                canvas.MouseMove += canvas_MouseMove_Place;
                canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown_Place;
                deletePointsToggleButton.IsChecked = false;
                movePointsToggleButton.IsChecked = false;
            }
            else if (deletePointsToggleButton.IsChecked == true && sender == deletePointsToggleButton)
            {
                canvas.MouseMove += canvas_MouseMove_Delete;
                canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown_Delete;
                placePointsToggleButton.IsChecked = false;
                movePointsToggleButton.IsChecked = false;
            }
            else
            {
                canvas.MouseMove += canvas_MouseMove_Move;
                canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown_Move;
                canvas.MouseLeftButtonUp += canvas_MouseLeftButtonUp_Move;
                deletePointsToggleButton.IsChecked = false;
                placePointsToggleButton.IsChecked = false;
            }
        }

        private void ClearCanvasEvents()
        {
            canvas.MouseMove -= canvas_MouseMove_Place;
            canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown_Place;
            canvas.MouseMove -= canvas_MouseMove_Delete;
            canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown_Delete;
            canvas.MouseMove -= canvas_MouseMove_Move;
            canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown_Move;
            canvas.MouseLeftButtonUp -= canvas_MouseLeftButtonUp_Move;
        }

        private Ellipse? GetEllipseByPoint(Point point)
        {
            Ellipse? res = null;
            EllipseGeometry temp_geometry;

            foreach (Ellipse point_mark in placed_points)
            {
                temp_geometry = new EllipseGeometry(new Rect(Canvas.GetLeft(point_mark), Canvas.GetTop(point_mark), point_mark.Width, point_mark.Height));

                if (temp_geometry.FillContains(point))
                {
                    res = point_mark;
                }
            }

            return res;
        }
    }
}