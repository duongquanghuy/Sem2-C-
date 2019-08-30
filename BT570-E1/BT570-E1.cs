using System;

namespace BT570_E1
{
    class Program
    {
        static void Main(string[] args)
        {
            MobilePhone mp = new MobilePhone();
            mp.Display();
        }
    }

    public class Phone
    {
        string phoneName;
        string phoneType;
        public string PhoneType {
            get {
                return this.phoneType;
            }
            set {
                this.phoneType = value;
            }
        }
        float phonePrice;

        public Phone()
        {

        }

        public virtual void Display()
        {
            Console.WriteLine("Phone " + this.phoneName + ", Type " + this.phoneType + ", Price " + this.phonePrice);
        }
    }

    public class MobilePhone : Phone
    { 
        public MobilePhone()
        {
            this.PhoneType = "Mobile";
        }

        public override void Display()
        {
            base.Display();
        }
    }
}
