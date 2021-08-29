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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UserInfo User;
        public static bool IsClosedForLogoutOrLock = false;
        //Common common;

        public MainWindow(UserInfo user)
        {
            InitializeComponent();
            MainWindow.User = user;
            txtUserName.Content = "Logged as: " + login.ID_STA+ " [ " + login.NAME_STA + " ]";
           // common = new Common();

            if (MainWindow.User.IsAdmin == 1)
            {
                //this.rbAddUser.Visibility = Visibility.Visible;
                //this.tabSettings.Visibility = Visibility.Visible;
                //this.tabUserManagement.Visibility = Visibility.Visible;
            }
            else
            {
                //this.rbAddUser.Visibility = Visibility.Collapsed;
                //this.tabSettings.Visibility = Visibility.Collapsed;
            }
            if (login.ID_STA == "admin")
            {
                this.tabUserManagement.Visibility = Visibility.Visible;
                this.tabReports.Visibility= Visibility.Visible;
                this.tabdatabase.Visibility = Visibility.Visible;
            }
            else
            {
                this.tabUserManagement.Visibility = Visibility.Collapsed;
                this.tabReports.Visibility = Visibility.Collapsed;
                this.tabdatabase.Visibility = Visibility.Collapsed;
            }
            if (login.ID_STA == "admin" || login.ID_STA=="supplier")
            {
                this.tab_Supplier_Home.Visibility = Visibility.Visible;
            }
            else
            {
                this.tab_Supplier_Home.Visibility = Visibility.Collapsed;
            }

            if (login.ID_STA == "admin" || login.ID_STA == "cashier")
            {
                this.tabHome.Visibility= Visibility.Visible;
            }
            else
            {
                this.tabHome.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLockApp_Click(object sender, RoutedEventArgs e)
        {
            IsClosedForLogoutOrLock = true;
            this.Hide();
            new winLogin(User).Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            IsClosedForLogoutOrLock = true;
            EnterUserLogoutTime();
            this.Hide();
            new winLogin().Show();
            this.Close();
        }

        private void EnterUserLogoutTime()
        {
            //UserLoginData userLoggedData = new UserLoginData();
            //userLoggedData.UserId = MainWindow.User.Id;
            ////userLoggedData.UserName = MainWindow.User.UserName;
            ////userLoggedData.IsAdmin = MainWindow.User.IsAdmin;
            ////userLoggedData.LoginDateTime = DateTime.Now;
            ////userLoggedData.LogoutDateTime = DateTime.Now;
            //if (userLoggedData.UserId > 0)
            //{
            //    bool result = common.UpdateUserLoginData(userLoggedData);
            //    if (!result)
            //        MessageBox.Show("Unable to enter user logout time in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            string msg = "The Customer Management System can be used in our local market to keep track of all the Dealers and Payments that a normal merchant has to deal with." +
                "\nIt has following main functionalities:" +
                "\n1) Add New User like(Cashier , supplier , admin)  - when you are going to business with new Supplier." +
                "\n2) Record every sale along the customer records." +
                "\n3) User report is availabel which can access by admin " +
                "\n4) Product Report along with its update quantity also availabel" +
                "\n5) Add Users - when you allow any other person to use your Ledger." +
                "\n6) Admin users and Not-Admin users have different access levels in software." +
               
                "\nThank You for using it!\nDesigned by: Hammad Ullah Khan\nDatabase by: M.Faizan";
                MessageBox.Show(msg, "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "The Inventory Management System can be used in our local market to keep track of all the Supplier and Every sale.\n" +
                "Thank You for using it!\n->Designed by :: Hammad Ullah Khan \n->Database Designed By :: Faizan Sheikh",
                "About",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to close application?", "Warning", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                EnterUserLogoutTime();
                //Window1 q = new Window1();
                //q.Close();
                this.Close();
            }
        }
       // Container.Theme = ThemeType.Generic; 
        private MdiChild FindMdiChildByName(UserControl uc)
        {
            return Container.Children.Where(p => p.Content.GetType() == uc.GetType() && p.IsEnabled).Single();
        }
        private bool IsAlreadyOpened(UserControl uc)
        {
            return Container.Children.Where(p => p.Content.GetType() == uc.GetType() && p.IsEnabled).Count() == 0 ? false : true;
        }
        private void Open(UserControl uc, string title = "Title", WindowState state = System.Windows.WindowState.Maximized)
        {
            if (IsAlreadyOpened(uc))
            {
                MdiChild mc = FindMdiChildByName(uc);
                if (mc.WindowState == WindowState.Minimized)
                    mc.WindowState = WindowState.Maximized;
                    
                
                mc.Focus();
            }
            else
            {
                uc.Margin = new Thickness(0, 0, 0, 10); //required to set margin of UserControls so that they would't overlap with StatusBar
                Container.Children.Add(new MdiChild()
                {
                    Content = uc,
                    Title = title,
                    WindowState = state
                   
                });
            }
            
           
        }

        //private bool IsAlreadyOpened(string ucName)
        //{
        //    bool isOpen;
        //    isOpen = this.Container.Children.OfType<MdiChild>().ToList().Exists(item => item.Name == ucName && item.IsEnabled);
        //    return isOpen;
        //}

        //private MdiChild FindMdiChildByName(string ucName)
        //{
        //    MdiChild temp = null;
        //    foreach (MdiChild item in this.Container.Children)
        //    {
        //        if (item.Name == ucName && item.IsEnabled == true && item != null)
        //            temp = item;
        //    }
        //    return temp;
        //}

        //private void btnPendings_Click(object sender, RoutedEventArgs e)
        //{
        //    Open(new ucPendings(), "Pendings");
        //}
        
        private void  btnAddSale_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "admin" || login.ID_STA == "cashier")
            {
                Open(new sale(), "sale");
            }
            else
            {
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void btnNewDealer_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "admin")
            {
               // this.Container.Theme = ThemeType.Generic;
                Open(new ucNewDealer(), "New Dealer");
                //Container.Theme = ThemeType.Generic; 
                //this.Container.Theme = ThemeType.Generic;
            }
            else
            {
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
            private void   btnAdditems_Click(object sender, RoutedEventArgs e)
            {
                if (login.ID_STA == "supplier" || login.ID_STA == "admin")
                {
                    Open(new supplier(),"Add ITEMS");
                }
                else
                {
                    MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
//            Open(new ucTransaction(), "Transaction");
        }

        private void btnOnScreenMonthlyReport_Click(object sender, RoutedEventArgs e)
        {
  //          Open(new ucMonthlyReport(), "Monthly Transaction Report");
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Open(new Password(), "Update Password");
            //Utilities.ShowSearchPopup(new winChangePassword(MainWindow.User));
            //User = winChangePassword.User;

        }

        private void btnOnScreenDealerReport_Click(object sender, RoutedEventArgs e)
        {
//            Open(new ucDealerReport(), "Dealer Transaction Report");
        }

        private void btnSaveMonthlyReport_Click(object sender, RoutedEventArgs e)
        {

            Window3 obj = new Window3();
            obj.Show();
        }

        private void btnSaveDealerReport_Click(object sender, RoutedEventArgs e)
        {
            Window2 obj = new Window2();
            obj.Show();
        }

        private void btnOnScreenUserReport_Click(object sender, RoutedEventArgs e)
        {
            //Open(new ucUserReport(), "User Login Report");
        }

        private void btnSaveUserReport_Click(object sender, RoutedEventArgs e)
        {
            Window4 obj = new Window4();
            obj.Show();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
          //  Open(new ucNewUser(), "New User");
        }

        private void btnHorizontal_Click(object sender, RoutedEventArgs e)
        {
            this.Container.MdiLayout = MdiLayout.TileHorizontal;
        }

        private void btnVertical_Click(object sender, RoutedEventArgs e)
        {
            this.Container.MdiLayout = MdiLayout.TileVertical;
        }

        private void btnCascade_Click(object sender, RoutedEventArgs e)
        {
            this.Container.MdiLayout = MdiLayout.Cascade;
        }

        private void btnCloseAllWindows_Click(object sender, RoutedEventArgs e)
        {
            this.Container.Children.Clear();
        }

        private void btnThemeAero_Click(object sender, RoutedEventArgs e)
        {
            this.Container.Theme = ThemeType.Aero;
        }

        private void btnThemeLuna_Click(object sender, RoutedEventArgs e)
        {
            this.Container.Theme = ThemeType.Luna;
        }

        private void btnThemeGeneric_Click(object sender, RoutedEventArgs e)
        {
            this.Container.Theme = ThemeType.Generic;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsClosedForLogoutOrLock == true)
            {
                e.Cancel = false;
                return;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you really want to close application?", "Warning", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    EnterUserLogoutTime();
                    e.Cancel = false; //this will allow the window to close
                    //Application.Current.Shutdown(); //will competely close the application process from task manager.
                }
                else e.Cancel = true; //this will stop window form closing
            }
        }

        private void btnDeleteAllDealers_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "admin")
            {
                bool result12 = false;
                MessageBoxResult result = MessageBox.Show("Are you Sure You want to do this  ? " + "\nYou cannot UNDO if you clicked YES to proceed otherwise click NO.", "Caution ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                 if (result == MessageBoxResult.Yes)
                 {
                     login obj11 = new login();
                     obj11.OpenDBConnection();
                     result12=obj11.reset_userdatabase();

                 }
                 else
                 {
                     MessageBox.Show("Operation not complete..! ", "Not complete", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                 }

                


                if (result12)
                    MessageBox.Show("All User/Employees record are deleted successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Unable to complete your request! An error occured in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteAllUsers_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult choice;
            //bool result = false;
            //choice = MessageBox.Show("Are you sure you want to DELETE all users from database?\n"
            //    + "You cannot UNDO if you clicked YES to proceed otherwise click NO.", "Warning",
            //           MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            //if (choice == MessageBoxResult.Yes)
            //{
            //    result = common.DeleteAllUsers(MainWindow.User.Id);
            //    if (result)
            //        MessageBox.Show("All users are deleted successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            //    else
            //        MessageBox.Show("Unable to complete your request! An error occured in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btnDeleteAllTransactions_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult choice;
            //bool result = false;
            //choice = MessageBox.Show("Are you sure you want to DELETE all transactions from database?\n"
            //    + "You cannot UNDO if you clicked YES to proceed otherwise click NO.", "Warning",
            //           MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            //if (choice == MessageBoxResult.Yes)
            //{
            //    result = common.DeleteAllTransactions();
            //    if (result)
            //        MessageBox.Show("All transactions are deleted successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            //    else
            //        MessageBox.Show("Unable to complete your request! An error occured in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btnDeleteAllLoginDetails_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult choice;
            //bool result = false;
            //choice = MessageBox.Show("Are you sure you want to DELETE all user's login data from database?\n"
            //    + "You cannot UNDO if you clicked YES to proceed otherwise click NO.", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            //if (choice == MessageBoxResult.Yes)
            //{
            //    result = common.DeleteAllUserLoginData(MainWindow.User.Id);
            //    if (result)
            //        MessageBox.Show("All user's login data is deleted successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            //    else
            //        MessageBox.Show("Unable to complete your request! An error occured in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        public void SendNotificationMsg(string msg)
        {
            this.txtNotificationMsg.Text = msg;
            this.NotificationPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnHideNotification_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            this.txtNotificationMsg.Text = "";
            this.NotificationPanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Notify_Click(object sender, RoutedEventArgs e)
        {
            string str12 = "Default Password is '12345' \nFor any query contact system admin \nDeveloped By 'Hammad-Ullah-Khan'";
            SendNotificationMsg(str12);
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_CashReport_Click(object sender, RoutedEventArgs e)
        {
            Open(new rep_inv(), "Stock View");
        }
       
            private void  btn_new_items_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "supplier" || login.ID_STA == "admin")
            {
                Open(new supp2(), "Add new items");
            }
            else
            {
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btn_UserReport_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "admin")
            {
                Open(new User_report(), "Employee Reports");
            }
            else
            {
                
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    
            private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "admin")
            {
                Open(new del_user(), "Delete User"); ;
            }
            else
            {
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        private void btn_MonthlyReport_Click(object sender, RoutedEventArgs e)
        {

        }
        
         private void btn_profile_Click(object sender, RoutedEventArgs e)
        {
            Open(new user_profile(), "Profile");
        }
        
      

        private void  btn_product_Report_Click(object sender, RoutedEventArgs e)
        {
            Open(new ucPendings(), "Product Report");
        }
        private void  btn_reset_pass_Click(object sender, RoutedEventArgs e)
        {
            if (login.ID_STA == "admin")
            {
                Open(new reset_pass(), "Reset Password");
            }
            else
            {
                MessageBox.Show("You Don't have Enough Acess to do this...!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
     //   btn_find_pass_Click
        private void btn_find_pass_Click(object sender, RoutedEventArgs e)
        {
            Open(new Find_user(), "Find User");
        }
        
        private void  btnDelete_customer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you Sure You want to do this  ? " + "\nYou cannot UNDO if you clicked YES to proceed otherwise click NO.", "Caution ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                login obj23 = new login();
                obj23.OpenDBConnection();
                obj23.reset_customerdata();

            }
            else
            {
                MessageBox.Show("Operation not complete..! ", "Not complete", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Container_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void btnDelete_product_Click(object sender, RoutedEventArgs e)
        {
             

             MessageBoxResult result = MessageBox.Show("Are you Sure You want to do this  ? " + "\nYou cannot UNDO if you clicked YES to proceed otherwise click NO.", "Caution ", MessageBoxButton.YesNo, MessageBoxImage.Question);
             if (result == MessageBoxResult.Yes)
             {
                 login obj21 = new login();

                 obj21.reset_productdata();

             }
             else
             {
                 MessageBox.Show("Operation not complete..! ", "Not complete", MessageBoxButton.OK, MessageBoxImage.Exclamation);
             }
           
        }
    }
}
