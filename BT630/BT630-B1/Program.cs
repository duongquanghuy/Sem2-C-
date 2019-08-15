using System;

namespace BT630_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            int i;
            int j;
            Console.WriteLine("nhap N  : ");
            N = int.Parse(Console.ReadLine());

            for (i = 0; i < N; i++)
            {
                for (j = N; j > i; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
