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
//using BusinessLogic;


namespace UserInterface.UserControls
{
    /// <summary>
    /// Interaction logic for User_report.xaml
    /// </summary>
    public partial class User_report : UserControl
    {
        public User_report()
        {
            InitializeComponent();
        }

        private void txtSerch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgPendings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
             login obj5 = new login();
           
             obj5.OpenDBConnection();
             obj5.show_data_user();
             dgPendings.ItemsSource = obj5.list_user;
             total_emp.Text = obj5.count_user.ToString();
               
             
        }
    }
}
