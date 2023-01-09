using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phan4_Bai1
{
    internal class NhanVien
    {
        private string HoTen;
        private DateTime NgaySinh;
        private string DiaChi;
        private int GioiTinh;
        private string ChucVu;
        private DateTime Ngay_BD;
        private PhongBan phongban = new PhongBan();
        public NhanVien() { }

        public NhanVien(string hoTen, DateTime ngaySinh, string diaChi, int gioiTinh, string chucVu, DateTime ngay_BD, PhongBan phongban)
        {
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.DiaChi = diaChi;
            this.GioiTinh = gioiTinh;
            this.ChucVu = chucVu;
            this.Ngay_BD = ngay_BD;
            this.phongban = phongban;
        }

        public string hoten { get => HoTen; set => HoTen = value; }
        public DateTime ngaysinh { get => NgaySinh; set => NgaySinh = value; }
        public string diachi { get => DiaChi; set => DiaChi = value; }
        public int gioitinh { get => GioiTinh; set => GioiTinh = value; }
        public string chucvu { get => ChucVu; set => ChucVu = value; }
        public DateTime ngay_bd { get => Ngay_BD; set => Ngay_BD = value; }
        public PhongBan Phongban { get => phongban; set => phongban = value; }

        public void Input()
        {
            Console.Write("Ho Ten: ");
            hoten = Console.ReadLine();
            Console.Write("Ngay Sinh(dd/MM/yyyy): ");
            ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Dia Chi: ");
            diachi = Console.ReadLine();
            Console.Write("Gioi Tinh(1: Nam, 0: Nu): ");
            gioitinh = Convert.ToInt32(Console.ReadLine());
            Console.Write("Chuc Vu: ");
            chucvu = Console.ReadLine();
            Console.Write("Ngay Bat Dau lam viec(dd/MM/yyyy): ");
            ngay_bd = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
        public void Output()
        {
            Console.Write("---------------------------\n");
            Console.WriteLine("Ho Ten: {0}", hoten);
            Console.WriteLine("Ngay Sinh: {0:dd/MM/yyyy}", ngaysinh);
            Console.WriteLine("Dia Chi: {0}", diachi);
            Console.WriteLine("Gioi Tinh: {0}", gioitinh == 1?"Nam":"Nu");
            Console.WriteLine("chucvu: {0}", chucvu);
            Console.WriteLine("Ngay Bat Dau Lam viec: {0}", ngay_bd.ToString("dd/MM/yyyy"));
        }
    }
}
