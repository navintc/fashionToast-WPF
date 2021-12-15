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
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Window
    {
        public CartPage()
        {
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("-----------------------------------------------------"); 
            MainWindow mw = new MainWindow();
            foreach (Object obj in mw.cart)
                System.Diagnostics.Debug.WriteLine("{0}", obj);
        }
    }
}
