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

public class Source
{
	public string Name { get; set; }
	public int WritingYear { get; set; }
	public string Type { get; set; }
   
}
