﻿/*12. ------------------ - Бібліотека
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
