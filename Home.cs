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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        string tentk = "";

        public string Tentk
        {
            get { return tentk; }
            set { tentk = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TuyenBayTbl Can = new TuyenBayTbl();
            Can.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChuyenBayTbl Can = new ChuyenBayTbl();
            Can.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DatChoTbl Can = new DatChoTbl();
            Can.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KhachHang Can = new KhachHang();
            Can.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void Doimatkhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau n=new DoiMatKhau();
            n.Show();
            this.Hide();
        }

        

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login n=new login();
            n.Show();
            this.Hide();
        }

        private void đỏiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau n = new DoiMatKhau();
            n.tentk = this.tentk;
            n.Show();
            this.Hide();
        }

        private void sânBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanBayTbl Can = new SanBayTbl();
            Can.Show();
            this.Hide();

        }

        private void tuyếnBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TuyenBayTbl Can = new TuyenBayTbl();
            Can.Show();
            this.Hide();
        }

        private void chuyếnBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChuyenBayTbl Can = new ChuyenBayTbl();
            Can.Show();
            this.Hide();
        }

        private void KhachHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KhachHang Can = new KhachHang();
            Can.Show();
            this.Hide();
        }

        private void đặtChỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatChoTbl Can = new DatChoTbl();
            Can.Show();
            this.Hide();
        }

        private void doanhThuToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DoanhThuTbl n=new DoanhThuTbl();
            n.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                đăngXuấtToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                sânBayToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                chuyếnBayToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.T)
            {
                tuyếnBayToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                đặtChỗToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.K)
            {
                KhachHangToolStripMenuItem1.PerformClick();
            }
            if (e.Alt == true && e.KeyCode == Keys.C)
            {
                đỏiMậtKhẩuToolStripMenuItem.PerformClick();
            }
            if (e.Alt == true && e.KeyCode == Keys.D)
            {
                doanhThuToolStripMenuItem2.PerformClick();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
