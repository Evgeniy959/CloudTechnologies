using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;
using �ountriesGDP.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/all", async (ApplicationDbContext db) =>
{
    return await db.TableGDP.ToListAsync();
});

app.MapPost("/add", async (TableGDP data, ApplicationDbContext db) =>
{
    db.TableGDP.Add(data);
    await db.SaveChangesAsync();
    return data;
});
app.MapGet("/find", async (int id, ApplicationDbContext db) =>
{
    return await db.TableGDP.Where(x => x.Id == id).ToListAsync();
});
app.MapGet("/delete", async (int id, ApplicationDbContext db) =>
{
    TableGDP data = db.TableGDP.Find(id);
    if (data != null)
    {
        db.TableGDP.Remove(data);
        await db.SaveChangesAsync();
    }
    return await db.TableGDP.ToListAsync();
});

/*app.MapGet("/update", async (int rating, string country, string countryNew, double volumeGDP, ApplicationDbContext db) =>
{
    //TableGDP dataNew = db.TableGDP.Find(id);
    //TableGDP dataNew = db.TableGDP.Where(x => x.Country == country).FirstOrDefault();
    TableGDP dataNew = db.TableGDP.FirstOrDefault(x => x.Country == country);
    if (dataNew != null)
    {
        dataNew.Rating = rating;
        dataNew.Country = countryNew;
        dataNew.VolumeGDP = volumeGDP;
        await db.SaveChangesAsync();
    }
    return await db.TableGDP.ToListAsync();
});*/
app.MapPost("/update", async (TableGDP data, ApplicationDbContext db) =>
{
    TableGDP dataNew = db.TableGDP.Find(data.Id);
    if (dataNew != null)
    {
        dataNew.Rating = data.Rating;
        dataNew.Country = data.Country;
        dataNew.VolumeGDP = data.VolumeGDP;
        await db.SaveChangesAsync();
    }
    return await db.TableGDP.ToListAsync();
});

app.Run();
