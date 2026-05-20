---
uid: core-app-manager
title: App manager
---

# App manager

The [`AppManager`](xref:Legerity.AppManager) is the entry point for launching and managing application drivers in Legerity. It handles creating platform-specific Selenium/Appium drivers from a configuration object, tracking active driver instances for parallel test execution, and cleaning up drivers when tests complete.

Every Legerity test starts with `AppManager.StartApp()` and ends with `AppManager.StopApp()`. If you're using `LegerityTestClass`, this lifecycle is handled automatically.

## Configuring app manager options

Each platform has its own `AppManagerOptions` implementation with platform-specific properties. You configure your target application by creating the appropriate options object and passing it to `StartApp()`.

### Web

```csharp
var options = new WebAppManagerOptions
{
    DriverType = WebAppDriverType.Chrome,
    Url = "https://myapp.example.com",
    ImplicitWait = TimeSpan.FromSeconds(5),
    Maximize = true,
};
```

[`WebAppManagerOptions`](xref:Legerity.Web.WebAppManagerOptions) properties:

- `DriverType` - The browser to launch (`Chrome`, `Firefox`, `Safari`, `Edge`).
- `Url` - The URL to navigate to on launch.
- `DesiredSize` - Browser window size (defaults to 1280x800).
- `Maximize` - Whether to maximize the browser window.

### Windows

```csharp
var options = new WindowsAppManagerOptions
{
    AppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App",
    DriverUri = "http://localhost:4723",
    ImplicitWait = TimeSpan.FromSeconds(5),
};
```

[`WindowsAppManagerOptions`](xref:Legerity.Windows.WindowsAppManagerOptions) properties:

- `AppId` - The Application User Model ID (AUMID) or executable path.
- `LaunchDriver` - Whether to auto-launch the Windows Driver server.
- `Maximize` - Whether to maximize the application window.

### Android

```csharp
var options = new AndroidAppManagerOptions
{
    AppId = "com.example.myapp",
    AppActivity = "com.example.myapp.MainActivity",
    DriverUri = "http://localhost:4723",
    DeviceName = "Pixel_6_API_33",
    OSVersion = "13",
    LaunchAppiumServer = true,
    ImplicitWait = TimeSpan.FromSeconds(10),
};
```

[`AndroidAppManagerOptions`](xref:Legerity.Android.AndroidAppManagerOptions) properties:

- `AppId` - The Android package name.
- `AppActivity` - The main activity to launch.
- `AppPath` - Path to the APK file (alternative to `AppId`).
- `DeviceName`, `DeviceId`, `OSVersion` - Target device configuration.
- `LaunchAppiumServer` - Whether to start an Appium server automatically.

### iOS

```csharp
var options = new IOSAppManagerOptions
{
    AppId = "com.example.myapp",
    DeviceName = "iPhone 15",
    OSVersion = "17.0",
    DriverUri = "http://localhost:4723",
    LaunchAppiumServer = true,
    ImplicitWait = TimeSpan.FromSeconds(10),
};
```

[`IOSAppManagerOptions`](xref:Legerity.IOS.IOSAppManagerOptions) properties:

- `AppId` - The iOS bundle identifier.
- `DeviceName`, `DeviceId`, `OSVersion` - Target device/simulator configuration.
- `AutomationName` - The automation engine (defaults to `"XCUITest"`).
- `LaunchAppiumServer` - Whether to start an Appium server automatically.

### Common properties

All options inherit from [`AppManagerOptions`](xref:Legerity.AppManagerOptions):

- `DriverUri` - The URI of the driver server (Appium, Legerity Windows Driver, or browser driver).
- `ImplicitWait` - How long the driver waits for elements before throwing (defaults to 2 seconds).
- `DriverOptions` - Additional Selenium `DriverOptions` for advanced configuration.

## Starting the app

Call `AppManager.StartApp()` with your options to create a driver and launch the application:

```csharp
WebDriver app = AppManager.StartApp(options);
```

The returned `WebDriver` is your handle for interacting with the application. You can use it to find elements, navigate, and perform assertions.

### Waiting until the app is ready

Many applications show a loading screen or splash before the main UI is available. You can pass a wait condition to `StartApp()` that blocks until your application is ready:

```csharp
WebDriver app = AppManager.StartApp(
    options,
    waitUntil: driver => driver.FindElement(By.Id("mainContent")).Displayed,
    timeout: TimeSpan.FromSeconds(15),
    retries: 3);
```

The `waitUntil` delegate is evaluated repeatedly until it returns `true` or the timeout expires. The `retries` parameter controls how many times to retry the entire wait cycle before accepting failure.

## Accessing the current driver

After calling `StartApp()`, the current driver is available via the static `AppManager.App` property:

```csharp
AppManager.StartApp(options);

// Later in your test...
WebElement element = AppManager.App.FindElement(By.Id("username"));
```

`AppManager.App` is backed by `AsyncLocal<WebDriver>`, so each test execution context (thread) gets its own isolated driver reference. This makes parallel test execution safe without any additional synchronization.

For platform-specific driver access, use the typed properties:

```csharp
WindowsDriver windowsApp = AppManager.WindowsApp;
AndroidDriver androidApp = AppManager.AndroidApp;
IOSDriver iosApp = AppManager.IOSApp;
WebDriver webApp = AppManager.WebApp;
```

## Stopping the app

When your test completes, stop the driver to close the application and clean up resources:

```csharp
// Stop the current test's driver
AppManager.StopApp();

// Stop a specific driver
AppManager.StopApp(app);

// Stop all drivers (useful in global teardown)
AppManager.StopApps();
```

`StopApp()` is idempotent. Calling it multiple times for the same driver is safe. The method catches exceptions during `Quit()` to prevent teardown failures from masking real test failures.

For Appium-based tests, you can also stop the Appium server:

```csharp
AppManager.StopApp(stopServer: true);
```

## Parallel test execution

`AppManager` is designed for parallel testing. Each call to `StartApp()` creates a new driver instance and registers it in the `StartedApps` collection (a `ConcurrentDictionary`). The `App` property uses `AsyncLocal<WebDriver>` to isolate the driver per execution context.

```csharp
// Each parallel test gets its own driver
[Test]
public void TestA()
{
    var app = AppManager.StartApp(options); // Creates driver A
    // AppManager.App returns driver A in this context
}

[Test]
public void TestB()
{
    var app = AppManager.StartApp(options); // Creates driver B
    // AppManager.App returns driver B in this context
}
```

## Best practices

- **Use `LegerityTestClass` instead of calling `AppManager` directly.** The test base class wraps the start/stop lifecycle in test setup and teardown, so you don't need to manage it manually. See [Test classes](xref:core-test-classes).
- **Set `ImplicitWait` to a sensible default.** A value of 2-5 seconds handles most network and rendering delays without making tests slow. Increase it for applications with heavy loading times.
- **Use `waitUntil` for applications with splash screens.** This is more reliable than adding arbitrary `Thread.Sleep()` calls.
- **Always call `StopApp()` in teardown.** Leaked driver processes consume system resources and can cause subsequent tests to fail.
