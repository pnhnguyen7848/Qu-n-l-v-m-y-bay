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
    public partial class DatChoTbl : Form
    {
        public DatChoTbl()
        {
            InitializeComponent();
        }
        ketnoi cn = new ketnoi();
        //Hiển thị ra màn hình dữ liệu
        private void DatChoTbl_Load(object sender, EventArgs e)
        {
            cbMaChuyenBay.DataSource = cn.ExecuteData("select * from CHUYENBAY ");
            cbMaChuyenBay.ValueMember = "MACHUYENBAY";
            cbMaChuyenBay.DisplayMember = "MACHUYENBAY";
            cbMaChuyenBay.SelectedIndex = 0;

            cbMaHanhKhach.DataSource = cn.ExecuteData("select * from KHACHHANG ");
            cbMaHanhKhach.ValueMember = "MAKH";
            cbMaHanhKhach.DisplayMember = "MAKH";

            cbHangVe.DataSource = cn.ExecuteData("select * from HANGVE ");
            cbHangVe.ValueMember = "mahangve";
            cbHangVe.DisplayMember = "tenhangve";

            dataGridView1.DataSource = cn.ExecuteData("select * from DATCHO");
            this.KeyPreview = true;
        }
        //Nhập lại
        private void button4_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = "";
            txtSoGheDat.Text = "";
            txtGiaTien.Text = "3000000";
            txtThanhTien.Text = "0";
            cbMaChuyenBay.Text = "";
            cbMaHanhKhach.Text = "";
            cbHangVe.Text = "Vé hạng 1";
            NgayDat.Text = "";
            textBox1.Text = "";
            txtMaTuyenBay.Text = "";
        }
        //Trở về
        private void TroVe_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        public DataTable SelectAll()
        {
            return cn.ExecuteData("select * from CHUYENBAY");
        }
        public DateTime KiemTraGio(string MaChuyenBay)
        {
            string sql = "select NGAYGIO from chuyenbay where machuyenbay='" + MaChuyenBay + "'";
            DataTable dt=cn.ExecuteData(sql);
            DateTime date;
            if (dt.Rows.Count > 0)
            {
                date = Convert.ToDateTime(dt.Rows[0][0].ToString());
                return date;
            }
             return DateTime.Now;
        }

        public void ThanhTien()
        {
            BatLoiDatCho dc = new BatLoiDatCho(txtGiaTien.Text, txtThanhTien.Text, txtMaPhieu.Text, cbMaHanhKhach.Text);
            string modifiedString = txtGiaTien.Text.Replace(",", "").Replace("VNĐ", "");
            int sl, gn, tt;
            if (txtGiaTien.Text == "") gn = 0;
            else gn = int.Parse(modifiedString.ToString());
            if (txtSoGheDat.Text == "") sl = 0;
            else sl = int.Parse((txtSoGheDat.Text));
            if (dc.KiemTraKhach())
            {
                tt = gn * sl - ((gn * sl) * 10 / 100);
                txtThanhTien.Text = tt.ToString();
            }
            else
            {
                tt = gn * sl;
                txtThanhTien.Text = tt.ToString();
            }
        }
        public bool KiemTraVe(string MaChuyenBay, string HangVe)
        {

            string SoGheHang1, SoGheHang2, DatGheHang1, DatGheHang2;
            string sql1 = "select SOGHEHANG1, SOGHEHANG2 FROM chuyenbay where MACHUYENBAY = N'" + MaChuyenBay + "'";
            string sql2 = "select MACHUYENBAY,sum(SOGHEDAT) from DATCHO group by MACHUYENBAY,MAHANGVE having MACHUYENBAY = '" + MaChuyenBay + "' and MAHANGVE='" + HangVe + "'";
            string sql3 = " SELECT count(*) FROM DATCHO where MACHUYENBAY='" + MaChuyenBay + "' and MAHANGVE='" + HangVe + "'";
            DataTable dt = cn.ExecuteData(sql1);
            DataTable dt2 = cn.ExecuteData(sql2);
            DataTable dt3 = cn.ExecuteData(sql3);
            if (dt.Rows.Count > 0)
            {
                SoGheHang1 = dt.Rows[0][0].ToString();
                SoGheHang2 = dt.Rows[0][1].ToString();
                //sql2 bảng có giá trị trả về
                if (dt2.Rows.Count > 0)
                {

                    if (cbHangVe.Text == "Vé hạng 1")
                    {
                        DatGheHang1 = dt2.Rows[0][1].ToString();
                        if (int.Parse(SoGheHang1) > int.Parse(DatGheHang1))
                        {
                            textBox1.Text = (int.Parse(SoGheHang1) - int.Parse(DatGheHang1)).ToString();
                            return true;
                        }
                        else
                        {
                            textBox1.Text = "0";
                        }
                    }
                    else
                    {
                        DatGheHang2 = dt2.Rows[0][1].ToString();
                        if (int.Parse(SoGheHang2) > int.Parse(DatGheHang2))
                        {
                            textBox1.Text = (int.Parse(SoGheHang2) - int.Parse(DatGheHang2)).ToString();
                            return true;
                        }
                        else
                        {
                            textBox1.Text = "0";
                        }

                    }
                }
                else
                {
                    //sql2 không có giá trị trả về 
                    if (dt3.Rows[0][0].ToString() == "0")
                    {
                        if (cbHangVe.Text == "Vé hạng 1")
                        {
                            textBox1.Text = SoGheHang1;
                        }
                        else
                        {
                            textBox1.Text = SoGheHang2;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        public int INSERT(string MAPHIEU, string MAKH, string MACHUYENBAY, string MATUYENBAY, string MAHANGVE, int SOGHEDAT, DateTime NGAYDAT, string GIATIEN)
        {
            string sql = "INSERT INTO DATCHO(MAPHIEU,MAKH,MACHUYENBAY,MATUYENBAY,MAHANGVE,SOGHEDAT,NGAYDAT,GIATIEN) VALUES (N'" + MAPHIEU + "',N'" + MAKH + "',N'" + MACHUYENBAY + "',N'" + MATUYENBAY + "',N'" + MAHANGVE + "',N'" + SOGHEDAT + "',N'" + NGAYDAT.ToString("MM/dd/ yyyy") + "',N'" + GIATIEN + "')";
            return cn.ExecuteNonQuery(sql);
        }
        public int UPDATE(string MAPHIEU, string MAKH, string MACHUYENBAY, string MATUYENBAY, string MAHANGVE, int SOGHEDAT, DateTime NGAYDAT, string GIATIEN)
        {
            string sql = "UPDATE DATCHO SET  MAKH=N'" + MAKH + "', MACHUYENBAY=N'" + MACHUYENBAY + "', MATUYENBAY=N'" + MATUYENBAY + "', MAHANGVE=N'" + MAHANGVE + "', SOGHEDAT=N'" + SOGHEDAT + "', NGAYDAT=N'" + NGAYDAT.ToString("MM/dd/ yyyy") + "', GIATIEN=N'" + GIATIEN + "' WHERE MAPHIEU=N'" + MAPHIEU + "'";
            return cn.ExecuteNonQuery(sql);
        }
        public int Delete(string MAPHIEU)
        {
            string sql = "DELETE FROM DATCHO WHERE [MAPHIEU]=N'" + MAPHIEU + "'";
            return cn.ExecuteNonQuery(sql);
        }
        //Cập nhật
        private void CapNhat_Click(object sender, EventArgs e)
        {
            BatLoiDatCho dc = new BatLoiDatCho(txtGiaTien.Text, txtThanhTien.Text, txtMaPhieu.Text, cbMaHanhKhach.Text);
            bool VeConCho = KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
            DateTime date1 = NgayDat.Value;
            DateTime date2 = DateTime.Now.AddDays(-1);
            DateTime date3 = KiemTraGio(cbMaChuyenBay.Text);
            DateTime date4 = date1.AddDays(-1);
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Không để trống mã phiếu");
            }
            else if (txtSoGheDat.Text == "" || txtSoGheDat.Text == "0" || int.Parse(txtSoGheDat.Text) > 1)
            {
                MessageBox.Show("Số ghế không được để trống hoặc bằng 0 hoặc lớn hơn 1");
            }
            else if (txtThanhTien.Text == "" || txtThanhTien.Text == "0")
            {
                MessageBox.Show("Thành tiền không được để trống hoặc bằng 0");
            }
            else if (date1 < date2)
            {
                MessageBox.Show("Ngày không hợp lệ");
            }
            else if (date1 > date3)
            {
                MessageBox.Show("Không thể cập nhật do đã quá ngày bay");

            }
            else if (date1 == date3)
            {
                MessageBox.Show("Không thể cập nhật do đã là ngày bay");
            }
            else
            {

                if (dc.KiemTraMaPhieu() == false) { MessageBox.Show("Vui lòng nhập mã phiếu theo bảng Quy Định Đặt Chỗ"); }
                else
                {

                    if (UPDATE(txtMaPhieu.Text, cbMaHanhKhach.Text, cbMaChuyenBay.Text, txtMaTuyenBay.Text, cbHangVe.SelectedValue.ToString(), int.Parse(txtSoGheDat.Text), NgayDat.Value, txtThanhTien.Text) != -1)
                    {
                        MessageBox.Show("Đã cập nhật phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DatChoTbl_Load(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Mã phiếu hoặc mã khách bị trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
        }
        //Xóa
        private void Xoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text != "")
            {

                if (MessageBox.Show("Bạn muốn xóa phiếu: " + txtMaPhieu.Text, "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Delete(txtMaPhieu.Text) != -1)
                    {
                        MessageBox.Show("Đã xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DatChoTbl_Load(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không để trống mã phiếu");
            }
            KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
        }
        //Thêm
        private void Them_Click(object sender, EventArgs e)
        {
            bool VeConCho = KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
            DateTime date1 = NgayDat.Value;
            DateTime date2 = DateTime.Now.AddDays(-1);
            DateTime date3 = KiemTraGio(cbMaChuyenBay.Text);
            if (VeConCho)
            {
                if (txtMaPhieu.Text == "")
                {
                    MessageBox.Show("Không để trống mã phiếu");
                }
                else if (txtSoGheDat.Text == "" || txtSoGheDat.Text == "0" || int.Parse(txtSoGheDat.Text) > 1)
                {
                    MessageBox.Show("Số ghế không được để trống hoặc bằng 0 hoặc lớn hơn 1");
                }
                else if (txtThanhTien.Text == "" || txtThanhTien.Text == "0")
                {
                    MessageBox.Show("Thành tiền không được để trống hoặc bằng 0");
                }
                else if (date1 < date2)
                {
                    MessageBox.Show("Ngày không hợp lệ");
                }
                else if (date1>date3)
                {
                    MessageBox.Show("Mã chuyến bay đã quá hạn");
                  
                }
                else if(date1 == date3)
                {
                    MessageBox.Show("Không thể đặt vì đã trùng ngày bay");
                }
                else
                {
                    BatLoiDatCho dc = new BatLoiDatCho(txtGiaTien.Text, txtThanhTien.Text, txtMaPhieu.Text, cbMaHanhKhach.Text);
                    if (dc.KiemTraMaPhieu() == false) { MessageBox.Show("Vui lòng nhập mã phiếu đúng theo bảng Quy Định Đặt Chỗ"); }
                    else
                    {

                        if (INSERT(txtMaPhieu.Text, cbMaHanhKhach.Text, cbMaChuyenBay.Text, txtMaTuyenBay.Text, cbHangVe.SelectedValue.ToString(), int.Parse(txtSoGheDat.Text), NgayDat.Value, txtThanhTien.Text) != -1)
                        {
                            MessageBox.Show("Đã thêm phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DatChoTbl_Load(new object(), new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("Mã phiếu hoặc mã khách bị trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Vé đã bán hết");
            }
            KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
        }

      
        //Qui định đặt chỗ
        private void QuyDinhDC_Click(object sender, EventArgs e)
        {
            QuyDinhDatCho n = new QuyDinhDatCho();
            n.Show();
        }
        //Phím tắt
        private void DatChoTbl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                TroVe.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                dataGridView1.DataSource = cn.ExecuteData("select * from DATCHO");
            }
        }

        private void cbHangVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHangVe.Text == "Vé hạng 1")
            {
                txtGiaTien.Text = "3000000";
            }
            else
            {
                txtGiaTien.Text = "1000000";
            }
            bool VeConCho = KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
            ThanhTien();
        }

        private void txtSoGheDat_TextChanged(object sender, EventArgs e)
        {
            ThanhTien();
        }

        private void cbMaHanhKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThanhTien();
        }
        // GIÁ TIỀN
        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtGiaTien.Text, System.Globalization.NumberStyles.AllowThousands);
            txtGiaTien.Text = String.Format(culture, "{0:N0}", value);
            txtGiaTien.Select(txtGiaTien.Text.Length, 0);
        }
        // THÀNH TIỀN
        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(txtThanhTien.Text, System.Globalization.NumberStyles.AllowThousands);
            txtThanhTien.Text = String.Format(culture, "{0:N0}", value);
            txtThanhTien.Select(txtThanhTien.Text.Length, 0);
        }

        private void cbMaChuyenBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select MATUYENBAY from CHUYENBAY where MACHUYENBAY='" + cbMaChuyenBay.Text + "'";
            string sql2 = "select MAHANGVE,MACHUYENBAY from DATCHO where MACHUYENBAY='" + cbMaChuyenBay.Text + "'";
            string HangVe;
            DataTable dt = cn.ExecuteData(sql);
            DataTable dt2 = cn.ExecuteData(sql2);
            if (dt.Rows.Count > 0)
            {
                txtMaTuyenBay.Text = dt.Rows[0][0].ToString();
                if (dt2.Rows.Count > 0)
                {
                    cbMaChuyenBay.Text = dt2.Rows[0][1].ToString();
                    if (dt2.Rows[0][0].ToString() == "1")
                    {
                        HangVe = "1";
                    }
                    else
                    {
                        HangVe = "2";
                    }
                    KiemTraVe(cbMaChuyenBay.Text, HangVe.ToString());
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaPhieu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbMaHanhKhach.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbMaChuyenBay.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMaTuyenBay.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "1")
            {
                cbHangVe.Text = "Vé hạng 1";
            }
            else
            {
                cbHangVe.Text = "Vé hạng 2";
            }
            txtSoGheDat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            NgayDat.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtThanhTien.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            bool VeConCho = KiemTraVe(cbMaChuyenBay.Text, cbHangVe.SelectedValue.ToString());
            ThanhTien();
        }

        private void TiemKiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from DATCHO WHERE MAPHIEU =N'"+txtMaPhieu.Text+"' AND MAKH=N'"+cbMaHanhKhach.Text+"'";
            string sql1 = "select * from DATCHO WHERE MAKH=N'" + cbMaHanhKhach.Text + "'";
            string sql2 = "select * from DATCHO WHERE MAPHIEU =N'" + txtMaPhieu.Text + "'";
            if (txtMaPhieu.Text == "")
            {
                dataGridView1.DataSource = cn.ExecuteData(sql1);
            }
            else if (cbMaHanhKhach.Text == "")
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
