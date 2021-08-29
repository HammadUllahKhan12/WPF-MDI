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
using System.Data.SqlClient;

namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for Find_user.xaml
    /// </summary>
    public partial class Find_user : UserControl
    {
        List<login>find_user = new List<login>();
        public Find_user()
        {
            InitializeComponent();
           
        }
        void user ()
        {
              if (txt_user.Text != "" || txt_phone.Text != "")
            {
                string connetionString = null;
                SqlConnection connection;
                string sql = null;
                /////////////////////////////////////////////////////////////////////////////////////////////
                connetionString = "Data Source=DESKTOP-ANKLL09;Integrated Security=True";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    //MessageBox.Show("Connection opened successfully...!!!");

                }
                catch
                {
                    MessageBox.Show("Can not open connection !!!! ");
                }

                //////////////////////////////////////////////////////////////////////////////////////////////
                string check_un, check_ut;
                string check_gender, check_age, check_phone, check_date, check_salary, check_ID;

                SqlCommand command;
                sql = "select * from final_emp";
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    check_ID = reader["id"].ToString();
                    check_un = reader["name"].ToString();
                    check_ut = reader["user_type"].ToString().ToLower();
                    check_gender = reader["gender"].ToString();
                    check_age = reader["age"].ToString();
                    check_phone = reader["phone"].ToString();
                    check_date = reader["date_of_join"].ToString();
                    check_salary = reader["salary"].ToString();

                    if ((check_un == txt_user.Text.ToLower()) || (check_phone == txt_phone.Text.ToLower()))
                    {
                    

                        login p = new login();

                        p.UN = check_un ;
                        p.USER_TYPE =  check_ut;
                        p.GENDER = check_gender;
                        p.AGE =  check_age ;
                        p.PHONE_NO = check_phone ;
                        p.ID = check_ID;
                        p.SALE = check_salary ;
                        p.TIME_DATE =  check_date ;

                        find_user.Add(p);
                        record_List.ItemsSource = find_user;
                        command.Dispose();
                        MessageBox.Show("Emplyee found!!", " found", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.record_List.Visibility = Visibility.Visible;
                        txt_user.Text = "";
                        txt_phone.Text = "";
                        return;
                    }

                }

                txt_user.Text = "";
                txt_phone.Text = "";
       
                 MessageBox.Show("Emplyee Does Not found ...!!", " Not found", MessageBoxButton.OK, MessageBoxImage.Stop);
                 return;
                
 

            }
            else
            {
                MessageBox.Show("Requirements Does not fill Properly...!!", " Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }

        private void btnSearchDealer_Click(object sender, RoutedEventArgs e)
        {
            user();
            
           
        }
        //private void btnSearchDealer_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("papi cholo..!!1", " Hi", MessageBoxButton.OK, MessageBoxImage.Error);


        //}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
