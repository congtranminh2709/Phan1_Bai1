using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2QlBook
{
    internal class Book : IBook, IComparable<Book>
    {
        private string title;
        private string author;
        private string publisher;
        public int year;
        public string isbn;

        private ArrayList chapter = new ArrayList();

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < chapter.Count)
                    return (string)chapter[index];
                else
                    throw new NotImplementedException();
            }
            set
            {
                if (index >= 0 && index < chapter.Count)
                    chapter[index] = value;
                else if (index == chapter.Count)
                    chapter.Add(value);
                else
                    throw new NotImplementedException();
            }
        }
     
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string ISBN { get => isbn; set => isbn = value; }
        public int Year { get => year; set => year = value; }
       

        public void Show()
        {
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Publisher: " + publisher);
            Console.WriteLine("Year: " + year);
            Console.WriteLine("ISBN: " + isbn);
            for (int i = 0; i < chapter.Count; i++)
            Console.WriteLine("\t{0}:{1}", i + 1, chapter[i]);
            Console.WriteLine("---------------------\n");
        }
        public void Input()
        {
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write("Author: ");
            author = Console.ReadLine();
            Console.Write("Publisher: ");
            publisher = Console.ReadLine();
            Console.Write("ISBN: ");
            isbn = Console.ReadLine();
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("\nNhap so luong: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < quantity; i++)
            {
                Console.Write("\nNhap ten chuong: ");
                chapter.Add(Console.ReadLine());
            }
        }

        public int CompareTo(Book other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
}