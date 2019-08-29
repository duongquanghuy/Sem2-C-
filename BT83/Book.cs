using System;
using System.Collections.Generic;
using System.Text;

namespace BT83
{
     class Book
    {

        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string Producer { get; set; }
        public int YearPublishing { get; set; }
        public int Price { get; set; }

        public Book() { }
        public Book(string bookName , string bookAuthor , string producer ,int yearPublishing , int price)
        {
            this.BookName = bookName;
            this.BookAuthor = bookAuthor;
            this.Producer = producer;
            this.YearPublishing = yearPublishing;
            this.Price = price;
        }
        public virtual void InputBook()
        {
            Console.WriteLine("nhap ten sach :");
            BookName = Console.ReadLine();
            Console.WriteLine("nhap ten tac gia :");
            BookAuthor = Console.ReadLine();
            Console.WriteLine("nhap nha xuat ban: ");
            Producer = Console.ReadLine();
            Console.WriteLine("nhap nam xuat ban :");
            YearPublishing = int.Parse(Console.ReadLine());
            Console.WriteLine("nhap gia ban ");
            Price = int.Parse(Console.ReadLine());

        }
        public virtual void DisplayBook()
        {
            Console.WriteLine("ten sach : {0} ; ten tac gia : {1} , nha xuat ban : {2} ; nam xuat ban: {3} ; gia ban : {4} ;" ,
                BookName , BookAuthor , Producer , YearPublishing ,Price );
        }
    }
}
