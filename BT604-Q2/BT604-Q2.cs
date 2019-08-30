using System;
using System.Collections.Generic;

namespace BT604_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            HiredProgrammer myemployee = new HiredProgrammer(7);

            Console.WriteLine("Input 3 new Programmers: ");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input Programmer " + (i + 1) + ": ");

                Programmer pr = new Programmer();

                pr.AddInfo();

                myemployee.AddNew(pr);
            }

            Console.Write("Input Under Age Restrict Value: ");
            int count = myemployee.ShowFilterInfo(int.Parse(Console.ReadLine()));
            Console.WriteLine("Finded " + count + " result(s)");
        }
    }

    class Programmer
    {
        int _age;
        public int Age { get => _age; set => _age = value; }

        string _name;
        public string Name { get => _name; set => _name = value; }

        public void ShowInfo()
        {
            Console.WriteLine("Name: " + _name + " - Age: " + _age);
        }

        public void AddInfo()
        {
            Console.Write("Input Name: ");
            _name = Console.ReadLine();
            Console.Write("Input Age: ");
            _age = int.Parse(Console.ReadLine());
        }
    }

    class HiredProgrammer
    {
        List<Programmer> HPGM = new List<Programmer>();

        public HiredProgrammer(int n)
        {
            HPGM.Capacity = n;
        }

        public void AddNew(Programmer prog)
        {
            if (HPGM.Count == HPGM.Capacity)
            {
                Console.WriteLine("Out of Capacity!!!");
            }
            else
            {
                HPGM.Add(prog);
            }
        }

        public int ShowFilterInfo(int underAge)
        {
            int count = 0;

            foreach (Programmer pr in HPGM)
            {
                if (pr.Age <= underAge)
                {
                    pr.ShowInfo();
                    count++;
                }
            }

            return count;
        }
    }
}
