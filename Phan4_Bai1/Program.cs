using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan4_Bai1
{
    internal class Program
    {
        static List<PhongBan> phongban = new List<PhongBan>();
        static List<NhanVien> nhanvien = new List<NhanVien>();
        static void Main(string[] args)
        {
            int choose;
            do
            {
                Console.WriteLine("1. Phong ban");
                Console.WriteLine("2. Danh sach phong ban");
                Console.WriteLine("3. Nhan Vien");
                Console.WriteLine("4. Danh sach nhan vien");
                Console.WriteLine("5. Tim nhan vian");
                Console.WriteLine("6. Danh sach cay");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        PhongBan a = new PhongBan();
                        a.Input();
                        phongban.Add(a);
                        Console.WriteLine("Press any button to exit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(string.Format("{0,-20}|{1,-20}|{2,-20}|{3,-20}", "MaPB", "SttPB", "TenPB", "MoTa"));
                        foreach (PhongBan b in phongban)
                            b.Output();
                        Console.WriteLine("Press any button to exit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        NhanVien c = new NhanVien();
                        c.Input();
                        PhongBan x = new PhongBan();
                        do
                        {
                            Console.Write("Department code: ");
                            string d = Console.ReadLine();
                            x = phongban.Find(i => i.stt_pb == d);

                            if (x == null)
                                Console.WriteLine("Department does not exist");
                        } while (x == null);

                        c.Phongban = x;

                        nhanvien.Add(c);
                        Console.WriteLine("Press any button to exit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(string.Format("{0,-21}{1,-21}{2,-21}{3,-21}{4,-21}{5,-21}{6,-21}", "Ho Ten", "Ngay Sinh(dd/MM/yyyy)", "Dia Chi", "Gioi Tinh", "Chuc Vu", "Ngay Bat Dau lam viec(dd/MM/yyyy)", "Phong Ban"));
                        foreach (NhanVien d in nhanvien)
                        {
                            Console.WriteLine(string.Format("{0,-21}{1,-21}{2,-21}{3,-21}{4,-21}{5,-21}{6,-21}", d.hoten, d.ngaysinh.ToString("dd/MM/yyyy"), d.diachi, d.gioitinh == 1 ? "Nam" : "Nu", d.chucvu, d.ngay_bd.ToString("dd/MM/yyyy"), d.Phongban.ten_pb));
                            Console.WriteLine();
                        }

                        Console.WriteLine("Press any button to exit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        FindEmployee();
                        Console.WriteLine("Press any button to exit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Tree();
                        Console.WriteLine("Press any button to exit.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (choose != 0);
        }
        static void FindEmployee()
        {
            Console.Write("Employee name: ");
            string name = Console.ReadLine();

            Console.WriteLine();

            List<NhanVien> find = nhanvien.Where(x => x.hoten.Equals(name)).ToList();

            if (find == null)
            {
                Console.WriteLine("Employee does not exist");
            }
            else
            {
                Console.WriteLine(string.Format("{0,-21}{1,-21}{2,-21}{3,-21}{4,-21}{5,-21}{6,-21}", "Ho Ten", "Ngay Sinh(dd/MM/yyyy)", "Dia Chi", "Gioi Tinh", "Chuc Vu", "Ngay Bat Dau lam viec(dd/MM/yyyy)", "Phong Ban"));

                foreach (NhanVien d in find)
                {
                    Console.WriteLine(string.Format("{0,-21}{1,-21}{2,-21}{3,-21}{4,-21}{5,-21}{6,-21}", d.hoten, d.ngaysinh.ToString("dd/MM/yyyy"), d.diachi, d.gioitinh == 1 ? "Nam" : "Nu", d.chucvu, d.ngay_bd.ToString("dd/MM/yyyy"), d.Phongban.ten_pb));
                }

            }
        }

        static void Tree()
        {
            int i = 1;
            foreach (PhongBan a in phongban)
            {
                Console.WriteLine("{0}. Department {1}", i, a.ten_pb);
                List<NhanVien> list = nhanvien.Where(x => x.Phongban.ten_pb == a.ten_pb).ToList();
                Console.WriteLine(string.Format("{0,-21}{1,-21}{2,-21}{3,-21}{4,-21}{5,-21}{6,-21}", "Ho Ten", "Ngay Sinh(dd/MM/yyyy)", "Dia Chi", "Gioi Tinh", "Chuc Vu", "Ngay Bat Dau lam viec(dd/MM/yyyy)", "Phong Ban"));
                list.ForEach(d =>
                {
                    Console.WriteLine(string.Format("{0,-21}{1,-21}{2,-21}{3,-21}{4,-21}{5,-21}{6,-21}", d.hoten, d.ngaysinh.ToString("dd/MM/yyyy"), d.diachi, d.gioitinh == 1 ? "Nam" : "Nu", d.chucvu, d.ngay_bd.ToString("dd/MM/yyyy"), d.Phongban.ten_pb));
                });
                Console.Write("----------------------------------\n");
                i++;
            }
        }
    }
}
