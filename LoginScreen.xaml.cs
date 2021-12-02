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

namespace fashionApp2
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            
                if (txtpw.Password == ("password") && txtUserName.Text == ("customer"))
                {
                    MainWindow m = new MainWindow();
                    m.Show();

                }
                else
                {
                    MessageBox.Show("Password or username is incorrecr! Please try again!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            

           
            
        }
    }
}
