using System;
using System.Collections.Generic;

namespace MyBookLibrary
{
    public class Book
    {
        private string id;
        private string name;
        private string publisher;
        private int price;

        public Book()
        {
        }

        public Book(string id, string name, string publisher, int price)
        {
            this.Id = id;
            this.Name = name;
            this.Publisher = publisher;
            this.Price = price;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public int Price { get => price; set => price = value; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Publisher: {Publisher}, Price: {Price}";

    }
    public class MyBook
    {
        private readonly List<Book> listBook = new();


        public void AddBook()
        {
            string id;
            while (true)
            {
                Console.Write("ID: ");
                id = Console.ReadLine();
                if (listBook == null || listBook.Count == 0) break;
                bool flag = true;
                foreach (var item in listBook)
                {
                    if (item.Id == id) flag = false;
                }
                if (flag) break;
                Console.WriteLine("ID existed!");
            }
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Price: ");
            int price;
            while (!int.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Price must be number and must be greater than 0");
                Console.Write("Price: ");
            }
            listBook.Add(new(id, name, publisher, price));
            Console.WriteLine("Added!");
        }

        private int _findPosBookById(string id)
        {
            if (listBook == null || listBook.Count == 0) return -1;
            for (int i = 0; i < listBook.Count; i++)
            {
                if (listBook[i].Id == id) return i;
            }
            return -1;
        }
        public void UpdateABook()
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();
            int pos = _findPosBookById(id);
            if (pos > -1)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Publisher: ");
                string publisher = Console.ReadLine();
                Console.Write("Price: ");
                int price;
                while (!int.TryParse(Console.ReadLine(), out price) || price < 0)
                {
                    Console.WriteLine("Price must be number and must be greater than 0");
                    Console.Write("Price: ");
                }
                listBook[pos] = new(listBook[pos].Id, name, publisher, price);
                Console.WriteLine("Updated");
                return;
            }
            Console.WriteLine("Not found!");
        }

        public void DeleteABook()
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();
            int pos = _findPosBookById(id);
            if (pos > 0)
            {
                Console.WriteLine("Are you sure? Y/N");
                string check = Console.ReadLine();
                if (check.ToLower()[0] == 'y')
                {
                    listBook.RemoveAt(pos);
                    Console.WriteLine("Deleted");
                    return;
                }
                Console.WriteLine("Canceled!");
                return;

            }
            Console.WriteLine("Not found!");

        }

        public void ListBook()
        {
            if (listBook == null || listBook.Count == 0)
            {
                Console.WriteLine("Null");
                return;
            }
            foreach (var item in listBook)
            {
                Console.WriteLine(item);
            }
        }
    }
}
