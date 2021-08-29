//using BusinessLogic;
//using Customer_Management_System.UserInterface.UserControls;
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
    /// Interaction logic for del_user.xaml
    /// </summary>
    public partial class del_user : UserControl
    {
        public del_user()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (user_type.Text != "" && txt_username.Text != "")
            {
                if ((user_type.Text.ToLower() == "admin") || (user_type.Text.ToLower() == "supplier") || (user_type.Text.ToLower() == "cashier"))
                {
                    MessageBoxResult result = MessageBox.Show("Are you Sure You want to do this  ? "+"\nYou cannot UNDO if you clicked YES to proceed otherwise click NO."  , "Warning ", MessageBoxButton.YesNo,MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        login obj10 = new login();
                        obj10.OpenDBConnection();
                        obj10.delete_user(txt_username.Text.ToLower(), user_type.Text.ToLower());
                        user_type.Text = "";
                        txt_username.Text = "";
                        //if ((login.ID_STA==user_type.Text) && (login.NAME_STA == txt_username.Text))
                        //{

                        //    MessageBox.Show("You can't your own record...!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            

                        //}

                    }
                    else
                    {
                        user_type.Text = "" ;
                        txt_username.Text = "";
                    }


                }
                else
                {
                    MessageBox.Show("Invalid User Type", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Requirements Does not fill Properly..!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void user_type_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
