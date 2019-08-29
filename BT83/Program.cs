using System;
using System.Collections.Generic;



namespace BT83
{
    class Program
    {
        static List<AptechBook> listBook = new List<AptechBook>();
        static void Main(string[] args)
        {
            int choose;
            
            do
            {
                ShowMenu();
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        int M;
                        Console.WriteLine("nhap so cuon sach muon them :");
                        M = int.Parse(Console.ReadLine());
                        int count = 0;
                       while(count < M)
                        { 

                            AptechBook ap = new AptechBook();
                            ap.InputBook();
                            listBook.Add(ap);
                            count++;
                        }
                        break;
                    case 2:
                        DisPlayBook();
                        break;
                    case 3:
                        SortYearPublishing();
                        break;
                    case 4:
                        SearchNameBook();
                        break;
                    case 5:
                        SearchBookAuthor();
                        break;
                    case 6:
                        // doc toan bo file txt
                        string content = System.IO.File.ReadAllText("book.txt");
                        Console.WriteLine(content);
                        // sever vao file book.txt
                        for (int i = 0; i < listBook.Count; i++)
                        {
                            System.IO.File.AppendAllText("book.txt", listBook[i].ToString() + " " );

                        }
                       
                        break;
                    case 7:
                        //read  data
                        string[] lines = System.IO.File.ReadAllLines("book.txt");
                        foreach (string line in lines)
                        {
                            if (line == null || line == "")
                            {
                                continue;
                            }
                             string[] elements = line.Split(new char[] { ',' });
                           
                            if (elements.Length == 7)
                            {
                                AptechBook ap = new AptechBook(elements[0] ,elements[1] ,elements[2] ,int.Parse(elements[3]) ,int.Parse(elements[4]) , elements[5] ,int.Parse(elements[6]) );
                                listBook.Add(ap);


                            }
                        }
                        foreach  (AptechBook ap in listBook)
                        {
                            Console.WriteLine(ap.ToString());
                        }
                            break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("chon ko phu hop :");
                        break;

                }

            } while (choose != 8);
         
        }
      
        private static void SearchBookAuthor()
        {
            Console.WriteLine("nahp ten tac gia can tim kiem");
            string timkiem = Console.ReadLine();
            foreach  (AptechBook ap in listBook)
            {
                if (ap.BookAuthor.Equals(timkiem))
                {
                    ap.DisplayBook();
                }
            }
        }

        private static void SearchNameBook()
        {
            Console.WriteLine("nhap ten sach muon tim kiem ");
            string timkiem = Console.ReadLine();
            foreach (AptechBook ap in listBook)
            {
                if (ap.BookName.Equals(timkiem))
                {
                    ap.DisplayBook();
                }
            }
        }

        private static void SortYearPublishing()
        {
            listBook.Sort(delegate (AptechBook ap1, AptechBook ap2) {
                return ap2.YearPublishing.CompareTo(ap1.YearPublishing);

            });
        }

        private static void DisPlayBook()
        {
            foreach (AptechBook ap in listBook)
            {
                ap.DisplayBook();
            }
        }

        // nhap thong tin n cuon sach


        public static void ShowMenu()
        {

            Console.WriteLine("1. nhap thong tin n cuon sach ");
            Console.WriteLine("2. hien thi thong tin vua nhap ");
            Console.WriteLine("3. sap xep thong tin giam dan thoe nam xuat ban ");
            Console.WriteLine("4 .tim kiem thoe ten sach ");
            Console.WriteLine("5. tim kiem thoe ten tac gia ");
            Console.WriteLine("6. luu thong tin da nhap vao file ");
            Console.WriteLine("7. doc noi dung vao file va luu vao mang quan ly sinh vien ");
            Console.WriteLine("8. thoat ");
            Console.WriteLine(" choose :");
        }
    }
}
