using Legerity.WindowsDriver.Automation;
using Legerity.WindowsDriver.Endpoints;
using Legerity.WindowsDriver.Middleware;

if (!OperatingSystem.IsWindows())
{
    Console.Error.WriteLine("Legerity Windows Driver requires Windows.");
    return 1;
}

var port = 4723;

for (int i = 0; i < args.Length; i++)
{
    if (args[i] is "--port" or "-p" && i + 1 < args.Length && int.TryParse(args[i + 1], out var p))
    {
        port = p;
    }
}

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls($"http://localhost:{port}");
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

app.UseMiddleware<WebDriverErrorMiddleware>();

var sessionManager = new SessionManager();
app.MapWebDriverRoutes(sessionManager);

Console.WriteLine($"Legerity Windows Driver listening on http://localhost:{port}");
Console.WriteLine("Press Ctrl+C to stop.");

app.Run();

return 0;
