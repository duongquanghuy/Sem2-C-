using System;
using System.Collections.Generic;
using BT68_B3;


namespace BT68_B3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n;
            Console.WriteLine("nhap so san pham can theem : ");
            n = int.Parse(Console.ReadLine());

            Product[] list = new Product[n];
            // nhap thong tin san pham
            for (int i = 0; i < list.Length ; i++)
            {
                Console.WriteLine("nhap san pham thu : " + (i + 1));
                 list[i] = new Product();
                 list[i].Input() ;

            }
            //hien thi thong tin nhap vao
            for (int j = 0; j < list.Length; j++)
            {
                Console.WriteLine(list[j]);
            }

            // tim san pham co gia ban cao nhat 
      /*      float max = list[0].Gia1SP;
            for (int i = 0; i < list.Length; i++)
            {
                if(list[i].Gia1SP > max)
                {
                    Console.WriteLine(" gia san pham cao nhat la : ");
                    list[i].Display();
                }

            }*/

            
            Array.Sort(list, delegate (Product prod1, Product prod2) {
                return prod1.Gia1SP.CompareTo(prod2.Gia1SP);
            });
            Console.WriteLine("gia san pham cao nhat la ");
            list[list.Length - 1].Display();
            
        
        }
    }
}
