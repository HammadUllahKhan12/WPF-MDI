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
    class inv_rep
    {
        private string connetionString = null;
        private SqlConnection connection;
        private string sql = null;
        public List<inv_rep> list_user = new List<inv_rep>();

        public string quantity;
        public string productid;
        public string date;
      public String Quantity
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

        public String pId
        {
            get
            {
                return productid;
            }
            set
            {
                productid = value;
            }
        }
        public String Date
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
        /////////////////
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
            ////////////
        //
        public int count_user = 0;
            public void inventorychk()
        {
            try
            {

                SqlCommand command;
                sql = "select * from updateinventory";
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    inv_rep obj0 = new inv_rep();
                    obj0.quantity = reader["quantity"].ToString();
                    obj0.productid = reader["pid"].ToString();

                    obj0.date = reader["date12"].ToString();
                   list_user.Add(obj0);
                  //   count_user++;



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

