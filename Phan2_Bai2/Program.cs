using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Phan2_Bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountList accountList = new AccountList();
            //accountList.InputList();
            //accountList.ShowList();
            //Console.ReadKey();
            int choose = 0;
            do
            {
                Console.Write("----------------------------------\n");
                Console.WriteLine("1. New Account");
                Console.WriteLine("2. Save File");
                Console.WriteLine("3. Load File");
                Console.WriteLine("4. Report");
                Console.WriteLine("0. Exit");

                Console.Write("Select: ");
                choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        accountList.InputList();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        accountList.SaveFile();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        accountList.LoadFile();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        accountList.ShowList();
                        break;
                    default:
                        break;
                }
            } while (choose != 0);
        }
    }
}
