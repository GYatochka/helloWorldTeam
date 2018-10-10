using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace ShapesPainter
{

    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        private bool isCreated = false;
        public CreateWindow()
        {
            InitializeComponent();
        }

        public string getName()
        {
            return namebox.Text;
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            isCreated = true;
        }

        public  bool Created()
        {
            return isCreated;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
