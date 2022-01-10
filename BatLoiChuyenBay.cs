using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKI1
{
    internal class BatLoiChuyenBay
    {
        private string CB;
        private string SOGHEHANG1;
        private string SOGHEHANG2;
        public BatLoiChuyenBay()
        {
            this.CB = null;
            this.SOGHEHANG1 = null;
            this.SOGHEHANG2 = null;
        }
        public BatLoiChuyenBay(string cb, string soghehang1, string soghehang2)
        {
            this.CB = cb;
            this.SOGHEHANG1 = soghehang1;
            this.SOGHEHANG2 = soghehang2;
        }
        public bool kiemtrachuyenbay()
        {
            string str1 = "VN"; // HẢNG VN "Vietnam Airlines"
            string str2 = "VJ";
            string str3 = "QH";
            bool KiemTraDoDai = false;
            if (CB.Length == 6)//Kiểm tra id có đủ độ dài
            {
                KiemTraDoDai = true;
            }
            bool KiemTraKyTu = false;
            bool KiemTraSo = false;

            if (CB.StartsWith(str1) || CB.StartsWith(str2) || CB.StartsWith(str3))//Kiểm tra Ký tự trong mã khách
            {
                KiemTraKyTu = true;
            }
            for (int i = 2; i < CB.Length; i++)//kiểm tra số
            {
                if (CB[i] >= '0' && CB[i] <= '9')
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
        public bool kiemtrasoghe()
        {
            if (SOGHEHANG1.Length > 2 || SOGHEHANG2.Length > 2)
            {
                return false;
            }
            if (SOGHEHANG1[0] == '0' || SOGHEHANG2[0] == '0')
            {
                return false;
            }
            //kiểm tra giá trị cuối có khác 0 để đảm bảo thành tiền không là số thập phân 
            if (SOGHEHANG1[SOGHEHANG1.Length - 1] != '0' || SOGHEHANG2[SOGHEHANG2.Length - 1] != '0')
            {
                return false;
            }
            return true;
        }
    }

}
