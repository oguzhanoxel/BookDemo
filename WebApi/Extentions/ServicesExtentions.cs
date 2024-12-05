using Entities.DTOs.Book;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extentions;

public static class ServicesExtentions
{
	public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration) =>
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

	public static void AddRepositoryManager(this IServiceCollection services) =>
		services.AddScoped<IRepositoryManager, RepositoryManager>();

	public static void AddServiceManager(this IServiceCollection services) =>
		services.AddScoped<IServiceManager, ServiceManager>();

	public static void AddLoggerManager(this IServiceCollection services) =>
		services.AddSingleton<ILoggerService, LoggerManager>();

	public static void AddActionFilters(this IServiceCollection services)
	{
		services.AddScoped<ValidationFilterAttribute>();
		services.AddSingleton<LogFilterAttribute>();
	}

	public static void AddCorsConfig(this IServiceCollection services)
	{
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader()
			.WithExposedHeaders("X-Pagination"));
		});
	}

	public static void AddDataShaper(this IServiceCollection services)
	{
		services.AddScoped<IDataShaper<BookResponseDto>, DataShaper<BookResponseDto>>();
	}
}
