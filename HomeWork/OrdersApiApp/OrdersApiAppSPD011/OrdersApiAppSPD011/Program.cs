using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service.ClientService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/ping", () => new {Time = DateTime.Now, Message = "pong"});

app.MapGet("/client/all", async (IDaoClient daoClient) =>
{
    return await daoClient.GetAllAsync();
});

app.MapPost("/client/add", async (Client client, IDaoClient daoClient) =>
{
    return await daoClient.AddAsync(client);
});

app.MapGet("/client/delete", async (int id, IDaoClient daoClient) =>
{
    return await daoClient.DeleteAsync(id);
});

app.MapGet("/client/find", async (int id, IDaoClient daoClient) =>
{
    return await daoClient.GetAsync(id);
});

app.MapPost("/client/update", async (Client client, IDaoClient daoClient) =>
{
    return await daoClient.UpdateAsync(client);
});

app.Run();
