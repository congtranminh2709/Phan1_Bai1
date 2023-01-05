using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bai1MaTran
{
    internal class Program
    {
        public static int[,] arr_1 = new int[50, 50];
        public static int[,] arr_2 = new int[50, 50];
        public static int[,] arr_result = new int[50, 50];
        public static int r1, c1, r2, c2, i,j,k, sum;
        static void Main(string[] args)
        {
            input();
            XMtrix();
            inputXMtrix();
            Console.Write("\n\n");
            Console.ReadKey();
        }
        public static void input()
        {
            Console.Write("\nNhan hai ma tran:\n");
            Console.Write("----------------------------------\n");

            Console.Write("\nNhap so hang va so cot cua ma tran thu nhat:\n");
            Console.Write("Nhap so hang: ");
            r1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            c1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nNhap so hang va so cot cua ma tran thu hai:\n");
            Console.Write("Nhap so hang: ");
            r2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            c2 = Convert.ToInt32(Console.ReadLine());

            if (c1 != c2)
            {
                Console.Write("Khong the nhan hai ma tran tren !!!");
                Console.Write("\nSo cot cua ma tran thu nhat phai bang so hang cua ma tran thu hai.");
                Console.ReadKey();
                input();
            }
            else
            {
                Console.Write("Nhap cac phan tu cua ma tran thu nhat:\n");
                for (i = 0; i < r1; i++)
                {
                    for (j = 0; j < c1; j++)
                    {
                        Console.Write("Phan tu - [{0}],[{1}]: ", i, j);
                        arr_1[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Write("Nhap cac phan tu cua ma tran thu hai:\n");
                for (i = 0; i < r2; i++)
                {
                    for (j = 0; j < c2; j++)
                    {
                        Console.Write("Phan tu - [{0}],[{1}]: ", i, j);
                        
                        arr_2[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Write("\nIn ma tran dau tien:\n");
                for (i = 0; i < r1; i++)
                {
                    Console.Write("\n");
                    for (j = 0; j < c1; j++)
                        Console.Write("{0}\t", arr_1[i, j]);
                }

                Console.Write("\nIn ma tran thu hai:\n");
                for (i = 0; i < r2; i++)
                {
                    Console.Write("\n");
                    for (j = 0; j < c2; j++)
                        Console.Write("{0}\t", arr_2[i, j]);
                }

            }
               
        }
        public static void XMtrix()
        {
            for (i = 0; i < r1; i++)
                for (j = 0; j < c2; j++)
                    arr_result[i, j] = 0;
            for (i = 0; i < r1; i++)    //hang cua ma tran thu nhat 
            {
                for (j = 0; j < c2; j++)    //cot cua ma tran thu hai 
                {
                    sum = 0;
                    for (k = 0; k < c1; k++)
                        sum = sum + arr_1[i, k] * arr_2[k, j];
                    arr_result[i, j] = sum;
                }
            }
           
        }
        public static void inputXMtrix()
        {
            Console.Write("\nMa tran tich cua hai ma tran tren la: \n");
            for (i = 0; i < r1; i++)
            {
                Console.Write("\n");
                for (j = 0; j < c2; j++)
                {
                    Console.Write("{0}\t", arr_result[i, j]);
                }
            }

        }
           
    }
}
