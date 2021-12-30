 
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
    /// 
    public class SQLHolder
    {
        public string DatItemID { get; set; }
        public string DatName { get; set; }
        public int DatPrice { get; set; }
        public string DatColor { get; set; }
        public string DatStyle { get; set; }
        public string DatGender { get; set; }

    }

    public partial class MainWindow : Window
    {

        
        public static SQLHolder[] allRecords = null;


        public string selectedColor = null;
        public string selectedSize = null;
        
        public MainWindow()
        {
            InitializeComponent();
        }


        // this will run as soon as the window opens
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            sqlQueryLord("");

            fucking();

        }



        private void sqlQueryLord(string extendedQuery)
        {
            //'SQLServerConnections' is from the sqlserverconnections.cs
            SQLServerConnections.openConnection();

            SQLServerConnections.sql = "SELECT [itemID], [name], [price], [color], [style], [gender] from items " + extendedQuery ;

            SQLServerConnections.cmd.CommandType = CommandType.Text;
            SQLServerConnections.cmd.CommandText = SQLServerConnections.sql;

            SQLServerConnections.da = new SqlDataAdapter(SQLServerConnections.cmd);
            SQLServerConnections.dt = new DataTable();
            SQLServerConnections.da.Fill(SQLServerConnections.dt);

            newDG.ItemsSource = SQLServerConnections.dt.DefaultView;


            //Recieved data will be appended into the allRecords array. you can access each data by (allRecords[0].Col2)

            

            using (var reader = SQLServerConnections.cmd.ExecuteReader())
            {
                var list = new List<SQLHolder>();
                while (reader.Read())
                    list.Add(new SQLHolder { DatItemID = reader.GetString(0), DatName = reader.GetString(1), DatPrice = reader.GetInt32(2),
                        DatColor = reader.GetString(3), DatStyle = reader.GetString(4), DatGender = reader.GetString(5) });
                allRecords = list.ToArray();
            }

            SQLServerConnections.closeConnection();

            dataAssigner(allRecords);
        }


        //This function updates data in the blocks. Must give an object of SQLHolder
        private void dataAssigner(SQLHolder[] allRecords)
        {
            //System.Diagnostics.Debug.WriteLine(allRecords[0].DatName);




            /*
            int recordsCount = 6;
            if (allRecords.Count() > 8)
            {
                recordsCount = 6;
            }
            else {
                recordsCount = allRecords.Count();
            }
            for (int k=0; k< recordsCount; k++)
            {
                System.Diagnostics.Debug.WriteLine(allRecords[k].DatItemID);
                System.Diagnostics.Debug.WriteLine(allRecords[k].DatName);
                System.Diagnostics.Debug.WriteLine(allRecords[k].DatPrice);

                
            }
            */





            // If දාලා කෑලි කඩහන් array එකේ size එක බලලා.. මුලින්ම ඔක්කොම අලු කරන්න function එක්කුත් දාන්න.


            System.Windows.Controls.Image myImage = new System.Windows.Controls.Image();

            if (allRecords.Count() > 0)
            {
                lblItemName1.Content = allRecords[0].DatName;
                lblItemCat1.Content = allRecords[0].DatGender + " | " + allRecords[0].DatStyle;
                lblItemPrice1.Content = "LKR. " + allRecords[0].DatPrice;
                
                imgFa1.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[0].DatItemID + ".jpg"));
                rect1.Visibility = Visibility.Visible;
                btnAdd1.Visibility = Visibility.Visible;


                if (allRecords[0].DatColor == "Red")
                {
                    eclColour1.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[0].DatColor == "Yellow")
                {
                    eclColour1.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[0].DatColor == "Green")
                {
                    eclColour1.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[0].DatColor == "Blue")
                {
                    eclColour1.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[0].DatColor == "Black")
                {
                    eclColour1.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[0].DatColor == "White")
                {
                    eclColour1.Fill = new SolidColorBrush(Colors.White);
                }


            }

            // --------

            if (allRecords.Count() > 1)
            {

                lblItemName2.Content = allRecords[1].DatName;
                lblItemCat2.Content = allRecords[1].DatGender + " | " + allRecords[1].DatStyle;
                lblItemPrice2.Content = "LKR. " + allRecords[1].DatPrice;

                imgFa2.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[1].DatItemID + ".jpg"));
                rect2.Visibility = Visibility.Visible;
                btnAdd2.Visibility = Visibility.Visible;

                if (allRecords[1].DatColor == "Red")
                {
                    eclColour2.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[1].DatColor == "Yellow")
                {
                    eclColour2.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[1].DatColor == "Green")
                {
                    eclColour2.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[1].DatColor == "Blue")
                {
                    eclColour2.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[1].DatColor == "Black")
                {
                    eclColour2.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[1].DatColor == "White")
                {
                    eclColour2.Fill = new SolidColorBrush(Colors.White);
                }


            }
            // --------

            if (allRecords.Count() >2)
            {

                lblItemName3.Content = allRecords[2].DatName;
                lblItemCat3.Content = allRecords[2].DatGender + " | " + allRecords[2].DatStyle;
                lblItemPrice3.Content = "LKR. " + allRecords[2].DatPrice;

                imgFa3.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[2].DatItemID + ".jpg"));
                rect3.Visibility = Visibility.Visible;
                btnAdd3.Visibility = Visibility.Visible;

                if (allRecords[2].DatColor == "Red")
                {
                    eclColour3.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[2].DatColor == "Yellow")
                {
                    eclColour3.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[2].DatColor == "Green")
                {
                    eclColour3.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[2].DatColor == "Blue")
                {
                    eclColour3.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[2].DatColor == "Black")
                {
                    eclColour3.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[2].DatColor == "White")
                {
                    eclColour3.Fill = new SolidColorBrush(Colors.White);
                }


            }
            // --------



            if (allRecords.Count() > 3)
            {
                lblItemName4.Content = allRecords[3].DatName;
                lblItemCat4.Content = allRecords[3].DatGender + " | " + allRecords[3].DatStyle;
                lblItemPrice4.Content = "LKR. " + allRecords[3].DatPrice;

                imgFa4.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[3].DatItemID + ".jpg"));
                rect4.Visibility = Visibility.Visible;
                btnAdd4.Visibility = Visibility.Visible;

                if (allRecords[3].DatColor == "Red")
                {
                    eclColour4.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[3].DatColor == "Yellow")
                {
                    eclColour4.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[3].DatColor == "Green")
                {
                    eclColour4.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[3].DatColor == "Blue")
                {
                    eclColour4.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[3].DatColor == "Black")
                {
                    eclColour4.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[3].DatColor == "White")
                {
                    eclColour4.Fill = new SolidColorBrush(Colors.White);
                }


            }
            // --------


            if (allRecords.Count() > 4)
            {

                lblItemName5.Content = allRecords[4].DatName;
                lblItemCat5.Content = allRecords[4].DatGender + " | " + allRecords[4].DatStyle;
                lblItemPrice5.Content = "LKR. " + allRecords[4].DatPrice;

                imgFa5.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[4].DatItemID + ".jpg"));
                rect5.Visibility = Visibility.Visible;
                btnAdd5.Visibility = Visibility.Visible;

                if (allRecords[4].DatColor == "Red")
                {
                    eclColour5.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[4].DatColor == "Yellow")
                {
                    eclColour5.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[4].DatColor == "Green")
                {
                    eclColour5.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[4].DatColor == "Blue")
                {
                    eclColour5.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[4].DatColor == "Black")
                {
                    eclColour5.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[4].DatColor == "White")
                {
                    eclColour5.Fill = new SolidColorBrush(Colors.White);
                }

            }

            // --------


            if (allRecords.Count() > 5)
            {
                lblItemName6.Content = allRecords[5].DatName;
                lblItemCat6.Content = allRecords[5].DatGender + " | " + allRecords[5].DatStyle;
                lblItemPrice6.Content = "LKR. " + allRecords[5].DatPrice;

                imgFa6.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[5].DatItemID + ".jpg"));
                rect6.Visibility = Visibility.Visible;
                btnAdd6.Visibility = Visibility.Visible;

                if (allRecords[5].DatColor == "Red")
                {
                    eclColour6.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[5].DatColor == "Yellow")
                {
                    eclColour6.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[5].DatColor == "Green")
                {
                    eclColour6.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[5].DatColor == "Blue")
                {
                    eclColour6.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[5].DatColor == "Black")
                {
                    eclColour6.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[5].DatColor == "White")
                {
                    eclColour6.Fill = new SolidColorBrush(Colors.White);
                }
            }
            // --------

            if (allRecords.Count() > 6)
            {
                lblItemName7.Content = allRecords[6].DatName;
                lblItemCat7.Content = allRecords[6].DatGender + " | " + allRecords[6].DatStyle;
                lblItemPrice7.Content = "LKR. " + allRecords[6].DatPrice;

                imgFa7.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[6].DatItemID + ".jpg"));
                rect7.Visibility = Visibility.Visible;
                btnAdd7.Visibility = Visibility.Visible;

                if (allRecords[6].DatColor == "Red")
                {
                    eclColour7.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[6].DatColor == "Yellow")
                {
                    eclColour7.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[6].DatColor == "Green")
                {
                    eclColour7.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[6].DatColor == "Blue")
                {
                    eclColour7.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[6].DatColor == "Black")
                {
                    eclColour7.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[6].DatColor == "White")
                {
                    eclColour7.Fill = new SolidColorBrush(Colors.White);
                }
            }

            // --------

            if (allRecords.Count() > 7)
            {
                lblItemName8.Content = allRecords[7].DatName;
                lblItemCat8.Content = allRecords[7].DatGender + " | " + allRecords[7].DatStyle;
                lblItemPrice8.Content = "LKR. " + allRecords[7].DatPrice;

                imgFa8.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/" + allRecords[7].DatItemID + ".jpg"));
                rect8.Visibility = Visibility.Visible;
                btnAdd8.Visibility = Visibility.Visible;

                if (allRecords[7].DatColor == "Red")
                {
                    eclColour8.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (allRecords[7].DatColor == "Yellow")
                {
                    eclColour8.Fill = new SolidColorBrush(Colors.Yellow);
                }
                else if (allRecords[7].DatColor == "Green")
                {
                    eclColour8.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (allRecords[7].DatColor == "Blue")
                {
                    eclColour8.Fill = new SolidColorBrush(Colors.Blue);
                }
                else if (allRecords[7].DatColor == "Black")
                {
                    eclColour8.Fill = new SolidColorBrush(Colors.Black);
                }
                else if (allRecords[7].DatColor == "White")
                {
                    eclColour8.Fill = new SolidColorBrush(Colors.White);
                }
            }

            // --------
        }


        private void grayNuller()
        {
            lblItemName1.Content = "";
            lblItemCat1.Content = "  ";
            lblItemPrice1.Content = " ";
            imgFa1.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour1.Fill = new SolidColorBrush(Colors.White);
            eclColour1.Stroke = new SolidColorBrush(Colors.White);
            rect1.Visibility = Visibility.Hidden;
            btnAdd1.Visibility = Visibility.Hidden;

            lblItemName2.Content = "";
            lblItemCat2.Content = "  ";
            lblItemPrice2.Content = " ";
            imgFa2.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour2.Fill = new SolidColorBrush(Colors.White);
            eclColour2.Stroke = new SolidColorBrush(Colors.White);
            rect2.Visibility = Visibility.Hidden;
            btnAdd2.Visibility = Visibility.Hidden;

            lblItemName3.Content = "";
            lblItemCat3.Content = "  ";
            lblItemPrice3.Content = "";
            imgFa3.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour3.Fill = new SolidColorBrush(Colors.White);
            eclColour3.Stroke = new SolidColorBrush(Colors.White);
            rect3.Visibility = Visibility.Hidden;
            btnAdd3.Visibility = Visibility.Hidden;

            lblItemName4.Content = "";
            lblItemCat4.Content = "  ";
            lblItemPrice4.Content = "";
            imgFa4.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour4.Fill = new SolidColorBrush(Colors.White);
            eclColour4.Stroke = new SolidColorBrush(Colors.White);
            rect4.Visibility = Visibility.Hidden;
            btnAdd4.Visibility = Visibility.Hidden;

            lblItemName5.Content = "";
            lblItemCat5.Content = "  ";
            lblItemPrice5.Content = "";
            imgFa5.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour5.Fill = new SolidColorBrush(Colors.White);
            eclColour5.Stroke = new SolidColorBrush(Colors.White);
            rect5.Visibility = Visibility.Hidden;
            btnAdd5.Visibility = Visibility.Hidden;

            lblItemName6.Content = "";
            lblItemCat6.Content = "  ";
            lblItemPrice6.Content = "";
            imgFa6.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour6.Fill = new SolidColorBrush(Colors.White);
            eclColour6.Stroke = new SolidColorBrush(Colors.White);
            rect6.Visibility = Visibility.Hidden;
            btnAdd6.Visibility = Visibility.Hidden;

            lblItemName7.Content = "";
            lblItemCat7.Content = "  ";
            lblItemPrice7.Content = " ";
            imgFa7.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour7.Fill = new SolidColorBrush(Colors.White);
            eclColour7.Stroke = new SolidColorBrush(Colors.White);
            rect7.Visibility = Visibility.Hidden;
            btnAdd7.Visibility = Visibility.Hidden;


            lblItemName8.Content = "";
            lblItemCat8.Content = "  ";
            lblItemPrice8.Content = " ";
            imgFa8.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/img/logoGray.png"));
            eclColour8.Fill = new SolidColorBrush(Colors.White);
            eclColour8.Stroke = new SolidColorBrush(Colors.White);
            rect8.Visibility = Visibility.Hidden;
            btnAdd8.Visibility = Visibility.Hidden;
        }
        //useless ATM
        private void fucking()
        {
            
            double[] marginA = { 2.4, 228.4 };
            double[] marginB = { 14, 14 };
            double[] marginC = { 0, 0 };
            double[] marginD = { 0, 0};

            // Create a Grid and add it to a component of your page
            Grid mainGrid = new Grid();
            DataGrid1.Children.Add(mainGrid);

            for (int i = 0; i < 2; i++)
            {
                // I am creating a Grid with a TextBlock inside, 
                // it will have the same apperance as a Rectangle, 
                // but this way you can have a Text inside
                Grid g = new Grid();
                TextBlock tb = new TextBlock();

                tb.Text = i.ToString();
                g.Children.Add(tb);

                // Here you set the Grid properties, such as border and alignment
                // You can add other properties and events you need
             
                g.HorizontalAlignment = HorizontalAlignment.Stretch;
                g.VerticalAlignment = VerticalAlignment.Stretch;
                //g.Margin = new Thickness(marginA[i], marginB[i], marginC[i], marginD[i]);


                // Add the newly created Grid to the outer Grid
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.Children.Add(g);

                // Set the row of the Grid. 
                Grid.SetRow(g, i);
            }
        }



        private void rectColorChanger(string a)
        {
            switch (a){
                case "Red":
                    rectBla.Stroke =  new SolidColorBrush(Colors.White);
                    rectWhi.Stroke = new SolidColorBrush(Colors.White);
                    rectBlu.Stroke = new SolidColorBrush(Colors.White);
                    rectRed.Stroke = new SolidColorBrush(Colors.Black);
                    rectGre.Stroke = new SolidColorBrush(Colors.White);
                    rectYel.Stroke = new SolidColorBrush(Colors.White);
                    break;

                case "Blue":
                    rectBla.Stroke = new SolidColorBrush(Colors.White);
                    rectWhi.Stroke = new SolidColorBrush(Colors.White);
                    rectBlu.Stroke = new SolidColorBrush(Colors.Black);
                    rectRed.Stroke = new SolidColorBrush(Colors.White);
                    rectGre.Stroke = new SolidColorBrush(Colors.White);
                    rectYel.Stroke = new SolidColorBrush(Colors.White);
                    break;

                case "Green":
                    rectBla.Stroke = new SolidColorBrush(Colors.White);
                    rectWhi.Stroke = new SolidColorBrush(Colors.White);
                    rectBlu.Stroke = new SolidColorBrush(Colors.White);
                    rectRed.Stroke = new SolidColorBrush(Colors.White);
                    rectGre.Stroke = new SolidColorBrush(Colors.Black);
                    rectYel.Stroke = new SolidColorBrush(Colors.White);
                    break;

                case "Yellow":
                    rectBla.Stroke = new SolidColorBrush(Colors.White);
                    rectWhi.Stroke = new SolidColorBrush(Colors.White);
                    rectBlu.Stroke = new SolidColorBrush(Colors.White);
                    rectRed.Stroke = new SolidColorBrush(Colors.White);
                    rectGre.Stroke = new SolidColorBrush(Colors.White);
                    rectYel.Stroke = new SolidColorBrush(Colors.Black);
                    break;

                case "Black":
                    rectBla.Stroke = new SolidColorBrush(Colors.Black);
                    rectWhi.Stroke = new SolidColorBrush(Colors.White);
                    rectBlu.Stroke = new SolidColorBrush(Colors.White);
                    rectRed.Stroke = new SolidColorBrush(Colors.White);
                    rectGre.Stroke = new SolidColorBrush(Colors.White);
                    rectYel.Stroke = new SolidColorBrush(Colors.White);
                    break;

                case "White":
                    rectBla.Stroke = new SolidColorBrush(Colors.White);
                    rectWhi.Stroke = new SolidColorBrush(Colors.Black);
                    rectBlu.Stroke = new SolidColorBrush(Colors.White);
                    rectRed.Stroke = new SolidColorBrush(Colors.White);
                    rectGre.Stroke = new SolidColorBrush(Colors.White);
                    rectYel.Stroke = new SolidColorBrush(Colors.White);
                    break;

                case "All":
                    rectBla.Stroke = new SolidColorBrush(Colors.Black);
                    rectWhi.Stroke = new SolidColorBrush(Colors.Black);
                    rectBlu.Stroke = new SolidColorBrush(Colors.Black);
                    rectRed.Stroke = new SolidColorBrush(Colors.Black);
                    rectGre.Stroke = new SolidColorBrush(Colors.Black);
                    rectYel.Stroke = new SolidColorBrush(Colors.Black);
                    break;
            }
        }

        // Clicking Color Bottons

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ButtonRed_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ebuwa Rathu");
            selectedColor = "Red";
            rectColorChanger("Red");
        }

        private void ButtonGre_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ebuwa Kola");
            selectedColor = "Green";
            rectColorChanger("Green");
        }
        private void ButtonBlu_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ebuwa Nil");
            selectedColor = "Blue";
            rectColorChanger("Blue");
        }
        private void ButtonBla_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ebuwa Kalu");
            selectedColor = "Black";
            rectColorChanger("Black");
        }

        private void ButtonWhi_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ebuwa Sudu");
            selectedColor = "White";
            rectColorChanger("White");
        }

        private void ButtonYel_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ebuwa Kaha");
            selectedColor = "Yellow";
            rectColorChanger("Yellow");
        }




        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(comboStyle.Text);
            rectColorChanger("All");

            radioAll.IsChecked = true;
            selectedColor = null;
            comboStyle.Text = "";
            sqlQueryLord("");
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            string colorString = "";
            string styleString = "";
            string selectedGender = "Men' OR gender='Women";

            grayNuller();


            if (radioMen.IsChecked == true) {
                selectedGender = "Men";

            } else if (radioWomen.IsChecked == true) {
                selectedGender = "Women";
            }



            if (selectedColor != null)
            {
                colorString = " AND Color ='" + selectedColor + "' ";
            }

            if (comboStyle.Text != "")
            {
                styleString = " AND style ='" + comboStyle.Text + "' ";
            }

            sqlQueryLord("where (gender='" + selectedGender + "') " + styleString +  colorString + ";");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen m = new LoginScreen();
            this.Close();
            m.Show();
        }

        private void btnAdd1_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[0].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[0].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[0].DatPrice.ToString());
        }

        private void btnAdd2_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[1].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[1].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[1].DatPrice.ToString());
        }
        private void btnAdd3_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[2].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[2].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[2].DatPrice.ToString());
        }
        private void btnAdd4_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[3].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[3].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[3].DatPrice.ToString());
        }

        private void btnAdd5_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[4].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[4].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[4].DatPrice.ToString());
        }

        private void btnAdd6_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[5].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[5].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[5].DatPrice.ToString());
        }

        private void btnAdd7_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[6].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[6].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[6].DatPrice.ToString());
        }

        private void btnAdd8_Click(object sender, RoutedEventArgs e)
        {
            FunkyDataInterface.cart.Add(allRecords[7].DatItemID.ToString());
            FunkyDataInterface.cartNames.Add(allRecords[7].DatName.ToString());
            FunkyDataInterface.pricesList.Add(allRecords[7].DatPrice.ToString());

            foreach (Object obj in FunkyDataInterface.cart)
                System.Diagnostics.Debug.WriteLine("{0}", obj);
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            CartPage cartWindow = new CartPage();
            this.Close();
            cartWindow.Show();
        }
    }
}

