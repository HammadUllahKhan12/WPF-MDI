using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int inv = 0;
        public Window1()
        {
            InitializeComponent();
            txtUserName.Content = "Sale By :: " + login.ID_STA + " [" + login.NAME_STA + "]";
           
            bill_show();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void itemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void bill_show ()
        {
            
            
            label_total.Content = " Rs. "+login.AMOUNT_FINAL.ToString();
            cus_name_label.Content = Sale_line.CUS_NAME.ToUpper();
            
            date_time.Content = Sale_line.DATE;

            itemsList.ItemsSource = login.BILL;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           // string temp=txt_enter_price.ToString();

            if (txt_enter_price.Text != "")
            {
                int temp = int.Parse(txt_enter_price.Text);

                if (temp >= login.AMOUNT_FINAL)
                {
                 int r = temp - login.AMOUNT_FINAL;
                return_label.Content = "Rs . " + r.ToString();
                login obj25 = new login();
                obj25.OpenDBConnection();

                
                ++inv;
                label_inv.Content = inv.ToString();
                obj25.INVOICE12 = inv.ToString();
                obj25.invoice();
                MessageBox.Show("Sale is Successfully Ended", "Successfully", MessageBoxButton.OK, MessageBoxImage.Warning);
                login.BILL.Clear();
                login.AMOUNT_FINAL = 0;
                this.Close();
                }
                else
                {
                    MessageBox.Show("You Enterd less amount..!!", "less amount", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_enter_price.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Enter Customer Giving Amount ? ", " Wraning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

         
        }

        private void txt_total_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_NumaricValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
         
        }
    }
}
