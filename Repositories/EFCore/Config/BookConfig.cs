using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories.EFCore.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.HasData(
			new Book { Id = 1, Title = "Moby Dick", Price = 15.99m },
			new Book { Id = 2, Title = "Pride and Prejudice", Price = 9.49m },
			new Book { Id = 3, Title = "War and Peace", Price = 20.00m },
			new Book { Id = 4, Title = "The Great Gatsby", Price = 10.99m },
			new Book { Id = 5, Title = "1984", Price = 14.99m },
			new Book { Id = 6, Title = "To Kill a Mockingbird", Price = 12.49m },
			new Book { Id = 7, Title = "The Catcher in the Rye", Price = 8.99m },
			new Book { Id = 8, Title = "The Hobbit", Price = 13.49m },
			new Book { Id = 9, Title = "Fahrenheit 451", Price = 11.99m },
			new Book { Id = 10, Title = "Brave New World", Price = 15.00m },
			new Book { Id = 11, Title = "Crime and Punishment", Price = 18.49m },
			new Book { Id = 12, Title = "The Brothers Karamazov", Price = 19.99m },
			new Book { Id = 13, Title = "The Odyssey", Price = 10.99m },
			new Book { Id = 14, Title = "The Iliad", Price = 12.99m },
			new Book { Id = 15, Title = "Jane Eyre", Price = 9.99m },
			new Book { Id = 16, Title = "Wuthering Heights", Price = 8.49m },
			new Book { Id = 17, Title = "Great Expectations", Price = 10.49m },
			new Book { Id = 18, Title = "Oliver Twist", Price = 9.49m },
			new Book { Id = 19, Title = "Les Misérables", Price = 22.00m },
			new Book { Id = 20, Title = "Anna Karenina", Price = 17.99m },
			new Book { Id = 21, Title = "A Tale of Two Cities", Price = 11.49m },
			new Book { Id = 22, Title = "Don Quixote", Price = 23.99m },
			new Book { Id = 23, Title = "The Divine Comedy", Price = 21.99m },
			new Book { Id = 24, Title = "The Old Man and the Sea", Price = 7.99m },
			new Book { Id = 25, Title = "Ulysses", Price = 19.99m },
			new Book { Id = 26, Title = "The Sound and the Fury", Price = 14.49m },
			new Book { Id = 27, Title = "Beloved", Price = 12.99m },
			new Book { Id = 28, Title = "Slaughterhouse-Five", Price = 13.99m },
			new Book { Id = 29, Title = "The Sun Also Rises", Price = 11.99m },
			new Book { Id = 30, Title = "On the Road", Price = 10.99m },
			new Book { Id = 31, Title = "Of Mice and Men", Price = 8.99m },
			new Book { Id = 32, Title = "Catch-22", Price = 15.49m },
			new Book { Id = 33, Title = "Lolita", Price = 16.99m },
			new Book { Id = 34, Title = "Middlemarch", Price = 14.99m },
			new Book { Id = 35, Title = "Frankenstein", Price = 9.49m },
			new Book { Id = 36, Title = "Dracula", Price = 10.49m },
			new Book { Id = 37, Title = "Rebecca", Price = 11.49m },
			new Book { Id = 38, Title = "The Picture of Dorian Gray", Price = 10.99m },
			new Book { Id = 39, Title = "Sense and Sensibility", Price = 9.99m },
			new Book { Id = 40, Title = "Persuasion", Price = 8.99m },
			new Book { Id = 41, Title = "Emma", Price = 9.49m },
			new Book { Id = 42, Title = "A Christmas Carol", Price = 7.49m },
			new Book { Id = 43, Title = "David Copperfield", Price = 12.99m },
			new Book { Id = 44, Title = "The Scarlet Letter", Price = 8.99m },
			new Book { Id = 45, Title = "Mansfield Park", Price = 9.49m },
			new Book { Id = 46, Title = "Northanger Abbey", Price = 8.49m },
			new Book { Id = 47, Title = "Bleak House", Price = 14.99m },
			new Book { Id = 48, Title = "Hard Times", Price = 10.49m },
			new Book { Id = 49, Title = "Dombey and Son", Price = 12.49m },
			new Book { Id = 50, Title = "Little Women", Price = 11.99m }
		);
	}
}
