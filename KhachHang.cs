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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        // trở về
        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        // Thêm
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIDKhachHang.Text != "" && txtCMND.Text != "" && txtTenKhachHang.Text != "" && txtSoDienThoai.Text != "")
            {
                BatLoiKhachHang d = new BatLoiKhachHang(txtIDKhachHang.Text, txtCMND.Text, cbQuocTich.Text, txtPassport.Text, txtSoDienThoai.Text);
                if (d.KiemTraID() == false)
                {
                    MessageBox.Show("Vui lòng nhập id đúng theo bảng Quy Định Khách Hàng");
                }
                else if (d.KiemTraPassPort() == false) { MessageBox.Show("Vui lòng nhập PassPort đúng theo bẳng Quy Định Khách Hàng"); }
                else if (d.KiemTraCMND() == false) { MessageBox.Show("Vui lòng nhập CMND đúng theo băng Quy Định Khách Hàngh"); }
                else
                { 
                     if (d.KiemTraSoDienThoai() == false)
                     {
                        MessageBox.Show("Vui lòng nhập số điện thoại đúng theo bảng Quy Định Khách Hàng");
                    }
                    else
                    {
                        if (INSERT(txtIDKhachHang.Text, txtTenKhachHang.Text, txtCMND.Text, txtSoDienThoai.Text, cbQuocTich.Text, txtPassport.Text) != -1)
                        {
                            MessageBox.Show("Thêm thành công");
                            dataGridView1.DataSource = cn.ExecuteData("select * from KHACHHANG");
                        }
                        else
                        {
                            MessageBox.Show("Thông tin định danh đã tồn tại");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        // Cập nhật
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtIDKhachHang.Text != "" && txtCMND.Text != "" && txtTenKhachHang.Text != "" && txtSoDienThoai.Text != "")
            {
                BatLoiKhachHang d = new BatLoiKhachHang(txtIDKhachHang.Text, txtCMND.Text, cbQuocTich.Text, txtPassport.Text, txtSoDienThoai.Text);
                if (d.KiemTraID() == false)
                {
                    MessageBox.Show("Vui lòng nhập id đúng theo bảng Quy Định Khách Hàng");
                }
                else if (d.KiemTraPassPort() == false) { MessageBox.Show("Vui lòng nhập PassPort đúng theo bảng Quy Định Khách Hàng"); }
                else if (d.KiemTraCMND() == false) { MessageBox.Show("Vui lòng nhập CMND đúng theo bảng quy định"); }
                else
                {
                    if (d.KiemTraSoDienThoai() == false)
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại đúng theo bảng Quy Định Khách Hàng");
                    }
                    else
                    {
                        if (UPDATE(txtIDKhachHang.Text, txtTenKhachHang.Text, txtCMND.Text, txtSoDienThoai.Text, cbQuocTich.Text, txtPassport.Text) != -1)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            dataGridView1.DataSource = cn.ExecuteData("select * from KHACHHANG");
                        }
                        else
                        {
                            MessageBox.Show("Thông tin định danh đã tồn tại");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        // Xóa
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIDKhachHang.Text != "")
            {
                if (MessageBox.Show("Bạn muốn xóa khách hàng: " + txtIDKhachHang.Text, "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Delete(txtIDKhachHang.Text) != -1)
                    {
                        MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KhachHang_Load(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID khách cần xóa");
            }
        }
        // Nhập lại
        private void button3_Click(object sender, EventArgs e)
        {
            txtIDKhachHang.Text = "";
            txtCMND.Text = "";
            txtTenKhachHang.Text = "";
            txtSoDienThoai.Text = "";
        }
        ketnoi cn = new ketnoi();
        public int INSERT(string MAKHACHHANG, string TENKHACHHANG, string CMND, string SODIENTHOAI, string QUOCTICH, string PASSPORT)
        {
            string sql = "INSERT INTO KHACHHANG(MAKH,TENKH,CMND,SODIENTHOAI,QUOCTICH,PASSPORT) VALUES (N'" + MAKHACHHANG + "',N'" + TENKHACHHANG + "',N'" + CMND + "',N'" + SODIENTHOAI + "',N'" + QUOCTICH + "',N'" + PASSPORT + "')";
            return cn.ExecuteNonQuery(sql);
        }
        public int UPDATE(string MAKHACHHANG, string TENKHACHHANG, string CMND, string SODIENTHOAI, string QUOCTICH, string PASSPORT)
        {
            string sql = "UPDATE KHACHHANG SET TENKH=N'" + TENKHACHHANG + "', CMND=N'" + CMND + "', SODIENTHOAI=N'" + SODIENTHOAI + "', QUOCTICH=N'" + QUOCTICH + "', PASSPORT=N'" + PASSPORT + "' WHERE [MAKH]=N'" + MAKHACHHANG + "'";
            return cn.ExecuteNonQuery(sql);
        }
        public int Delete(string MAKHACHHANG)
        {
            string sql = "DELETE FROM KHACHHANG WHERE [MAKH]=N'" + MAKHACHHANG + "'";
            return cn.ExecuteNonQuery(sql);
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cn.ExecuteData("select * from KHACHHANG");
            this.KeyPreview = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIDKhachHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCMND.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTenKhachHang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbQuocTich.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPassport.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void QuyDinhKH_Click(object sender, EventArgs e)
        {
            QuyDinhKhachHang n = new QuyDinhKhachHang();
            n.Show();
        }

        private void KhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                button4.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                dataGridView1.DataSource = cn.ExecuteData("select * from KHACHHANG");
            }
        }
        // TÌM KIẾM
        private void TimKiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from KHACHHANG WHERE MAKH =N'" + txtIDKhachHang.Text + "' AND CMND=N'" + txtCMND.Text + "'";
            string sql1 = "select * from KHACHHANG WHERE MAKH=N'" + txtIDKhachHang.Text + "'";
            string sql2 = "select * from KHACHHANG WHERE CMND =N'" + txtCMND.Text + "'";
            if (txtCMND.Text == "")
            {
                dataGridView1.DataSource = cn.ExecuteData(sql1);
            }
            else if (txtIDKhachHang.Text == "")
            {
                dataGridView1.DataSource = cn.ExecuteData(sql2);
            }
            else
            {
                dataGridView1.DataSource = cn.ExecuteData(sql);
            }
        }
    }
}
