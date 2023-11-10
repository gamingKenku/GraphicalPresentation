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
using System.Threading;

namespace PolygonFillingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteableBitmap wb;
        Int32Rect pixel_rect;

        int start_x = 160;
        int start_y = 170;

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

            wb = new WriteableBitmap(483, 392, 96, 96, PixelFormats.Pbgra32, null);

            wb.DrawPolyline(coordinates, Colors.Black);

            pixel_rect = new Int32Rect(0, 0, 1, 1);

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
            FloodFill(start_x, start_y);

            //image.Source = wb;
        }

        private void clearFillingButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WritePixel(int x, int y, Color color)
        {
            // Calculate the index of the pixel in the buffer
            int stride = wb.PixelWidth * 4; // Assuming Pbgra32 format
            int index = y * stride + x * 4;

            // Create a pixel buffer (4 bytes for Pbgra32 format)
            byte[] pixelBuffer = new byte[4];

            // Set the color values in the pixel buffer
            pixelBuffer[0] = color.B;
            pixelBuffer[1] = color.G;
            pixelBuffer[2] = color.R;
            pixelBuffer[3] = color.A;

            pixel_rect.X = x; pixel_rect.Y = y;

            // Write the pixel data to the WriteableBitmap
            wb.WritePixels(pixel_rect, pixelBuffer, 4, 0);
        }

        private void FloodFill(int start_x, int start_y)
        {
            Stack<Pixel> unfilled_pixels = new Stack<Pixel>();
            Color filling_color;

            Color target_color = wb.GetPixel(start_x, start_y);

            if (fillColorPicker.SelectedColor.HasValue)
            {
                filling_color = (Color)fillColorPicker.SelectedColor;
            }
            else
            {
                return;
            }

            Pixel start_pixel = new Pixel(start_x, start_y);
            unfilled_pixels.Push(start_pixel);

            while (unfilled_pixels.Count > 0)
            {
                Pixel pixel = unfilled_pixels.Pop();

                if (wb.GetPixel(pixel.X, pixel.Y) == target_color)
                {
                    WritePixel(pixel.X, pixel.Y, filling_color);

                    unfilled_pixels.Push(new Pixel(pixel.X, pixel.Y + 1));
                    unfilled_pixels.Push(new Pixel(pixel.X + 1, pixel.Y));
                    unfilled_pixels.Push(new Pixel(pixel.X, pixel.Y - 1));
                    unfilled_pixels.Push(new Pixel(pixel.X - 1, pixel.Y));

                    Thread.Sleep(1);
                }
            }
        }
    }
    public class Pixel
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public Pixel(int x, int y) {  X = x; Y = y; }
    }
}
