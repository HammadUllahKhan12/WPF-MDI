//using BusinessLogic;
using Entities;
//using Entities;
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
using System.Windows.Shapes;

namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        //Common common;
        UserInfo LoggedUser;
        public winLogin()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, txtUserName);
           
        }

        public winLogin(UserInfo user)
        {
            InitializeComponent();
            this.txtUserName.Text = user.UserName;
            this.txtUserName.IsEnabled = false;
            this.txtUserName.IsReadOnly = true;
            FocusManager.SetFocusedElement(this, pbPassword);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to close application?", "Warning", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
                this.Close();
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            LoggedUser = new UserInfo();
            // common = new Common();
            string userName = txtUserName.Text.ToLower();
            string password = pbPassword.Password.ToLower();
            string user_type_admin = admin.IsChecked.ToString();
            string user_type_cashier = cashier.IsChecked.ToString();
            string user_type_supplier = Supplier.IsChecked.ToString();

            if ((userName != "") && (password != ""))
            {

                if ((user_type_admin == "True") || (user_type_cashier == "True") || (user_type_supplier == "True"))
                {
                    if (user_type_admin == "True")
                    {
                       
                        string Admin = "admin";
                        bool IsVerified = VerifyLogin(userName, password, Admin);
                        if (IsVerified)
                        {
                            InsertUserLoginData();
                            new MainWindow(LoggedUser).Show();
                            this.Close();
                        }

                    }
                    else if (user_type_cashier == "True")
                    {
                        string Cashier = "cashier";
                        bool IsVerified = VerifyLogin(userName, password, Cashier);
                        if (IsVerified)
                        {
                            InsertUserLoginData();
                            new MainWindow(LoggedUser).Show();
                            this.Close();
                       }

                    }
                    else if (user_type_supplier == "True")
                    {
                        // string Cashier = "Supplier";
                        bool IsVerified = VerifyLogin(userName, password, "supplier");
                        if (IsVerified)
                        {
                            InsertUserLoginData();
                            new MainWindow(LoggedUser).Show();
                            this.Close();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Choose one option...! ");
                }
            }
            else
            {
                MessageBox.Show("Requirements Does not fill properly...!!! ");
            }

            
        }

        private bool VerifyLogin(string username, string password, string user)
        {

            login obj1 = new login();
            obj1.OpenDBConnection();
            obj1.UN = username;
            obj1.PASSWORD = password;
            obj1.USER_TYPE = user;

            bool final_check = obj1.login_checking();
            if (final_check)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void InsertUserLoginData()
        {
            //bool result = false;
            //UserLoginData userLoggedData = new UserLoginData();
            //userLoggedData.UserId = LoggedUser.Id;
            ////userLoggedData.UserName = LoggedUser.UserName;
            ////userLoggedData.IsAdmin = LoggedUser.IsAdmin;
            ////userLoggedData.LoginDateTime = DateTime.Now;
            ////userLoggedData.LogoutDateTime = DateTime.Now;
            //if (userLoggedData.UserId > 0)
            //{
            //    result = common.InsertUserLoginData(userLoggedData);
            //    if (!result)
            //        MessageBox.Show("Unable to enter user login time in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
