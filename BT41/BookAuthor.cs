using System;
using System.Collections.Generic;
using System.Text;

namespace BT41
{
    class BookAuthor
    {
        public string Name {  get; private set; }
        private int _age;
        public int Age
        {
            get
            {
                return this.Age;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("ko hop le");
                    return;
                }
                this._age= value;
            }
        }
        public string Pseudonym { get ; set; }

        
        public string Birthday { get ; private set; }
        
        public string HomeTown { get; private set; }

        public BookAuthor() { }
        public BookAuthor(String pseudonym)
        {
            Pseudonym = pseudonym;
        }

        public BookAuthor(string name , int age , string pseudonym , string birthday , string homTown)
        {
            Name = name;
            Age = age;
            Pseudonym = pseudonym;
            Birthday = birthday;
            HomeTown = homTown;

        }
        public void InputBookAuthor(List<BookAuthor> listAuthor)
        {
            InputAuthor();
            Console.WriteLine("nhap but danh tac gia :");
            while (true)
            {
                Pseudonym = Console.ReadLine();
                Boolean timKiem = false;
                for (int i = 0; i < listAuthor.Count; i++)
                {
                    if (listAuthor[i].Pseudonym.Equals(Pseudonym)){
                        Console.WriteLine("da trung ten nhap lai");
                        timKiem = true;
                        break;
                    }
                }
                if (!timKiem)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("but danh da ton tai moi  nhap but danh khac : ");
                }


            }


        }
        public void InputAuthor()
        {
            Console.WriteLine("nhap ten tac gia :");
            Name = Console.ReadLine();
            Console.WriteLine(" nhap tuoi tac gia : ");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("nhap ngay sinh Tg : ");
            Birthday = Console.ReadLine();
            Console.WriteLine("nhap que quan :");
            HomeTown = Console.ReadLine();
        }
        public void DisplayBookAuthor()
        {
            Console.WriteLine(" ten : {0} ; tuoi : {1} ; but danh : {2} ; ngay sinh {3} ; quen quan : {4} ",
                Name, Age, Pseudonym, Birthday, HomeTown);
        }

    }
}
