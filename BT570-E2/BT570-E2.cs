using System;

namespace BT570_E2
{
    public delegate Boolean PrimeNumberFinder(int n);

    class Program
    {
        public static event PrimeNumberFinder OnPrimeNumber;

        static void Main(string[] args)
        {
            PrimeNumberFinder snt = CheckPrimeNumber;

            OnPrimeNumber = snt;

            Console.WriteLine("Print Number from 1 to 10: ");

            for (int i = 1; i <= 10; i++)
            {
                if (OnPrimeNumber(i))
                {
                    Console.WriteLine(i + " is Prime Number!!!");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static Boolean CheckPrimeNumber(int m)
        {
            int count = 0;

            if (m < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(m); i++)
            {
                if (m % i == 0)
                {
                    count++;
                }
            }
            if (count != 0)
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
