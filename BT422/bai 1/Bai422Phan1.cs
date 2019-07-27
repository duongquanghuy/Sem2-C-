using System;

namespace DuongQuangHUY
{
    class Program
    {
        static void Main(string[] args)
        {
            int yrsofService = 3;
            int salary = 1500;
            int bonus = 0;

            if (yrsofService < 5)
            {
                if (salary < 500)
                {
                    bonus = 100;
                    Console.WriteLine("bonus  :{0} ", bonus);
                }
                else
                {
                    bonus = 200;
                    Console.WriteLine("bonus  :{0} ", bonus);
                }


            }
            else
            {
                bonus = 500;
                Console.WriteLine("bonus :{0} ", bonus);

            }
        }
    }
}
