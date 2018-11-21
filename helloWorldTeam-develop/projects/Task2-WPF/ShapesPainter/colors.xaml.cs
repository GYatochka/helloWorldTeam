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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace ShapesPainter
{
    /// <summary>
    /// Interaction logic for colors.xaml
    /// </summary>
    public partial class colors : Window
    {
        int x_pos = 0;
        int y_pos = 0;
        public SolidColorBrush brush;
        public SolidColorBrush poly_brush { get; set; }

        public colors()
        {
            InitializeComponent();
        }

       /// <summary>
       /// fill rectangle for choosing showing color in choosed color 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void MouseDowsnEvent(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                selected_rec.Fill = brush;
                poly_brush = brush;
            }
        }

        /// <summary>
        /// changing color on color elipse when you move mouse around color wheel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                poly_brush = brush;
            }

        }

        /// <summary>
        /// method for picking color from color wheel 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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

        /// <summary>
        /// open default windows palett for choosing color and fill selected rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void palette_button_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog d = new ColorDialog();
            brush = new SolidColorBrush();
            d.ShowDialog();
            Color a = new Color();
            a.R = d.Color.R;
            a.G = d.Color.G;
            a.B = d.Color.B;

            brush.Color = Color.FromRgb(a.R, a.G, a.B);
            selected_rec.Fill = brush;
            palette_button.IsEnabled = false;
            poly_brush = brush;
        }

        /// <summary>
        /// for closes window when you select color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void select_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
