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
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Principal;


namespace Entities
{
    class login
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
        //////////////////////////////////////////////////////////////////////

        private string un;
        private string password;
        private string user_type;
        private string gender;
        private string renter_password;
        private string age;
        private string phone_no;

        public string AGE
        {
            get { return age; }
            set { age = value; }

        }
        public string PHONE_NO
        {
            get { return phone_no; }
            set { phone_no = value; }

        }

        public string GENDER
        {
            get { return gender; }
            set { gender = value; }

        }
        public string RENTER_PASSWORD
        {
            get { return renter_password; }
            set { renter_password = value; }

        }


        public string UN
        {
            get { return un; }
            set { un = value; }

        }
        private string p_password;
        public string P_PASSWORD
        {
            get { return password; }
            set { password = value; }
        }

        public string PASSWORD
        {
            get { return password; }
            set { password = value; }
        }
        public string USER_TYPE
        {
            get { return user_type; }
            set { user_type = value; }
        }




        //-----------------------------------------------------------------------------------------

        static private string id_sta;
        static public String ID_STA
        {
            get
            {
                return id_sta;
            }
            set
            {
                id_sta = value;
            }
        }

        private string time_date;

        public string TIME_DATE
        {
            get
            {
                return time_date;
            }
            set
            {
                time_date = value;
            }
        }

        static private string name_sta;
        static public String NAME_STA
        {
            get
            {
                return name_sta;
            }
            set
            {
                name_sta = value;
            }
        }


        public bool login_checking()
        {

            try
            {
                string check_un;
                string check_pas;
                string check_ut;

                SqlCommand command;
                sql = "select * from final_emp";
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    check_un = reader["name"].ToString();
                    
                    
                    string m = reader["password12"].ToString();
                    check_pas = Decrypt(m);

                    
                    check_ut = reader["user_type"].ToString().ToLower();

                    if ((check_un == un) && (check_pas == password) && (check_ut == user_type))
                    {

                        command.Dispose();
                        MessageBox.Show("Welcome! Mr." + check_un + " to Inventory Managment System !", "Welcome", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        id_sta = check_ut;
                        name_sta = check_un;

                        if (check_pas == "12345")
                        {
                            MessageBox.Show("-> Your Password is Default..!" + "\n-> You must update the password", "Warning ", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }


                        return true;

                    }
                }
                command.Dispose();
                MessageBox.Show("You entered the incorrect credentials!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            catch
            {
                MessageBox.Show("Database error..!!! ");
                return false;
            }

        }

        private string sale;

        public string SALE
        {
            get
            {
                return sale;
            }

            set
            {
                sale = value;
            }
        }

        private string id;

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }


        public bool add_user()
        {
            try
            {

                //double phone = double.Parse(phone_no);
                String query = "INSERT INTO dbo.final_emp(name,password12,user_type,gender,age,phone,date_of_join,salary) VALUES(@name,@password12,@user_type,@gender,@age,@phone,@date_of_join,@salary)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@name", un);

                string l = Encrypt(password);
                command.Parameters.Add("@password12", l);

                command.Parameters.Add("@user_type", user_type);
                command.Parameters.Add("@gender", gender);

                command.Parameters.Add("@salary", sale);
                command.Parameters.Add("@age", age);
                command.Parameters.Add("date_of_join", TIME_DATE);

                command.Parameters.Add("@phone", phone_no);

                command.ExecuteNonQuery();
                command.Dispose();



                return true;
            }
            catch
            {
                MessageBox.Show("Database Error..!!!");
                return false;
            }

        }


        private string replace_password;
        public string REPLACE_PASSWORD
        {
            get
            {
                return replace_password;
            }
            set
            {
                replace_password = value;
            }
        }
        private string replace_user;
        public string REPLACE_USER
        {
            get
            {
                return replace_user;
            }
            set
            {
                replace_user = value;
            }
        }
        private string new_password;
        public string NEW_PASSWORD
        {
            get
            {
                return new_password;
            }
            set
            {
                new_password = value;
            }
        }




        public void sqlUpdatePassword()
        {
            string l = Encrypt(new_password);
            string k = Encrypt(replace_password);
            //SqlCommand command = new SqlCommand(query, connection);
            string query = "Update final_emp Set password12 ='" + l + "'where name ='" + replace_user + "'and password12 ='" + k + "'";
            //SqlConnection con = new SqlConnection(path);
            //con.Open();
            //login obj = new login();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Your Password has sucessfully been updated...!!!");
            }
            else
            {
                MessageBox.Show("A database Error Occured....!!");
            }


        }


