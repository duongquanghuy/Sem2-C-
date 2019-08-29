using System;
using System.Collections.Generic;

namespace BT555
{
    class Program
    {
        static List<IInfor> a = new List<IInfor>();
        static void Main(string[] args)
        {
            People people = new People();
            Car car = new Car();

            people.Input();
            a.Add(people);
            car.Input();
            a.Add(car);

            ShowInfor(a);
        }
        public static void ShowInfor(List<IInfor> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                a[i].Showinfor();
            }
        }
    }
}
