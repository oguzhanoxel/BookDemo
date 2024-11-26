namespace Entities;

public class Book
{
	public int Id { get; set; }
	public string Title { get; set; }
	public decimal Price { get; set; }

	public static explicit operator Book(UpdateBookDto v)
	{
		return new Book() { Title = v.Title, Price = v.Price };
	}

	public static explicit operator Book(CreateBookDto v)
	{
		return new Book() { Title = v.Title, Price = v.Price };
	}
}

public record UpdateBookDto(string Title, decimal Price);
public record CreateBookDto(string Title, decimal Price);
