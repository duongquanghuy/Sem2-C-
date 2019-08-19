using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BT445
{
    class Test
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int n;
            string choose;
            string confirm;
            string searchString;

            List<AptechBook> Library = new List<AptechBook>();
            List<AptechBook> BooksSearch = new List<AptechBook>();

            Console.WriteLine("=== CHƯƠNG TRÌNH QUẢN LÝ SÁCH ===");

            while (true)
            {
                ShowMenu();

                choose = Console.ReadLine();

                if (Regex.IsMatch(choose, "[1-6]{1}"))
                {
                    switch (int.Parse(choose))
                    {
                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine("=== THÊM SÁCH ===");
                            Console.Write("Nhập số lượng sách Aptech bạn muốn thêm: ");

                            n = int.Parse(Console.ReadLine());

                            for (int i = 0; i < n; i++)
                            {
                                AptechBook aptBk = new AptechBook();
                                Console.WriteLine("Nhập thông tin cho cuốn sách thứ " + (i + 1) + ": ");
                                aptBk.InputBook();
                                Library.Add(aptBk);
                                Console.WriteLine("");
                            }

                            Console.WriteLine("Nhập thông tin các cuốn sách thành công!");
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine("");
                            if (Library.Count != 0)
                            {
                                Console.WriteLine("=== HIỂN THỊ THÔNG TIN SÁCH ===");
                                foreach (AptechBook ab in Library)
                                {
                                    Console.WriteLine("");
                                    ab.DisplayBook();
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Chưa có cuốn sách nào trong hệ thông, vui lòng thử lại!");
                            }
                            Console.WriteLine("");
                            break;

                        case 3:
                            Console.WriteLine("");
                            if (Library.Count != 0)
                            {
                                Console.WriteLine("=== SẮP XẾP SÁCH GIẢM DẦN THEO NĂM XUẤT BẢN ===");

                                AptechBook[] LibArr = Library.ToArray();

                                Array.Sort(LibArr, delegate (AptechBook aptb1, AptechBook aptb2)
                                {
                                    return aptb1.YearPublishing.CompareTo(aptb2.YearPublishing)*(-1);
                                });

                                foreach(AptechBook ab in LibArr)
                                {
                                    Console.WriteLine(ab.BookName + " - Xuất bản năm: " + ab.YearPublishing);
                                }

                                LibArr = null;
                            }
                            else
                            {
                                Console.WriteLine("Chưa có cuốn sách nào trong hệ thông, vui lòng thử lại!");
                            }
                            Console.WriteLine("");
                            break;

                        case 4:
                            Console.WriteLine("");
                            if (Library.Count != 0)
                            {
                                Console.WriteLine("=== TÌM KIẾM THEO TÊN SÁCH ===");
                                Console.WriteLine("");
                                Console.WriteLine("- Nhập tên sách bạn muốn tìm kiếm: ");
                                searchString = Console.ReadLine();

                                foreach (AptechBook ab in Library)
                                {
                                    if (ab.BookName.Equals(searchString))
                                    {
                                        BooksSearch.Add(ab);
                                    }
                                }

                                if (BooksSearch.Count == 0)
                                {
                                    Console.WriteLine("Không tìm thấy cuốn sách nào có tên " + searchString + "!");
                                }
                                else
                                {
                                    Console.WriteLine("Đã tìm thấy " + BooksSearch.Count + " cuốn sách: ");
                                    foreach (AptechBook ab in BooksSearch)
                                    {
                                        Console.WriteLine("");
                                        ab.DisplayBook();
                                        Console.WriteLine("");
                                    }
                                    BooksSearch.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Chưa có cuốn sách nào trong hệ thông, vui lòng thử lại!");
                            }
                            Console.WriteLine("");
                            break;

                        case 5:
                            Console.WriteLine("");
                            if (Library.Count != 0)
                            {
                                Console.WriteLine("=== TÌM KIẾM THEO TÊN TÁC GIẢ ===");
                                Console.WriteLine("");
                                Console.WriteLine("- Nhập tên tác giả bạn muốn tìm kiếm: ");
                                searchString = Console.ReadLine();

                                foreach (AptechBook ab in Library)
                                {
                                    if (ab.BookAuthor.Equals(searchString))
                                    {
                                        BooksSearch.Add(ab);
                                    }
                                }

                                if (BooksSearch.Count == 0)
                                {
                                    Console.WriteLine("Không tìm thấy cuốn sách nào có tác giả là " + searchString + "!");
                                }
                                else
                                {
                                    Console.WriteLine("Đã tìm thấy " + BooksSearch.Count + " cuốn sách của tác giả " + searchString + ": ");
                                    foreach (AptechBook ab in BooksSearch)
                                    {
                                        Console.WriteLine("");
                                        ab.DisplayBook();
                                        Console.WriteLine("");
                                    }
                                    BooksSearch.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Chưa có cuốn sách nào trong hệ thông, vui lòng thử lại!");
                            }
                            Console.WriteLine("");
                            break;

                        case 6:
                            while (true)
                            {
                                Console.Write("Bạn có chắc chắn muốn thoát chương trình? (y/n): ");
                                confirm = Console.ReadLine();

                                if (confirm.Equals("y") || confirm.Equals("Y"))
                                {
                                    System.Environment.Exit(1);
                                }
                                else if (confirm.Equals("n") || confirm.Equals("N"))
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            break;

                        default:
                            Console.WriteLine("Bạn đã nhập sai, vui lòng thử lại!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Bạn đã nhập sai, vui lòng thử lại!");
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n1.Nhập thông tin n cuốn sách của Aptech");
            Console.WriteLine("2.Hiển thị thông tin vừa nhập");
            Console.WriteLine("3.Sắp xếp thông tin giảm dần theo năm xuất bản và hiển thị");
            Console.WriteLine("4.Tìm kiếm theo tên sách");
            Console.WriteLine("5.Tìm kiếm theo tên tác giả");
            Console.WriteLine("6.Thoát\n");
            Console.Write("=== Mời bạn chọn: ");
        }
    }

    class Book
    {
        private string _bookName;
        public string BookName {
            get {
                return this._bookName;
            }
            set {
                this._bookName = value;
            }
        }

        private string _bookAuthor;
        public string BookAuthor {
            get
            {
                return this._bookAuthor;
            }
            set
            {
                this._bookAuthor = value;
            }
        }

        private string _producer;
        public string Producer {
            get
            {
                return this._producer;
            }
            set
            {
                this._producer = value;
            }
        }

        private int _yearPublishing;
        public int YearPublishing {
            get
            {
                return this._yearPublishing;
            }
            set
            {
                this._yearPublishing = value;
            }
        }

        private float _price;
        public float Price {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }

        public Book()
        {

        }

        public Book(string bookName, string bookAuthor, string produccer, int yearPublishing, float price)
        {
            _bookName = bookName;
            _bookAuthor = bookAuthor;
            _producer = produccer;
            _yearPublishing = yearPublishing;
            _price = price;
        }

        public virtual void InputBook()
        {
            Console.Write("Input Book Name: ");
            _bookName = Console.ReadLine();
            Console.Write("Input Book Author: ");
            _bookAuthor = Console.ReadLine();
            Console.Write("Input Book Producer: ");
            _producer = Console.ReadLine();
            Console.Write("Input Book's Year Publishing: ");
            _yearPublishing = int.Parse(Console.ReadLine());
            Console.Write("Input Book Price: ");
            _price = float.Parse(Console.ReadLine());
        }

        public virtual void DisplayBook()
        {
            Console.WriteLine("Name: " + _bookName + ", Author: " + _bookAuthor);
            Console.WriteLine("Producer: " + _producer + ", Year Publishing: " + YearPublishing);
            Console.WriteLine("Price: " + _price);
        }
    }

    class AptechBook : Book
    {
        string _language;
        public string Language
        {
            get
            {
                return this._language;
            }
            set
            {
                this._language = value;
            }
        }
        int _semester;
        public int Semester
        {
            get
            {
                return this._semester;
            }
            set
            {
                this._semester = value;
            }
        }

        public AptechBook()
        {

        }

        public AptechBook(string bookName, string bookAuthor, string producer, int yearPublishing, float price
            , string language, int semester) : base(bookName, bookAuthor, producer, yearPublishing, price)
        {
            _language = language;
            _semester = semester;
        }

        public override void InputBook()
        {
            base.InputBook();
            Console.Write("Input Book Language: ");
            _language = Console.ReadLine();
            Console.Write("Input Book Semester: ");
            _semester = int.Parse(Console.ReadLine());
        }

        public override void DisplayBook()
        {
            base.DisplayBook();
            Console.WriteLine("Book Language: " + _language + ", Semester: " + _semester);
        }
    }
}
