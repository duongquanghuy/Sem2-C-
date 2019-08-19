using System;
using System.Collections.Generic;
using System.Text;

namespace BT68
{
    class Employee
    {
        public string FullName { get; set; }
        public string Sex{ get; set; }
        public string Adress { get; set; }
        public string ChucVu { get; set; }
        public string Luong { get; set ; }

        public Employee() { }

        public Employee(string fullName, string sex , string adress , string chucVu , string luong) {
            FullName = fullName;
            Sex = sex;
            Adress = adress;
            ChucVu = chucVu;
            Luong = luong;
        }
        public void Input()
        {
            Console.WriteLine("nhap ho ten");
            FullName = Console.ReadLine();
            Console.WriteLine("nhap gioi tinh");
            Sex = Console.ReadLine();
            Console.WriteLine("nhap que quan");
            Adress = Console.ReadLine();
            Console.WriteLine("nhap chuc vu");
            ChucVu = Console.ReadLine();
            Console.WriteLine("nhap luong");
            Luong = Console.ReadLine();
        }
        public void Display()
        {
            Console.WriteLine("ho ten : {0} , gioi tinh : {1} , que quan : {2} , chuc vu : {3} , luong : {4}"
                , FullName, Sex, Adress, ChucVu, Luong);

        }
         

    }
}
