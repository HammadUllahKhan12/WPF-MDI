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
    /// Interaction logic for reset_pass.xaml
    /// </summary>
    public partial class reset_pass : UserControl
    {
        public reset_pass()
        {
            InitializeComponent();
        }

        private void txt_phone_no_NumaricValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result  = MessageBox.Show("Are you want to reset the Password ?","",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {


                if (txt_user_name.Text != "" && txt_user_type.Text != "" )
                {
                    login obj13 = new login();
                    obj13.OpenDBConnection();
                   bool result12 =  obj13.reset_password1(txt_user_name.Text.ToLower(), txt_user_type.Text.ToLower(), txt_phone_no.Text);
                    if (result12)
                    {
                        MessageBox.Show("Password has successfully reset...!!!", "Congrats", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("You enter invalid details...!!","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    obj13.closeConnection();

                }
                else
                {
                    MessageBox.Show("Requirements does not fill properly...!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("You cancel the operation", "Cancel", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
