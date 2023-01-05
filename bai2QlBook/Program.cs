using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2QlBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList b1 = new BookList();
            b1.InputList();
            //b1.ShowList();
            Console.WriteLine("------------------------");
            b1.Sort();
            b1.ShowList();
            Console.ReadLine();
        }
    }
}
