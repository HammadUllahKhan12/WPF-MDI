using Entities;
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


namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for supp2.xaml
    /// </summary>
    public partial class supp2 : UserControl
    {
        public supp2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text != "" && txt_name.Text != "" && txt_price.Text != "")
            {
                login obj18 = new login();
                obj18.OpenDBConnection();
                string t = DateTime.Now.ToString();
                obj18.add_new_product(txt_name.Text.ToLower(), txt_id.Text, txt_price.Text);
                obj18.add_new_items_update_inv(txt_id.Text, "0",t);
                txt_id.Text = ""; 
                txt_name.Text = ""; 
                txt_price.Text = "";
                MessageBox.Show("Enter Next Item..!", "Enter item", MessageBoxButton.OK, MessageBoxImage.Question);
               

            }
            else
            {
                MessageBox.Show("Requirements Does no fill Properly ..!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txt_price_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void txt_price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_price_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
