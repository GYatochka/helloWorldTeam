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
<<<<<<< HEAD
        private string _pictureName;

        private MenuBar _menuBar;
=======
        //Point[] mass = new Point[5];
>>>>>>> 767a7f638d69269887ab6de5b654bb47644fac40
        public MainWindow()
        {
          
            InitializeComponent();
<<<<<<< HEAD

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

         private void Save_Click(object sender, RoutedEventArgs e)
         {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)cnv.RenderSize.Width,
                 (int)cnv.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
             rtb.Render(cnv);

             var crop = new CroppedBitmap(rtb, new Int32Rect(50, 50, 250, 250));

             BitmapEncoder pngEncoder = new PngBitmapEncoder();
             pngEncoder.Frames.Add(BitmapFrame.Create(crop));

             using (var fs = System.IO.File.OpenWrite("logo.png"))
             {
                 pngEncoder.Save(fs);
             }
        }


         private void Create_Click(object sender, RoutedEventArgs e)
         {
             CreateWindow createWindow = new CreateWindow();
             createWindow.Show();
            // if (createWindow.isCreated)
            // {
                 _pictureName = createWindow.getName();
                 createWindow.Close();
             //}
=======
          
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

>>>>>>> 767a7f638d69269887ab6de5b654bb47644fac40
        }
    }

}


