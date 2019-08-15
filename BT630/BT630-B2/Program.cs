using System;
using System.Collections.Generic;
namespace BT630_B2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so N");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Cac so trong day Fibonaci nho hon so nay la :");
            for(int n = 0; Fibo(n - 1) + Fibo(n - 2) < a; n++)
            {
                Fibo(n);
            }

            foreach(var fibo in listFibo)
            {
                Console.WriteLine(fibo.Value);
            }
        }

        
        static int Fibo(int n)
        {
            if (listFibo.ContainsKey(n))
            {
                return listFibo[n];
            }
            if(n <= 1)
            {
                return n;
            }
            else
            {
                int newFibo = Fibo(n - 1) + Fibo(n - 2);
                listFibo.Add(n, newFibo);
                return newFibo;
            }
        }
        static Dictionary<int, int> listFibo = new Dictionary<int, int>();
    }
}
