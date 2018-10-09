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
using Microsoft.Win32;

namespace ShapesPainter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Point[] mass = new Point[5];
        private string _pictureName;
        public MainWindow()
        {
          
            InitializeComponent();
          
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "*"; // Default file name
            dlg.DefaultExt = "bmp"; // Default file extension
            dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png |Tiff Image (.tiff)|*.tiff |Wmf Image (.wmf)|*.wmf"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }


        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow();
            createWindow.Show();
             if (createWindow.Created())
             {
            _pictureName = createWindow.getName();
            createWindow.Close();
            }

        }
        private void canvas_LeftMouseClick(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(canvas);
            Ellipse elipse = new Ellipse();

            elipse.Width = 4;
            elipse.Height = 4;

            elipse.StrokeThickness = 2;
            elipse.Stroke = Brushes.Black;
            elipse.Margin = new Thickness(point.X - 2, point.Y - 2, 0, 0);

            canvas.Children.Add(elipse);

        }
    }
}
