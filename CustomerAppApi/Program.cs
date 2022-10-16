using CustomerAppApi;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CustomerAppApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");// "localhost";
var dbName = Environment.GetEnvironmentVariable("DB_Customer_NAME"); //"customerDb";
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");  //"Andandy@123";
var connectionString = $"Data Source = {dbHost}; Initial Catalog={dbName}; User ID=shazaly;Password={dbPassword}";
//"Server=.;Database=EmployeeDB;Integrated Security=True";
//$"Data Source = {dbHost}; Initial Catalog={dbName}; User ID=sa;Password={dbPassword}";
builder.Services.AddDbContext<CustomerDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddMediatR(typeof(Customer).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
