namespace Legerity.Infrastructure.Logging;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

internal static class SerilogConfigurator
{
    private const string LoggingMessageTemplate = "[{Level}] {Message:lj}{NewLine}";

    public static void ConfigureLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(outputTemplate: LoggingMessageTemplate,
                theme: AnsiConsoleTheme.Literate,
                restrictedToMinimumLevel: LogEventLevel.Debug)
            .CreateLogger();
    }
}