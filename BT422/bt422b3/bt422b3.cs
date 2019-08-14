using System;

namespace bt422b3
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number;
            int c = 1;
            float avg = 0;

            while (c <= 3)
            {
                Console.WriteLine("Input a number: ");
                number = int.Parse(Console.ReadLine());
                sum += number;
                c++;
            }
            avg = sum / 3;
            Console.WriteLine("Sum is: {0}; Avg is: {1}", sum, avg);
        }
    }
}