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

        public MainWindow()
        {
            InitializeComponent();

            roofShapeCombobox.ItemsSource = roofShapes;
            roofShapeCombobox.SelectedIndex = 0;

            previewWindow = new Rectangle()
            {
                Width = 25,
                Height = 25,
                Stroke = Brushes.Gray,
                Fill = Brushes.White,
                Opacity = 0.5,
            };
        }

        private void buildButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

            CombinedGeometry house = new CombinedGeometry() { GeometryCombineMode = GeometryCombineMode.Union};

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
            canvas.InvalidateVisual();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            UpdatePreviewWindow(e.GetPosition(canvas));
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddWindow(e.GetPosition(canvas));
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

            canvas.Children.Add(window);

            Canvas.SetTop(window, mouse_position.Y - window.Height / 2);
            Canvas.SetLeft(window, mouse_position.X - window.Width / 2);
        }

        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            canvas.Children.Add(previewWindow);
            UpdatePreviewWindow(e.GetPosition(canvas));
        }

        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            canvas.Children.Remove(previewWindow);
        }
    }
}
