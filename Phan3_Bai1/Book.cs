using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan3_Bai1
{
    internal class Book
    {
        private DateTime NgayBook;
        private DateTime NgayTraPhong;
        private int SoCCCD;
        private string NguoiBook;
        private int MaKS;
        private int MaPhong;

        public Book() { }
        public Book(DateTime ngayBook, DateTime ngayTraPhong, int soCCCD, string nguoiBook, int maKS, int maPhong)
        {
            NgayBook = ngayBook;
            NgayTraPhong = ngayTraPhong;
            SoCCCD = soCCCD;
            NguoiBook = nguoiBook;
            MaKS = maKS;
            MaPhong = maPhong;
        }

        public DateTime ngaybook { get => NgayBook; set => NgayBook = value; }
        public DateTime ngaytraphong { get => NgayTraPhong; set => NgayTraPhong = value; }
        public int socccd { get => SoCCCD; set => SoCCCD = value; }
        public string nguoibook { get => NguoiBook; set => NguoiBook = value; }
        public int maks { get => MaKS; set => MaKS = value; }
        public int maphong { get => MaPhong; set => MaPhong = value; }

        
    }
}
