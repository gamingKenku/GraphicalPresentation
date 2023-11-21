using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Xceed.Wpf.AvalonDock.Controls;

namespace PersonalTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<String> roofShapes = new List<String>() 
        {
            "Односкатная",
            "Двускатная",
            "Сводчатая"
        };

        Rectangle previewWindow;
        CombinedGeometry house;
        List<Rectangle> placed_rectangles;
        public MainWindow()
        {
            InitializeComponent();

            roofShapeCombobox.ItemsSource = roofShapes;
            roofShapeCombobox.SelectedIndex = 0;
            house = new CombinedGeometry() { GeometryCombineMode = GeometryCombineMode.Union };
            placed_rectangles = new List<Rectangle>();

            previewWindow = new Rectangle()
            {
                Width = 25,
                Height = 25,
                Stroke = Brushes.Gray,
                Fill = Brushes.White,
                Opacity = 0.5,
            };

            Panel.SetZIndex(previewWindow, 1);
            canvas.Children.Add(previewWindow);

            Canvas.SetTop(previewWindow, 0);
            Canvas.SetLeft(previewWindow, 0);
        }

        private void buildButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

            int foundation_width = (int)widthInput.Value!;
            int foundation_height = (int)heigthInput.Value!;
            int roof_height = (int)roofHeigthInput.Value!;
            PointCollection roof_points;
            PathFigure roof_figure;

            RectangleGeometry foundation_bounds = new RectangleGeometry()
            {
                Rect = new Rect() { Width = foundation_width, Height = foundation_height, X = (canvas.ActualWidth / 2) - (foundation_width / 2), Y = canvas.ActualHeight - 100 - foundation_height},
            };
            PathGeometry roof_bounds = new PathGeometry();

            switch (roofShapeCombobox.SelectedIndex)
            {
                case 0:
                    roof_points = new PointCollection()
                    {
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - 100 - foundation_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - 100 - foundation_height - roof_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2) + foundation_width, canvas.ActualHeight - 100 - foundation_height)
                    };

                    roof_figure = new PathFigure()
                    {
                        StartPoint = roof_points[0],

                        Segments = new PathSegmentCollection()
                        {
                            new PolyLineSegment(roof_points.Skip(1), true)
                        },

                        IsClosed = true,
                    };

                    break;
                case 1:
                    roof_points = new PointCollection()
                    {
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - 100 - foundation_height),
                        new Point((canvas.ActualWidth / 2), canvas.ActualHeight - 100 - foundation_height - roof_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2) + foundation_width, canvas.ActualHeight - 100 - foundation_height)
                    };

                    roof_figure = new PathFigure()
                    {
                        StartPoint = roof_points[0],

                        Segments = new PathSegmentCollection()
                        {
                            new PolyLineSegment(roof_points.Skip(1), true)
                        },

                        IsClosed = true,
                    };

                    break;
                case 2:
                    roof_points = new PointCollection()
                    {
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - 100 - foundation_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2) + foundation_width, canvas.ActualHeight - 100 - foundation_height)
                    };

                    roof_figure = new PathFigure()
                    {
                        StartPoint = roof_points[0],

                        Segments = new PathSegmentCollection()
                        {
                            new ArcSegment(roof_points[1], new Size(foundation_width / 2, roof_height), 0, true, SweepDirection.Clockwise, true),
                        },

                        IsClosed = true,
                    };

                    break;
                default:
                    {
                        MessageBox.Show("Что-то пошло не так.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
            }

            roof_bounds.Figures = new PathFigureCollection { roof_figure };

            house.Geometry1 = foundation_bounds;
            house.Geometry2 = roof_bounds;

            Path unified_path = new Path()
            {
                Data = house,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
            };

            canvas.Children.Add(unified_path);
            canvas.Children.Add(previewWindow);

            canvas.InvalidateVisual();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            previewWindow.Visibility = IsPointInsideOfHouse(e.GetPosition(canvas), house) ? Visibility.Visible : Visibility.Hidden;

            previewWindow.Stroke = PreviewWindowInsideOfHouse(e.GetPosition(canvas), house, previewWindow) && CheckRectangleOverlapping(previewWindow) ? Brushes.Green : Brushes.Red;

            UpdatePreviewWindow(e.GetPosition(canvas));
        }
        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (house != null && PreviewWindowInsideOfHouse(e.GetPosition(canvas), house, previewWindow)) {
                AddWindow(e.GetPosition(canvas));
            }
        }

        private void UpdatePreviewWindow(Point mouse_position)
        {
            Canvas.SetTop(previewWindow, mouse_position.Y - previewWindow.Height / 2);
            Canvas.SetLeft(previewWindow, mouse_position.X - previewWindow.Width / 2);
        }

        private void AddWindow(Point mouse_position)
        {
            Rectangle window = new Rectangle()
            {
                Width = 25,
                Height = 25,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
            };

            Canvas.SetTop(window, mouse_position.Y - window.Height / 2);
            Canvas.SetLeft(window, mouse_position.X - window.Width / 2);

            if (IsPointInsideOfHouse(mouse_position, house) && CheckRectangleOverlapping(window))
            {
                canvas.Children.Add(window);
                placed_rectangles.Add(window);
            }
        }

        private bool IsPointInsideOfHouse(Point point, CombinedGeometry house)
        {
            return house != null && house.FillContains(point);
        }

        private bool PreviewWindowInsideOfHouse(Point point, CombinedGeometry house, Rectangle previewWindow)
        {
            bool res;

            if (IsPointInsideOfHouse(new Point(point.X - previewWindow.Width / 2, point.Y - previewWindow.Height / 2), house) &&
                IsPointInsideOfHouse(new Point(point.X - previewWindow.Width / 2, point.Y + previewWindow.Height / 2), house) &&
                IsPointInsideOfHouse(new Point(point.X + previewWindow.Width / 2, point.Y + previewWindow.Height / 2), house) &&
                IsPointInsideOfHouse(new Point(point.X + previewWindow.Width / 2, point.Y - previewWindow.Height / 2), house)) 
            {
                res = true;
            }
            else
            {
                res = false;
            }

            return res;
        }

        private bool CheckRectangleOverlapping(Rectangle rectangle)
        {
            foreach(Rectangle placed_rectangle in placed_rectangles)
            {
                if (AreOverlapping(rectangle, placed_rectangle))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreOverlapping(Rectangle rectangle1, Rectangle rectangle2)
        {
            Rect rect1 = new Rect(Canvas.GetLeft(rectangle1), Canvas.GetTop(rectangle1), rectangle1.Width, rectangle1.Height);
            Rect rect2 = new Rect(Canvas.GetLeft(rectangle2), Canvas.GetTop(rectangle2), rectangle2.Width, rectangle2.Height);

            return rect1.Contains(rect2.TopLeft) ||
                   rect1.Contains(rect2.TopRight) ||
                   rect1.Contains(rect2.BottomRight) ||
                   rect1.Contains(rect2.BottomLeft);
        }
    }
}
