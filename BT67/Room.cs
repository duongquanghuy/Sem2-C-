using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Room
    {
        private String roomName;
        private float roomPrice;
        private int roomFloor;
        private int roomMaxNumberOfPeople;
        private int roomId;

        public string RoomName { get => roomName; set => roomName = value; }
        public float RoomPrice { get => roomPrice; set => roomPrice = value; }
        public int RoomFloor { get => roomFloor; set => roomFloor = value; }
        public int RoomMaxNumberOfPeople { get => roomMaxNumberOfPeople; set => roomMaxNumberOfPeople = value; }
        public int RoomId { get => roomId; set => roomId = value; }

        public Room(string roomName, float roomPrice, int roomFloor, int roomMaxNumberOfPeople, int roomId)
        {
            this.roomName = roomName;
            this.roomPrice = roomPrice;
            this.roomFloor = roomFloor;
            this.roomMaxNumberOfPeople = roomMaxNumberOfPeople;
            this.roomId = roomId;
        }

        public Room()
        {
        }

        public void inputRoomInfo()
        {
            Console.WriteLine("Nhap vao ten phong : ");
            roomName = Console.ReadLine();
            Console.WriteLine("Nhap vao gia phong : ");
            roomPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao tang cua phong : ");
            roomFloor = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao so luong nguoi toi da cua phong : ");
            roomMaxNumberOfPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao ma phong : ");
            roomId = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------");
        }
        public void showRoomInfo()
        {
            Console.WriteLine("Ten phong : "+ roomName);
            Console.WriteLine("Gia phong : "+ roomPrice);
            Console.WriteLine("Tang cua phong : "+ roomFloor);
            Console.WriteLine("So luong nguoi toi da : " + roomMaxNumberOfPeople);
            Console.WriteLine("Ma phong : "+ roomId);
            Console.WriteLine("---------------");
        }
    }
}
