using System;

namespace room
{
    class program
    {
        static void Main(string[] args)
        {
            Table tb1 = new Table();
            tb1.input();
            tb1.showInfo();
            Table tb2 = new Table("Tb2", "red", "Hong Ha", 10);
            tb2.showInfo();
        }
    }
    public class Table
    {
        private String name;
        private String color;
        private String producter;
        private int daysUsed;

        public string Name { get => name; set => name = value; }
        public string Color { get => color; set => color = value; }
        public string Producter { get => producter; set => producter = value; }
        public int DaysUsed { get => daysUsed; set => daysUsed = value; }

        public Table(string name, string color, string producter, int daysUsed)
        {
            this.name = name;
            this.color = color;
            this.producter = producter;
            this.daysUsed = daysUsed;
        }

        public Table()
        {
        }

        public void input()
        {
            Console.WriteLine("Nhap vao ten :");
            name = Console.ReadLine();
            Console.WriteLine("Nhap vao mau sac :");
            color = Console.ReadLine();
            Console.WriteLine("Nhap vao nha san xuat :");
            producter = Console.ReadLine();
            Console.WriteLine("Nhap vao so ngay da su dung :");
            daysUsed = int.Parse(Console.ReadLine());
        }
        public void showInfo()
        {
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Color : " + color);
            Console.WriteLine("Producter : " + Producter);
            Console.WriteLine("Days used : " + daysUsed);
        }
    }
}
