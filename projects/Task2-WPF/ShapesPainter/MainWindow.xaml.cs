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

namespace ShapesPainter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PointCollection Points = new PointCollection();
        int clickCounter = 0;
        public MainWindow()
        {
          
            InitializeComponent();
          
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

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
                SolidColorBrush blackBrush = new SolidColorBrush();
                blackBrush.Color = Colors.Black;
                for(int i=0;i<5;i++)
                {
                    Points1.Add(Points[i]);
                }
                p.Stroke = blackBrush;
                p.Points = Points1;
                canvas.Children.Add(p);
                Points.Clear();
                  
            }


        }
    }
}
