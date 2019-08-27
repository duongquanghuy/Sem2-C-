using System;

namespace BT37
{
    class Program
    {
        static void Main(string[] args)
        {
            HinhChuNhat cn = new HinhChuNhat();
            cn.getChieuDai();
            cn.getChieuRong();
            cn.DienTichHCN();
         
            cn.Display();
        }
    }
}
