using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TodoApp.Application;
using TodoApp.Infrastructure;
using TodoApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

const string connectionString = "DataSource=db.sqlite3; cache=shared;";
builder.Services.AddDbContext<TodoDbContext>(opts => opts.UseSqlite(connectionString));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();


app.Run();