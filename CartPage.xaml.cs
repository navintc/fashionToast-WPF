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

using System.Collections;
using fashionApp2.Classes;

namespace fashionApp2
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Window
    {

        double totalPrice = 0;

        public CartPage()
        {
            InitializeComponent();
            
            tesing();
            


        }
       
        
        public void tesing() {
            System.Diagnostics.Debug.WriteLine("-----------------------------------------------------");

            foreach (Object obj in FunkyDataInterface.cartNames)
            {
                System.Diagnostics.Debug.WriteLine("{0}", obj);
                
                cartitems.Items.Add(obj);
                
            }

            foreach (Object obj in FunkyDataInterface.pricesList){

                totalPrice = totalPrice + Convert.ToInt32(obj);
                 
            }


            finalBill.Content =("Rs. " + totalPrice + " /=");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen m = new LoginScreen();
            this.Close();
            m.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }


}
