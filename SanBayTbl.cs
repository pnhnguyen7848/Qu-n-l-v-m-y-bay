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
    public partial class SanBayTbl : Form
    {
        public SanBayTbl()
        {
            InitializeComponent();
        }
        ketnoi cn = new ketnoi();
        // Thêm sân bay
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                BatLoiSanBay n = new BatLoiSanBay(textBox1.Text);
                if (n.KiemTraID())
                {
                    if(INSERT(textBox1.Text, textBox2.Text) != -1)
                    {
                        MessageBox.Show("Đã thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }

                }
                else
                {
                    MessageBox.Show("Vui long nhập mã sân bay đúng định dạng");
                }
            }
            else if (textBox1.Text == "" && textBox2.Text == "") MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
            else if (textBox1.Text == "" && textBox2.Text != "") MessageBox.Show("Không được để mã sân bay trống");
            else if (textBox1.Text != "" && textBox2.Text == "") MessageBox.Show("Không được để tên sân bay trống");
            dataGridView1.DataSource = SelectAll(); // truyền dữ liệu vào khung dataGridView1, nếu không có cái này sẽ không hiển thị được
        }

        //Nhập dữ liệu
        public int INSERT(string MASANBAY, string TENSANBAY)
        {
            string sql = "INSERT INTO SANBAY(MASANBAY,TENSANBAY) VALUES (N'" + MASANBAY + "',N'" + TENSANBAY + "')";
            return cn.ExecuteNonQuery(sql);
        }
        public int UPDATE(string MASANBAY, string TENSANBAY)
        {
            //this.cn.KetNoi();
            string sql = "UPDATE SANBAY SET [MASANBAY]=N'" + MASANBAY + "',[TENSANBAY]=N'" + TENSANBAY + "' WHERE [MASANBAY]=N'" + MASANBAY + "'";
            return cn.ExecuteNonQuery(sql);
        }
        public int Delete(string MASANBAY)
        {
            //this.cn.KetNoi();
            string sql = "DELETE FROM SANBAY WHERE [MASANBAY]=N'" + MASANBAY + "'";
            return cn.ExecuteNonQuery(sql);
        }

        //Chạy dữ liệu từ bảng SANBAY
        public DataTable SelectAll()
        {
            return cn.ExecuteData("select * from SANBAY");
        }
        // cập nhật sân bay
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                BatLoiSanBay n = new BatLoiSanBay(textBox1.Text);
                if (n.KiemTraID())
                {
                    if (UPDATE(textBox1.Text, textBox2.Text) != -1)
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }

                }
                else
                {
                    MessageBox.Show("Vui long nhập mã sân bay đúng định dạng");
                }
            }
            else if (textBox1.Text == "" && textBox2.Text == "") MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
            else if (textBox1.Text == "" && textBox2.Text != "") MessageBox.Show("Không được để mã sân bay trống");
            else if (textBox1.Text != "" && textBox2.Text == "") MessageBox.Show("Không được để tên sân bay trống");
            dataGridView1.DataSource = SelectAll(); // truyền dữ liệu vào khung dataGridView1, nếu không có cái này sẽ không hiển thị được
        }

       
        
        // xóa sân bay
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Delete(textBox1.Text);
                    MessageBox.Show("Đã xóa thành công");
                }
                dataGridView1.DataSource = SelectAll();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        
        // tải dữ liệu lên dataGridView
        private void SanBayTbl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SelectAll(); // đổ vào dữ liệu trong bảng sân bay
            this.KeyPreview = true; // để dùng phím tắt ESC
        }

     
        // trở về
        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        

       

       

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        //khai báo phím tắt ESC
        private void SanBayTbl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button4.PerformClick();
            }
        }
    }
}
