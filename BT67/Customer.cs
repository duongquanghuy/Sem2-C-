using System;
using System.Collections.Generic;
using System.Text;

namespace BT67
{
    class Customer
    {
        private int customerIdNumber;
        private String customerName;
        private int customerAge;
        private String customerGender;
        private String customerAddress;

        public int CustomerIdNumber { get => customerIdNumber; set => customerIdNumber = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public int CustomerAge { get => customerAge; set => customerAge = value; }
        public string CustomerGender { get => customerGender; set => customerGender = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }

        public Customer(int customerIdNumber, string customerName, int customerAge, string customerGender, string customerAddress)
        {
            this.customerIdNumber = customerIdNumber;
            this.customerName = customerName;
            this.customerAge = customerAge;
            this.customerGender = customerGender;
            this.customerAddress = customerAddress;
        }
        public Customer()
        {
        }
        public void inputCustomerInfo()
        {
            Console.WriteLine("Nhap vao so chung minh thu khach hang : ");
            CustomerIdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao ho ten khach hang : ");
            customerName = Console.ReadLine();
            Console.WriteLine("Nhap vao tuoi khach hang : ");
            customerAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao gioi tinh khach hang : ");
            customerGender = Console.ReadLine();
            Console.WriteLine("Nhap vao que quan khach hang : ");
            customerAddress = Console.ReadLine();
        }
        public void showCustomerInfo()
        {
            Console.WriteLine("So chung minh thu : " + customerIdNumber);
            Console.WriteLine("Ten : " + customerName);
            Console.WriteLine("Tuoi : " + customerAge);
            Console.WriteLine("Gioi tinh : " + customerGender);
            Console.WriteLine("Que quan : "+ customerAddress);
        }
    }
}
