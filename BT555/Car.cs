using System;
using System.Collections.Generic;
using System.Text;

namespace BT555
{
    class Car : IInfor
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public Car() { }

        public Car(string name , string color)
        {
            this.Name = name;
            this.Color = color;
        }
        public override void Showinfor()
        {
            Console.WriteLine("ten : {0} , mau sac : {1}", Name, Color);
        }
        public void Input()
        {
            Console.WriteLine("nhap ten xe ");
            Name = Console.ReadLine();
            Console.WriteLine("nhap mau xe :");
            Color = Console.ReadLine();
        }
    }
}
