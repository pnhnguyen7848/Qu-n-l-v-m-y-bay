using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BAOCAOCUOIKI1
{
    public partial class ChuyenBayTbl : Form
    {
        public ChuyenBayTbl()
        {
            InitializeComponent();
        }
        // thêm
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = DateTime.Now.AddDays(-1);
            DateTime date3 =date2.AddDays(7);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã chuyến bay vào");
            }
            else if (textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào");
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && comboBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào");
            }
            else if ((comboBox2.Text == "" && textBox2.Text == "") || comboBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào");
            }
            else if(txtMaTuyenBay.Text.Length < 7)
            {
                MessageBox.Show("Mã tuyến bay không hợp lệ");
            }
            else if (date1 < date2)
            {
                MessageBox.Show("Ngày không hợp lệ");
            }
            else if (date1 <= date3)
            {
                MessageBox.Show("Ngày đi phải tạo trước 1 tuần hoặc hơn");
            }
            else
            {
                BatLoiChuyenBay b = new BatLoiChuyenBay(textBox1.Text, textBox2.Text, textBox3.Text);
                if (b.kiemtrachuyenbay() == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng mã chuyến bay");
                }
                else if (b.kiemtrasoghe() == false)
                {
                    MessageBox.Show("Vui long nhập đúng theo quy định");
                }
                else if (INSERT(textBox1.Text,txtMaTuyenBay.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Value, int.Parse(textBox2.Text), int.Parse(textBox3.Text)) != -1)
                {
                    dataGridView1.DataSource = SelectAll();
                    MessageBox.Show("Thêm dữ liệu thành công");
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại");
                }
            }
        }
        // xóa
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Bạn muốn xóa chuyến bay: " + textBox1.Text, "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Delete(textBox1.Text) != -1)
                    {
                        MessageBox.Show("Đã xóa chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChuyenBayTbl_Load(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Xóa chuyến bay thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        //ChuyenBayTbl_Load
        // cập nhật 
        private void button4_Click(object sender, EventArgs e)
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = DateTime.Now.AddDays(-1);
            DateTime date3 = date2.AddDays(7);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã chuyến bay vào");
            }
            else if (textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào");
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && comboBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào");
            }
            else if ((comboBox2.Text == "" && textBox2.Text == "") || comboBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào");
            }
            else if (txtMaTuyenBay.Text.Length < 7)
            {
                MessageBox.Show("Mã tuyến bay không hợp lệ");
            }
            else if (date1 < date2)
            {
                MessageBox.Show("Ngày không hợp lệ");
            }
            else if (date1 < date3)
            {
                MessageBox.Show("Ngày đi phải tạo trước 1 tuần hoặc hơn");
            }
            else
            {
                BatLoiChuyenBay b = new BatLoiChuyenBay(textBox1.Text, textBox2.Text, textBox3.Text);
                if (b.kiemtrachuyenbay() == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng mã chuyến bay");
                }
                else if (b.kiemtrasoghe() == false)
                {
                    MessageBox.Show("Vui long nhập đúng theo quy định");
                }
                else if (UPDATE(textBox1.Text,txtMaTuyenBay.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Value, int.Parse(textBox2.Text), int.Parse(textBox3.Text)) != -1)
                {
                    dataGridView1.DataSource = SelectAll();
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại");
                }
            }
        }
        // NHập lại
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
        }
        ketnoi cn = new ketnoi();

        private void ChuyenBayTbl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SelectAll();
            comboBox1.DataSource = cn.ExecuteData("select * from SanBay ");
            comboBox1.DisplayMember = "TenSanBay";
            comboBox1.ValueMember = "MaSanBay";
            comboBox1.SelectedIndex = 0; // Khong có dữ liệu bên database nó sẽ báo lỗi
            comboBox2.DataSource = cn.ExecuteData("select MASANBAY, TENSANBAY from TUYENBAY, SANBAY where SANBAY.MASANBAY = TUYENBAY.MASANBAYDEN and MASANBAYDI='" + comboBox1.SelectedValue + "' ");
            comboBox2.DisplayMember = "TENSANBAY";
            comboBox2.ValueMember = "MASANBAY";
            txtMaTuyenBay.Text = comboBox1.SelectedValue + "-" + comboBox2.SelectedValue;
            this.KeyPreview = true;
        }
        public DataTable SelectAll()
        {
            return cn.ExecuteData("select * from CHUYENBAY");
        }
        public int INSERT(string MACHUYENBAY,string MATUYENBAY, string SANBAYDI, string SANBAYDEN, DateTime NGAYGIO, int SOGHEHANG1, int SOGHEHANG2)
        {
            string sql = "INSERT INTO CHUYENBAY(MACHUYENBAY,MATUYENBAY,SANBAYDI,SANBAYDEN,NGAYGIO,SOGHEHANG1,SOGHEHANG2) VALUES (N'" + MACHUYENBAY + "',N'" + MATUYENBAY + "',N'" + SANBAYDI + "',N'" + SANBAYDEN + "',N'" + NGAYGIO.ToString("MM/dd/yyyy") + "'," + SOGHEHANG1 + "," + SOGHEHANG2 + ")";
            return cn.ExecuteNonQuery(sql);
        }
        public int UPDATE(string MACHUYENBAY,string MATUYENBAY, string SANBAYDI, string SANBAYDEN, DateTime NGAYGIO, int SOGHEHANG1, int SOGHEHANG2)
        {
            string sql = "UPDATE CHUYENBAY SET [MATUYENBAY]=N'" + MATUYENBAY + "',[SANBAYDI]=N'" + SANBAYDI + "',[SANBAYDEN]=N'" + SANBAYDEN + "',[NGAYGIO]=N'" + NGAYGIO.ToString("MM/dd/yyyy") + "',[SOGHEHANG1]=N'" + SOGHEHANG1 + "',[SOGHEHANG2]=N'" + SOGHEHANG2 + "' WHERE [MACHUYENBAY]=N'" + MACHUYENBAY + "'";
            return cn.ExecuteNonQuery(sql);
        }
        public int Delete(string MACHUYENBAY)
        {
            string sql = "DELETE FROM CHUYENBAY WHERE [MACHUYENBAY]=N'" + MACHUYENBAY + "'";
            return cn.ExecuteNonQuery(sql);
        }
        // Thay đổi tuyến bay
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.DataSource = cn.ExecuteData("select MASANBAY, TENSANBAY from TUYENBAY, SANBAY where SANBAY.MASANBAY = TUYENBAY.MASANBAYDEN and MASANBAYDI='" + comboBox1.SelectedValue + "' ");
            comboBox2.DisplayMember = "TENSANBAY";
            comboBox2.ValueMember = "MASANBAY";
 
            txtMaTuyenBay.Text = comboBox1.SelectedValue + "-" + comboBox2.SelectedValue;

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtMaTuyenBay.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChuyenBayTbl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                button3.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                dataGridView1.DataSource = cn.ExecuteData("SELECT * FROM CHUYENBAY");
            }
        }
        // Quy Dịnh chuyến bay
        private void button6_Click(object sender, EventArgs e)
        {
            QuyDinhChuyenBay n = new QuyDinhChuyenBay();
            n.Show();
        }
        // Thay đổi mã tuyến bay
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaTuyenBay.Text = comboBox1.SelectedValue + "-" + comboBox2.SelectedValue;
        }

        private void TiemKiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from CHUYENBAY WHERE MACHUYENBAY=N'" + textBox1.Text + "'";
            dataGridView1.DataSource = cn.ExecuteData(sql);
        }

        // 
    }
}
