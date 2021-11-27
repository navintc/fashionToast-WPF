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
using System.IO;
using System.Xml;
using System.Windows.Markup;

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




            CreateDynamicWPFGrid();

        }



        private void CreateDynamicWPFGrid()

        {

            // Create the Grid

            Grid DynamicGrid = new Grid();

            DynamicGrid.Width = 400;

            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;

            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;

            DynamicGrid.ShowGridLines = true;

            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);



            // Create Columns

            ColumnDefinition gridCol1 = new ColumnDefinition();

            ColumnDefinition gridCol2 = new ColumnDefinition();

            ColumnDefinition gridCol3 = new ColumnDefinition();

            DynamicGrid.ColumnDefinitions.Add(gridCol1);

            DynamicGrid.ColumnDefinitions.Add(gridCol2);

            DynamicGrid.ColumnDefinitions.Add(gridCol3);



            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(45);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(45);

            RowDefinition gridRow3 = new RowDefinition();

            gridRow3.Height = new GridLength(45);

            DynamicGrid.RowDefinitions.Add(gridRow1);

            DynamicGrid.RowDefinitions.Add(gridRow2);

            DynamicGrid.RowDefinitions.Add(gridRow3);



            // Add first column header

            TextBlock txtBlock1 = new TextBlock();

            txtBlock1.Text = "Author Name";

            txtBlock1.FontSize = 14;

            txtBlock1.FontWeight = FontWeights.Bold;

            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock1.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock1, 0);

            Grid.SetColumn(txtBlock1, 0);



            // Add second column header

            TextBlock txtBlock2 = new TextBlock();

            txtBlock2.Text = "Age";

            txtBlock2.FontSize = 14;

            txtBlock2.FontWeight = FontWeights.Bold;

            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 0);

            Grid.SetColumn(txtBlock2, 1);



            // Add third column header

            TextBlock txtBlock3 = new TextBlock();

            txtBlock3.Text = "Book";

            txtBlock3.FontSize = 14;

            txtBlock3.FontWeight = FontWeights.Bold;

            txtBlock3.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock3.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock3, 0);

            Grid.SetColumn(txtBlock3, 2);



            //// Add column headers to the Grid

            DynamicGrid.Children.Add(txtBlock1);

            DynamicGrid.Children.Add(txtBlock2);

            DynamicGrid.Children.Add(txtBlock3);



            // Create first Row

            TextBlock authorText = new TextBlock();

            authorText.Text = "Mahesh Chand";

            authorText.FontSize = 12;

            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 1);

            Grid.SetColumn(authorText, 0);



            TextBlock ageText = new TextBlock();

            ageText.Text = "33";

            ageText.FontSize = 12;

            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 1);

            Grid.SetColumn(ageText, 1);



            TextBlock bookText = new TextBlock();

            bookText.Text = "GDI+ Programming";

            bookText.FontSize = 12;

            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 1);

            Grid.SetColumn(bookText, 2);

            // Add first row to Grid

            DynamicGrid.Children.Add(authorText);

            DynamicGrid.Children.Add(ageText);

            DynamicGrid.Children.Add(bookText);



            // Create second row

            authorText = new TextBlock();

            authorText.Text = "Mike Gold";

            authorText.FontSize = 12;

            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 2);

            Grid.SetColumn(authorText, 0);



            ageText = new TextBlock();

            ageText.Text = "35";

            ageText.FontSize = 12;

            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 2);

            Grid.SetColumn(ageText, 1);



            bookText = new TextBlock();

            bookText.Text = "Programming C#";

            bookText.FontSize = 12;

            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 2);

            Grid.SetColumn(bookText, 2);



            // Add second row to Grid

            DynamicGrid.Children.Add(authorText);

            DynamicGrid.Children.Add(ageText);

            DynamicGrid.Children.Add(bookText);



            // Display grid into a Window

            //MainWindow.Content = DynamicGrid;

            CreateControls();
        }







        private void CreateControls()
        {
            string xaml =
            "<Grid Margin='10' " +
                "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' " +
                "xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' " +
                "xmlns:sdk='http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk'>" +
                "<Grid.ColumnDefinitions>" +
                    "<ColumnDefinition Width='100' />" +
                    "<ColumnDefinition Width='*' />" +
                "</Grid.ColumnDefinitions>" +

                "<Grid.RowDefinitions>" +
                    "<RowDefinition Height='Auto' />" +
                    "<RowDefinition Height='Auto' />" +
                    "<RowDefinition Height='Auto' />" +
                    "<RowDefinition Height='*' />" +
                "</Grid.RowDefinitions>" +

                "<TextBlock Text='First Name' Height='19' Margin='0,7,31,4' />" +
                "<TextBox x:Name='FirstName' Margin='3' Grid.Row='0' Grid.Column='1' />" +

                "<TextBlock Text='Last Name' Margin='0,7,6,3' Grid.Row='1' Height='20' />" +
                "<TextBox x:Name='LastName' Margin='3' Grid.Row='1' Grid.Column='1' />" +

                "<TextBlock Text='Date of Birth' Grid.Row='2' Margin='0,9,0,0' Height='21' />" +
                

                "<Button x:Name='SubmitChanges' Grid.Row='3' Grid.Column='3' " +
                    "HorizontalAlignment='Right' VerticalAlignment='Top' " +
                    "Margin='3' Width='80' Height='25' Content='Save' />" +


            "</Grid>";


            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);

            UIElement tree = (UIElement)XamlReader.Load(xmlReader);

            DataGrid1.Children.Add(tree);

           
        }
    }
}
