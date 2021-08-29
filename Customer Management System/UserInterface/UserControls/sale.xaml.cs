using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WPF.MDI;
using UserInterface.UserControls;
using Entities;
using System.Data.SqlClient;

namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for sale.xaml
    /// </summary>
    public partial class sale : UserControl
    {
        string s = DateTime.Now.ToString();
        public sale()
        {
            InitializeComponent();
           // string s = DateTime.Now.ToString();
            date_Label.Content = s;
            login.AMOUNT_FINAL = 0;
            label_id.Content = "Nill";
            label_name.Content = "Nill";
            label_price.Content = "Nill";
            total_label.Content = "Rs." + "0";
           
        }
     

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void timebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void timebox_Loaded(object sender, RoutedEventArgs e)
        {
            //txt_rtime.Text = "20 : 00";
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txt_items_id.Text != "" && txt_cus_name.Text != "" && txt_quantity.Text != "")
            {
               
                login obj7 = new login();
               
             
                obj7.PRO_ID = txt_items_id.Text;
                obj7.QUANTITY_SALE = txt_quantity.Text;
                obj7.CUS_NAME = txt_cus_name.Text;

                obj7.add_sale_final();
                label_id.Content = obj7.SHOW_PID;
                label_name.Content = obj7.SHOW_PNAME ;
                label_price.Content = "Rs."+obj7.SHOW_PRICE ;

                txt_cus_name.IsEnabled = false;
                txt_quantity.Text ="";
                txt_items_id.Text = "" ;
                MessageBox.Show("Enter Next items..!!!","New items", MessageBoxButton.OK,MessageBoxImage.Question);
                total_label.Content = "Rs." + login.AMOUNT_FINAL.ToString();
            
               
            }
            else
            {
                MessageBox.Show("Empty Product does not allow..!!","Warning", MessageBoxButton.OK,MessageBoxImage.Error);
            }


        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt_cus_name.IsEnabled = true;
            txt_quantity.IsEnabled = true;
            txt_items_id.IsEnabled = true;
            txt_cus_name.Text = "";
            txt_quantity.Text = "";
            txt_items_id.Text = "";
            login.AMOUNT_FINAL = 0;
            total_label.Content = "Rs." +"0";
            date_Label.Content = DateTime.Now.ToString();

            label_id.Content = "Nill";
            label_name.Content = "Nill";
            label_price.Content = "Nill";

            MessageBox.Show("Enter New Customer..!", "New Customer", MessageBoxButton.OK, MessageBoxImage.Question);
            
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          MessageBoxResult r =  MessageBox.Show("Are you Sure you want end the sale ? ", "End Sale", MessageBoxButton.OKCancel, MessageBoxImage.Question);
          if (r == MessageBoxResult.OK)
          {
              // txt_cus_name.IsEnabled =  false;
               txt_quantity.IsEnabled =  false;
               txt_items_id.IsEnabled =  false;
              //login.AMOUNT_FINAL = 0;
              // login.AMOUNT_FINAL = 0;
              //tabdatabase.Visibility = Visibility.Visible
              // Page1 p = new Page1();
              // p.Visibility = Visibility.Visible;

              Window1 q = new Window1();
              q.Show();
              //IsClosedForLogoutOrLock = true;
              //MainWindow.IsClosedForLogoutOrLock = true;
            
          }
           // itemsList.ItemsSource = ;
          

        }
        
        private void total_sum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txt_quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
         
    }
}
