using NLog;
using WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup()
	.LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers()
	.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
	.AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddRepositoryManager();
builder.Services.AddServiceManager();
builder.Services.AddLoggerManager();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
