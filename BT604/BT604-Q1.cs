using System;
using System.Text;

namespace BT604
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Programmer ltv = new Programmer(1, "Nguyễn Văn A", "Good Communation, Expert in JAVA", Convert.ToDateTime("28/08/1995"));
            ltv.ShowInfo();
        }
    }

    interface IPerson
    {
        string Skills { get; set; }
        DateTime DateOfBirth { get; }
        int Age { get; }
    }

    abstract class Employee {
        int _id;
        string _name;

        public int ID { get => _id;}
        public string Name {
            get => _name;
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Wrong Input!!! Please Try again!!!");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public Employee(int ID)
        {
            _id = ID;
            _name = "No Name";
        }

        public Employee(int ID, string name)
        {
            _id= ID;
            _name = name;
        }

        public Employee()
        {

        }

        public abstract void ShowInfo();
    }

    class Programmer : Employee, IPerson
    {
        string _skills;
        DateTime _DOB;
        int _age;

        public String Skills
        {
            get
            {
                return this._skills;
            }
            set
            {
                if (value.Equals(""))
                {
                    Console.WriteLine("Wrong Input!!! Please Try again!!!");
                }
                else
                {
                    this._skills = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this._DOB;
            }
            set
            {
                this._DOB = value;
            }
        }

        public int Age
        {
            get
            {
                return (new DateTime(1, 1, 1) + (DateTime.Now - DateOfBirth)).Year - 1;
            }
        }

        public Programmer(int id, string name)
        {
            _skills = String.Empty;
            _DOB = DateTime.Now;
        }

        public Programmer(int id, string name, string skills, DateTime dob) : base(id, name)
        {
            _skills = skills;
            _DOB = dob;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Id: {0} | Name: {1} | Skills: {2} | DOB: {3} | Age: {4}", ID, Name, Skills, DateOfBirth.ToString("dd/MM/yyyy"), Age);
        }
    }
}
