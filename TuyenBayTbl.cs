using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAOCAOCUOIKI1
{
    public partial class TuyenBayTbl : Form
    {
        public TuyenBayTbl()
        {
            InitializeComponent();
        }
        // thêm 
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.StartsWith(comboBox2.Text)){
                MessageBox.Show("Mã sân bay không bị trùng");
            }
            else if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                if (INSERT(textBox1.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString()) != -1)
                {
                    dataGridView1.DataSource = cn.ExecuteData("select * from TUYENBAY");
                    MessageBox.Show("Đã thêm thành công");
                }
                else
                {
                    MessageBox.Show("Mã tuyến bay đã có sẵn");
                }
            }
            else if (textBox1.Text == "" && comboBox1.Text != "" && comboBox2.Text != "") MessageBox.Show("Không được để trống mã tuyến bay");
            else if (textBox1.Text == "" && comboBox1.Text == "" && comboBox2.Text != "") MessageBox.Show("Không được để trống mã tuyến bay và tên sân bay đi");
            else if (textBox1.Text == "" && comboBox1.Text == "" && comboBox2.Text == "") MessageBox.Show("Tất cả không được để trống");
            else if (textBox1.Text == "" && comboBox1.Text != "" && comboBox2.Text == "") MessageBox.Show("Không được để trống mã tuyến bay và tên sân bay đến");
            else if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text == "") MessageBox.Show("Không được để trống tên sân bay đến");
            else if (textBox1.Text != "" && comboBox1.Text == "" && comboBox2.Text == "") MessageBox.Show("Không được để trống tên sân bay đi và tên sân bay đến");
        }
        // xóa 
        private void button2_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Bạn muốn xóa tuyến bay: " + textBox1.Text, "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Delete(textBox1.Text) != -1)
                    {
                        MessageBox.Show("Đã xóa tuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TuyenBayTbl_Load(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Xóa tuyến bay thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if(textBox1.Text == "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                MessageBox.Show("Không được để trống mã chuyến bay");
            }
        }
        ketnoi cn = new ketnoi();

        private void TuyenBayTbl_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = cn.ExecuteData("select * from sanbay");
            comboBox1.DisplayMember = "TenSanBay";
            comboBox1.ValueMember = "MaSanBay";
            comboBox2.DataSource = cn.ExecuteData("select * from sanbay");
            comboBox2.DisplayMember = "TenSanBay";
            comboBox2.ValueMember = "MaSanBay";
         
            dataGridView1.DataSource = cn.ExecuteData("select * from TUYENBAY");
            textBox1.Text = comboBox1.SelectedValue + "-" + comboBox2.SelectedValue;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            this.KeyPreview = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedValue + "-" + comboBox2.SelectedValue;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedValue + "-" + comboBox2.SelectedValue;
        }
        public int INSERT(string MATUYENBAY, string MASANBAYDI, string MASANBAYDEN)
        {
            //if (MATUYENBAY == "")
            //    return -1;
            string sql = "INSERT INTO TUYENBAY(MATUYENBAY,MASANBAYDI,MASANBAYDEN) VALUES (N'" + MATUYENBAY + "',N'" + MASANBAYDI + "',N'" + MASANBAYDEN + "')";
            return cn.ExecuteNonQuery(sql);
        }

        public int Delete(string MATUYENBAY)
        {
            string sql = "DELETE FROM TUYENBAY WHERE [MATUYENBAY]=N'" + MATUYENBAY + "'";
            return cn.ExecuteNonQuery(sql);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["MATUYENBAY"].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["MASANBAYDI"].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells["MASANBAYDEN"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        // nhập lại
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TuyenBayTbl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                button3.PerformClick();
            } 
        }
    }
}
