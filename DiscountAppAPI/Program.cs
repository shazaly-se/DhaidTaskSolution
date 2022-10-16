using DiscountAppAPI;
using DiscountAppAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_Discount_NAME"); 
var dbPassword =  Environment.GetEnvironmentVariable("DB_PASSWORD");  
var connectionString = $"Data Source = {dbHost}; Initial Catalog={dbName}; User ID=shazaly;Password={dbPassword}";

builder.Services.AddDbContext<DiscountCodeDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddMediatR(typeof(DiscountCode).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
