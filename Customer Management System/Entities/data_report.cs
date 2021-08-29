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
using System.Data.SqlClient;


namespace Entities
{
    class data_report
    {
        static private int transfer;
        private string connetionString = null;
        private SqlConnection connection;
        private string sql = null;
        public List<login> list_user = new List<login>();

        public void OpenDBConnection()
        {
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
        }

        public void closeConnection()
        {
            connection.Close();
        }
          private string cust_name;

        public string CUST_NAME
        {
            get
            {
                return cust_name;
            }
            set
            {
                cust_name = value;
            }
        }
       private string sale_id;

        public string SALE_ID
        {
            get
            {
                return sale_id;
            }
            set
            {
                sale_id = value;
            }
        }
         private string p_id;

        public string P_ID
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }
        private string pro_name;

        public string PRO_NAME
        {
            get
            {
                return pro_name;
            }
            set
            {
                pro_name = value;
            }
        }
        private string pro_price;

        public string PRO_PRICE
        {
            get
            {
                return pro_price;
            }
            set
            {
                pro_price = value;
            }
        }
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
        private string time_p;

        public string TIME_P
        {
            get
            {
                return time_p;
            }
            set
            {
                time_p = value;
            }
        }
        public List<data_report> cust_list = new List<data_report> () ;
        public void show_customer ()
        {
            try
            {

                SqlCommand command;
                sql = "select * from Add_Sale";
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data_report obj1 = new data_report();
                    obj1.CUST_NAME= reader["customerID"].ToString();
                    obj1.SALE_ID = reader["SaleId"].ToString();

                    obj1.P_ID = reader["pid"].ToString();
                    obj1.PRO_PRICE = reader["productname"].ToString();
                    obj1.PRO_NAME = reader["productprice"].ToString();

                    obj1.QUANTITY = reader["quantity"].ToString();
                    obj1.AMOUNT = reader["amount"].ToString();
                    obj1.TIME_P = reader["timeOfPurchase"].ToString();


                    cust_list.Add(obj1);



                }
                command.Dispose();
                MessageBox.Show("Record is showed...!", "Showed");


            }
            catch
            {
                MessageBox.Show("Can not read from DB !!! ");

            }
        }

    }
}
