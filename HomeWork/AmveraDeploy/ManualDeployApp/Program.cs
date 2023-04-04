var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Пример приложения которое будем деплоить

// корневой обработчик
app.MapGet("/", () => new { Time = DateTime.Now, Message = "Server is running..." });

// ping
app.MapGet("/ping", () => new { Time = DateTime.Now, Message = "pong" });

// info
app.MapGet("/info", () => new { Version = Environment.Version, UserName = Environment.UserName, ProcessorCount = Environment.ProcessorCount, ProcessorArchitecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"), ProcessorIdentifier = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") });

app.Run();
