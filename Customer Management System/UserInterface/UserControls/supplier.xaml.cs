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

namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for supplier.xaml
    /// </summary>
    public partial class supplier : UserControl
    {
        public supplier()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (item_id.Text != "" && item_quantity.Text != "")
            {
                login obj6 = new login();
                obj6.OpenDBConnection();
                string s = DateTime.Now.ToString();


                obj6.add_items(item_id.Text, item_quantity.Text, s);
                label_product.Content = obj6.SUPPLIER_PRO_NAME;
                item_id.Text = "";
                // item_name.Text = "";
                item_quantity.Text = "";
                //txt_prize.Text = "";
                MessageBox.Show("Enter Next Item", "New item", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("Fill All the box properly...!!");
            }
            item_id.Text = "";
            // item_name.Text = "";
            item_quantity.Text = "";
            //txt_prize.Text = "";

        }

        private void item_quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void item_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }








}
