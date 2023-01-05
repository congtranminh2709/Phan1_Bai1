using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhKhoanCachToaDo
{
    internal class Program
    {
        public static int xM, yM, a, b, c;
        public static double distance;
        static void Main(string[] args)
        {
            input();
            coordinatedistance();
            inputCoordinatedistance();
            Console.Write("\n\n");
            Console.ReadKey();
        }
        public static void input()
        {
            Console.Write("\nTinh khoanh cach toa do:\n");
            Console.Write("----------------------------------\n");

            Console.Write("\nNhap toa do xM và yM:\n");
            Console.Write("Nhap xM: ");
            xM = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap yM: ");
            yM = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nNhap a,b,c :\n");
            Console.Write("Nhap a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap c: ");
            c = Convert.ToInt32(Console.ReadLine());

        }
        public static void coordinatedistance()
        {
            distance = (Math.Abs((a * xM) + (b * yM) + c) / (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2))));
        }
        public static void inputCoordinatedistance()
        {
            Console.Write("\nKhoang cach toa do: {0}", distance);

        }
    }
}
