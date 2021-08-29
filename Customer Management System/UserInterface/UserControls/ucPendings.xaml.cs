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
    /// Interaction logic for ucPendings.xaml
    /// </summary>
    public partial class ucPendings : UserControl
    {
        //List<PendingEntity> transList;
        //Common common;
        public ucPendings()
        {
            InitializeComponent();
            //common = new Common();
            //transList = new List<PendingEntity>();
            //RefereshList();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string text = txtSearch.Text.ToLower();
            //if (text != null)
            //{
            //    this.dgPendings.ItemsSource = transList.FindAll(p => p.dealerinfo.FirstName.ToLower().Contains(text) ||
            //        p.dealerinfo.LastName.ToLower().Contains(text));
            //}
        }

        private void btnRefreshList_Click(object sender, RoutedEventArgs e)
        {
            //RefereshList();
            data_report obj2 = new data_report ();
            obj2.OpenDBConnection();
            obj2.show_customer();
             dgPendings.ItemsSource = obj2.cust_list ;
             obj2.closeConnection();

           
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void linkDetails_Click(object sender, RoutedEventArgs e)
        {
            //SearchEntity entity = new SearchEntity();
            //PendingEntity temp = dgPendings.SelectedItem as PendingEntity;
            //entity.dealerinfo = temp.dealerinfo;
            //Utilities.ShowSearchPopup(new winDetailsPopup(entity, DetailsType.DealerDetails));
        }

        //private void linkDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    SearchEntity entity = new SearchEntity();
        //    PendingEntity temp = dgPendings.SelectedItem as PendingEntity;
        //    if (temp.TotalPaid == temp.TotalReceived)
        //    {
        //        transList.Remove(temp);
        //    }
        //    else
        //        MessageBox.Show("Paid/Received are present against this dealer.\nYou cannot delete it.", "Information", 
        //            MessageBoxButton.OK, MessageBoxImage.Information);
        //}

        private void linkAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            //DealerInfo dealer = (dgPendings.SelectedItem as PendingEntity).dealerinfo;
            //Utilities.ShowSearchPopup(new winAccountDetails(dealer));
        }

        private void RefereshList()
        {
            //dgPendings.ItemsSource = null;
            //transList = common.SelectDealersWithPendingBalance();
            //if (transList != null)
            //    dgPendings.ItemsSource = transList;

            //double SumPaid = transList.Sum(p => p.TotalPaid);
            //double SumReceived = transList.Sum(p => p.TotalReceived);
            //string tempP = string.Format("{0:N}", SumPaid);
            //txtSumPaid.Content = tempP + "/-";
            //string tempR = string.Format("{0:N}", SumReceived);
            //txtSumReceived.Content = tempR + "/-";
            //string tempB = string.Format("{0:N}", SumReceived - SumPaid);
            //txtBalance.Content = tempB + "/-";
            //txtCount.Content = transList.Count;
        }

        //private void linkCloseLedger_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBoxResult choice;
        //    bool result = false;
        //    choice = MessageBox.Show("Are you sure you want to CLOSE all ledgers?\n"
        //        + "You cannot UNDO if you clicked YES to proceed otherwise click NO.", "Warning",
        //               MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
        //    if (choice == MessageBoxResult.Yes)
        //    {
        //        PendingEntity pendingEntity = dgPendings.SelectedItem as PendingEntity;
        //        result = common.CloseLedger(pendingEntity, MainWindow.User.UserName);
        //        if (result)
        //            MessageBox.Show("Ledgers is closed successfuly!\nYou don't have any pendings againt this dealer now.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //        else
        //            MessageBox.Show("Unable to complete your request! An error occured in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}
