using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan3_Bai1
{
    internal class KhachHang
    {
        private int CCCD;
        private string HoTen;
        private int Tuoi;
        private string GioiTinh;
        private string DiaChi;

        public int cccd { get => CCCD; set => CCCD = value; }
        public string hoten { get => HoTen; set => HoTen = value; }
        public int tuoi { get => Tuoi; set => Tuoi = value; }
        public string gioitinh { get => GioiTinh; set => GioiTinh = value; }
        public string diachi { get => DiaChi; set => DiaChi = value; }

        public KhachHang(){}

        public KhachHang(int cCCD, string hoTen, int tuoi, string gioiTinh, string diaChi)
        {
            CCCD = cCCD;
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
        }

        public void InputKH()
        {
            Console.Write("---------------------------------\n");
            Console.WriteLine("KhachHang\n");
            Console.Write("CCCD: ");
            cccd = Convert.ToInt32(Console.ReadLine());
            Console.Write("HoTen: ");
            hoten = Console.ReadLine();
            Console.Write("Tuoi: ");
            tuoi = Convert.ToInt32(Console.ReadLine());
            Console.Write("GioiTinh: ");
            gioitinh = Console.ReadLine();
            Console.Write("DiaChi: ");
            diachi = Console.ReadLine();
        }

        public void OutputKH()
        {
            Console.Write("---------------------------\n");
            Console.WriteLine("CCCD: {0}", cccd);
            Console.WriteLine("HoTen: {0}", hoten);
            Console.WriteLine("Tuoi: {0}", tuoi);
            Console.WriteLine("GioiTinh: {0}", gioitinh);
            Console.WriteLine("DiaChi: {0}", diachi);
        }
    }
}
