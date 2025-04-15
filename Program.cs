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
			
			break;

        case 2:
            
            break;

        case 3:
            
            break;

        case 4:
			
            break;

        case 5:

            break;

        case 7:
            
            break;

        case 11:
			
            break; 
		
		case 12:
			
            break;
	}
}
