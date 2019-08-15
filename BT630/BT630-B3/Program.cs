using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BT630_B3
{
    class Program
    {
        static void Main(string[] args)
        {
            Student std = new Student();
            std.inputInfo();
            std.showInfo();
            XmlSerializer xsStudent = new XmlSerializer(typeof(Student));

            XmlSerializer x = new XmlSerializer(std.GetType());
            x.Serialize(Console.Out, std);
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class Student
    {
        private String name;
        private int id;
        private int age;
        private String address;

        public string Address { get => address; set => address = value; }
        public int Age { get => age; set => age = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public void inputInfo()
        {
            Console.Write("Nhap vao ten :");
            name = Console.ReadLine();
            Console.WriteLine("Nhap vao ma sinh vien");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao tuoi :");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao dia chi :");
            address = Console.ReadLine();
        }

        public void showInfo()
        {
            Console.WriteLine("Ten :" + name);
            Console.WriteLine("ID :" + id);
            Console.WriteLine("Tuoi :" + age);
            Console.WriteLine("Dia chi :" + address);
        }
    }
}
