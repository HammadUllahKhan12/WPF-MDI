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

namespace Entities
{
    class Sale_line
    {
          

        static private string cus_name;

        static public string CUS_NAME
        {
            get
            {
                return cus_name;
            }
            set
            {
                cus_name = value;
            }
        }
        static private string date;

        static public string DATE
        {
            get
            {
                return date;
            }
            set
            {
              date = value;
            }
        }
             

        private string item_id;

        public string ITEMS_ID
        {
            get
            {
                return item_id;
            }
            set
            {
                item_id = value;
            }

        }
        /////////////////////////////////////
        private string item_name;

        public string ITEMS_NAME
        {
            get
            {
                return item_name;
            }
            set
            {
                item_name = value;
            }

        }
       //////////////////////////////////////////
        private string price;

        public string PRICE
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }

        }
       ////////////////////////////////////////////
        private string quantity;

        public string QUANTITY
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }

        }
       /////////////////////////////////

        private string amount;

        public string AMOUNT
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }

        }

        private string detail;

        public string DETAIL
        {
            get
            {
                return detail;
            }
            set
            {
                detail = value;
            }
        }



    }
}
