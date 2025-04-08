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
			foreach (var item in books)
			{
				Console.WriteLine("------Library--------");
				Console.WriteLine($"Type: {item.Type}");
				Console.WriteLine($"Name: {item.Name}");
				Console.WriteLine($"Writing Year: {item.WritingYear}");
			}
			break;
        
		case 3:
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

        case 5:
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

        case 7:
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
		
		case 8:
			string jsonToLoad = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/books_db.json");
			books = JsonSerializer.Deserialize<List<Book>>(jsonToLoad);

            string jsonToLoad2 = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/magazines_db.json");
            magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonToLoad2);
            break;
	}
}
public class Source
{
	public string Name { get; set; }
	public int WritingYear { get; set; }
	public string Type { get; set; }
   
}
public class Book:Source
{
	public string Author { get; set; }
	public string Genre { get; set; }
	public string Description { get; set; }
    public void Show()
    {
        Console.WriteLine("------- Product ---------");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Category: {this.Type}");
        Console.WriteLine($"Writing Year: {this.WritingYear}");
        Console.WriteLine($"Author: {this.Author}");
        Console.WriteLine($"Genre: {this.Genre}");
    }
}

public class Magazine : Source
{
	public int Id { get; set; }
    public void Show()
    {
        Console.WriteLine("------- Product ---------");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Category: {this.Type}");
        Console.WriteLine($"Writing Year: {this.WritingYear}");
        Console.WriteLine($"Id: {this.Id}");
    }
}

public class Newspaper : Source
{
	public string Theme { get; set; }
    public void Show()
    {
        Console.WriteLine("------- Product ---------");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Category: {this.Type}");
        Console.WriteLine($"Writing Year: {this.WritingYear}");
        Console.WriteLine($"Theme: {this.Theme}");
    }
}