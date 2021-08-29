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
//using UserInterface.Enums;
//using BusinessLogic;

namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for ucNewDealer.xaml
    /// </summary>
    public partial class ucNewDealer : UserControl
    {
        login obj2 = new login();

        //Common common;
        //DealerInfo selectedDealer;
        //bool EditInformation = false;
        public ucNewDealer()
        {
            InitializeComponent();
            //common = new Common();
            //selectedDealer = new DealerInfo();
        }

        private void btnSaveNewDealer_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Name.Text != "" && txt_age.Text!="" && txt_usertype.Text != "" && txtMobileNumber.Text != "" && pbPassword.Password != "" && txt_salary.Text != ""  && pb_renter_Password.Password != "" )
            {
                if ((txt_gender.Text == "male") || (txt_gender.Text == "female"))
                {
                    if (pbPassword.Password == pb_renter_Password.Password)
                    {
                        if ((txt_usertype.Text == "admin") || (txt_usertype.Text == "supplier") || (txt_usertype.Text == "cashier"))
                        {
                            
                            obj2.OpenDBConnection();
                            obj2.UN = txt_Name.Text;
                            obj2.PASSWORD = pbPassword.Password;

                            string s = DateTime.Now.ToString();
                            obj2.TIME_DATE = s;
                            obj2.USER_TYPE = txt_usertype.Text;
                            obj2.GENDER = txt_gender.Text;
                            obj2.AGE = txt_age.Text;
                            obj2.PHONE_NO = txtMobileNumber.Text;
                            obj2.SALE = txt_salary.Text;

                            bool final_add = obj2.add_user();
                            if (final_add)
                            {
                                MessageBox.Show("User Successfully added..!!!");

                            }
                            else
                            {
                                MessageBox.Show("Internal Server Error..!!");
                            }
                            txt_salary.Text = "";
                            txtMobileNumber.Text = "";
                            txt_age.Text = "";
                            txt_gender.Text = "";
                            txt_usertype.Text="";
                            txt_Name.Text = "";
                            pbPassword.Password ="";
                            pb_renter_Password.Password = "";
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Type..!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Both Password does not match..!!!");
                    }
                }
                else
                {
                    MessageBox.Show("You entered the invalid Gender..!");
                }

            }
            else
            {
                MessageBox.Show("Requirements Does not fill Properly..!!!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //this.Reset();
            //this.selectedDealer = null;
            //EnableControls();
          

        }

        private void txtPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9]+");
            //e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMobileNumber_NumaricValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txt_salary_NumaricValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMobileNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (txtMobileNumber.Text.Length == 11)
            //{
            //    txtMobileNumber.Text = string.Format("{0:0###-## ## ###}", Convert.ToDecimal(txtMobileNumber.Text));
            //}
        }

        private void txtPhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (txtPhoneNumber.Text.Length == 10)
            //{
            //    txtPhoneNumber.Text = string.Format("{0:0##-## ## ###}", Convert.ToDecimal(txtPhoneNumber.Text));
            //}
        }

        //private void btnEditDealer_Click(object sender, RoutedEventArgs e)
        //{
        //    EnableControls();
        //}

        private void btnAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            //if (selectedDealer != null && selectedDealer.Id > 0)
            //    Utilities.ShowSearchPopup(new winAccountDetails(selectedDealer));
            //else MessageBox.Show("Please search a dealer to view his/her account details", "Information",
            //    MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnSearchDealer_Click(object sender, RoutedEventArgs e)
        {
            //winSearchPopup.sendback = null;
            //Utilities.ShowSearchPopup(new winSearchPopup(DetailsType.DealerDetails));
            //SearchEntity selected = winSearchPopup.sendback;
            //selectedDealer = selected.dealerinfo;
            //if (selected != null && selected.dealerinfo != null)
            //{ 
            //    this.txtFirstName.Text = selected.dealerinfo.FirstName.ToString();
            //    this.txtLastName.Text = selected.dealerinfo.LastName.ToString();
            //    this.txtShopeName.Text = selected.dealerinfo.ShopName.ToString();
            //    this.txtShopeAddress.Text = selected.dealerinfo.ShopAddress.ToString();
            //    this.txtHomeAddress.Text = selected.dealerinfo.HomeAddress.ToString();
            //    this.dpJoiningDate.SelectedDate = selected.dealerinfo.JoiningDate;
            //    this.txtComments.Text = selected.dealerinfo.Comments.ToString();
            //    this.txtMobileNumber.Text = selected.dealerinfo.Mobile.ToString();
            //    this.txtPhoneNumber.Text = selected.dealerinfo.Phone.ToString();

            //    btnSaveNewDealer.Content = "Edit Information";
            //    EditInformation = true;
            //    DisableControls();
            //}
        }

        private void Reset()
        {
            //this.txtFirstName.Text = string.Empty;
            //this.txtLastName.Text = string.Empty;
            //this.txtMobileNumber.Text = string.Empty;
            //this.txtPhoneNumber.Text = string.Empty;
            //this.txtShopeName.Text = string.Empty;
            //this.txtShopeAddress.Text = string.Empty;
            //this.txtHomeAddress.Text = string.Empty;
            //this.txtComments.Text = string.Empty;
            //this.dpJoiningDate.SelectedDate = DateTime.Now;
            //selectedDealer = null;
            //this.btnSaveNewDealer.Content = "Save";
            //EditInformation = false;
        }

        private void DisableControls()
        {
            //this.txtFirstName.IsEnabled = false;
            //this.txtLastName.IsEnabled = false;
            //this.txtMobileNumber.IsEnabled = false;
            //this.txtPhoneNumber.IsEnabled = false;
            //this.txtShopeName.IsEnabled = false;
            //this.txtShopeAddress.IsEnabled = false;
            //this.txtHomeAddress.IsEnabled = false;
            //this.txtComments.IsEnabled = false;
            //this.dpJoiningDate.IsEnabled = false;
        }

        private void EnableControls()
        {
            //this.txtFirstName.IsEnabled = true;
            //this.txtLastName.IsEnabled = true;
            //this.txtMobileNumber.IsEnabled = true;
            //this.txtPhoneNumber.IsEnabled = true;
            //this.txtShopeName.IsEnabled = true;
            //this.txtShopeAddress.IsEnabled = true;
            //this.txtHomeAddress.IsEnabled = true;
            //this.txtComments.IsEnabled = true;
            //this.dpJoiningDate.IsEnabled = true;
        }

        private void btnDeleteDealer_Click(object sender, RoutedEventArgs e)
        {
            //bool result = false;
            //bool IsPendingAmount = false;
            //if (!string.IsNullOrEmpty(MainWindow.User.UserName) && MainWindow.User.IsAdmin == Convert.ToInt32(UserStatus.Admin))
            //{
            //    if (selectedDealer.Id > 0)
            //    {
            //        List<PendingEntity> pendingList = common.SelectDealersWithPendingBalance();
            //        IsPendingAmount = pendingList.Exists(p => p.dealerinfo.Id == selectedDealer.Id);
            //        if (IsPendingAmount)
            //        {
            //            MessageBox.Show("Paid/Received are present against this dealer.\nYou cannot delete it.", "Warning",
            //                MessageBoxButton.OK, MessageBoxImage.Warning);
            //            return;
            //        }
            //        else
            //        {
            //            result = common.DeleteSelectedDealer(selectedDealer);
            //            if (result)
            //            {
            //                MessageBox.Show("Dealer deleted successfuly.", "Information",
            //                MessageBoxButton.OK, MessageBoxImage.Information);
            //                this.Reset();
            //            }
            //            else
            //                MessageBox.Show("Unable to delete deleter.\nAn error occoured in database.", "Error",
            //                MessageBoxButton.OK, MessageBoxImage.Error);
            //        }

            //    }
            //    else MessageBox.Show("Please select a dealer first.", "Information",
            //        MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //    MessageBox.Show("Please login with admin credentials.", "Information",
            //        MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void txtMobileNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            pbPassword.Password = "12345";
            pb_renter_Password.Password = "12345";
            pb_renter_Password.IsEnabled = false;
            pbPassword.IsEnabled = false;

            if (txt_Name.Text != "" && txt_age.Text != "" && txt_usertype.Text != "" && txtMobileNumber.Text != "" && pbPassword.Password != "" && txt_salary.Text != "" && pb_renter_Password.Password != "")
            {
                if ((txt_gender.Text == "male") || (txt_gender.Text == "female"))
                {
                    if (pbPassword.Password == pb_renter_Password.Password)
                    {
                        if ((txt_usertype.Text == "admin") || (txt_usertype.Text == "supplier") || (txt_usertype.Text == "cashier"))
                        {
                            

                            obj2.OpenDBConnection();
                            obj2.UN = txt_Name.Text;
                            obj2.PASSWORD = pbPassword.Password;

                            string s = DateTime.Now.ToString();
                            obj2.TIME_DATE = s;
                            obj2.USER_TYPE = txt_usertype.Text;
                            obj2.GENDER = txt_gender.Text;
                            obj2.AGE = txt_age.Text;
                            obj2.PHONE_NO = txtMobileNumber.Text;
                            obj2.SALE = txt_salary.Text;

                            bool final_add = obj2.add_user();

                            if (final_add)
                            {
                                MessageBox.Show("User Successfully added with Default Password...!!" , "Successfully"  );


                            }
                            else
                            {
                                MessageBox.Show("Internal Server Error..!!");
                            }
                            txt_salary.Text = "";
                            txtMobileNumber.Text = "";
                            txt_age.Text = "";
                            txt_gender.Text = "";
                            txt_usertype.Text = "";
                            txt_Name.Text = "";
                            pbPassword.Password = "";
                            pb_renter_Password.Password = "";
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Type..!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Both Password does not match..!!!");
                    }
                }
                else
                {
                    MessageBox.Show("You entered the invalid Gender..!");
                }

            }
            else
            {
                MessageBox.Show("Requirements Does not fill Properly..!!!");
            }

        }
    }
}