        public void delete_user(string user_name, string type)
        {

            string query = "delete final_emp where name ='" + user_name + "'and user_type ='" + type + "'";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("User Successfully Deleted....!");
            }
            else
            {
                MessageBox.Show("A database Error Occured....!!");
            }

        }


        public bool reset_userdatabase()
        {
            string temp = "admin";
            string query = "delete final_emp where user_type !='" + temp + "'";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool reset_password1(string name1, string user_type1, string phone1)
        {
            string temp5 = "12345";
            string temp = Encrypt(temp5);
            string query = "Update final_emp Set password12 ='" + temp + "'where name ='" + name1 + "'or phone ='" + phone1 + "'";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;

            }
            else
            {
                return false;
            }
        }





        public int count_user = 0;


        public void show_data_user()
        {
            try
            {

                SqlCommand command;
                sql = "select * from final_emp";
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    login obj0 = new login();
                    obj0.ID = reader["id"].ToString();
                    obj0.UN = reader["name"].ToString();

                    string l = reader["password12"].ToString();
                    string m =Decrypt(l);

                    obj0.PASSWORD = m; 
                    obj0.USER_TYPE = reader["user_type"].ToString();
                    obj0.GENDER = reader["gender"].ToString();

                    obj0.SALE = reader["salary"].ToString();
                    obj0.TIME_DATE = reader["date_of_join"].ToString();
                    obj0.PHONE_NO = reader["phone"].ToString();
                    obj0.AGE = reader["age"].ToString();


                    list_user.Add(obj0);
                    count_user++;



                }
                command.Dispose();
                MessageBox.Show("Record is showed...!", "Showed");


            }
            catch
            {
                MessageBox.Show("Can not read from DB !!! ");

            }

        }

        private string supplier_pro_name;

        public string SUPPLIER_PRO_NAME
        {
            get
            {
                return supplier_pro_name;
            }
            set
            {
                supplier_pro_name = value;
            }
        }

        public void add_items(string id, string quantity12, string time12)
        {



            OpenDBConnection();
            string check_p_id;
            string check_p_name;

            SqlCommand command;
            sql = "select * from products";
            command = new SqlCommand(sql, connection);
            //command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                check_p_id = reader["pId"].ToString();
                check_p_name = reader["productName"].ToString();
                if (id == check_p_id)
                {
                    closeConnection();

                    MessageBoxResult r = MessageBox.Show("Item Name ::" + check_p_name, "Items Found", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    SUPPLIER_PRO_NAME = check_p_name;
                    if (r == MessageBoxResult.Yes)
                    {
                        OpenDBConnection();


                        string query = "update updateInventory set quantity=quantity+'" + quantity12 + "'where pId='" + id + "'";

                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            MessageBox.Show("Items Stock Scessfully Updated...!", "Sucessfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }
                        command.Dispose();
                        closeConnection();
                        return;


                    }
                    else
                    {
                        closeConnection();
                        MessageBox.Show("Operation Denied", "Denied", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;


                    }
                }



            }


            MessageBox.Show("Invalid Items ID..!!-", "Invalid Item ID", MessageBoxButton.OK, MessageBoxImage.Error);
            command.Dispose();
            closeConnection();


        }



        private string invoice12;
        public string INVOICE12
        {
            get
            {
                return invoice12;
            }
            set
            {
                invoice12 = value;
            }
        }

        public void invoice()
        {


            try
            {

                //double phone = double.Parse(phone_no);
                String query = "INSERT INTO dbo.final_invoice(invoice_no,cust_name,total) VALUES(@invoice_no,@cust_name,@total)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@invoice_no", INVOICE12);

                command.Parameters.Add("@cust_name", Sale_line.CUS_NAME);

                command.Parameters.Add("@total", login.AMOUNT_FINAL);


                command.ExecuteNonQuery();
                command.Dispose();



            }
            catch
            {
                MessageBox.Show("Database Error..!!!");

            }

        }




        public List<login> item_list = new List<login>();
        public string item_check(string item_id)
        {
            try
            {
                string check_id;
                string check_quantity;
                string check_name;
                string check_prize;
                SqlCommand command;
                sql = "select * from items_record_ims";
                command = new SqlCommand(sql, connection);
                //command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    check_id = reader["item_id"].ToString();
                    check_name = reader["item_name"].ToString();
                    check_quantity = reader["quantity"].ToString();
                    check_prize = reader["prize"].ToString();
                    if (check_id == item_id)
                    {
                        login obj8 = new login();
                        obj8.UN = check_name;
                        obj8.ID = check_id;

                        item_list.Add(obj8);
                        return check_name;


                    }
                }
                command.Dispose();
                MessageBox.Show("You entered the incorrect item id!!!", "Warning");
                return "";



            }
            catch
            {
                MessageBox.Show("Database error..!!! ");
                return "";
            }

        }


        public void add_new_items_update_inv(string id12, string quantity12, string time12)
        {
            try
            {
                //float p = float.Parse(price12);

                //double phone = double.Parse(phone_no);
                String query = "INSERT INTO dbo.updateinventory(pid,quantity,date12) VALUES (@pid,@quantity,@date12)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@pid", id12);

                command.Parameters.Add("@quantity", quantity12);

                command.Parameters.Add("@date12", time12);

                command.ExecuteNonQuery();
                command.Dispose();




            }
            catch
            {
                MessageBox.Show("Database Error..!!!");

            }
        }

        /////////////////////////////////////////////////////////////////////////////////////

        public void add_new_product(string name12, string id12, string price12)
        {
            try
            {
                float p = float.Parse(price12);

                //double phone = double.Parse(phone_no);
                String query = "INSERT INTO dbo.products(pid,productName,ProductPrice) VALUES (@pid,@productName,@ProductPrice)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@pid", id12);

                command.Parameters.Add("@productName", name12);

                command.Parameters.Add("@ProductPrice", p);



                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Product Successfully Added..!! ", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);


            }
            catch
            {
                MessageBox.Show("Database Error..!!!");

            }


        }

        public void sale_process(string cus_name, string t, string quantity12, string p_id)
        {
            // Add_Sale
            //            customerID
            //pId varchar(255) FOREIGN KEY REFERENCES  products(pId),
            //productname varchar(255),
            //productprice float,
            //quantity int default 0 ,
            //amount float,
            //timeOfPurchase varchar(255);

            try
            {
                int q = int.Parse(cus_name);
                int q1 = int.Parse(quantity12);

                //double phone = double.Parse(phone_no);
                String query = "INSERT INTO dbo.Add_Sale(pId,quantity,timeOfPurchase,customerID) VALUES(@pId,@quantity,@timeOfPurchase,@customerID)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@pId", p_id);

                command.Parameters.Add("@customerID", q);

                command.Parameters.Add("@quantity", q1);

                command.Parameters.Add("@timeOfPurchase", t);
                // command.Parameters.Add("@amount", gender);





                command.ExecuteNonQuery();
                command.Dispose();



            }
            catch
            {
                MessageBox.Show("Database Error..!!!");

            }






        }


        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        private string cus_name;
        public String CUS_NAME
        {
            get { return cus_name; }
            set { cus_name = value; }
        }
        private string pro_id;
        public String PRO_ID
        {
            get { return pro_id; }
            set { pro_id = value; }
        }
        private string quantity_sale;
        public String QUANTITY_SALE
        {
            get { return quantity_sale; }
            set { quantity_sale = value; }
        }

        private string product_name;
        public String PRODUCT_NAME
        {
            get { return product_name; }
            set { product_name = value; }
        }

        private string product_price;
        public String PRODUCT_PRICE
        {
            get { return product_price; }
            set { product_price = value; }
        }
        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>
        private string show_price;
        public String SHOW_PRICE
        {
            get { return show_price; }
            set { show_price = value; }
        }
        /// <summary>
        /// ////////////////////////////
        /// 
        /// </summary>
        ///  private string product_price;
        private string show_pname;
        public String SHOW_PNAME
        {
            get { return show_pname; }
            set { show_pname = value; }
        }
        /// <summary>
        /// /////////////////////////////////////////////////
        /// </summary>
        private string show_pid;
        public String SHOW_PID
        {
            get { return show_pid; }
            set { show_pid = value; }
        }
        public void add_sale_final()
        {

            OpenDBConnection();

            string check_product_price;
            string check_product_name;
            string check_product_id;


            SqlCommand cmd;
            sql = "select * from products";
            cmd = new SqlCommand(sql, connection);
            //command.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                check_product_name = reader["productName"].ToString();
                check_product_price = reader["ProductPrice"].ToString();
                check_product_id = reader["pid"].ToString().ToString();


                if (check_product_id == pro_id)
                {
                    closeConnection();

                    SHOW_PRICE = check_product_price;
                    SHOW_PNAME = check_product_name;
                    SHOW_PID = check_product_id;
                    // MessageBox.Show("Product Name ::" + check_product_name + "\n Product ID ::" + check_product_id + "\n Product Price Per Piece ::"+check_product_price , "Item Name", MessageBoxButton.OK, MessageBoxImage.Information);
                    bool r = sub_func2(quantity_sale, check_product_id);
                    if (r)
                    {
                        sub_func1(check_product_price, check_product_id, check_product_name);
                        cmd.Dispose();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            cmd.Dispose();
            closeConnection();
            MessageBox.Show("You entered the incorrect items id!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool sub_func2(string user_quantity, string p_id)
        {
            OpenDBConnection();
            string check_q;
            string check_id;
            //updateinventory(pid,quantity
            SqlCommand cmd;
            sql = "select * from updateinventory";
            cmd = new SqlCommand(sql, connection);
            //command.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                check_q = reader["quantity"].ToString();
                check_id = reader["pid"].ToString();


                if (check_id == pro_id)
                {
                    int chk_q = int.Parse(check_q);
                    int chk_q_user = int.Parse(user_quantity);
                    if (chk_q >= chk_q_user)
                    {
                        cmd.Dispose();
                        closeConnection();
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Out of Stocks..!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        cmd.Dispose();
                        closeConnection();
                        return false;

                    }

                }
            }

            cmd.Dispose();
            closeConnection();
            return false;

        }

        static private int amount_final;

        static public int AMOUNT_FINAL
        {
            get
            {
                return amount_final;
            }
            set
            {
                amount_final = value;
            }

        }




        static private List<Sale_line> bill = new List<Sale_line>();
        static public List<Sale_line> BILL
        {
            get
            {
                return bill;
            }
            set
            {
                value = bill;
            }
        }



        private void sub_func1(string check_product_price, string check_product_id, string check_product_name)
        {
            OpenDBConnection();
            PRODUCT_NAME = check_product_name;
            PRODUCT_PRICE = check_product_price;
            String query = "INSERT INTO dbo.Add_Sale (pId,quantity,customerID,timeOfPurchase,productname,productprice,amount) VALUES (@pId,@quantity,@customerID,@timeOfPurchase,@productprice,@productname,@amount)"; //(@pId,@quantity,@customerID,@timeOfPurchase)

            string q = DateTime.Now.ToString();

            int price = int.Parse(check_product_price);
            int amont = int.Parse(quantity_sale);
            int amo = price * amont;
            AMOUNT_FINAL = amo + AMOUNT_FINAL;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pId", PRO_ID);
            command.Parameters.AddWithValue("@quantity", QUANTITY_SALE);
            command.Parameters.AddWithValue("@customerID", CUS_NAME);
            command.Parameters.AddWithValue("@timeOfPurchase", q);
            command.Parameters.AddWithValue("@productname", check_product_name);
            command.Parameters.AddWithValue("@productprice", check_product_price);
            command.Parameters.AddWithValue("@amount", amo.ToString());



            command.ExecuteNonQuery();
            command.Dispose();
            Sale_line obj1 = new Sale_line();
            obj1.ITEMS_ID = PRO_ID;
            obj1.QUANTITY = QUANTITY_SALE;
            obj1.AMOUNT = amo.ToString();
            obj1.ITEMS_NAME = check_product_name;
            obj1.PRICE = check_product_price;
            obj1.DETAIL = check_product_price + "  *  " + QUANTITY_SALE;
            Sale_line.CUS_NAME = CUS_NAME;
            Sale_line.DATE = q;

            bill.Add(obj1);


            MessageBox.Show("Items Added to cart...!!!", "Successfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            closeConnection();
            sub_fun3(PRO_ID, QUANTITY_SALE);
            return;


        }


        void sub_fun3(string p_id, string qu)
        {
            OpenDBConnection();
            try
            {


                string query = "update updateInventory set quantity=quantity-'" + qu + "'where pId='" + p_id + "'";

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    //MessageBox.Show("DONE.!!", "Done", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    MessageBox.Show("ERROR IN update Inventory !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }




            }
            catch
            {
                MessageBox.Show("Database Error..!!!");

            }
            closeConnection();
        }



        public void reset_productdata()
        {
            OpenDBConnection();
            string query = "delete updateInventory";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                // MessageBox.Show("Product + Update Inventory database has sucessfully reset..!!", "Sucessfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("error in reseting database..!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            closeConnection();

            OpenDBConnection();

            string query1 = "delete products";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Product + Update Inventory database has sucessfully reset..!!", "Sucessfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Error in reseting database..!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            closeConnection();
        }


        public void reset_customerdata()
        {

            string query1 = "delete Add_Sale";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Customer database has sucessfully reset..!!", "Sucessfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Error in reseting database..!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            closeConnection();

        }



        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


      
            
        
        
    }
}