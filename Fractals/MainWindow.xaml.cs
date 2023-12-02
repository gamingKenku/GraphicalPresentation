using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        enum Turn
        {
            Left,
            Right,
        }

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

            StreamGeometry dragon_curve_geometry = new StreamGeometry();

            Path path = new Path()
            {
                Data = dragon_curve_geometry,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };

            canvas.Children.Add(path);

            using (StreamGeometryContext context = dragon_curve_geometry.Open())
            {
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

                context.BeginFigure(start, false, false);

                DrawDragon(start, end, (int)nestingLevelInput.Value!, canvas, Turn.Left, context);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void DrawDragon(Point start, Point end, int depth_level, Canvas canvas, Turn turn, StreamGeometryContext context)
        {
            Point n;

            if (depth_level > 0)
            {
                switch (turn)
                {
                    case Turn.Left:
                        n = new Point()
                        {
                            X = ((start.X + end.X) / 2) + ((end.Y - start.Y) / 2),
                            Y = ((start.Y + end.Y) / 2) - ((end.X - start.X) / 2),
                        };
                        break;
                    case Turn.Right:
                        n = new Point()
                        {
                            X = ((start.X + end.X) / 2) - ((end.Y - start.Y) / 2),
                            Y = ((start.Y + end.Y) / 2) + ((end.X - start.X) / 2),
                        };
                        break;
                    default:
                        return;
                }

                DrawDragon(start, n, depth_level - 1, canvas, Turn.Left, context);
                DrawDragon(n, end, depth_level - 1, canvas, Turn.Right, context);
            }
            else
            {
                context.LineTo(end, true, false);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvas_width = canvas.ActualWidth;
            canvas_height = canvas.ActualHeight;
        }
    }
}
