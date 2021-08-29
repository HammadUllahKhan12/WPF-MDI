using Entities;
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
//using UserInterface.Enums;
using WPF.MDI;

namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : UserControl
    {
        public Password()
        {
            InitializeComponent();
            user_name.Text = login.NAME_STA;
            user_type.Text = login.ID_STA;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (user_name.Text != "" && previous_pass.Text != "" && pbPassword_new.Password != "" && pbPassword_confirm.Password != "")
            {
                if (pbPassword_new.Password != "12345" || pbPassword_confirm.Password != "12345")
                {
                    if (pbPassword_new.Password == pbPassword_confirm.Password)
                    {
                        login obj4 = new login();
                        ////obj4.UN = user_name.Text;
                        ////obj4.PASSWORD = pbPassword_confirm.Password;
                        ////obj4.P_PASSWORD = previous_pass.Text;

                        obj4.NEW_PASSWORD = pbPassword_new.Password;
                        obj4.REPLACE_PASSWORD = previous_pass.Text;
                        obj4.REPLACE_USER = user_name.Text;
                        obj4.OpenDBConnection();
                        obj4.sqlUpdatePassword();
                        previous_pass.IsEnabled = false;
                        pbPassword_new.IsEnabled = false ;
                        pbPassword_confirm.IsEnabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Both Password  Does Not Matched ...!! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You cannot use the default password!...!! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Requirements Does not fill Properly","Warning",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void user_type_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
