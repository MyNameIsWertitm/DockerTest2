using DotNetEnv;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? envPath = builder.Configuration["EnvPath"];

WebApplication app = builder.Build();

app.MapGet("/", (ILogger<Program> _logger) => 
{
    try
    {
        Env.Load(envPath);
        string? app_name = Environment.GetEnvironmentVariable("APP_NAME");
        _logger.LogInformation("logging Hello World!");
        return $"{app_name}";
    }
    catch (Exception ex) { return $"{ex.Message}"; }
});

app.Run();
