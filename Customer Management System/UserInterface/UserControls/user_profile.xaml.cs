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
    /// Interaction logic for user_profile.xaml
    /// </summary>
    public partial class user_profile : UserControl
    {
        void show ()
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
            string check_un , check_ut;
            string check_gender,check_age,check_phone,check_date,check_salary,check_ID;

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
                    check_phone= reader["phone"].ToString();
                    check_date = reader["date_of_join"].ToString();
                     check_salary = reader["salary"].ToString();
              
                    if ((check_un == login.NAME_STA) && (check_ut == login.ID_STA))
                    {
                        txt_user_ID.Text = check_ID;
                        txt_user_name.Text =check_un ;
                        txt_user_age.Text = check_age;
                        txt_user_date.Text = check_date;
                        txt_user_gender.Text =check_gender;
                        txt_user_phone.Text = check_phone;
                        txt_user_type.Text =check_ut ;
                        txt_user_salary.Text = check_salary;

                        command.Dispose();
                    }
                }
              
            

            
         

        }
        public user_profile()
        {
            InitializeComponent();
            show();
        }

        private void txt_user_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_user_salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
