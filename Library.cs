using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

/*rjvty*/

namespace LibraryApp
{
    public class Library
    {
        List<Book> books = new();
        List<Magazine> magazines = new();
        List<Newspaper> newspapers = new();

        public void AddBook()
        {
            var newBook = new Book();

            Console.Write("Enter item title: ");
            newBook.Name = Console.ReadLine();
            Console.Write("Enter item type: ");
            newBook.Type = Console.ReadLine();
            Console.Write("Enter writing year: ");
            newBook.WritingYear = Convert.ToInt32(Console.ReadLine());

            books.Add(newBook);
        }

        public void AddMagazine()
        {
            var newMagazine = new Magazine();

            Console.Write("Enter item title: ");
            newMagazine.Name = Console.ReadLine();
            Console.Write("Enter item type: ");
            newMagazine.Type = Console.ReadLine();
            Console.Write("Enter writing year: ");
            newMagazine.WritingYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter magazine ID: ");
            newMagazine.Id = Convert.ToInt32(Console.ReadLine());

            magazines.Add(newMagazine);
        }

        public void AddNewspaper()
        {
            var newNewspaper = new Newspaper();

            Console.Write("Enter item title: ");
            newNewspaper.Name = Console.ReadLine();
            Console.Write("Enter item type: ");
            newNewspaper.Type = Console.ReadLine();
            Console.Write("Enter writing year: ");
            newNewspaper.WritingYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter magazine ID: ");
            newNewspaper.Theme = Console.ReadLine();

            newspapers.Add(newNewspaper);
        }

        public void Show()
        {
            foreach (var item in books)
            {
                Console.WriteLine("------Library--------");
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Writing Year: {item.WritingYear}");
            }

            foreach (var item in magazines)
            {
                Console.WriteLine("------Library--------");
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Writing Year: {item.WritingYear}");
            }

            foreach (var item in newspapers)
            {
                Console.WriteLine("------Library--------");
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Theme: {item.Theme}");
            }
        }

        public void Delete()
        {
            for (int i = 0; i < books.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + books[i].Name);

            Console.Write("Enter number to delete: ");
            int numToDelete = Convert.ToInt32(Console.ReadLine());

            if (numToDelete < 0 || numToDelete >= books.Count)
            {
                Console.WriteLine("Number out of range!");
                return;
            }

            books.RemoveAt(numToDelete);
            Console.WriteLine("Product deleted successfully!");

            for (int i = 0; i < magazines.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + magazines[i].Name);

            Console.Write("Enter number to delete: ");
            int numToDeleteM = Convert.ToInt32(Console.ReadLine());

            if (numToDeleteM < 0 || numToDelete >= magazines.Count)
            {
                Console.WriteLine("Number out of range!");
                return;
            }

            magazines.RemoveAt(numToDeleteM);
            Console.WriteLine("Product deleted successfully!");

            for (int i = 0; i < newspapers.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + newspapers[i].Name);

            Console.Write("Enter number to delete: ");
            int numToDeleteN = Convert.ToInt32(Console.ReadLine());

            if (numToDeleteN < 0 || numToDelete >= newspapers.Count)
            {
                Console.WriteLine("Number out of range!");
                return;
            }

            newspapers.RemoveAt(numToDeleteN);
            Console.WriteLine("Product deleted successfully!");
        }

        public void SearchBook()
        {
            Console.Write("Enter product name to find: ");
            string nameToFind = Console.ReadLine().Trim();

            var foundItem = books.Find(x => x.Name.Contains(nameToFind));

            if (foundItem == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            foundItem.Show();
        }

        public void Save()
        {
            string JsonToSave = JsonSerializer.Serialize(books);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/books_db.json", JsonToSave);

            string JsonToSave2 = JsonSerializer.Serialize(magazines);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/magazines_db.json", JsonToSave);

            string JsonToSave3 = JsonSerializer.Serialize(newspapers);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/newspapers_db.json", JsonToSave);
        }

        public void Load()
        {
            string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/books_db.json");
            books = JsonSerializer.Deserialize<List<Book>>(jsonToLoad);

            string jsonToLoad2 = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/magazines_db.json");
            magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonToLoad2);

            string jsonToLoad3 = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/newspapers_db.json");
            newspapers = JsonSerializer.Deserialize<List<Newspaper>>(jsonToLoad3);
        }
    }
}
