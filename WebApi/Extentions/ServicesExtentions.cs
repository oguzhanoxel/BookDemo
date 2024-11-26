﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extentions;

public static class ServicesExtentions
{
	public static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("SqlConnection"))
		);
	}

	public static void AddRepositoryManager(this IServiceCollection services)
	{
		services.AddScoped<IRepositoryManager, RepositoryManager>();
	}

	public static void AddServiceManager(this IServiceCollection services)
	{
		services.AddScoped<IServiceManager, ServiceManager>();
	}
}