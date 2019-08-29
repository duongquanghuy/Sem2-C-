using System;
using System.Collections.Generic;
using System.Text;

namespace BT555
{
    class People : IInfor
    {
        public string Name { get; set; }
        public int Age { get ; set ; }
        public string Adress { get; set; }

        public People() { }
        public People(string name , int age , string adress)
        {
            this.Name = name;
            this.Age = age;
            this.Adress = adress;
        }
        public override void Showinfor()
        {
            Console.WriteLine("name : {0} , tuoi : {1} , dia chi : {2} ", Name, Age, Adress);
        }
        public void Input()
        {
            Console.WriteLine("nhap ten");
            Name = Console.ReadLine();
            Console.WriteLine("nhap tuoi : ");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("nhap dia chi");
            Adress = Console.ReadLine();
        }
    }
}
