using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Phan2_Bai2
{
    internal class Account
    {
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }

        public Account() { }
        public Account(int AccountID, string FirstName, string LastName, double Balance)
        {
            this.AccountID = AccountID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Balance = Balance;
        }
        public int accountID { get => AccountID; set => AccountID = value; }
        public string firstName { get => FirstName; set => FirstName = value; }
        public string lastName { get => LastName; set => LastName = value; }
        public double balance { get => Balance; set => Balance = value; }

        public void Show()
        {
            Console.WriteLine("--------------------\n");
            Console.WriteLine("AcountID: " + AccountID);
            Console.WriteLine("FirstName: " + FirstName);
            Console.WriteLine("LastName: " + LastName);
            Console.WriteLine("Balance: " + Balance);
        }
        public void Input()
        {
            Console.Write("AccountID: ");
            AccountID = int.Parse(Console.ReadLine());
            Console.Write("FirstName: ");
            FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            LastName = Console.ReadLine();
            Console.Write("Balance: ");
            Balance = int.Parse(Console.ReadLine());

        }
    }
}
