using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Database Context Dependency Injection */

var dbHost = "DESKTOP-G9NG7UR\\SQLEXPRESS";
var dbName = "dms_customer";
var dbPassword = "sa123";
//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var ConnectionString = $" Data Source={dbHost}; Initial Catalog={dbName};TrustServerCertificate=true; User ID=sa; Password={dbPassword}";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(ConnectionString));
/*-----*/

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
