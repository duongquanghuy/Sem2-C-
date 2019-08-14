using System;

namespace bt423b1
{
    class bt423b1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GIAI PHUONG TRINH BAC NHAT ax + b = 0");

            int a, b;
            float x;

            Console.WriteLine("- Nhap a: ");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("- Nhap b: ");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("Phuong trinh co dang {0}x + {1} = 0\n", a, b);

            if ((a == 0) && (b == 0))
            {
                Console.WriteLine("Phuong trinh co vo so nghiem");
            }
            else if ((b == 0) && (a != 0))
            {
                Console.WriteLine("Phuong trinh co nghiem x = 0");
            }
            else if ((b != 0) && (a == 0))
            {
                Console.WriteLine("Phuong trinh khong ton tai");
            }
            else if ((a != 0) && (b != 0))
            {
                x = (-b) / a;
                Console.WriteLine("Phuong trinh co 1 nghiem duy nhat: " + x);
            }
        }
    }
}
