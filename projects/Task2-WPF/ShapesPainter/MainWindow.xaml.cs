using System;
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
using System.Threading;
using System.ComponentModel;

namespace ShapesPainter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        List<Polygon> polygons = new List<Polygon>();
        private string _pictureName;

        
        //for counting angles in shape
        int count = 0;

        int z_index_count = 0;

        bool dragging = false;
        PointCollection Points = new PointCollection();
        int clickCounter = 0;
        Point clickV;
        Shape selectedShape;

        public MainWindow()
        {            
            InitializeComponent();           

            //event for moving shapes
            canvas.MouseMove += new MouseEventHandler(canvas1_MouseMove);
            //event for choosing shapes
            canvas.MouseUp += new MouseButtonEventHandler(canvas1_MouseUp);

        }
       
        /// <summary>
        /// method for open xaml files from folder by using dialog window and loading to the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// method for saving canvas in xaml file by using dialog window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Clear canvas in other words creating new picture 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

        }

        /// <summary>
        /// method for loading xaml content to the canvas
        /// </summary>
        /// <param name="originalElement"></param>
        /// <returns></returns>
        FrameworkElement CloneFrameworkElement(FrameworkElement originalElement)
        {
            string elementString = XamlWriter.Save(originalElement);

            StringReader stringReader = new StringReader(elementString);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            FrameworkElement clonedElement = (FrameworkElement)XamlReader.Load(xmlReader);

            return clonedElement;
        }

        /// <summary>
        /// method for creating and drawing pentagons on the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_LeftMouseClick(object sender, MouseButtonEventArgs e)
        {
            Polygon p = new Polygon();
            if (dragging == false)
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
               
                Point point = e.GetPosition(canvas);   //create Points 
                Ellipse elipse = new Ellipse();

                elipse.Width = 4; 
                elipse.Height = 4;

                elipse.StrokeThickness = 2;
                elipse.Stroke = Brushes.Black;
                elipse.Margin = new Thickness(point.X - 2, point.Y - 2, 0, 0);
          
                canvas.Children.Add(elipse);   
                Points.Add(point);
            }

                if (clickCounter % 5 == 0)   //if we have 5 points we create Pentagon
                {
                    PointCollection Points1 = new PointCollection();
                    

                    SolidColorBrush Brush = new SolidColorBrush();
                    Brush.Color = Colors.Black;
               

                    SolidColorBrush blackBrush = new SolidColorBrush();
                    blackBrush.Color = Colors.Black;
                    
                    for (int i = 0; i < 5; i++)
                    {
                        Points1.Add(Points[i]);
                    }


                    p.Stroke = Brush;

                    p.Stroke = blackBrush;

                    p.Points = Points1;
                 
                    Canvas.SetZIndex(p, count);    
                    canvas.Children.Add(p);
                    polygons.Add(p);
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = "Pentagon" + polygons.Count;
                    cmbx.Items.Add(item);
                    Points.Clear();
                   

                 

                    //--------------- added by Zlata-------------------------



                    /// create new window where user can choose color for his pentagon 
                    Canvas.SetZIndex(p, count);
                    colors c = new colors();
                    c.ShowDialog();
                    p.Fill = c.poly_brush;

                    count++;

                    int ellipse_count = 0;
                    for (int i = 0; i < canvas.Children.Count;)
                    {
                        if (canvas.Children[i].GetType() == typeof(Ellipse))
                        {
                            canvas.Children.Remove(canvas.Children[i]);
                            ellipse_count++;
                        }
                        else { i++; }
                        if (ellipse_count == 5) { break; }
                    }

                }
                p.MouseDown += new MouseButtonEventHandler(myPoly_MouseDown);

               
            }

        }
       
       /// <summary>
       /// for leaving your shape at new coordinates
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void canvas1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = false;
            
        }
        /// <summary>
        /// for moving your shape to the new coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            Polygon p = selectedShape as Polygon;
            
            if (dragging)
            {
               
                Canvas.SetLeft(p, e.GetPosition(canvas).X - clickV.X);
                Canvas.SetTop(p, e.GetPosition(canvas).Y - clickV.Y);

                if ((Mouse.GetPosition(this).X - e.GetPosition(canvas).X) < 147 || (Mouse.GetPosition(this).X - e.GetPosition(canvas).Y) < 10)
                {
                    Canvas.SetLeft(p, 150);
                    Canvas.SetTop(p, 20);
                }
            }
        }
        /// <summary>
        /// for choosing your shape 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myPoly_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dragging = true;
            selectedShape = sender as Shape;
            clickV = e.GetPosition(selectedShape);

        }
/// <summary>
/// method for choosing Pentagon
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void sel_changed(object sender, SelectionChangedEventArgs e)
        {
            int index = cmbx.SelectedIndex;
            for (int i = 0; i < polygons.Count; i++)
            {
                if(i!=index)
                Canvas.SetZIndex(polygons[i], 0);

            }
            Canvas.SetZIndex(polygons[index], 100);
          
        }
    }
}
