namespace Legerity.WindowsDriver.Automation;

using System.Diagnostics;
using System.Text.Json;
using System.Xml;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using Legerity.WindowsDriver.Exceptions;
using Legerity.WindowsDriver.Models;

public sealed class DriverSession : IDisposable
{
    private readonly UIA3Automation _automation;
    private readonly Dictionary<string, AutomationElement> _knownElements = new();
    private int _elementCounter;
    private bool _disposed;

    public string Id { get; }
    public Application? Application { get; private set; }
    public AutomationElement? RootElement { get; private set; }
    public TimeSpan ImplicitWait { get; set; } = TimeSpan.Zero;
    public Dictionary<string, object> Capabilities { get; }

    public DriverSession(string id, Dictionary<string, object> capabilities)
    {
        Id = id;
        Capabilities = capabilities;
        _automation = new UIA3Automation();
    }

    public void LaunchApp(string appPath, string? appArguments)
    {
        if (string.IsNullOrEmpty(appPath))
        {
            throw new WebDriverException(WebDriverErrors.SessionNotCreated, "No app specified in capabilities.");
        }

        try
        {
            if (appPath.Contains('!'))
            {
                // UWP/MSIX PackageFamilyName!AppId format
                Application = Application.LaunchStoreApp(appPath);
            }
            else if (appPath.Equals("Root", StringComparison.OrdinalIgnoreCase))
            {
                // Desktop root session
                Application = null;
                RootElement = _automation.GetDesktop();
                return;
            }
            else
            {
                var processStartInfo = new ProcessStartInfo(appPath);
                if (!string.IsNullOrEmpty(appArguments))
                {
                    processStartInfo.Arguments = appArguments;
                }

                Application = Application.Launch(processStartInfo);
            }

            // Wait for main window
            var retry = Application.WaitWhileMainHandleIsMissing(TimeSpan.FromSeconds(30));
            if (!retry)
            {
                throw new WebDriverException(WebDriverErrors.SessionNotCreated, "Application main window did not appear within 30 seconds.");
            }

            RootElement = Application.GetMainWindow(_automation);
        }
        catch (WebDriverException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebDriverException(WebDriverErrors.SessionNotCreated, $"Failed to launch application: {ex.Message}");
        }
    }

    public void AttachToApp(int processId)
    {
        try
        {
            Application = Application.Attach(processId);
            RootElement = Application.GetMainWindow(_automation);
        }
        catch (Exception ex)
        {
            throw new WebDriverException(WebDriverErrors.SessionNotCreated, $"Failed to attach to process {processId}: {ex.Message}");
        }
    }

    public string RegisterElement(AutomationElement element)
    {
        // Check if we already have this element registered by runtime ID
        var runtimeId = element.Properties.RuntimeId.ValueOrDefault;
        if (runtimeId != null && runtimeId.Length > 0)
        {
            var runtimeIdStr = string.Join(".", runtimeId);
            foreach (var (key, value) in _knownElements)
            {
                var existingId = value.Properties.RuntimeId.ValueOrDefault;
                if (existingId != null && string.Join(".", existingId) == runtimeIdStr)
                {
                    return key;
                }
            }
        }

        var id = $"element-{Interlocked.Increment(ref _elementCounter)}";
        _knownElements[id] = element;
        return id;
    }

    public AutomationElement GetElement(string elementId)
    {
        if (!_knownElements.TryGetValue(elementId, out var element))
        {
            throw new WebDriverException(WebDriverErrors.NoSuchElement, $"Element not found: {elementId}", 404);
        }

        // Validate the element is still alive
        try
        {
            _ = element.Properties.ProcessId.Value;
        }
        catch
        {
            _knownElements.Remove(elementId);
            throw new WebDriverException(WebDriverErrors.StaleElementReference, $"Element is no longer attached to the DOM: {elementId}", 404);
        }

        return element;
    }

    public AutomationElement FindElement(string strategy, string value, AutomationElement? parent = null)
    {
        var searchRoot = parent ?? RootElement
            ?? throw new WebDriverException(WebDriverErrors.NoSuchWindow, "No root element available.");

        var deadline = DateTime.UtcNow + ImplicitWait;

        do
        {
            try
            {
                var element = FindElementCore(searchRoot, strategy, value);
                if (element != null)
                {
                    return element;
                }
            }
            catch (WebDriverException)
            {
                if (DateTime.UtcNow >= deadline)
                {
                    throw;
                }
            }

            if (DateTime.UtcNow < deadline)
            {
                Thread.Sleep(100);
            }
        }
        while (DateTime.UtcNow < deadline);

        // One final attempt
        var result = FindElementCore(searchRoot, strategy, value);
        if (result != null)
        {
            return result;
        }

        throw new WebDriverException(WebDriverErrors.NoSuchElement,
            $"No element found using strategy '{strategy}' with value '{value}'.", 404);
    }

