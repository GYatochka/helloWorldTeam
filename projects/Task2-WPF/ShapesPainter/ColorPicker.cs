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
using System.IO;
using System.Windows.Forms;        //added reference to System.Windows.Forms and System.Drawing

namespace colorpicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {/*
        int x_pos = 0;
        int y_pos = 0;
        SolidColorBrush brush;
        bool button_hit = false;

        public MainWindow()
        {
           // InitializeComponent();
        }

        private void EnterKey(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                selected_rec.Fill = brush;

            }
        }

        private void MouseMoveEvent(object sender, System.Windows.Input.MouseEventArgs e)
        {
            palette_button.IsEnabled = true;
            x_pos = Convert.ToInt32(Mouse.GetPosition(this).X);
            y_pos = Convert.ToInt32(Mouse.GetPosition(this).Y);

            ImageSource img = image.Source;
            BitmapSource bmp = (BitmapSource)img;
            Color a = new Color();
            a = GetPixelColor(bmp, x_pos - 10, y_pos - 10);
            brush = new SolidColorBrush(a);
            ellipse.Fill = brush;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                selected_rec.Fill = brush;
            }

        }


        public static Color GetPixelColor(BitmapSource source, int x, int y)
        {
            Color c = Colors.White;
            if (source != null)
            {
                try
                {
                    CroppedBitmap cb = new CroppedBitmap(source, new Int32Rect(x, y, 1, 1));
                    var pixels = new byte[4];
                    cb.CopyPixels(pixels, 4, 0);
                    c = Color.FromRgb(pixels[2], pixels[1], pixels[0]);
                }
                catch (Exception) { }
            }
            return c;
        }

        private void palette_button_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog d = new ColorDialog();
            d.ShowDialog();
            Color a = new Color();
            a.R = d.Color.R;
            a.G = d.Color.G;
            a.B = d.Color.B;

            brush.Color = Color.FromRgb(a.R, a.G, a.B);
            selected_rec.Fill = brush;
            palette_button.IsEnabled = false;
        }*/
    }
}