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

Console.WriteLine("--------- Welcome to the Library ---------");
Console.WriteLine("\tMENU:");
Console.WriteLine("\t1. Add new item");
Console.WriteLine("\t2. Show library");
Console.WriteLine("\t3. Delete item");
Console.WriteLine("\t4. Sort all items");
Console.WriteLine("\t5. Search item");
Console.WriteLine("\t6. Show item info");
Console.WriteLine("\t7. Category info");
Console.WriteLine("\t8. Edit archive");
Console.WriteLine("\t9. Show obligors list by author");

Source item = new();

while (true)
{
	Console.Write("Enter your choice: ");
	int choice = Convert.ToInt32(Console.ReadLine());

	switch (choice)
	{
		case 1:
			Console.Write("Enter item title: ");
			item.Name = Console.ReadLine();
            Console.Write("Enter item type: ");
            item.Type = Console.ReadLine();
            Console.Write("Enter writing year: ");
			item.WritingYear = Convert.ToInt32(Console.ReadLine());
		break;
		case 2:
			Console.WriteLine("------Library--------");
            Console.WriteLine($"Type: {item.Type}");
            Console.WriteLine($"Name: {item.Name}");
			Console.WriteLine($"Writing Year: {item.WritingYear}");
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
}

public class Magazine : Source
{
	public int Id { get; set; }
}

public class Newspaper : Source
{
	public string Theme { get; set; }
}