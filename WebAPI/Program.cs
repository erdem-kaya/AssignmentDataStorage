using Business.Interfaces;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\AssignmentDataStorage\Data\Databases\assignment_database.mdf;Integrated Security=True;Connect Timeout=30"));
builder.Services.AddScoped<ICompanyRepository, ICompanyRepository>();
builder.Services.AddScoped<ICompanyService, ICompanyService>();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
