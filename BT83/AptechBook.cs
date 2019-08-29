using System;



namespace BT83
{
    class AptechBook : Book
    {
        public string  Language { get ; set;  }
        public int Semester { get; set; }

        public AptechBook() { }

        public AptechBook(string bookName, string bookAuthor, string producer, int yearPublishing, int price , string language , int semester)
            : base(bookName , bookAuthor , producer , yearPublishing , price  )
        {
            this.Language = language;
            this.Semester = semester;

        }
        public override string ToString()
        {
            
            DisplayBook();
            return base.ToString();
        }
        public override void InputBook()
        {
            base.InputBook();

            Console.WriteLine("nhap ngon ngu sach :");
            Language = Console.ReadLine();
            Console.WriteLine("nhap ky hok ");
            Semester = int.Parse(Console.ReadLine());
            Console.WriteLine("ket thuc ...............................................................");
        }
      
        public override void DisplayBook()
        {
            base.DisplayBook();

            Console.WriteLine("ngon ngu : {0} ; hok ky : {1}", Language, Semester);
        }
    }
}
