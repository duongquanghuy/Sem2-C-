using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    public class Book
    {
        private DateTime bookDate;
        private DateTime bookDateCheckOut;
        private int bookIdNumberCustomer;
        private int bookHotelId;
        private int bookRoomId;

        public DateTime BookDate { get => bookDate; set => bookDate = value; }
        public DateTime BookDateCheckOut { get => bookDateCheckOut; set => bookDateCheckOut = value; }
        public int BookIdNumberCustomer { get => bookIdNumberCustomer; set => bookIdNumberCustomer = value; }
        public int BookHotelId { get => bookHotelId; set => bookHotelId = value; }
        public int BookRoomId { get => bookRoomId; set => bookRoomId = value; }

        public Book(DateTime bookDate, DateTime bookDateCheckOut, int bookIdNumberCustomer, int bookHotelId, int bookRoomId)
        {
            this.bookDate = bookDate;
            this.bookDateCheckOut = bookDateCheckOut;
            this.bookIdNumberCustomer = bookIdNumberCustomer;
            this.bookHotelId = bookHotelId;
            this.bookRoomId = bookRoomId;
        }

        public Book()
        {
        }
        public void inputInfoBookRoom()
        {
            Console.WriteLine("Nhap vao ngay book phong : ");
            bookDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao ngay tra phong phong : ");
            bookDateCheckOut = DateTime.Parse(Console.ReadLine());
            int checkDate = DateTime.Compare(bookDate, bookDateCheckOut);
            while(checkDate > 0)
            {
                Console.WriteLine("Nhap book phong phai truoc ngay tra phong, hay nhap lai");
                Console.WriteLine("Nhap vao ngay book phong : ");
                bookDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Nhap vao ngay tra phong phong : ");
                bookDateCheckOut = DateTime.Parse(Console.ReadLine());
                checkDate = DateTime.Compare(bookDate, bookDateCheckOut);
            }
            Console.WriteLine("Nhap vao so chung minh thu nguoi book : ");
            bookIdNumberCustomer = int.Parse(Console.ReadLine());
            if (!checkExistIdNumberCustomer(bookIdNumberCustomer))
            {
                Console.WriteLine("Khach hang nay chua ton tai , hay nhap thong tin khach hang");
                Customer cus = new Customer();
                cus.inputCustomerInfo();
                cus.CustomerIdNumber = bookIdNumberCustomer;
                Program.listCustomer.Add(cus.CustomerIdNumber,cus);
            }
            Console.WriteLine("Nhap vao ma khach san : ");
            bookHotelId = int.Parse(Console.ReadLine());
            while (!checkExistHotelId(bookHotelId))
            {
                Console.WriteLine("Khong ton tai ma khach san nay, hay nhap lai : ");
                bookHotelId = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Nhap ma phong cua khach san : ");
            bookRoomId = int.Parse(Console.ReadLine());
            while (!checkExistRoomId(bookHotelId, bookRoomId))
            {
                Console.WriteLine("Khach san nay khong co ma phong nay, hay nhap lai : ");
                bookRoomId = int.Parse(Console.ReadLine());
            }
        }
        private Boolean checkExistIdNumberCustomer(int IdNumberCustomer)
        {
            if (Program.listCustomer.ContainsKey(IdNumberCustomer))
            {
                return true;
            }
            return false;
        }
        private Boolean checkExistHotelId(int bookHotelId)
        {
            if (Program.listHotel.ContainsKey(bookHotelId))
            {
                return true;
            }
            return false;
        }
        private Boolean checkExistRoomId(int hotelId ,int roomId)
        {
            if (Program.listHotel.ContainsKey(hotelId))
            {
                for(int i = 0; i < Program.listHotel[hotelId].ListRoom.Count; i++)
                {
                    if(Program.listHotel[hotelId].ListRoom[i].RoomId == roomId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
