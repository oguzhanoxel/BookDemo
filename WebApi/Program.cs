using Microsoft.AspNetCore.Mvc;
using NLog;
using Presentation.ActionFilters;
using Services.Contracts;
using WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup()
	.LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers()
	.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
	.AddNewtonsoftJson();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddRepositoryManager();
builder.Services.AddServiceManager();
builder.Services.AddLoggerManager();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddActionFilters();
builder.Services.AddCorsConfig();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();

app.AddExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
