﻿using System;
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

        int start_x = 225;
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
            if (fillColorPicker.SelectedColor != null) 
            { 
                floodFillButton.IsEnabled = true;
                stringScanFillButton.IsEnabled = true;
            }
            else
            {
                floodFillButton.IsEnabled = false;
                stringScanFillButton.IsEnabled = false;
            }
        }

        private void stringScanFillButton_Click(object sender, RoutedEventArgs e)
        {
            LineScanFilling();
        }
        private void floodFillButton_Click(object sender, RoutedEventArgs e)
        {
            FloodFill(start_x, start_y);
        }

        private void clearFillingButton_Click(object sender, RoutedEventArgs e)
        {
            wb.Clear();

            wb.DrawPolyline(coordinates, Colors.Black);

            image.Source = wb;
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

        private async void FloodFill(int start_x, int start_y)
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

                    await Task.Delay(1);
                }
            }
        }

        private async void LineScanFilling()
        {
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

            List<Point> polygon_points = ConvertToPointList(coordinates);

            await Task.Run(() =>
            {
                double minY = polygon_points.Min(p => p.Y);
                double maxY = polygon_points.Max(p => p.Y);

                for (int y = (int)minY; y < (int)maxY; y++)
                {
                    List<double> nodeX = new List<double>();
                    for (int i = 0; i < polygon_points.Count; i++)
                    {
                        Point p1 = polygon_points[i];
                        Point p2 = polygon_points[(i + 1) % polygon_points.Count];

                        if ((p1.Y < y && p2.Y >= y) || (p2.Y < y && p1.Y >= y))
                        {
                            nodeX.Add(p1.X + (y - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X));
                        }
                    }

                    nodeX.Sort();

                    wb.Dispatcher.Invoke(() =>
                    {
                        for (int i = 0; i < nodeX.Count; i += 2)
                        {                        
                            if (nodeX[i] >= wb.Width) break;
                            if (nodeX[i + 1] > 0)
                            {
                                for (int x = (int)nodeX[i] + 1; x < nodeX[i + 1]; x++)
                                {
                                    if (x >= 0 && x < wb.Width)
                                    {
                                        Color currentPixelColor = wb.GetPixel(x, y);
                                        if (currentPixelColor == target_color)
                                        {
                                            wb.SetPixel(x, y, filling_color);
                                        }
                                    }
                                }
                            }
                            Thread.Sleep(1);
                        }
                    });
                }
            });
        }

        static List<Point> ConvertToPointList(int[] coordinates)
        {
            if (coordinates.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid number of coordinates.");
            }

            List<Point> pointsList = new List<Point>();

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                int x = coordinates[i];
                int y = coordinates[i + 1];
                Point point = new Point(x, y);
                pointsList.Add(point);
            }

            return pointsList;
        }
    }
    public class Pixel
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public Pixel(int x, int y) {  X = x; Y = y; }
    }
}
