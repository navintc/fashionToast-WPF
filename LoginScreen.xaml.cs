
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
using Microsoft.Toolkit.Uwp.Notifications;
using fashionApp2.Classes;
using System.Data;

namespace fashionApp2
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    /// 
    public class SQLHolderLogin
    {
        public string password { get; set; }
        public string role { get; set; }

    }

    public partial class LoginScreen : Window
    {
        public static SQLHolderLogin[] allRecords = null;
        public LoginScreen()
        {
            InitializeComponent();

            //welcome toast
            new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Hey There!")
            .AddText("Welcome to FashionToast, the digital luxury clothing store.")
            .Show(); 
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //'SQLServerConnections' is from the sqlserverconnections.cs
            SQLServerConnections.openConnection();

            SQLServerConnections.sql = "SELECT [password], [role] from members where username='" + txtUserName.Text + "';";

            SQLServerConnections.cmd.CommandType = CommandType.Text;
            SQLServerConnections.cmd.CommandText = SQLServerConnections.sql;


            using (var reader = SQLServerConnections.cmd.ExecuteReader())
            {
                var list = new List<SQLHolderLogin>();
                while (reader.Read())
                    list.Add(new SQLHolderLogin
                    {
                        password = reader.GetString(0),
                        role = reader.GetString(1),

                    });
                allRecords = list.ToArray();
            }

            SQLServerConnections.closeConnection();

            //cleaning db data
            string r = allRecords[0].role.ToString(); 
            string p = allRecords[0].password.ToString();
            p = p.Replace(" ", String.Empty);
            r = r.Replace(" ", String.Empty);

            if (txtpw.Password.ToString() == p && r == "user") 
            {   
                    MainWindow m = new MainWindow();
                    this.Close();
                    m.Show();
            }
            else if (txtpw.Password.ToString() == p && r == "admin")
            {
                    AdminPortal n = new AdminPortal();
                    this.Close();
                    n.Show();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(allRecords[0].role);
                MessageBox.Show("Password or username is incorrect! Please try again!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
