using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Hotel
    {
        private String hotelName;
        private String hotelAddress;
        private String hotelType;
        private int hotelID;
        private List<Room> listRoom = new List<Room>();

        public string HotelName { get => hotelName; set => hotelName = value; }
        public string HotelAddress { get => hotelAddress; set => hotelAddress = value; }
        public string HotelType { get => hotelType; set => hotelType = value; }
        public int HotelID { get => hotelID; set => hotelID = value; }
        public List<Room> ListRoom { get => listRoom; set => listRoom = value; }

        public Hotel(string hotelName, string hotelAddress, string hotelType, int hotelID)
        {
            this.hotelName = hotelName;
            this.hotelAddress = hotelAddress;
            this.hotelType = hotelType;
            this.hotelID = hotelID;
        }

        public Hotel()
        {
        }
        public void inputHotelInfo()
        {
            Console.WriteLine("Nhap vao ten khach san : ");
            hotelName = Console.ReadLine();
            Console.WriteLine("Nhap vao dia chi khach san : ");
            hotelAddress = Console.ReadLine();
            Console.WriteLine("Nhap vao loai khach san : ");
            hotelType = Console.ReadLine();
            Console.WriteLine("Nhap vao ma khach san : ");
            hotelID = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao so luong phong : ");
            int amountRoom = int.Parse(Console.ReadLine());
            for(int i = 0; i< amountRoom; i++)
            {
                Room room = new Room();
                room.inputRoomInfo();
                listRoom.Add(room);
            }
            Console.WriteLine("-----------------");
        }
        public void showHotelInfo()
        {
            Console.WriteLine("Ten khach san : " + hotelName);
            Console.WriteLine("Dia chi khach san : " + hotelAddress);
            Console.WriteLine("Loai khach san : " + hotelType);
            Console.WriteLine("Ma khach san : " + hotelID);
            Console.WriteLine("+");
            Console.WriteLine("Danh sach phong : ");
            foreach(Room room in listRoom)
            {
                room.showRoomInfo();
            }
        }
    }
}
