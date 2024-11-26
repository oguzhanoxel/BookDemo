using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace WebApi.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	public AppDbContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<AppDbContext>()
			.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
			x => x.MigrationsAssembly("WebApi"));

		return new AppDbContext(builder.Options);
	}
}
