using System;

namespace BT68_B3
{
    class Product
    {
        private string MaHH { get ; set; }
        private string TenHH { get ; set; }
        private float SoLuong { get ; set; }
        public float Gia1SP { get ; set; }

        public Product() { }
        public Product(string maHH ,string tenHH , float soLuong ,float gia1SP) {
            MaHH = maHH;    
            TenHH = tenHH;
            SoLuong = soLuong;
            Gia1SP = gia1SP;

        }
        public void Input()
        {
            Console.WriteLine("nhap ma hang hoa");
            MaHH = Console.ReadLine();
            Console.WriteLine("nhap ten hang hoa");
            TenHH = Console.ReadLine();
            Console.WriteLine("nhap so luong hang ");
            SoLuong = float.Parse(Console.ReadLine());
            Console.WriteLine("nhap gia mot san pham ");
            Gia1SP = float.Parse(Console.ReadLine());
        }
        public void Display()
        {
            Console.WriteLine("ma HH : {0} ; ten HH : {1} ; so luong : {2} ; gia 1 SP : {3} ;",
                MaHH, TenHH, SoLuong, Gia1SP);
        }


    }
}
