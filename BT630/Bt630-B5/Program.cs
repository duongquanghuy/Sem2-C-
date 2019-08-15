using System;

namespace BT630_B5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so N :");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Cac so nguyen to nho hon N la :");

            for(int i = 0; i < n; i++){
                if (soNguyenTo(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static Boolean soNguyenTo(int n)
        {
            int count = 0;
            if(n <= 1)
            {
                return false;
            }
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }
            if(count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
