var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (ILogger<Program> _logger) => { _logger.LogInformation("logging Hello World!"); return "Hello World!"; });

app.Run();
