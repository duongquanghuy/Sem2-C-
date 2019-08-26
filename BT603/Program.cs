using System;
using System.Collections.Generic;

namespace BT603
{
    class Program
    {
        public static event Student.PrintInfoStudentHandler EventPrintInfoStudent;
        public static List<Student> listStudent = new List<Student>();
        public static List<Parent> listParent = new List<Parent>();

        static void Main(string[] args)
        {
            
            int choose;
            do
            {
                showMenu();
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine(">> Nhap thong tin N phu huynh <<");
                        Console.WriteLine("Nhap vao so luong phu huynh ");
                        int amuontParent = int.Parse(Console.ReadLine());
                        for (int i = 0; i < amuontParent; i++)
                        {
                            Parent parent = new Parent();
                            parent.inputParentInfo();
                            listParent.Add(parent);
                        }
                        break;
                    case 2:
                        Console.WriteLine(">> Nhap thong tin M sinh vien <<");
                        Console.WriteLine("Nhap vao so luong sinh vien ");
                        int amuontStudent = int.Parse(Console.ReadLine());
                        for (int i = 0; i < amuontStudent; i++)
                        {
                            Student student = new Student();
                            student.inputStudentInfo();
                            listStudent.Add(student);
                        }
                        break;
                    case 3:
                        Console.WriteLine(">> Tra cuu thong tin sinh vien theo ten phu huynh <<");
                        if (listStudent.Count == 0)
                        {
                            Console.WriteLine("Chua co thong tin hoc sinh nao");
                        }
                        if (listParent.Count == 0)
                        {
                            Console.WriteLine("Chua co thong tin phu huynh nao");
                        }
                        else
                        {
                            int count1 = 0;
                            Console.WriteLine("Nhap vao ten phu huynh : ");
                            String nameParentSearch = Console.ReadLine();
                            for (int i = 0; i < listParent.Count; i++)
                            {
                                if (listParent[i].NameParent.Equals(nameParentSearch))
                                {
                                    for(int j = 0; j < listStudent.Count; j++)
                                    {
                                        if (listParent[i].IdParent.Equals(listStudent[j].ParentsId))
                                        {
                                            listStudent[j].showStudentInfo();
                                            count1++;
                                            Console.WriteLine("----------------------------");
                                        }
                                    }
                                }
                                if(count1 == 0)
                                {
                                    Console.WriteLine("Khong co hoc sinh nao lien quan den phu huynh nay, hay kiem tra lai thong tin");
                                }
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine(">> Tra cuu thong tin phu huynh theo ten hoc sinh <<");
                        if (listStudent.Count == 0)
                        {
                            Console.WriteLine("Chua co thong tin hoc sinh nao");
                        }
                        if (listParent.Count == 0)
                        {
                            Console.WriteLine("Chua co thong tin phu huynh nao");
                        }
                        else
                        {
                            int count2 = 0;
                            Console.WriteLine("Nhap vao ten sinh vien : ");
                            String nameStudentSearch = Console.ReadLine();
                            for (int i = 0; i < listStudent.Count; i++)
                            {
                                if (listStudent[i].StudentName.Equals(nameStudentSearch))
                                {
                                    for (int j = 0; j < listParent.Count; j++)
                                    {
                                        if (listParent[j].IdParent.Equals(listStudent[i].ParentsId))
                                        {
                                            listParent[j].showParentInfo();
                                            Console.WriteLine("----------------------------");
                                            count2++;
                                        }
                                    }
                                }
                            }
                            if(count2 == 0)
                            {
                                Console.WriteLine("Khong co phu huynh nao lien quan den hoc sinhs nay, hay kiem tra lai thong tin");
                            }
                        } 
                        break;
                    case 5:
                        Console.WriteLine(" >> Thuc hien in thong tin sinh vien theo dia chi nhap vao <<");
                        Student.PrintInfoStudentHandler printInfoStudentByAddress
                                    = HandlingSearchAndPrintInfoStudent;
                        EventPrintInfoStudent += printInfoStudentByAddress;
                        EventPrintInfoStudent();
                        break;
                    case 6:
                        Console.WriteLine(" >>Thoat chuong trinh, Bye Bye <<");
                        break;
                }

            } while (choose != 6);
        }

        static void HandlingSearchAndPrintInfoStudent()
        {
            Console.WriteLine("Nhap vao dia chi can tim : ");
            String addressSearch = Console.ReadLine();
            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].StudentAddress.Equals(addressSearch))
                {
                    listStudent[i].showStudentInfo();
                    Console.WriteLine("----------------------------");
                }
            }
        }
        static void showMenu()
        {
            Console.WriteLine(">> Menu <<");
            Console.WriteLine("1. Nhap thong tin N phu huynh");
            Console.WriteLine("2. Nhap thong tin M sinh vien");
            Console.WriteLine("3. Tra cuu thong tin sinh vien theo ten phu huynh");
            Console.WriteLine("4. Tra cuu thong tin phu huynh theo ten hoc sinh");
            Console.WriteLine("5. In thong tin theo dia chi nhap vao");
            Console.WriteLine("6. Thoat");
        }
    }

    public class Student
    {
        public delegate void PrintInfoStudentHandler();
        String studentName;
        int studentAge;
        String studentId;
        String studentAddress;
        String studentEmail;
        String parentsId;

        public string StudentName { get => studentName; set => studentName = value; }
        public int StudentAge { get => studentAge; set => studentAge = value; }
        public String StudentId { get => studentId; set => studentId = value; }
        public string StudentAddress { get => studentAddress; set => studentAddress = value; }
        public string StudentEmail { get => studentEmail; set => studentEmail = value; }
        public string ParentsId { get => parentsId; set => parentsId = value; }
        public Student(string studentName, int studentAge, String studentId, string studentAddress, string studentEmail, string parentsId)
        {
            this.studentName = studentName;
            this.studentAge = studentAge;
            this.studentId = studentId;
            this.studentAddress = studentAddress;
            this.studentEmail = studentEmail;
            this.parentsId = parentsId;
        }
        public Student()
        {
        }

        public void inputStudentInfo()
        {
            Console.WriteLine("Nhap vao ten sinh vien : ");
            studentName = Console.ReadLine();
            Console.WriteLine("Nhap vao tuoi sinh vien : ");
            studentAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao ma sinh vien : ");
            studentId = Console.ReadLine();
            Console.WriteLine("Nhap vao dia chi sinh vien : ");
            studentAddress = Console.ReadLine();
            Console.WriteLine("Nhap vao email sinh vien : ");
            StudentEmail = Console.ReadLine();
            Console.WriteLine("Nhap vao ma phu huynh cua sinh vien : ");
            parentsId = Console.ReadLine();
        }
        public void showStudentInfo()
        {
            Console.WriteLine("Ten : " + studentName);
            Console.WriteLine("Tuoi : " + studentAge);
            Console.WriteLine("Ma sinh vien : " + studentId);
            Console.WriteLine("Dia chi : " + studentAddress);
            Console.WriteLine("Email : " + StudentEmail);
            Console.WriteLine("Ma phu huynh : " + parentsId);
        }
    }

    public class Parent
    {
        String nameParent;
        String addressParent;
        int phoneNumberParent;
        String idParent;

        public string NameParent { get => nameParent; set => nameParent = value; }
        public string AddressParent { get => addressParent; set => addressParent = value; }
        public int PhoneNumberParent { get => phoneNumberParent; set => phoneNumberParent = value; }
        public string IdParent { get => idParent; set => idParent = value; }

        public void inputParentInfo()
        {
            Console.WriteLine("Nhap vao ten phu huynh : ");
            nameParent = Console.ReadLine();
            Console.WriteLine("Nhap vao dia chi phu huynh : ");
            addressParent = Console.ReadLine();
            Console.WriteLine("Nhap vao so dien thoai phu huynh : ");
            phoneNumberParent = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao ma phu huynh : ");
            idParent = Console.ReadLine();
        }
        public void showParentInfo()
        {
            Console.WriteLine("Ten : " + nameParent);
            Console.WriteLine("Dia chi : " + addressParent);
            Console.WriteLine("So dien thoai : " + phoneNumberParent);
            Console.WriteLine("Ma phu huynh : " + idParent);
        }
    }
}
