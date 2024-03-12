namespace Legerity;

using System.IO;
using System.Threading.Tasks;
using CommandLine;
using Features.Generators.Android;
using Features.Generators.Windows;
using Infrastructure.Configuration;
using Infrastructure.Logging;
using Features.Generators;
using Serilog;

public class Program
{
    public static async Task Main(string[] args)
    {
        SerilogConfigurator.ConfigureLogging();
        await Parser.Default.ParseArguments<Options>(args)
            .WithNotParsed(errors =>
            {
                foreach (var error in errors)
                {
                    if (error.Tag == ErrorType.MissingRequiredOptionError)
                    {
                        Log.Error("Missing required option: {0}", error.ToString());
                    }
                }
            })
            .WithParsedAsync(async options =>
            {
                Log.Information($"Locating {options.PlatformType:G} page files in {options.InputPath}...");

                IPageObjectGenerator? pageObjectGenerator = default;

                switch (options.PlatformType)
                {
                    case PlatformType.Windows:
                        pageObjectGenerator = new XamlPageObjectGenerator();
                        break;
                    case PlatformType.Android:
                        pageObjectGenerator = new AxmlPageObjectGenerator();
                        break;
                    case PlatformType.Web:
                        Log.Warning("Web page object generation is not currently supported!");
                        break;
                    case PlatformType.IOS:
                        Log.Warning("iOS page object generation is not currently supported!");
                        break;
                    default:
                        Log.Warning("Cannot generate Legerity page objects for an unsupported platform type!");
                        return;
                }

                if (pageObjectGenerator == default)
                {
                    return;
                }

                if (!Directory.Exists(options.OutputPath))
                {
                    Directory.CreateDirectory(options.OutputPath);
                }

                await pageObjectGenerator.GenerateAsync(options.Namespace, options.InputPath, options.OutputPath);

                Log.Information("Finished generating Legerity page objects!");
            });
    }
}
