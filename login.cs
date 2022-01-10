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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        ketnoi cn = new ketnoi();

        // Nút Reset
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        // Nút đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select TENTAIKHOAN, MATKHAU from ADMIN where TENTAIKHOAN ='" + textBox1.Text + "' and MATKHAU='" + textBox2.Text + "'";
            DataTable dt = cn.ExecuteData(sql);
            if (dt.Rows.Count > 0)
            {
                Home n = new Home();
                n.Tentk = dt.Rows[0][0].ToString();
                this.Hide();
                n.Show();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Nút Exit
        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
