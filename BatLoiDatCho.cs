using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKI1
{
    internal class BatLoiDatCho
    {
        private string GIATIEN;
        private string THANHTIEN;
        private string MAPHIEU;
        private string MAKH;
        public BatLoiDatCho()
        {
            this.GIATIEN = null;
            this.THANHTIEN = null;
            this.MAPHIEU = null;
            this.MAKH = null;
        }
        public BatLoiDatCho(string giatien, string thanhtien, string maphieu,string makh)
        {
            this.GIATIEN = giatien;
            this.THANHTIEN = thanhtien;
            this.MAPHIEU = maphieu;
            this.MAKH = makh;
        }
        public bool KiemTraMaPhieu()
        {
            string str1 = "VB";
            bool KiemTraDoDai = false;
            if (MAPHIEU.Length == 8)//Kiểm tra mã phiếu có đủ độ dài
            {
                KiemTraDoDai = true;
            }
            bool KiemTraKyTu = false;
            bool KiemTraSo = false;

            if (MAPHIEU.StartsWith(str1))//Kiểm tra Ký tự trong mã phiếu
            {
                KiemTraKyTu = true;
            }
            for (int i = 2; i < MAPHIEU.Length; i++)//kiểm tra số
            {
                if (MAPHIEU[i] >= '0' && MAPHIEU[i] <= '9')
                {
                    KiemTraSo = true;
                }
                else
                {
                    KiemTraSo = false;
                    break;
                }
            }
            if (KiemTraDoDai == true && KiemTraKyTu == true && KiemTraSo == true)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraGiaTien()
        {
            if(GIATIEN.Length < 6)
            {
                return false;
            }
            if (GIATIEN[0] == '0')
            {
                return false;
            }
            //kiểm tra giá trị cuối có khác 0 để đảm bảo thành tiền không là số thập phân 
            if(GIATIEN[GIATIEN.Length-1] != '0')
            {
                return false;
            }
            for (int i = 1; i < GIATIEN.Length-2; i++)
            {
                if (GIATIEN[i] < '0' || GIATIEN[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        //kiểm tra khách vip
        public bool KiemTraKhach()
        {
            string str1 = "VIP";
            bool KiemTraKhachVip=false;
            if (MAKH.StartsWith(str1))//Kiểm tra Ký tự trong mã phiếu
            {
                KiemTraKhachVip = true;
            }
            if (KiemTraKhachVip == true)//Nếu true là khách vip
            {
                return true;
            }
            return false;
        }
    }
}
