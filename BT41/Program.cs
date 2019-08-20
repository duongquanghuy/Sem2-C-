using System;
using System.Collections.Generic;

namespace BT41
{
    class Program
    {
        static List<Book> listBook = new List<Book>();
        static List<BookAuthor> listAuthor = new List<BookAuthor>();

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
                        InputBook();
                        break;
                    case 2:
                        DisplayAllBook();
                        break;
                    case 3:
                        InputBookAuthor();
                        break;
                    case 4:
                        SearchAuthorBook();
                        break;
                    case 5:
                        SearchBook();
                        break;
                    case 6:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("nhap ko phu hop ");
                        break;

                }

            } while (choose != 6);
        }

        private static void SearchBook()
        {
            Console.WriteLine("nhap ten sach can tim kiem");
            string search = Console.ReadLine();
            for (int i = 0; i < listBook.Count; i++)
            {
                if (listBook[i].NameBook.Equals(search))
                {
                    listBook[i].DisplaBook();
                }
            }
        }

        private static void SearchAuthorBook()
        {
            Console.WriteLine("nhap but danh can tim : ");
            string searchPseudonym = Console.ReadLine();
            for (int i = 0; i < listBook.Count; i++)
            {
                if (listBook[i].Pseudonym.Equals(searchPseudonym))
                {
                    Console.WriteLine("cuon thu " + (i + 1));
                    listBook[i].DisplaBook();
                }
            }
        }

        private static void InputBookAuthor()
        {
            Console.WriteLine("nhap so tac gia can them : ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n ; i++)
            {
                BookAuthor bookAuthor = new BookAuthor();
                bookAuthor.InputBookAuthor(listAuthor);
                listAuthor.Add(bookAuthor);
            }
        }

        private static void DisplayAllBook()
        {
            foreach (Book book in listBook)
            {
                book.DisplaBook();
            }
        }

        private static void InputBook()
        {
            Console.WriteLine("nhap cuon so sach can them : ");
            int n = int.Parse(Console.ReadLine());
            for (int k = 0; k < n ; k++)
            {
                Book book = new Book();
                book.InputBook(listAuthor);
                


                Boolean timkiem = false;
                // kiem tra xem tac gia da ton tai hay chua 
               
                    for (int j = 0; j < listAuthor.Count; j++)
                    {
                        if (listAuthor[j].Pseudonym.Equals(book.Pseudonym))
                        {
                            timkiem = true;
                            break;
                        }
                    }
                    // chua ton tai tao ms
                    if (!timkiem)
                    {
                       
                        Console.WriteLine("nhap thong tin tac gia ........");
                        BookAuthor author = new BookAuthor();
                        author.InputAuthor();

                        //luu thong ti tac gia
                        listAuthor.Add(author);
                    }

                   
                
                listBook.Add(book);
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("1. nhap thong tin sach");
            Console.WriteLine("2. hien thong tin tat ca sach");
            Console.WriteLine("3. nhap thong tin tac gia");
            Console.WriteLine("4. tim kiem tat ca cac sach dk viet boi tac gia");
            Console.WriteLine("5. tim kiem sach");
            Console.WriteLine("6. thoat" +
                "");

            Console.WriteLine("choose : ");

        }
    }
}
