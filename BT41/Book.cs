using System;
using System.Collections.Generic;
using System.Text;

namespace BT41
{
    class Book
    {
        public string NameBook { get; set; }
        public string Date { get; set; }
        public string Pseudonym { get; set; }

        public Book() { }
        public Book(string nameBook , string date , string pseudonym)
        {
            NameBook = nameBook;
            Date = date;
            Pseudonym = pseudonym;
        }

        public void InputBook(List<BookAuthor> listAuthor)
        {
            Console.WriteLine("nhap ten sach :");
             NameBook = Console.ReadLine();
            Console.WriteLine("nhap nam xuat ban :");
            Date = Console.ReadLine();
            Console.WriteLine("nhap but danh :");
            Pseudonym = Console.ReadLine();


        }
        public void DisplaBook()
        {
            Console.WriteLine("ten sach : {0} ; nam xuat ban : {1} ; but danh :{2}", NameBook, Date, Pseudonym);
        }
    }
}
