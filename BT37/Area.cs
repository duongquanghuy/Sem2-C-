using System;
using System.Collections.Generic;
using System.Text;

namespace HCNPackage
{
    class Area
    {
        public interface HCNinterface
        {
            int DienTichHCN();
            int getChieuDai();
            int getChieuRong();
            void setChieuRong(int cd , int cr);
        }
    }
}
