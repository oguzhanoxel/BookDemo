using BookDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDemo.Repositories.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.HasData(
			new Book { Id = 1, Title = "Moby Dick", Price = 15.99m },
			new Book { Id = 2, Title = "Pride and Prejudice", Price = 9.49m },
			new Book { Id = 3, Title = "War and Peace", Price = 20.00m }
		);
	}
}
