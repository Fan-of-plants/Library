/*12. ------------------ - Бібліотека
Створити програму для обліку книг, довідок про про наявність книг, журналів, газет. Реалізувати наступні сервіси:
	- Заповнення бази даних 
	- Перегляд даних про всі джерела
	- Доповнення бази даних записом джерела
	- Видалення джерела із бази даних
	- Упорядкування по полях: тип інформаційного джерела (книга, журнал, газета) і назва
	Пошук: наявність заданої книги (відомі автор і назва), наявність заданого журналу
	Вибірка: книги автора ХХ; книги певної категорії (фантастика, детектив тощо), журнали за певний рік (відомі рік і назва журналу)
	Обчислення: кількість книг деякої категорії
	Корекція: видалення зведень про газети за певний рік
	Табличний звіт: список боржників книг певного автора*/

using System.Text.Json;

Console.WriteLine("--------- Welcome to the Library ---------");
Console.WriteLine("\tMENU:");
Console.WriteLine("\t0. Exit");
Console.WriteLine("\t1. Add new book");
Console.WriteLine("\t2. Add new magazine");
Console.WriteLine("\t3. Add new newspaper");
Console.WriteLine("\t4. Show library");
Console.WriteLine("\t5. Delete item");
Console.WriteLine("\t6. Sort all items");
Console.WriteLine("\t7. Search book");
Console.WriteLine("\t8. Search magazine");
Console.WriteLine("\t9. Search newspaper");
Console.WriteLine("\t10. Category info");
Console.WriteLine("\t11. Save Library to file");
Console.WriteLine("\t12. Load Library from file");

List<Book> books = new();
List<Magazine> magazines = new();
List<Newspaper> newspapers = new();


while (true)
{
	Console.Write("Enter your choice: ");
	int choice = Convert.ToInt32(Console.ReadLine());

	switch (choice)
	{
        case 0:
            Environment.Exit(0);
            break;
        
		case 1:
			var newBook = new Book();
			
			Console.Write("Enter item title: ");
            newBook.Name = Console.ReadLine();
            Console.Write("Enter item type: ");
            newBook.Type = Console.ReadLine();
            Console.Write("Enter writing year: ");
            newBook.WritingYear = Convert.ToInt32(Console.ReadLine());

			books.Add(newBook);
			break;

        case 2:
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
            break;

        case 3:
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
            break;

        case 4:
			foreach (var item in books)
			{
				Console.WriteLine("------Library--------");
				Console.WriteLine($"Type: {item.Type}");
				Console.WriteLine($"Name: {item.Name}");
				Console.WriteLine($"Writing Year: {item.WritingYear}");
			}
			break;
            
            foreach (var item in magazines)
            {
                Console.WriteLine("------Library--------");
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Writing Year: {item.WritingYear}");
            }
            break;

            foreach (var item in newspapers)
            {
                Console.WriteLine("------Library--------");
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Writing Year: {item.WritingYear}");
            }
            break;

        case 5:
            for (int i = 0; i < books.Count; ++i)
                Console.WriteLine($"[{i}] Product: " + books[i].Name);

            Console.Write("Enter number to delete: ");
            int numToDelete = Convert.ToInt32(Console.ReadLine());

            if (numToDelete < 0 || numToDelete >= books.Count)
            {
                Console.WriteLine("Number out of range!");
                break;
            }

            books.RemoveAt(numToDelete);
            Console.WriteLine("Product deleted successfully!");
            break;

        case 7:
            Console.Write("Enter product name to find: ");
            string nameToFind = Console.ReadLine().Trim();

            var foundItem = books.Find(x => x.Name.Contains(nameToFind));

            if (foundItem == null)
            {
                Console.WriteLine("Product not found!");
                break;
            }

            foundItem.Show();
            break;

        case 11:
			string JsonToSave = JsonSerializer.Serialize(books);
			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
			File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/books_db.json", JsonToSave);

            string JsonToSave2 = JsonSerializer.Serialize(magazines);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/magazines_db.json", JsonToSave);

            string JsonToSave3 = JsonSerializer.Serialize(newspapers);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/newspapers_db.json", JsonToSave);
            break; 
		
		case 12:
			string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/books_db.json");
			books = JsonSerializer.Deserialize<List<Book>>(jsonToLoad);

            string jsonToLoad2 = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/magazines_db.json");
            magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonToLoad2);
            break;
	}
}
