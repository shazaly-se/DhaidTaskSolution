using Microsoft.EntityFrameworkCore;
using ProductAppApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");// "localhost";
var dbName = Environment.GetEnvironmentVariable("DB_Product_Name"); 
var dbPassword =  Environment.GetEnvironmentVariable("DB_PASSWORD");  
var connectionString = $"Data Source = {dbHost}; Initial Catalog={dbName}; User ID=shazaly;Password={dbPassword}";

builder.Services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
