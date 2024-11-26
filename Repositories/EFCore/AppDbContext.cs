using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories.EFCore;

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

