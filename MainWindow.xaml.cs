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

//new
using System.Data;
using System.Data.SqlClient;
using fashionApp2.Classes;

namespace fashionApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //"SQLServerConnections" is from the sqlserverconnections.cs
            SQLServerConnections.openConnection();

            SQLServerConnections.sql = "SELECT [itemID], [name], [color] from items";


            SQLServerConnections.cmd.CommandType = CommandType.Text;
            SQLServerConnections.cmd.CommandText = SQLServerConnections.sql;

            SQLServerConnections.da = new SqlDataAdapter(SQLServerConnections.cmd);
            SQLServerConnections.dt = new DataTable();
            SQLServerConnections.da.Fill(SQLServerConnections.dt);


            newDG.ItemsSource = SQLServerConnections.dt.DefaultView;
            SQLServerConnections.closeConnection();


        }
    }
}
