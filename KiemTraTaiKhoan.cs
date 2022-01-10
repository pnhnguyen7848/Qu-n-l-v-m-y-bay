using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKI1
{

    internal class KiemTraTaiKhoan
    {
        private string TaiKhoan;
        private string MatKhau;
        public KiemTraTaiKhoan()
        {
            this.TaiKhoan = null;
            this.MatKhau = null;
        }
        public KiemTraTaiKhoan(string tk, string mk)
        {
            this.TaiKhoan = tk;
            this.MatKhau = mk;
        }
        public bool KiemTraMatKhau()
        {
            bool KiemTraDoDai = false;
            if (MatKhau.Length >= 8)//Kiểm tra id có đủ độ dài
            {
                KiemTraDoDai = true;
            }
            bool KiemTraKyTu = false;
            bool KiemTraSo = false;
            bool KiemTraChu = false;

            for (int i = 0; i < MatKhau.Length; i++)//kiểm tra số
            {
                if (KiemTraKyTu == true && KiemTraSo == true && KiemTraChu == true)
                {
                    break;
                }
                if (MatKhau[i] >= '0' && MatKhau[i] <= '9')
                {
                    KiemTraSo = true;
                }
                if (MatKhau[i] >= 'A' && MatKhau[i] <= 'Z' || MatKhau[i] >= 'a' && MatKhau[i] <= 'z')
                {
                    KiemTraChu = true;
                }
                if (MatKhau[i]>=33 && MatKhau[i]<=47|| MatKhau[i] >= 58 && MatKhau[i] <= 64|| MatKhau[i] >= 91 && MatKhau[i] <= 96|| MatKhau[i] >= 123 && MatKhau[i] <= 126)
                {
                    KiemTraKyTu = true;
                }
            }
            if (KiemTraDoDai == true && KiemTraKyTu == true && KiemTraSo == true && KiemTraChu == true)
            {
                return true;
            }
            return false;
        }
    }
}
