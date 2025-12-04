using dotenv.net;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string envPath = builder.Configuration["EnvPath"];
DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { envPath }));

WebApplication app = builder.Build();

app.MapGet("/", (ILogger<Program> _logger) => 
{
    try
    {
        var envVar = DotEnv.Read();
        _logger.LogInformation("logging Hello World!");
        return $"{envVar["APP_NAME"]}";
    }
    catch (Exception ex) { return $"{ex.Message}"; }
});

app.Run();
