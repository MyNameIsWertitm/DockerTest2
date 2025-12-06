using DotNetEnv;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.MapGet("/", (ILogger<Program> _logger) => 
{
    try
    {
        string? envPath = builder.Configuration["EnvPath"];
        Console.WriteLine(envPath);
        Env.Load(envPath);
        string? app_name = Environment.GetEnvironmentVariable("APP_NAME") + " " + envPath;
        _logger.LogInformation("logging Hello World!");
        return $"{app_name}";
    }
    catch (Exception ex) { return $"{ex.Message}"; }
});

app.Run();
