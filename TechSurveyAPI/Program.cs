using Microsoft.EntityFrameworkCore;
using TechSurveyAPI;
using Repository.Models;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddCORSService();
builder.Services.ConfigureLoggerService();
builder.Services.AddControllers();
builder.Services.AddDbContext<TechnologyStackContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TSDatabase"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureRepositoryWrapper();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("_myAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
