using System;
using System.Collections.Generic;
using System.Text;

namespace BT68_B2

{
    class StudentMark
    {
        static void Main(string[] args)
        {
            List<StudentMark> studenList = new List<StudentMark>();
            Console.WriteLine("nhap so sinh vien can them");
            int n = int.Parse(Console.ReadLine());
            for(int i =  0;  i < n ; i++)
            {
                Console.WriteLine("nhap sinh vien thu :" + (i + 1));
                StudentMark std = new StudentMark();
                std.Input();
                studenList.Add(std);

            }
            foreach(StudentMark std in studenList)
            {
               
                std.Display();
            }
            int max = studenList[0].Diem;
            for (int j = 0; j < studenList.Count; j++)
            {
                StudentMark std = new StudentMark();
                 
                
                if (studenList[j].Diem > max)
                {
                    Console.WriteLine("sinh cien co diem cao nhat la :");
                    studenList[j].Display();
                }
            }
                
          

        }

        public string Rollnumber { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public string Mon { get; set; }
        public int Diem { get; set; }

        public StudentMark() { }
        public StudentMark(string rollnumber , string hoTen , string lop , string mon , int diem)
        {
            Rollnumber = rollnumber;
            HoTen = hoTen;
            Lop = lop;
            Mon = mon;
            Diem = diem;
        }

        public void Input()
        {
            Console.WriteLine("nhap ma");
            Rollnumber = Console.ReadLine();
            Console.WriteLine("nhap ho ten");
            HoTen = Console.ReadLine();
            Console.WriteLine("nhap lop hoc");
            Lop = Console.ReadLine();
            Console.WriteLine("nhap mon hoc");
            Mon = Console.ReadLine();
            Console.WriteLine("nhap diem thi");
            Diem = int.Parse(Console.ReadLine());
        }
        public void Display()
        {
            Console.WriteLine("ma : {0} ; ho ten : {1} ; lop : {2} ; mon : {3} ; diem : {4}",
                Rollnumber, HoTen, Lop, Mon, Diem);
        }

       
    }
}
