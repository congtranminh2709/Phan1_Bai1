using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan3_Bai1
{
    internal class KhachSan
    {
        private string Ten;
        private string DiaChi;
        private string LoaiKS;
        private List<Phong> DSRoom;
        private int MaKS;

        public string ten { get => Ten; set => Ten = value; }
        public string diachi { get => DiaChi; set => DiaChi = value; }
        public string loaiKs { get => LoaiKS; set => LoaiKS = value; }
        public List<Phong> dsRoom { get => DSRoom; set => DSRoom = value; }
        public int maKs { get => MaKS; set => MaKS = value; }

        public KhachSan() 
        {
                
        }
        public KhachSan(string ten, string diaChi, string loaiKS, List<Phong> dSRoom, int maKS)
        {
            Ten = ten;
            DiaChi = diaChi;
            LoaiKS = loaiKS;
            DSRoom = dSRoom;
            MaKS = maKS;
        }

        public void InputKS()
        {
            DSRoom = new List<Phong>();

            Console.Write("---------------------------------\n");
            Console.WriteLine("KhachSan: \n");
            Console.Write("Ma Khach San: ");
            maKs = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ten: ");
            ten = Console.ReadLine();
            Console.Write("DiaChi: ");
            diachi = Console.ReadLine();
            Console.Write("LoaiKS: ");
            loaiKs = Console.ReadLine();
            Console.Write("So Phong: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Phong a = new Phong();
                a.InputRoom();
                DSRoom.Add(a);
            }
        }

        public void OutputKS()
        {
            Console.Write("---------------------------\n");
            Console.WriteLine("Ma Khach San: {0}", maKs);
            Console.WriteLine("Ten: {0}", ten);
            Console.WriteLine("DiaChi: {0}", diachi);
            Console.WriteLine("LoaiKS: {0}", loaiKs);
            Console.WriteLine("DiaChi: {0}", diachi);
            Console.Write("Danh Sach Phong: ");
            foreach (Phong a in dsRoom)
            {
                a.OutputRoom();
            }
        }
    }
}
