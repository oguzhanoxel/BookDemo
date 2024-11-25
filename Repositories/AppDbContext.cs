using BookDemo.Models;
using BookDemo.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace BookDemo.Repositories;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) :
		base(options)
	{
		
	}

	public DbSet<Book> Books { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.ApplyConfiguration(new BookConfig());
	}
}
