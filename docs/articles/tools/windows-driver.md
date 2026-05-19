---
uid: tools-windows-driver
title: Windows Driver
---

# Windows Driver

`Legerity.WindowsDriver` is a W3C WebDriver-compliant HTTP server for Windows desktop UI testing. Built with ASP.NET Core and [FlaUI](https://github.com/FlaUI/FlaUI) (UIA3), it is the driver used for running UI tests against Windows applications with Legerity.

It implements the W3C WebDriver protocol, so it works with Selenium, Appium, and Legerity without any changes to your test code.

## Installation

Install the Windows Driver as a global .NET tool:

```bash
dotnet tool install --global Legerity.WindowsDriver
```

Or update an existing install:

```bash
dotnet tool update --global Legerity.WindowsDriver
```

> [!NOTE]
> The Windows Driver requires Windows and .NET 10.0 or later.

## Usage

Start the driver server:

```bash
legerity-windows-driver --port 4723
```

The server listens on `http://localhost:4723` and accepts W3C WebDriver commands. Point your test project's `DriverUri` at this address:

```csharp
new WindowsAppManagerOptions
{
    AppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App",
    DriverUri = "http://localhost:4723",
}
```

### Options

| Option | Description | Default |
|--------|-------------|---------|
| `--port` | The port to listen on. | `4723` |

## Key features

- **W3C WebDriver protocol** for compatibility with modern Selenium and Appium clients.
- **No Developer Mode required** on the Windows machine.
- **Built on FlaUI/UIA3** which provides reliable access to the Windows UI Automation tree.
- **Included in the repository** and distributed as a .NET global tool via NuGet.

## Supported capabilities

### Session management

- Create sessions (launch applications by AUMID or executable path)
- Attach to running applications
- Delete sessions (close applications)

### Element finding

| Strategy | Description |
|----------|-------------|
| `AutomationId` | The primary identifier for Windows UI elements. |
| `Name` | The element's name/label. |
| `ClassName` | The UI control type (e.g., `Button`, `TextBox`). |
| `XPath` | XPath queries over the UI Automation tree. |
| `TagName` | Alias for ClassName. |

### Element interaction

- **Click** - Click/tap elements.
- **SendKeys** - Type text into elements.
- **Clear** - Clear text fields.
- **Text** - Read element text content.
- **Attributes** - Read UI Automation properties (Name, AutomationId, Value.Value, etc.).
- **Displayed/Enabled/Selected** - Check element state.
- **Rect** - Get element bounding rectangle.

### Window management

- **Window handle** - Get the current window handle.
- **Switch window** - Switch between application windows.
- **Maximize** - Maximize the window.
- **Close** - Close the current window.
- **Window rect** - Get/set window position and size.

### Other capabilities

- **Page source** - Get the UI Automation tree as XML.
- **Screenshots** - Capture screenshots of the current window.
- **Timeouts** - Configure implicit wait timeouts.

## Using with Legerity

The Windows Driver works with Legerity's `WindowsAppManagerOptions`. Your test code doesn't change:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    public BaseTestClass()
        : base(new WindowsAppManagerOptions
        {
            AppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App",
            DriverUri = "http://localhost:4723",
            ImplicitWait = TimeSpan.FromSeconds(5),
        })
    {
    }
}
```

## Using with raw Selenium

The driver works with any W3C WebDriver client:

```csharp
var options = new AppiumOptions();
options.PlatformName = "Windows";
options.App = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

var driver = new WindowsDriver(new Uri("http://localhost:4723"), options);
var result = driver.FindElement(By.Name("Display is 0"));
```

## Running in CI

For CI pipelines on Windows agents:

```yaml
# GitHub Actions example
steps:
  - name: Install Windows Driver
    run: dotnet tool install --global Legerity.WindowsDriver

  - name: Start Windows Driver
    run: |
      Start-Process legerity-windows-driver -ArgumentList "--port 4723" -WindowStyle Hidden
      Start-Sleep -Seconds 3

  - name: Run tests
    run: dotnet test

  - name: Stop Windows Driver
    run: Stop-Process -Name "Legerity.WindowsDriver" -ErrorAction SilentlyContinue
```

## Best practices

- **Use `LaunchDriver` for automatic lifecycle management.** Set `LaunchDriver = true` on your `WindowsAppManagerOptions` and Legerity will start the driver on `StartApp()` and stop it on `StopApp()`. This is the recommended approach for both local development and CI.
- **Use a fixed port.** The default `4723` is the conventional Appium port. Use a different port if you need to run multiple driver instances.
- **Use `AutomationId` as your primary locator.** It's the most reliable identifier for Windows UI elements and maps directly to the `AutomationProperties.AutomationId` set in XAML.
