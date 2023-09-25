using System.Reflection;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Middlewares;
using MovieArchiveAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context Service
builder.Services.AddDbContext<MovieArchiveDBContext>(options => options.UseInMemoryDatabase(databaseName: "MovieArchiveDB"));

// Logger Services
builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();
builder.Services.AddSingleton<ILoggerService,DBLogger>();

// Automapper Service
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

// Middleware
app.UseMovieArchive();

app.MapControllers();


app.Run();