    public AutomationElement[] FindElements(string strategy, string value, AutomationElement? parent = null)
    {
        var searchRoot = parent ?? RootElement
            ?? throw new WebDriverException(WebDriverErrors.NoSuchWindow, "No root element available.");

        var deadline = DateTime.UtcNow + ImplicitWait;

        do
        {
            var elements = FindElementsCore(searchRoot, strategy, value);
            if (elements.Length > 0)
            {
                return elements;
            }

            if (DateTime.UtcNow < deadline)
            {
                Thread.Sleep(100);
            }
        }
        while (DateTime.UtcNow < deadline);

        // One final attempt
        return FindElementsCore(searchRoot, strategy, value);
    }

    private AutomationElement? FindElementCore(AutomationElement searchRoot, string strategy, string value)
    {
        return strategy switch
        {
            "accessibility id" => searchRoot.FindFirstDescendant(cf => cf.ByAutomationId(value)),
            "name" => searchRoot.FindFirstDescendant(cf => cf.ByName(value)),
            "class name" or "className" => searchRoot.FindFirstDescendant(cf => cf.ByClassName(value)),
            "tag name" or "tagName" => searchRoot.FindFirstDescendant(cf => cf.ByLocalizedControlType(value)),
            "xpath" => FindByXPath(searchRoot, value, single: true)?.FirstOrDefault(),
            "css selector" => CssSelectorTranslator.FindFirst(searchRoot, value),
            _ => throw new WebDriverException(WebDriverErrors.InvalidArgument,
                $"Unsupported locator strategy: {strategy}", 400),
        };
    }

    private AutomationElement[] FindElementsCore(AutomationElement searchRoot, string strategy, string value)
    {
        return strategy switch
        {
            "accessibility id" => searchRoot.FindAllDescendants(cf => cf.ByAutomationId(value)),
            "name" => searchRoot.FindAllDescendants(cf => cf.ByName(value)),
            "class name" or "className" => searchRoot.FindAllDescendants(cf => cf.ByClassName(value)),
            "tag name" or "tagName" => searchRoot.FindAllDescendants(cf => cf.ByLocalizedControlType(value)),
            "xpath" => FindByXPath(searchRoot, value, single: false) ?? [],
            "css selector" => CssSelectorTranslator.FindAll(searchRoot, value),
            _ => throw new WebDriverException(WebDriverErrors.InvalidArgument,
                $"Unsupported locator strategy: {strategy}", 400),
        };
    }

    private AutomationElement[]? FindByXPath(AutomationElement root, string xpath, bool single)
    {
        // Build XML from UIA tree and evaluate XPath against it
        var xmlDoc = new XmlDocument();
        var elementMap = new Dictionary<XmlNode, AutomationElement>();
        BuildXmlTree(xmlDoc, xmlDoc, root, elementMap, maxDepth: 50);

        var navigator = xmlDoc.CreateNavigator()!;
        var nodeIterator = navigator.Select(xpath);

        var results = new List<AutomationElement>();
        while (nodeIterator.MoveNext())
        {
            var node = nodeIterator.Current!.UnderlyingObject as XmlNode;
            if (node != null && elementMap.TryGetValue(node, out var element))
            {
                results.Add(element);
                if (single)
                {
                    break;
                }
            }
        }

        return results.ToArray();
    }

    private static void BuildXmlTree(XmlDocument doc, XmlNode parentXml, AutomationElement element,
        Dictionary<XmlNode, AutomationElement> elementMap, int maxDepth, int currentDepth = 0)
    {
        if (currentDepth > maxDepth)
        {
            return;
        }

        var controlType = element.Properties.LocalizedControlType.ValueOrDefault ?? "Unknown";
        var className = element.Properties.ClassName.ValueOrDefault ?? "";
        var name = element.Properties.Name.ValueOrDefault ?? "";
        var automationId = element.Properties.AutomationId.ValueOrDefault ?? "";

        // Use ClassName as element name if valid XML name, otherwise use ControlType
        var elementName = !string.IsNullOrEmpty(className) && IsValidXmlName(className)
            ? className
            : SanitizeXmlName(controlType);

        XmlElement xmlElement;
        try
        {
            xmlElement = doc.CreateElement(elementName);
        }
        catch
        {
            xmlElement = doc.CreateElement("Element");
        }

        if (!string.IsNullOrEmpty(name))
        {
            xmlElement.SetAttribute("Name", name);
        }

        if (!string.IsNullOrEmpty(automationId))
        {
            xmlElement.SetAttribute("AutomationId", automationId);
        }

        if (!string.IsNullOrEmpty(className))
        {
            xmlElement.SetAttribute("ClassName", className);
        }

        xmlElement.SetAttribute("ControlType", controlType);

        var runtimeId = element.Properties.RuntimeId.ValueOrDefault;
        if (runtimeId != null)
        {
            xmlElement.SetAttribute("RuntimeId", string.Join(".", runtimeId));
        }

        parentXml.AppendChild(xmlElement);
        elementMap[xmlElement] = element;

        try
        {
            var children = element.FindAllChildren();
            foreach (var child in children)
            {
                BuildXmlTree(doc, xmlElement, child, elementMap, maxDepth, currentDepth + 1);
            }
        }
        catch
        {
            // Element tree may have inaccessible children
        }
    }

