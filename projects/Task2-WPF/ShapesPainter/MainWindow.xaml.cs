﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
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

        PointCollection Points = new PointCollection();
        int clickCounter = 0;
        public MainWindow()
        {
          
            InitializeComponent();
          
        }
        // як часіки
        private void Open_Click(object sender, RoutedEventArgs e)
        {           
            //Open FileDialog
            string filename;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".xaml"; // Default file extension
            dlg.Filter = "Xaml documents (.xaml)|*.xaml"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;

                //Open Xaml
                StreamReader sR = new StreamReader(filename);
                string text = sR.ReadToEnd();
                sR.Close();

                StringReader stringReader = new StringReader(text);
                XmlReader xmlReader = XmlReader.Create(stringReader);

                Canvas wp = (Canvas) System.Windows.Markup.XamlReader.Load(xmlReader);

                canvas.Children.Clear(); // clear the existing children

                foreach (FrameworkElement child in wp.Children
                ) // and for each child in the WrapPanel we just loaded (wp)
                {
                    canvas.Children.Add(
                        CloneFrameworkElement(child)); // clone the child and add it to our existing wrap panel
                }
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder outstr = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;


            XamlDesignerSerializationManager dsm = new XamlDesignerSerializationManager(XmlWriter.Create(outstr, settings));
            dsm.XamlWriterMode = XamlWriterMode.Expression;

            XamlWriter.Save(this.canvas, dsm);
            string savedControls = outstr.ToString();

            //Show Dialog Box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".xaml"; // Default file extension
            dlg.Filter = "Xaml documents (.xaml)|*.xaml"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                File.WriteAllText(filename, savedControls);
            }

        }
        //

        //глянути, мб вийде зробити якось краще
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

        }
        FrameworkElement CloneFrameworkElement(FrameworkElement originalElement)
        {
            string elementString = XamlWriter.Save(originalElement);

            StringReader stringReader = new StringReader(elementString);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            FrameworkElement clonedElement = (FrameworkElement)XamlReader.Load(xmlReader);

            return clonedElement;
        }

        private void canvas_LeftMouseClick(object sender, MouseButtonEventArgs e)
        {
            clickCounter++;
          if(clickCounter>=5)
            {
                clickCounter = clickCounter % 5;
                if(clickCounter%5==0)
                {
                    clickCounter = 5;
                }
            }
            if (clickCounter <= 5)
            {
               
                Point point = e.GetPosition(canvas);
                Ellipse elipse = new Ellipse();

                elipse.Width = 4;
                elipse.Height = 4;

                elipse.StrokeThickness = 2;
                elipse.Stroke = Brushes.Black;
                elipse.Margin = new Thickness(point.X - 2, point.Y - 2, 0, 0);
          
                canvas.Children.Add(elipse);
                Points.Add(point);
            }
       
            if (clickCounter % 5 == 0)
            {
                PointCollection Points1 = new PointCollection();
                Polygon p = new Polygon();

                SolidColorBrush Brush = new SolidColorBrush();
                Brush.Color = Colors.Black;

                SolidColorBrush blackBrush = new SolidColorBrush();
                blackBrush.Color = Colors.Black;

                for(int i=0;i<5;i++)
                {
                    Points1.Add(Points[i]);
                }

               
                p.Stroke = Brush;

                p.Stroke = blackBrush;

                p.Points = Points1;
                canvas.Children.Add(p);
                Points.Clear();
                  
            }


        }
    }
}