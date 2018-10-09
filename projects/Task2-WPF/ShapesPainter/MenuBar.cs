using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Win32;

namespace ShapesPainter
{
    class MenuBar
    {
        private string _pictureName;

        public void open()
        {
            
            
        }

        public void save(Canvas cnv)
        {
             /*RenderTargetBitmap rtb = new RenderTargetBitmap((int)cnv.RenderSize.Width,
                (int)cnv.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(cnv);

            var crop = new CroppedBitmap(rtb, new Int32Rect(50, 50, 250, 250));

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            using (var fs = System.IO.File.OpenWrite("logo.png"))
            {
                pngEncoder.Save(fs);
            }

           */
           using (FileStream fs = new FileStream("MyPicture", FileMode.Create))
             {
                 RenderTargetBitmap bmp = new RenderTargetBitmap((int)cnv.ActualWidth,
                     (int)cnv.ActualHeight, 1 / 96, 1 / 96, PixelFormats.Pbgra32);
                 bmp.Render(cnv);
                 BitmapEncoder encoder = new TiffBitmapEncoder();
                 encoder.Frames.Add(BitmapFrame.Create(bmp));
                 encoder.Save(fs);
                 fs.Close();
             }
        }

        public void create()
        {
            CreateWindow createWindow = new CreateWindow();
            createWindow.Show();
            if (createWindow.Created())
            {
                _pictureName = createWindow.getName();
            }
            
        }
    }
}