    private static bool IsValidXmlName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        try
        {
            XmlConvert.VerifyName(name);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static string SanitizeXmlName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "Element";
        }

        var sanitized = new char[name.Length];
        for (int i = 0; i < name.Length; i++)
        {
            sanitized[i] = char.IsLetterOrDigit(name[i]) || name[i] == '_' ? name[i] : '_';
        }

        var result = new string(sanitized);
        if (!char.IsLetter(result[0]) && result[0] != '_')
        {
            result = "_" + result;
        }

        return result;
    }

    public string GetPageSource()
    {
        var root = RootElement
            ?? throw new WebDriverException(WebDriverErrors.NoSuchWindow, "No root element available.");

        var xmlDoc = new XmlDocument();
        var elementMap = new Dictionary<XmlNode, AutomationElement>();
        BuildXmlTree(xmlDoc, xmlDoc, root, elementMap, maxDepth: 50);

        using var writer = new StringWriter();
        using var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { Indent = true });
        xmlDoc.WriteTo(xmlWriter);
        xmlWriter.Flush();
        return writer.ToString();
    }

    public string GetWindowHandle()
    {
        if (RootElement == null)
        {
            throw new WebDriverException(WebDriverErrors.NoSuchWindow, "No window available.");
        }

        var handle = RootElement.Properties.NativeWindowHandle.ValueOrDefault;
        return handle.ToString("X");
    }

    public string[] GetWindowHandles()
    {
        if (Application == null)
        {
            // Desktop session - return desktop handle
            return [GetWindowHandle()];
        }

        try
        {
            var windows = Application.GetAllTopLevelWindows(_automation);
            return windows.Select(w => w.Properties.NativeWindowHandle.Value.ToString("X")).ToArray();
        }
        catch
        {
            return [GetWindowHandle()];
        }
    }

    public void SwitchToWindow(string handle)
    {
        if (Application == null)
        {
            throw new WebDriverException(WebDriverErrors.NoSuchWindow, "Cannot switch windows in a desktop session.");
        }

        var targetHandle = IntPtr.Zero;
        try
        {
            targetHandle = new IntPtr(Convert.ToInt64(handle, 16));
        }
        catch
        {
            throw new WebDriverException(WebDriverErrors.InvalidArgument, $"Invalid window handle: {handle}", 400);
        }

        var windows = Application.GetAllTopLevelWindows(_automation);
        var target = windows.FirstOrDefault(w => w.Properties.NativeWindowHandle.Value == targetHandle);

        if (target == null)
        {
            throw new WebDriverException(WebDriverErrors.NoSuchWindow, $"No window with handle: {handle}", 404);
        }

        RootElement = target;
    }

    public void MaximizeWindow()
    {
        if (RootElement is Window window)
        {
            window.Patterns.Window.Pattern.SetWindowVisualState(WindowVisualState.Maximized);
        }
    }

    public ElementRect GetWindowRect()
    {
        if (RootElement == null)
        {
            throw new WebDriverException(WebDriverErrors.NoSuchWindow, "No window available.");
        }

        var bounds = RootElement.BoundingRectangle;
        return new ElementRect
        {
            X = (int)bounds.X,
            Y = (int)bounds.Y,
            Width = (int)bounds.Width,
            Height = (int)bounds.Height
        };
    }

    public void CloseWindow()
    {
        if (RootElement is Window window)
        {
            window.Close();
        }
    }

    public byte[] TakeScreenshot()
    {
        if (RootElement == null)
        {
            throw new WebDriverException(WebDriverErrors.NoSuchWindow, "No root element available.");
        }

        var capture = FlaUI.Core.Capturing.Capture.Element(RootElement);
        using var stream = new MemoryStream();
        capture.Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        return stream.ToArray();
    }

    public byte[] TakeElementScreenshot(AutomationElement element)
    {
        var capture = FlaUI.Core.Capturing.Capture.Element(element);
        using var stream = new MemoryStream();
        capture.Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        return stream.ToArray();
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _knownElements.Clear();

        try
        {
            Application?.Close();
        }
        catch
        {
            // Best effort
        }

        try
        {
            Application?.Dispose();
        }
        catch
        {
            // Best effort
        }

        _automation.Dispose();
    }
}
