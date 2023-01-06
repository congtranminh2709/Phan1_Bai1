using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan3_Bai1
{
    internal class Phong
    {
        private string TenPhong;
        private double GiaTien;
        private int Tang;
        private string SoNgToiDa;
        private int MaPhong;

        public string tenphong { get => TenPhong; set => TenPhong = value; }
        public double giatien { get => GiaTien; set => GiaTien = value; }
        public int tang { get => Tang; set => Tang = value; }
        public string soNgtoida { get => SoNgToiDa; set => SoNgToiDa = value; }
        public int maphong { get => MaPhong; set => MaPhong = value; }

        public Phong()
        {

        }
        public Phong(string tenPhong, double giaTien, int tang, string soNgToiDa, int maPhong)
        {
            TenPhong = tenPhong;
            GiaTien = giaTien;
            Tang = tang;
            SoNgToiDa = soNgToiDa;
            MaPhong = maPhong;
        }

        public void InputRoom()
        {
            Console.Write("---------------------------------\n");
            Console.WriteLine("Room\n");
            Console.Write("TenPhong: ");
            tenphong = Console.ReadLine();
            Console.Write("GiaTien: ");
            giatien = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tang: ");
            tang = Convert.ToInt32(Console.ReadLine());
            Console.Write("SoNgToiDa: ");
            soNgtoida = Console.ReadLine();
            Console.Write("MaPhong: ");
            maphong = Convert.ToInt32(Console.ReadLine());
        }

        public void OutputRoom()
        {
            Console.Write("---------------------------\n");
            Console.WriteLine("TenPhong: {0}", tenphong);
            Console.WriteLine("GiaTien: {0}", giatien);
            Console.WriteLine("Tang: {0}", tang);
            Console.WriteLine("SoNgToiDa: {0}", soNgtoida);
            Console.WriteLine("MaPhong: {0}", maphong);
        }
    }
}
