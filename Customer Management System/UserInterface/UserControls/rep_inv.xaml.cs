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
    /// Interaction logic for rep_inv.xaml
    /// </summary>
    public partial class rep_inv : UserControl
    {
        public rep_inv()
        {
            InitializeComponent();
            show();
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void dgPendings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void show ()
        {
            inv_rep obj1 = new inv_rep ();
            obj1.OpenDBConnection();
            obj1.inventorychk();
            dgPendings.ItemsSource = obj1.list_user;
            obj1.closeConnection();
        }


    }
}
