using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace BT565
{
    class Program
    {
        static List<Hotel> danhSachKhachSan = new List<Hotel>();
        static List<Customer> danhSachKhachHang = new List<Customer>();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int soKhachSanMuonNhap;
            int soKhachHangMuonNhap;
            string luaChon;
            string xacNhanThoat;

            Console.WriteLine("=== CHƯƠNG TRÌNH QUẢN LÝ KHÁCH SẠN ===");

            while (true)
            {
                HienMenu();

                luaChon = Console.ReadLine();

                if (Regex.IsMatch(luaChon,"[1-6]{1}"))
                {
                    switch (int.Parse(luaChon))
                    {
                        case 1:
                            Console.WriteLine("");

                            Console.Write("Nhập Số lượng Khách sạn muốn thêm: ");
                            soKhachSanMuonNhap = int.Parse(Console.ReadLine());

                            for (int i = 0; i < soKhachSanMuonNhap; i++)
                            {
                                Console.WriteLine("Nhập Khách sạn thứ " + (i + 1) + ": ");
                                Hotel ks = new Hotel();
                                ks.NhapKhachSan();
                                danhSachKhachSan.Add(ks);
                            }

                            Console.WriteLine("NHẬP KHÁCH SẠN THÀNH CÔNG!!!");

                            Console.WriteLine("");
                            break;

                        case 2:
                            Console.WriteLine("");
                            if (danhSachKhachSan.Count == 0)
                            {
                                Console.WriteLine("Bạn chưa có Khách sạn nào trong Hệ thống, Vui lòng thử lại!!!");
                            }
                            else
                            {
                                Console.WriteLine("HIỂN THỊ THÔNG TIN TOÀN BỘ CÁC KHÁCH SẠN: ");
                                foreach (Hotel ks in danhSachKhachSan)
                                {
                                    ks.HienKhachSan();
                                }
                            }
                            Console.WriteLine("");
                            break;

                        case 3:
                            Console.WriteLine("");
                            if (danhSachKhachSan.Count == 0)
                            {
                                Console.WriteLine("Bạn chưa có Khách sạn nào trong Hệ thống, Vui lòng thử lại!!!");
                            }
                            else
                            {
                                Console.WriteLine("LƯU DỮ LIỆU VÀO FILE DATA.JSON");

                                Console.WriteLine("Đang thi hành... Vui lòng đợi... ");

                                string jsonExport = JsonConvert.SerializeObject(danhSachKhachSan);

                                System.IO.File.WriteAllText("data.json", jsonExport);

                                Console.WriteLine("Lưu thành công!!!");
                            }
                            Console.WriteLine("");
                            break;

                        case 4:
                            Console.WriteLine("");

                            if (System.IO.File.Exists("data.json"))
                            {
                                Console.WriteLine("LẤY DỮ LIỆU TỪ FILE DATA.JSON VÀ LƯU VÀO MẢNG");

                                Console.WriteLine("Đang thi hành... Vui lòng đợi... ");

                                string jsonImport = System.IO.File.ReadAllText("data.json");

                                danhSachKhachSan = JsonConvert.DeserializeObject<List<Hotel>>(jsonImport);

                                Console.WriteLine("Lấy dữ liệu thành công!!!");

                                Console.WriteLine("");

                                foreach (Hotel ks in danhSachKhachSan)
                                {
                                    ks.HienKhachSan();
                                }
                            }
                            else
                            {
                                Console.WriteLine("File data.json KHÔNG TỒN TẠI, Vui lòng thử lại!!!");
                            }

                            Console.WriteLine("");
                            break;

                        case 5:
                            Console.WriteLine("");

                            Console.Write("Nhập Số lượng Khách hàng muốn thêm: ");
                            soKhachHangMuonNhap = int.Parse(Console.ReadLine());

                            for (int i = 0; i < soKhachHangMuonNhap; i++)
                            {
                                Customer kh = new Customer();
                                kh.NhapKhachHang();
                                danhSachKhachHang.Add(kh);
                            }

                            Console.WriteLine("LƯU THÔNG TIN KHÁCH HÀNG VÀO FILE CUS.DAT: ");
                            Console.WriteLine("Đang thực thi... Vui lòng chờ... ");

                            using (Stream stream = File.Open("cus.dat", FileMode.Create))
                            {
                                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                                binaryFormatter.Serialize(stream, danhSachKhachHang);
                            }

                            Console.WriteLine("Lưu thành công!!!");

                            Console.WriteLine("");
                            break;

                        case 6:
                            Console.WriteLine("");
                            
                            while (true)
                            {
                                Console.Write("Bạn có chắc chắn muốn Thoát chương trình? (y/n): ");
                                xacNhanThoat = Console.ReadLine();

                                if (xacNhanThoat.Equals("y"))
                                {
                                    System.Environment.Exit(1);
                                }
                                else if (xacNhanThoat.Equals("n"))
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            Console.WriteLine("");
                            break;

                        default:
                            Console.WriteLine("Bạn đã nhập Sai, Vui lòng thử lại!!!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Bạn đã nhập Sai, Vui lòng thử lại!!!");
                }
            }
        }

        static void HienMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Nhập thông tin N Khách sạn");
            Console.WriteLine("2. Hiển thị thông tin KS");
            Console.WriteLine("3. Export dữ liệu nhập sang chuỗi json và lưu vào file data.json");
            Console.WriteLine("4. Import dữ liệu từ file data.json và lưu vào mảng quản lý KS");
            Console.WriteLine("5. Lưu thông tin từng KH vào 1 file.");
            Console.WriteLine("6. Thoát");
            Console.Write("Mời bạn chọn: ");
        }
    }

    [Serializable]
    class Room
    {
        string _tenPhong;
        string TenPhong { get => _tenPhong; set => _tenPhong = value; }
        string _tang;
        string Tang { get => _tang; set => _tang = value; }
        int _giaTien;
        int GiaTien { get => _giaTien; set => _giaTien = value; }
        int _soNguoiToiDa;
        int SoNguoiToiDa { get => _soNguoiToiDa; set => _soNguoiToiDa = value; }

        public Room()
        {

        }

        public Room(string tenPhong, string tang, int giaTien, int soNguoiToiDa)
        {
            _tenPhong = tenPhong;
            _tang = tang;
            _giaTien = giaTien;
            _soNguoiToiDa = soNguoiToiDa;
        }

        public void NhapPhong()
        {
            Console.Write("Nhập Tên phòng: ");
            _tenPhong = Console.ReadLine();
            Console.Write("Nhập Tầng của phòng: ");
            _tang = Console.ReadLine();
            Console.Write("Nhập Giá phòng: ");
            _giaTien = int.Parse(Console.ReadLine());
            Console.Write("Nhập Số người tối đa của Phòng: ");
            _soNguoiToiDa = int.Parse(Console.ReadLine());
            Console.WriteLine("");
        }

        public void HienPhong()
        {
            Console.WriteLine("\tPhòng " + _tenPhong + ": ");
            Console.WriteLine("\tTầng: " + _tang + " - Giá: " + _giaTien);
            Console.WriteLine("\tSố người tối đa: " + _soNguoiToiDa);
            Console.WriteLine("");
        }
    }

    [Serializable]
    class Hotel
    {
        string _tenKhachSan;
        string _diaChiKhachSan;
        List<Room> _danhSachPhong = new List<Room>();

        public string TenKhachSan { get => _tenKhachSan; set => _tenKhachSan = value; }
        public string DiaChiKhachSan { get => _diaChiKhachSan; set => _diaChiKhachSan = value; }
        public List<Room> DanhSachPhong { get => _danhSachPhong; set => _danhSachPhong = value; }

        public Hotel()
        {

        }

        public Hotel(string tenKhachSan, string diaChiKhachSan, List<Room> danhSachPhong)
        {
            _tenKhachSan = tenKhachSan;
            _diaChiKhachSan = diaChiKhachSan;
            _danhSachPhong = danhSachPhong;
        }

        public void NhapKhachSan()
        {
            int soPhongMuonThem;

            Console.Write("Nhập Tên khách sạn: ");
            _tenKhachSan = Console.ReadLine();
            Console.Write("Nhập Địa chỉ Khách sạn: ");
            _diaChiKhachSan = Console.ReadLine();
            Console.WriteLine("Nhập Danh sách Phòng: ");

            Console.Write("Nhập Số lượng Phòng muốn thêm vào Danh Sách: ");
            soPhongMuonThem = int.Parse(Console.ReadLine());

            for (int i = 0; i < soPhongMuonThem; i++)
            {
                Console.WriteLine("Nhập Thông tin cho Phòng thứ " + (i + 1) + ": ");
                Room phong = new Room();
                phong.NhapPhong();
                _danhSachPhong.Add(phong);
            }

            Console.WriteLine("");
        }

        public void HienKhachSan()
        {
            Console.WriteLine("Khách Sạn " + _tenKhachSan);
            Console.WriteLine("Địa chỉ: " + _diaChiKhachSan);
            Console.WriteLine("Danh sách Phòng: \n");
            
            if (_danhSachPhong.Count == 0)
            {
                Console.WriteLine("Khách sạn này chưa có Phòng nào trong Danh sách!!!");
            }
            else
            {
                foreach (Room phong in _danhSachPhong)
                {
                    phong.HienPhong();
                }
            }
        }
    }

    [Serializable]
    class Customer
    {
        string _tenKhachHang;
        string _diaChiKhachHang;

        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
        public string DiaChiKhachHang { get => _diaChiKhachHang; set => _diaChiKhachHang = value; }

        public Customer()
        {

        }

        public Customer(string tenKhachHang, string diaChiKhachHang)
        {
            _tenKhachHang = tenKhachHang;
            _diaChiKhachHang = diaChiKhachHang;
        }

        public void NhapKhachHang()
        {
            Console.WriteLine("");
            Console.Write("Nhập Tên Khách hàng: ");
            _tenKhachHang = Console.ReadLine();
            Console.Write("Nhập Địa chỉ Khách hàng: ");
            _diaChiKhachHang = Console.ReadLine();
            Console.WriteLine("");
        }
    }
}
