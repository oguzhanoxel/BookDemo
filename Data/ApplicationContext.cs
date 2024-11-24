using BookDemo.Models;

namespace BookDemo.Data;

public static class ApplicationContext
{
	public static List<Book> Books { get; set; }

	static ApplicationContext()
	{

		Books = new List<Book>()
		{
			new Book { Id = 1, Title = "Moby Dick", Price = 15.99m },
			new Book { Id = 2, Title = "Pride and Prejudice", Price = 9.49m },
			new Book { Id = 3, Title = "War and Peace", Price = 20.00m }
		};
	}
}
