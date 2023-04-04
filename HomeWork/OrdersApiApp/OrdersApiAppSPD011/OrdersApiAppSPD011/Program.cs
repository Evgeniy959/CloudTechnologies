using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.ClientService;
using OrdersApiAppSPD011.Service.InfoService;
using OrdersApiAppSPD011.Service.OrderProductService;
using OrdersApiAppSPD011.Service.OrderService;
using OrdersApiAppSPD011.Service.ÑheckService;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddTransient<IDaoEntity<Client>, DbDaoClient>();
builder.Services.AddTransient<IDaoEntity<Product>, DbDaoProduct>();
builder.Services.AddTransient<IDaoEntity<Order>, DbDaoOrder>();
builder.Services.AddTransient<IDaoEntity<OrderProduct>, DbDaoOrderProduct>();
builder.Services.AddTransient<IDaoInfo, DbDaoInfo>();
builder.Services.AddTransient<IDaoCheck, DbDaoCheck>();

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();
app.MapControllers();

app.MapGet("/ping", () => new {Time = DateTime.Now, Message = "pong"});

app.Run();
