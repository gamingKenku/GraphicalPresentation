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
        Rectangle previewDoor;
        CombinedGeometry house;
        List<Rectangle> placed_rectangles;
        int grid_step;
        int to_bottom_length;

        public MainWindow()
        {
            InitializeComponent();

            roofShapeCombobox.ItemsSource = roofShapes;
            roofShapeCombobox.SelectedIndex = 0;
            house = new CombinedGeometry() { GeometryCombineMode = GeometryCombineMode.Union };
            placed_rectangles = new List<Rectangle>();
            grid_step = 5;
            to_bottom_length = 25;

            previewWindow = new Rectangle()
            {
                Width = 25,
                Height = 25,
                Stroke = Brushes.Gray,
                Fill = Brushes.White,
                Opacity = 0.5,
                Visibility = Visibility.Hidden,
            };

            previewDoor = new Rectangle()
            {
                Width = 25,
                Height = 50,
                Stroke = Brushes.Gray,
                Fill = Brushes.White,
                Opacity = 0.5,
                Visibility = Visibility.Hidden,
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(previewWindow, 1);
            Panel.SetZIndex(previewDoor, 2);

            canvas.Children.Add(previewWindow);
            canvas.Children.Add(previewDoor);

            Canvas.SetTop(previewWindow, 0);
            Canvas.SetLeft(previewWindow, 0);

            Canvas.SetTop(previewDoor, canvas.ActualHeight - to_bottom_length - previewDoor.Height);
        }

        private void buildButton_Click(object sender, RoutedEventArgs e)
        {

            int foundation_width = (int)widthInput.Value!;
            int foundation_height = (int)heigthInput.Value!;
            int roof_height = (int)roofHeigthInput.Value!;
            PointCollection roof_points;
            PathFigure roof_figure;

            if (foundation_height + roof_height + to_bottom_length >= canvas.ActualHeight ||
                foundation_width >= canvas.ActualWidth)
            {
                MessageBox.Show("Дом выходит за пределы панели!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            canvas.Children.Clear();

            RectangleGeometry foundation_bounds = new RectangleGeometry()
            {
                Rect = new Rect() { Width = foundation_width, Height = foundation_height, X = (canvas.ActualWidth / 2) - (foundation_width / 2), Y = canvas.ActualHeight - to_bottom_length - foundation_height},
            };
            PathGeometry roof_bounds = new PathGeometry();

            switch (roofShapeCombobox.SelectedIndex)
            {
                case 0:
                    roof_points = new PointCollection()
                    {
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - to_bottom_length - foundation_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - to_bottom_length - foundation_height - roof_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2) + foundation_width, canvas.ActualHeight - to_bottom_length - foundation_height)
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
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - to_bottom_length - foundation_height),
                        new Point((canvas.ActualWidth / 2), canvas.ActualHeight - to_bottom_length - foundation_height - roof_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2) + foundation_width, canvas.ActualHeight - to_bottom_length - foundation_height)
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
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2), canvas.ActualHeight - to_bottom_length - foundation_height),
                        new Point((canvas.ActualWidth / 2) - (foundation_width / 2) + foundation_width, canvas.ActualHeight - to_bottom_length - foundation_height)
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
            canvas.Children.Add(previewDoor);

            placed_rectangles.Clear();

            canvas.InvalidateVisual();
        }

        private void canvas_MouseMove_Window(object sender, MouseEventArgs e)
        {
            previewWindow.Visibility = IsPointInsideOfHouse(e.GetPosition(canvas), house) ? Visibility.Visible : Visibility.Hidden;

            previewWindow.Stroke = PreviewRectangleInsideOfHouse(house, previewWindow) && CheckRectangleOverlapping(previewWindow) ? Brushes.Green : Brushes.Red;

            UpdatePreviewWindow(e.GetPosition(canvas));
        }
        private void canvas_MouseLeftButtonDown_Window(object sender, MouseButtonEventArgs e)
        {
            if (house != null && PreviewRectangleInsideOfHouse(house, previewWindow)) {
                AddWindow(e.GetPosition(canvas));
            }
        }

        private void canvas_MouseMove_Door(object sender, MouseEventArgs e)
        {
            previewDoor.Visibility = IsPointInsideOfHouse(e.GetPosition(canvas), house) ? Visibility.Visible : Visibility.Hidden;

            previewDoor.Stroke = PreviewRectangleInsideOfHouse(house, previewDoor) && CheckRectangleOverlapping(previewDoor) ? Brushes.Green : Brushes.Red;

            if (IsPointInsideOfHouse(e.GetPosition(canvas), house) && placed_rectangles.Count() > 0)
            {
                previewDoor.Stroke = PreviewRectangleInsideOfHouse(house, previewDoor) && CheckRectangleOverlapping(previewDoor) ? Brushes.Green : Brushes.Red;
            }

            UpdatePreviewDoor(e.GetPosition(canvas));
        }
        private void canvas_MouseLeftButtonDown_Door(object sender, MouseButtonEventArgs e)
        {
            if (house != null && PreviewRectangleInsideOfHouse(house, previewDoor))
            {
                AddDoor(e.GetPosition(canvas));
            }
        }

        private void UpdatePreviewWindow(Point mouse_position)
        {
            Canvas.SetTop(previewWindow, RoundToClosestDivisible(mouse_position .Y - previewWindow.Height / 2, grid_step));
            Canvas.SetLeft(previewWindow, RoundToClosestDivisible(mouse_position.X - previewWindow.Width / 2, grid_step));
        }

        private void UpdatePreviewDoor(Point mouse_position)
        {
            Canvas.SetLeft(previewDoor, RoundToClosestDivisible(mouse_position.X - previewDoor.Width / 2, grid_step));
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

            Canvas.SetTop(window, Canvas.GetTop(previewWindow));
            Canvas.SetLeft(window, Canvas.GetLeft(previewWindow));

            if (PreviewRectangleInsideOfHouse(house, previewWindow) && CheckRectangleOverlapping(window))
            {
                canvas.Children.Add(window);
                placed_rectangles.Add(window);
            }
        }

        private void AddDoor(Point mouse_position)
        {
            Rectangle door = new Rectangle()
            {
                Width = 25,
                Height = 50,
                Stroke = Brushes.Black,
                Fill = Brushes.White,
            };

            Canvas.SetTop(door, Canvas.GetTop(previewDoor));
            Canvas.SetLeft(door, Canvas.GetLeft(previewDoor));

            if (PreviewRectangleInsideOfHouse(house, previewDoor) && CheckRectangleOverlapping(door))
            {
                canvas.Children.Add(door);
                placed_rectangles.Add(door);
            }
        }

        private bool IsPointInsideOfHouse(Point point, CombinedGeometry house)
        {
            return house != null && house.FillContains(point);
        }

        private bool PreviewRectangleInsideOfHouse(CombinedGeometry house, Rectangle previewRectangle)
        {
            bool res;

            Rect temp_rect = new Rect(Canvas.GetLeft(previewRectangle), Canvas.GetTop(previewRectangle), previewRectangle.Width, previewRectangle.Height);

            if (IsPointInsideOfHouse(temp_rect.TopLeft, house) &&
                IsPointInsideOfHouse(temp_rect.TopRight, house) &&
                IsPointInsideOfHouse(temp_rect.BottomLeft, house) &&
                IsPointInsideOfHouse(temp_rect.BottomRight, house))
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

            return rect1.IntersectsWith(rect2);
        }

        static double RoundToClosestDivisible(double originalNumber, int divisor)
        {
            return (int)Math.Round(originalNumber / divisor) * divisor;
        }

        private void modesToggleButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.MouseMove -= canvas_MouseMove_Door;
            canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown_Door;
            canvas.MouseMove -= canvas_MouseMove_Window;
            canvas.MouseLeftButtonDown -= canvas_MouseLeftButtonDown_Window;

            if (sender == windowsToggleButton && windowsToggleButton.IsChecked == true)
            {
                canvas.MouseMove += canvas_MouseMove_Window;
                canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown_Window;
                doorsToggleButton.IsChecked = false;
            }
            else if (sender == doorsToggleButton && doorsToggleButton.IsChecked == true)
            {
                canvas.MouseMove += canvas_MouseMove_Door;
                canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown_Door;
                windowsToggleButton.IsChecked = false;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

            canvas.Children.Add(previewDoor);
            canvas.Children.Add(previewWindow);

            placed_rectangles.Clear();
        }
    }
}
