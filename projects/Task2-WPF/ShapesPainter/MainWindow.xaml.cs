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
        //Point[] mass = new Point[5];
        public MainWindow()
        {
          
            InitializeComponent();
          
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

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
