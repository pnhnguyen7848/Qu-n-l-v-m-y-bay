using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAOCAOCUOIKI1
{
    public partial class DoanhThuTbl : Form
    {
        ketnoi general = new ketnoi();

        public DoanhThuTbl()
        {
            InitializeComponent();
        }
        // trở về
        private void button1_Click(object sender, EventArgs e)
        {
            Home hehe = new Home();
            hehe.Show();
            this.Hide();
        }

        private void DoanhThuTbl_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // Tìm theo tháng
        private void button2_Click(object sender, EventArgs e)
        {
            general.connection().Open();
            string sql = "SELECT * FROM DATCHO WHERE 1=1";
            if ((dateTimePicker1.Text != "") && (dateTimePicker2.Text != ""))
            {
                sql = sql + " AND NGAYDAT >= '" + dateTimePicker1.Text + "' AND NGAYDAT <= '" + dateTimePicker2.Text + "'";
            }
            DataSet ds = new DataSet();
            // tạo mới một instance SqlDataAdapter với câu lệnh lấy dữ liệu trong bảng DATCHO
            SqlDataAdapter da = new SqlDataAdapter(sql, general.connection());
            // sử dụng phương thức fill để điền dữ liệu vào
            da.Fill(ds);
            general.connection().Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
        }

        // tìm tất cả hóa đơn
        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from DATCHO";
            dataGridView1.DataSource = general.ExecuteData(sql);
        }
        // tính tổng
        private void button4_Click(object sender, EventArgs e)
        {
            int sc = dataGridView1.Rows.Count;
            Double thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dataGridView1.Rows[i].Cells["GIATIEN"].Value.ToString().Replace(".", "").Replace("VNĐ", ""));
            textBox1.Text = thanhtien.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowThousands);
            textBox1.Text = String.Format(culture, "{0:N0}", value);
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void DoanhThuTbl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                button1.PerformClick();
            }
        }
        public int Delete(string MAPHIEU)
        {
            string sql = "DELETE FROM DATCHO WHERE [MAPHIEU]=N'" + MAPHIEU + "'";
            return general.ExecuteNonQuery(sql);
        }
        private void Xoa_Click(object sender, EventArgs e)
        {
            int sc = dataGridView1.Rows.Count;
            for (int i = 0; i < sc - 1; i++)
            {
                string[] maphieu =new string[10] ;
                maphieu[i] += dataGridView1.Rows[i].Cells["MAPHIEU"].Value.ToString();
                Delete(maphieu[i]);
            }
             string sql = "select * from DATCHO";
                dataGridView1.DataSource = general.ExecuteData(sql);
        }
    }
}
