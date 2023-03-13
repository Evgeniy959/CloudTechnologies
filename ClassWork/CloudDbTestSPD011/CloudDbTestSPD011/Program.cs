using CloudDbTestSPD011.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();  // добавить DbContext (DI)

var app = builder.Build();

app.MapGet("/ping", () => "pong");

// тестирование БД
// получить все
app.MapGet("/all", async (ApplicationDbContext db) =>
{
    return await db.ExampleTable.ToListAsync();
});

// добавить запись
app.MapPost("/add", async (ExampleTable data, ApplicationDbContext db) =>
{
    db.ExampleTable.Add(data);
    await db.SaveChangesAsync();
    return data;
});

app.Run();
