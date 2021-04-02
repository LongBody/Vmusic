using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        SqlConnection cnn; //Ket noi DB
        SqlDataAdapter da; //Xu ly cac cau lenh SQL: Select
        SqlCommand cmd; //Thuc thi cau lenh insert update


        public DataProvider() {
            connect();
        }


        private void connect()
        {
            try
            {
                //string strCnn = "Data Source=localhost;Initial Catalog=ProductOrder;Integrated Security=True";
                string strCnn = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
                cnn = new SqlConnection(strCnn);
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cnn.Open();
                Console.WriteLine("Connect success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi ket noi:" + ex.Message);
            }
        }


        public DataTable executeNonQuery(string strSelect)
        {
            DataTable dt = new DataTable();//Chua du lieu sau khi select ve

            try
            {
                da = new SqlDataAdapter(strSelect, cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login fail:" + ex.Message);
            }
            return dt;
        }

        public void Excute(string query)
        {
            try
            {
                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi excute non query: " + ex.Message);
            }
        }

    }


}
