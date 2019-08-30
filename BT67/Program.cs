using System;
using System.Collections;
using System.Collections.Generic;
namespace BT67
{
    class Program
    {
        public static Dictionary<int, Customer> listCustomer = new Dictionary<int, Customer>();
        public static List<Book> listBook = new List<Book>();
        public static Dictionary<int, Hotel> listHotel = new Dictionary<int, Hotel>();
        static void Main(string[] args)
        {
            int choose = 0;
            do
            {
                showMenu();
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine(">> Nhap thong tin khach san <<");
                        addHotel();
                        break;
                    case 2:
                        Console.WriteLine(">> Hien thi thong tin khach san <<");
                        displayHotel();
                        break;
                    case 3:
                        Console.WriteLine(">> Dat phong nghi <<");
                        Book book = new Book();
                        book.inputInfoBookRoom();
                        listBook.Add(book);
                        break;
                    case 4:
                        Console.WriteLine(">> Tim phong con trong <<");
                        Console.WriteLine("Nhap ngay bat dau thue: ");
                        DateTime date1 = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ngay tra phong : ");
                        DateTime date2 = DateTime.Parse(Console.ReadLine());
                        while (DateTime.Compare(date1, date2) > 0)
                        {
                            Console.WriteLine("Ngay tra phong phai sau ngay bat dau thue, hay nhap lai");
                            Console.WriteLine("Nhap ngay bat dau thue: ");
                            date1 = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Nhap ngay tra phong : ");
                            date2 = DateTime.Parse(Console.ReadLine());
                        }
                            searchRoomAvailable(date1, date2);
                        break;
                    case 5:
                        Console.WriteLine(">> Thong ke doanh thu khach san <<");
                        if (listHotel.Count == 0)
                        {
                            Console.WriteLine("Chua co khach san nao, hay nhap thong tin khach san ");
                        }
                        else
                        {
                            Console.WriteLine("Nhap vao ma khach san can tra cuu : ");
                            foreach (KeyValuePair<int, Hotel> hotel in listHotel)
                            {
                                Console.WriteLine(hotel.Key + " : " + hotel.Value.HotelName);
                            }
                            int hotelId = int.Parse(Console.ReadLine());
                            if (listHotel.ContainsKey(hotelId))
                            {
                                Console.WriteLine("Doanh thu cua khach san ma " + hotelId + " la : " + revenueOfHotel(hotelId));
                            }
                            else
                            {
                                Console.WriteLine("Khong co khach san ma nay, hay kiem tra lai");
                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine(">> Tim kiem thong tin khach hang <<");
                        Console.WriteLine("Nhap vao so chung minh thu khach hang : ");
                        int customerId = int.Parse(Console.ReadLine());
                        Customer cus = searchCustomer(customerId);
                        cus.showCustomerInfo();
                        break;
                    case 7:
                        Console.WriteLine("Thoat, bye bye !!!");
                        break;
                }
            } while (choose != 7);
        }
        static void showMenu()
        {
            Console.WriteLine(">> Menu <<");
            Console.WriteLine("1. Nhap thong tin khach san");
            Console.WriteLine("2. Hien thi thong tin khach san");
            Console.WriteLine("3. Dat phong nghi");
            Console.WriteLine("4. Tim phong con trong");
            Console.WriteLine("5. Thong ke doanh thu khach san");
            Console.WriteLine("6. Tim kiem thong tin khach hang");
            Console.WriteLine("7. Thoat chuong trinh");
        }
        static Customer searchCustomer(int CustomerId) {
            if (listCustomer.ContainsKey(CustomerId))
            {
                return listCustomer[CustomerId];
            }
            else
            {
                Console.WriteLine("Khong co thong tin khach hang nay, hay kiem tra lai");
                return null;
            }
        } 
        static float revenueOfHotel(int hotelId)
        {
            float revenue = 0;
            for(int i = 0; i < listBook.Count; i++)
            {
                float coefficientDay;
                if (listBook[i].BookHotelId == hotelId)
                {
                    for(int j = 0; j< listHotel[hotelId].ListRoom.Count; j++)
                    {
                        if(listHotel[hotelId].ListRoom[j].RoomId == listBook[i].BookRoomId)
                        {
                            TimeSpan temp = listBook[i].BookDateCheckOut - listBook[i].BookDate;
                            coefficientDay = temp.Days + 1;
                            revenue = revenue + listHotel[hotelId].ListRoom[j].RoomPrice * coefficientDay;
                        }
                    }
                }
            }
            return revenue;
        }
        static void addHotel()
        {
            Console.WriteLine("Nhap so luong khach san can them : ");
            int amuontHotel = int.Parse(Console.ReadLine());
            for (int i = 1; i <= amuontHotel; i++)
            {
                Console.WriteLine("Nhap thong tin khach san thu " + i);
                Hotel hotel = new Hotel();
                hotel.inputHotelInfo();
                listHotel.Add(hotel.HotelID, hotel);
                Console.WriteLine("---");
            }
        }
        static void displayHotel()
        {
            if (listHotel.Count == 0)
            {
                Console.WriteLine("Chua co thong tin khach san nao, hay nhap thong tin khach san");
            }
            else
            {
                foreach (KeyValuePair<int, Hotel> hotelDisplay in listHotel)
                {
                    hotelDisplay.Value.showHotelInfo();
                }
            }
        }
        static void searchRoomAvailable(DateTime date1, DateTime date2)
        {
            Console.WriteLine("Cac phong va khach san thoa man yeu cau la : ");
            if (listBook.Count == 0 || listBook == null)
            {
                foreach (KeyValuePair<int, Hotel> hotelDisplay in listHotel)
                {
                    hotelDisplay.Value.showHotelInfo();
                }
            }
            else
            {
                foreach (KeyValuePair<int, Hotel> hotelDisplay in listHotel)
                {
                    int hotelCheckRoomExistInBook = 0;
                    int count = 0;
                    Console.WriteLine("Ten khach san : " + hotelDisplay.Value.HotelName);
                    Console.WriteLine("Ma khach san : " + hotelDisplay.Value.HotelID);
                    Console.WriteLine("Dia chi khach san : " + hotelDisplay.Value.HotelAddress);
                    Console.WriteLine("Loai khach san : " + hotelDisplay.Value.HotelType);
                    Console.WriteLine("Danh sach phong thoa man dieu kien : ");
                    for (int i = 0; i < listBook.Count; i++)
                    {
                        if (listBook[i].BookHotelId == hotelDisplay.Value.HotelID)
                        {
                            hotelCheckRoomExistInBook++;
                        }
                    }
                    if (hotelCheckRoomExistInBook == 0)
                    {
                        foreach (Room r in hotelDisplay.Value.ListRoom)
                        {
                            r.showRoomInfo();
                            count++;
                        }
                    }
                    else
                    {
                        for (int a = 0; a < hotelDisplay.Value.ListRoom.Count; a++)
                        {
                            Boolean roomAvailable = true;
                            for (int b = 0; b < listBook.Count; b++)
                            {
                                if (hotelDisplay.Value.HotelID == listBook[b].BookHotelId &&
                                    hotelDisplay.Value.ListRoom[a].RoomId == listBook[b].BookRoomId &&
                                    !(((DateTime.Compare(date1, listBook[b].BookDate) < 0 && DateTime.Compare(date2, listBook[b].BookDate) < 0)) ||
                                     (DateTime.Compare(date1, listBook[b].BookDateCheckOut) > 0 && DateTime.Compare(date2, listBook[b].BookDateCheckOut) > 0)))
                                {
                                    roomAvailable = false;
                                }
                            }
                            if (roomAvailable == true)
                            {
                                hotelDisplay.Value.ListRoom[a].showRoomInfo();
                                count++;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("** Khach san nay khong con phong **");
                    }
                }
            }
        }
    }
}
