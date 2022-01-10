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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        ketnoi cn = new ketnoi();
        private void label3_Click(object sender, EventArgs e)
        {
            Home n=new Home();
            n.Show();
            this.Close();
        }
        public string tentk;

        private int doiMatKhau(string matkhaumoi)
        {
            string sqlktmk = "select MATKHAU from ADMIN where TENTAIKHOAN='" + this.tentk + "'";
            DataTable dt = cn.ExecuteData(sqlktmk);
            if (dt.Rows.Count >  0)
            {
                if (dt.Rows[0][0].ToString() == txtMKCU.Text)
                {
                    string sql = "update ADMIN set MATKHAU ='" + matkhaumoi + "' where TENTAIKHOAN='" + this.tentk + "'";
                    return cn.ExecuteNonQuery(sql);
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return -1;
            }
        }
        // ĐỖI MẬT KHẨU
        private void button1_Click(object sender, EventArgs e)
        {
            KiemTraTaiKhoan n = new KiemTraTaiKhoan(txtTaiKhoan.Text,txtMatKhau.Text);
            if (txtTaiKhoan.Text== "")
            {
                MessageBox.Show("Không để tài khoản trống");
            }
            else if (txtMatKhau.Text== "")
            {
                MessageBox.Show("Không để mật khẩu trống");
            }
     
            else if (!n.KiemTraMatKhau())
            {
                MessageBox.Show("Mật khẩu không đúng định dạng");
            }
            else if (txtNhapLaiMatKhau.Text == "")
            {
                MessageBox.Show("Không để nhập lại mật khẩu trống");
            }
            else if (txtNhapLaiMatKhau.Text.StartsWith(txtMatKhau.Text))
            {
                if (doiMatKhau(txtNhapLaiMatKhau.Text) != -1)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Home a =new Home();
                    a.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nhập lại mật khẩu không đúng");
            }
        }

        private void DoiMatKhau_Load_1(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "Admin";
            this.KeyPreview = true;
        }

        private void DoiMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Home n = new Home();
                n.Show();
                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
