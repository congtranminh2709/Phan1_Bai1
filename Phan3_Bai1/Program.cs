using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan3_Bai1
{
    internal class Program
    {
        static List<KhachSan> khachsan = new List<KhachSan>();
        static List<KhachHang> khachhang = new List<KhachHang>();
        static List<Book> book = new List<Book>();
        static void Main(string[] args)
        {
            int choose;
            do
            {
                Show();
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("----------------------------------\n");
                        Console.Write("So Khach san: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            KhachSan a = new KhachSan();
                            a.InputKS();
                            khachsan.Add(a);
                        }
                        Console.WriteLine("Nhan nut bat ki de thoat.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Danh sach khach san");
                        foreach (KhachSan i in khachsan)
                            i.OutputKS();
                        Console.WriteLine("Nhan nut bat ki de thoat.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("----------------------------------\n");
                        bookroom();
                        Console.WriteLine("Nhan nut bat ki de thoat.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("----------------------------------\n");
                        findAvaiable();
                        Console.WriteLine("Nhan nut bat ki de thoat.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("----------------------------------\n");
                        Report();
                        Console.WriteLine("Nhan nut bat ki de thoat.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Danh sach khach hang");
                        foreach (KhachHang a in khachhang)
                        {
                            a.OutputKH();
                        }
                        Console.WriteLine("Nhan nut bat ki de thoat.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Nhap sai");
                        break;
                }

            }while (choose != 7);
        }
        public static void bookroom()
        {
            KhachHang a = new KhachHang();
            KhachSan b = new KhachSan();
            Phong c = new Phong();

            Console.Write("CCCD: ");
            int cmnd = Convert.ToInt32(Console.ReadLine());

            a = khachhang.Find(x => x.cccd == cmnd);

            if (a == null)
            {
                Console.WriteLine("Khong ton tai khach hang.");
                Console.Write("----------------------------------\n");
                a = new KhachHang();
                a.InputKH();
                khachhang.Add(a);
            }

            Console.Clear();

            Console.Write("Ma khach san: ");
            int Ma_KS = Convert.ToInt32(Console.ReadLine());

            b = khachsan.Find(x => x.maKs == Ma_KS);

            if (b == null)
            {
                Console.WriteLine("Khong ton tai khach san.");
                Console.Write("----------------------------------\n");
                b = new KhachSan();
                b.InputKS();
                khachsan.Add(b);
            }

            Console.Clear();

            do
            {
                Console.Write("Ma Phong: ");
                int Ma_P = Convert.ToInt32(Console.ReadLine());
                c = b.dsRoom.Find(x => x.maphong == Ma_P);
                if (c == null)
                {
                    Console.Write("----------------------------------\n");
                    Console.WriteLine("Khong ton tai phong.");
                }
            } while (c == null);

            Console.Clear();

            Console.Write("NgayBook: ");
            DateTime NgayBook = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("NgayTraPhong: ");
            DateTime NgayTraPhong = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Book d = new Book();
            d.socccd = a.cccd;
            d.nguoibook = a.hoten;
            d.maks = b.maKs;
            d.maphong = c.maphong;
            d.ngaybook = NgayBook;
            d.ngaytraphong = NgayTraPhong;

            book.Add(d);
        }

        static void findAvaiable()
        {
            Console.Write("NgayBook: ");
            DateTime NgayBook = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("NgayTraPhong: ");
            DateTime NgayTraPhong = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            List<KhachSan> avaiable = new List<KhachSan>();
            foreach (KhachSan a in khachsan)
            {
                KhachSan khachsan = new KhachSan();
                khachsan.maKs = a.maKs;
                khachsan.ten = a.ten;
                khachsan.diachi = a.diachi;
                khachsan.dsRoom = new List<Phong>();

                foreach (Phong r in a.dsRoom)
                {
                    Book find = new Book();
                    find = book.Find(x => x.maks == a.maKs && x.maphong == r.maphong && x.ngaybook <= NgayTraPhong && x.ngaytraphong >= NgayBook);

                    if (find == null)
                    {
                        khachsan.dsRoom.Add(r);
                    }
                }

                avaiable.Add(khachsan);
            }

            Console.Clear();

            foreach (KhachSan khachsan in avaiable)
            {
                khachsan.OutputKS();
            }
        }

        static void Report()
        {
            double revenue = 0;

            foreach (Book a in book)
            {
                int day = Convert.ToInt32((a.ngaytraphong - a.ngaybook).TotalDays);
                KhachSan b = khachsan.Find(x => x.maKs == a.maks);
                Phong c = b.dsRoom.Find(x => x.maphong == a.maphong);
                revenue += day * c.giatien;

                Console.WriteLine("Revenue: {0}", revenue);

            }
        }
        public static void Show()
        {
            Console.WriteLine("Quan ly khach san");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Nhap thong tin khach san");
            Console.WriteLine("2. In thong tin khach san");
            Console.WriteLine("3. Nhap thong tin dat phong");
            Console.WriteLine("4. Nhap ngay book, ngay tra phong, in cac phong có the dap ung");
            Console.WriteLine("5. In tong tien");
            Console.WriteLine("6. Nhap CCCD KH, in ra khach hang");
            Console.WriteLine("7. Thoat chuong trinh");
        }
    }
}
