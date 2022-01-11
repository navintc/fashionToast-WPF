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

namespace fashionApp2
{
    /// <summary>
    /// Interaction logic for Purchase2.xaml
    /// </summary>
    public partial class Purchase2 : Window
    {
        public Purchase2()
        {
            InitializeComponent();

            Random rnd = new Random();
            int num = rnd.Next();

            txtInvoice.Content = ("Reference Number: " + num);
            var image = new Image();
            String QRULR = ("https://qrtag.net/api/qr_4.png?url=" + num);
            var fullFilePath = @QRULR;



            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;
            wpimg.Children.Add(image);



            


        }
    }
}
