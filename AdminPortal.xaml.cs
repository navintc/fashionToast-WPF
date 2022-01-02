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


using System.Data;
using System.Data.SqlClient;
using fashionApp2.Classes;

namespace fashionApp2
{
    /// <summary>
    /// Interaction logic for AdminPortal.xaml
    /// </summary>
    public partial class AdminPortal : Window
    {
        public AdminPortal()
        {
            InitializeComponent();
        }


        private void sqlQueryADD()
        {
            //'SQLServerConnections' is from the sqlserverconnections.cs
            SQLServerConnections.openConnection();

            SQLServerConnections.sql = "INSERT INTO items VALUES ('" + txtItemID.Text + "', '" + txtItemName.Text + "', " + txtPrice.Text + ", '" + comboColor.Text + "', '" + comboStyle.Text + "', '" + comboGender.Text + "');";

            SQLServerConnections.cmd.CommandType = CommandType.Text;
            SQLServerConnections.cmd.CommandText = SQLServerConnections.sql;

            SQLServerConnections.rd = SQLServerConnections.cmd.ExecuteReader();

            SQLServerConnections.closeConnection();

        }


        private void sqlQueryUPDATE()
        {
            //'SQLServerConnections' is from the sqlserverconnections.cs
            SQLServerConnections.openConnection();

            SQLServerConnections.sql = "UPDATE items SET [name]='" + txtItemName.Text + "',  [price]=" + txtPrice.Text + ", [color]='" + comboColor.Text + "',  [style]='" + comboStyle.Text + "', [gender]='" + comboGender.Text + "' WHERE [itemID]= '" + txtItemID.Text + "';";

            SQLServerConnections.cmd.CommandType = CommandType.Text;
            SQLServerConnections.cmd.CommandText = SQLServerConnections.sql;

            SQLServerConnections.rd = SQLServerConnections.cmd.ExecuteReader();

            SQLServerConnections.closeConnection();

        }


        private void sqlQueryDELETE()
        {
            //'SQLServerConnections' is from the sqlserverconnections.cs
            SQLServerConnections.openConnection();

            SQLServerConnections.sql = "DELETE FROM items where [itemID]='" + txtItemID.Text + "';";

            SQLServerConnections.cmd.CommandType = CommandType.Text;
            SQLServerConnections.cmd.CommandText = SQLServerConnections.sql;

            SQLServerConnections.rd = SQLServerConnections.cmd.ExecuteReader();

            SQLServerConnections.closeConnection();

        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen m = new LoginScreen();
            this.Close();
            m.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sqlQueryADD();

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UPDATE items SET [name]='" + txtItemName.Text + "',  [price]=" + txtPrice.Text + ", [color]='" + comboColor.Text + "',  [style]='" + comboStyle.Text + "', [gender]='" + comboGender.Text + "' WHERE [itemID]= '" + txtItemID.Text + "';");
            sqlQueryUPDATE();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            sqlQueryDELETE();
        }
    }
}
