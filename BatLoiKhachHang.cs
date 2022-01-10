using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKI1
{
    internal class BatLoiKhachHang
    {
        private string ID;
        private string CMND;
        private string QuocTich;
        private string PassPort;
        private string SoDienThoai;
        //private string PassPort;
        public BatLoiKhachHang()
        {
            this.ID = null;
            this.CMND = null;
            this.QuocTich = null;
            this.PassPort = null;
            this.SoDienThoai = null;
        }
        public BatLoiKhachHang(string id, string cmnd, string quoctich, string passport, string sodienthoai)
        {
            this.ID = id;
            this.CMND = cmnd;
            this.QuocTich = quoctich;
            this.PassPort = passport;
            this.SoDienThoai = sodienthoai;
        }
        public bool KiemTraID()
        {
            string str1 = "VIP";
            string str2 = "NOR";
            bool KiemTraDoDai = false;
            if (ID.Length == 8)//Kiểm tra id có đủ độ dài
            {
                KiemTraDoDai = true;
            }
            bool KiemTraKyTu = false;
            bool KiemTraSo = false;

            if (ID.StartsWith(str1) || ID.StartsWith(str2))//Kiểm tra Ký tự trong mã khách
            {
                KiemTraKyTu = true;
            }
            for (int i = 3; i < ID.Length; i++)//kiểm tra số
            {
                if (ID[i] >= '0' && ID[i] <= '9')
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
        public bool KiemTraSoDienThoai()
        {
            bool KiemTraSo = true;
            if (SoDienThoai.Length < 10 || SoDienThoai.Length > 10)
            {
                return false;   
            }
            if (SoDienThoai[0] != '0')
            {
                return false;
            }
            for(int i = 1; i < SoDienThoai.Length; i++)
            {
                if (SoDienThoai[i] < '0' && SoDienThoai[i] > '9')
                {
                    KiemTraSo = false;
                }
            }
            if (KiemTraSo == true)
            {
                return true;
            }
            return true;
        }
        public bool KiemTraCMND()
        {
            if(QuocTich=="VIET NAM")
            {
                if (CMND.Length == 12)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
        public bool KiemTraPassPort(){
            bool KiemTraSo = false;
            bool KiemKyTu = false;
            if (QuocTich=="VIET NAM")
            {
                if (PassPort.Length < 8||PassPort.Length > 8)
                {
                    return false;
                }
                if(PassPort[0]>='A' && PassPort[0] <= 'Z')
                {
                    KiemKyTu = true;
                }
                else return false;
                for(int i = 1; i < PassPort.Length; i++)
                {
                    if (PassPort[i] >= '0' && PassPort[i] <= '9')
                    {
                        KiemTraSo = true;
                    }
                    else return false;
                }
                if (KiemKyTu==true&& KiemTraSo==true)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}
