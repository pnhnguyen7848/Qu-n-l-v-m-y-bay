using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace BAOCAOCUOIKI1
{
    class ketnoi
    {
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-G5S7O1BS\SQLEXPRESS;Initial Catalog=MayBayDB123;Integrated Security=True");
        string chuoiketnoi = @"Data Source=LAPTOP-G5S7O1BS\SQLEXPRESS;Initial Catalog=MayBayDB123;Integrated Security=True";
        public ketnoi()
        {

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        public ketnoi(string s)
        {
            cn = new SqlConnection(s);
        }

        public SqlConnection connection()
        {
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            return conn;
        }
        public void KetNoi()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }
        public void DongKetNoi()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }
        public int ExecuteNonQuery(string strQuery)
        {
            int CS = -1;
            try
            {
                int result = 0;
                if (this.cn.State == ConnectionState.Closed)
                {
                    this.cn.Open();
                }
                result = new SqlCommand { Connection = this.cn, CommandType = CommandType.Text, CommandText = strQuery }.ExecuteNonQuery();
                this.cn.Close();
                CS = result;
            }
            catch
            {

                return -1;
            }
            return CS;
        }

        public DataTable ExecuteData(string strQuery)
        {
            try
            {
                KetNoi();
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DongKetNoi();
                return ds.Tables[0];
            }
            catch { return null; }
        }
       
    }
}
