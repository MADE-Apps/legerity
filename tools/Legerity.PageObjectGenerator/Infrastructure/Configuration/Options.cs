namespace Legerity.Infrastructure.Configuration;

using System;
using CommandLine;

internal class Options
{
    [Option('i', "input",
        HelpText =
            "The path to the folder where platform pages exist that will be generating page objects for. Default to the executing folder.")]
    public string InputPath { get; set; } = Environment.CurrentDirectory;

    [Option('o', "output",
        HelpText =
            "The path to the folder where the generated class files should be stored. Default to the 'Generated' folder in the executing folder.")]
    public string OutputPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "Generated");

    [Option('n', "namespace",
        HelpText =
            "The namespace to apply to the output page objects. Default to 'LegerityTests.Pages'.")]
    public string Namespace { get; set; } = "LegerityTests.Pages";

    [Option('p', "platform", Required = true, HelpText = "The platform that will be generating page objects for.")]
    public PlatformType PlatformType { get; set; }
}
