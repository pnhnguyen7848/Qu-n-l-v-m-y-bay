using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKI1
{
    internal class BatLoiSanBay
    {
        private string IDSB;//mã sân bay
        public BatLoiSanBay()
        {
            this.IDSB = null;
        }
        public BatLoiSanBay(string idsb)
        {
            this.IDSB = idsb;
        }
        public bool KiemTraID()
        {
            bool KiemTraDoDai = false;
            if (IDSB.Length == 3)//Kiểm tra mã sân bay có đủ độ dài
            {
                KiemTraDoDai = true;
            }
            bool KiemTraKyTu = false;
            for (int i = 0; i < IDSB.Length; i++)//kiểm tra số
            {
                if (IDSB[i] >= 'A' && IDSB[i] <= 'Z')
                {
                    KiemTraKyTu = true;
                }
            }
            if (KiemTraDoDai == true && KiemTraKyTu == true)
            {
                return true;
            }
            return false;
        }
    }
}
