namespace Legerity.Features.Generators.Windows;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Infrastructure.IO;
using Generators;
using Models;
using Infrastructure.Extensions;
using MADE.Collections.Compare;
using MADE.Data.Validation.Extensions;
using Scriban;
using Serilog;

internal class XamlPageObjectGenerator : IPageObjectGenerator
{
    private const string XamlNamespace = "http://schemas.microsoft.com/winfx/2006/xaml";

    private const string BaseElementType = "WebElement";

    private static readonly GenericEqualityComparer<string> s_simpleStringComparer = new(s => s.ToLower());

    public static IEnumerable<string> SupportedCoreWindowsElements => new List<string>
    {
        "AppBarButton",
        "AppBarToggleButton",
        "AutoSuggestBox",
        "Button",
        "CalendarDatePicker",
        "CalendarView",
        "CheckBox",
        "ComboBox",
        "CommandBar",
        "DatePicker",
        "FlipView",
        "GridView",
        "Hub",
        "HyperlinkButton",
        "InfoBar",
        "InkToolbar",
        "ListBox",
        "ListView",
        "MenuBar",
        "MenuBarItem",
        "MenuFlyoutItem",
        "MenuFlyoutSubItem",
        "NavigationView",
        "NavigationViewItem",
        "NumberBox",
        "PasswordBox",
        "Pivot",
        "ProgressBar",
        "ProgressRing",
        "RadioButton",
        "RatingControl",
        "ScrollViewer",
        "Slider",
        "TabView",
        "TextBlock",
        "TextBox",
        "TimePicker",
        "ToggleButton",
        "ToggleSwitch"
    };

    public async Task GenerateAsync(string ns, string inputPath, string outputPath)
    {
        IEnumerable<string>? filePaths = GetXamlFilePaths(inputPath)?.ToList();

        if (filePaths == null || !filePaths.Any())
        {
            Log.Warning("No XAML files found in {InputPath}", inputPath);
            return;
        }

        foreach (var filePath in filePaths)
        {
            Log.Information($"Processing {filePath}...");

            await using var fileStream = File.Open(filePath, FileMode.Open);
            var xaml = XDocument.Load(fileStream);

            if (xaml.Root != null && xaml.Root.Name.ToString().Contains("Page"))
            {
                var templateData =
                    new GeneratorTemplateData(ns, Path.GetFileNameWithoutExtension(filePath), BaseElementType);

                Log.Information($"Generating template for {templateData}...");

                var elements = FlattenElements(xaml.Root.Elements());
                foreach (var element in elements)
                {
                    var automationId = element.Attribute("AutomationProperties.AutomationId")?.Value;
                    var uid = element.Attribute(XName.Get("Uid", XamlNamespace))?.Value;
                    var name = element.Attribute(XName.Get("Name", XamlNamespace))?.Value;

                    var byLocatorType = GetByLocatorType(uid, automationId, name);

                    if (byLocatorType == null || byLocatorType.IsNullOrWhiteSpace())
                    {
                        continue;
                    }

                    var wrapperAutomationId = uid ?? automationId;
                    var byQueryValue = wrapperAutomationId ?? name;

                    if (byQueryValue == null || byQueryValue.IsNullOrWhiteSpace())
                    {
                        continue;
                    }

                    var uiElement = new UiElement(
                        GetElementWrapperType(element.Name.LocalName),
                        byQueryValue.Capitalize(),
                        byLocatorType,
                        byQueryValue);

                    Log.Information($"Element found on page - {uiElement}");

                    templateData.Trait = uiElement;
                    templateData.Elements.Add(uiElement);
                }

                await GeneratePageObjectClassFileAsync(templateData, outputPath);
            }
            else
            {
                Log.Warning($"Skipping {filePath} as a page was not detected");
            }
        }
    }

    private static async Task GeneratePageObjectClassFileAsync(
        GeneratorTemplateData templateData,
        string outputFolder)
    {
        var pageObjectTemplate = Template.Parse(await EmbeddedResourceLoader.ReadAsync("Legerity.Templates.WindowsPageObject.template"));

        var outputFile = $"{templateData.Page}.cs";

        Log.Information($"Generating {outputFile} page object file...");
        var result = await pageObjectTemplate.RenderAsync(templateData);

        var output = File.Create(Path.Combine(outputFolder, outputFile));
        var outputWriter = new StreamWriter(output, Encoding.UTF8);

        await using (outputWriter)
        {
            await outputWriter.WriteAsync(result);
        }
    }

    private static string? GetByLocatorType(string? uid, string? automationId, string? name)
    {
        if ((uid != null && !uid.IsNullOrWhiteSpace()) || (automationId != null && !automationId.IsNullOrWhiteSpace()))
        {
            return "AutomationId";
        }

        return name != null && !name.IsNullOrWhiteSpace() ? "Name" : null;
    }

    private static IEnumerable<string>? GetXamlFilePaths(string searchFolder)
    {
        string[]? filePaths = default;

        try
        {
            filePaths = Directory.GetFiles(searchFolder, "*.xaml", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException)
        {
            Log.Error("An error occurred while retrieving XAML files for processing");
        }

        return filePaths;
    }

    private static string GetElementWrapperType(string elementName)
    {
        return SupportedCoreWindowsElements.Contains(elementName, s_simpleStringComparer) ? elementName : BaseElementType;
    }

    private IEnumerable<XElement> FlattenElements(IEnumerable<XElement> elements)
    {
        return elements.SelectMany(c => FlattenElements(c.Elements())).Concat(elements);
    }
}
