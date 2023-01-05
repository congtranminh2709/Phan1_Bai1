using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2QlBook
{
    internal class BookList
    {
        private List<Book> list = new List<Book> ();

        public void Sort()
        {
            list.Sort();
        }
        public void AddBook()
        {
            Book b = new Book();
            b.Input();
            list.Add(b);
        }
        public void ShowList()
        {
            foreach (Book b in list)
                b.Show();
        }
        public void InputList()
        {
            int n;
            Console.Write("So luong: ");
            
            n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                AddBook();
                n--;
            }
        }
    }
}
