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

namespace PolygonFillingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] coordinates = new int[]
        {
            150, 175,
            175, 200,
            175, 185,
            275, 185,
            275, 200,
            300, 175,
            275, 150,
            275, 165,
            235, 165,
            235, 115,
            250, 115,
            225, 90,
            200, 115,
            215, 115,
            215, 165,
            175, 165,
            175, 150,
            150, 175
        };

        public MainWindow()
        {
            InitializeComponent();

            WriteableBitmap wb = new WriteableBitmap(483, 392, 96, 96, PixelFormats.Pbgra32, null);

            wb.DrawPolyline(coordinates, Colors.Black);

            image.Source = wb;
        }

        private void fillColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {

        }

        private void stringScanFillButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void floodFillButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clearFillingButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FloodFill(int start_x, int start_y)
        {

        }
    }
}
