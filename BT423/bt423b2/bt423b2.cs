using System;

namespace bt423b2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, x1, x2, delta, xa;

            Console.WriteLine("This is program to find X in a quadratic equation");
            Console.WriteLine("\nQuadratic equation was browsered in: ax^2 + bx + c = 0");

            Console.WriteLine("\nInsert a: ");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInsert b: ");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInsert c: ");
            c = int.Parse(Console.ReadLine());

            Console.WriteLine("\nYour equation is: {0}x^2 + {1}x + {2} = 0", a, b, c);

            if ((a == 0) && (b == 0))
            {
                Console.WriteLine("\nX can be everynumber.");
            }

            else if ((a == 0) && (b != 0) && (c == 0))
            {
                Console.WriteLine("\nX = 0");
            }

            else if ((a == 0) && (b != 0) && (c != 0))
            {
                xa = (-c) / b;
                Console.WriteLine("\nEquation become a simple equation with X = {0}", xa);
            }

            else if (a != 0)
            {
                delta = b * b - 4 * a * c;

                //now let's check delta

                if (delta < 0)
                {
                    Console.WriteLine("\nEquation has no X");
                }

                else if (delta == 0)
                {
                    Console.WriteLine("\nEquation have dual X");
                    x1 = x2 = (-b) / (2 * a);
                    Console.WriteLine("\nX1 = X2 = {0}", x1);
                }

                else
                {
                    Console.WriteLine("\nEquation have two separate X");
                    x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("\nX1 = {0}", x1);
                    Console.WriteLine("\nX2 = {0}", x2);
                };
            }
        }
    }
}
