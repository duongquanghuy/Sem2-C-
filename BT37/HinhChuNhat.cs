using System;
using System.Collections.Generic;
using System.Text;
using HCNPackage;
using static HCNPackage.Area;

namespace BT37
{
    class HinhChuNhat : HCNinterface
    {
        int chieuDai;
        int chieuRong;
        int DienTich;
        Boolean kiemtra = false;
        public int DienTichHCN()

        {
         
          return DienTich =  ( chieuDai * chieuRong );
            
        }
        public void Display()
        {
            Console.WriteLine("dien tiach hcn la : " + DienTich);

        }
        public int getChieuDai()
        {
            Console.WriteLine("nhap chieu dai");
            while (true)
            {
                
                chieuDai = int.Parse(Console.ReadLine());
                if (chieuDai > 0)
                {
                    
                    kiemtra = true;
                    return chieuDai;
                }
            }
          
        }

        public int getChieuRong()

        {
           
            while (true)
            {
                Console.WriteLine("nhap chieu rong :");
                chieuRong = int.Parse(Console.ReadLine());
              if (chieuRong < chieuDai)
                {
                    kiemtra = true;
                    return chieuRong;
                }
            }
        
            
        }

     

        public void setChieuRong(int cd, int cr)
        {
            chieuDai = cd;
            chieuRong = cr;
        }
    }
}
