---
uid: building-with-legerity
title: Writing UI tests | Legerity
---

# Writing UI tests with Legerity

Writing UI tests should be simple and easy.

Legerity exposes an `AppManager` that is a lightweight wrapper for the application driver that allows you to start your applications using a configuration object.

## Creating a base test class

Using your testing framework of choice, getting your application started in the appropriate Selenium driver is as simple as calling `AppManager.StartApp()` passing through an `AppManagerOptions` configuration object.

Depending on your configuration object, the specific application will launch.

Currently, the `AppManager` configuration supports the following app drivers.

- [WindowsDriver](https://github.com/microsoft/WinAppDriver)
  - [WindowsAppManagerOptions](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/Windows/WindowsAppManagerOptions.cs)
- AndroidDriver
  - [AndroidAppManagerOptions](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/Android/AndroidAppManagerOptions.cs)
- IOSDriver
  - [IOSAppManagerOptions](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/IOS/IOSAppManagerOptions.cs)
- ChromeDriver, FirefoxDriver, OperaDriver, SafariDriver, EdgeDriver, InternetExplorerDriver
  - [WebAppManagerOptions](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/Web/WebAppManagerOptions.cs)

For Appium drivers, an options object also provides the use of additional capabilities using the `AppiumOptions` object to apply to the driver when the app is started.

### Example base test class

In this example, using the Microsoft Testing Framework, each test that implements the `BaseTestClass` will launch the application at the start of each test, then close the application once the test has been completed.

```csharp
namespace WindowsAlarmsAndClock
{
    using Legerity;
    using Legerity.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WindowsAppManagerOptions("Microsoft.WindowsAlarms_8wekyb3d8bbwe!App")
                {
                    AppiumDriverUrl = "http://127.0.0.1:4723",
                    LaunchWinAppDriver = true
                });
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}
```

To access the driver for the currently running application, it's as simple as reaching out to one of the following [`AppManager`](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/AppManager.cs) properties:

- `WindowsApp`
- `AndroidApp`
- `IOSApp`
- `WebApp`

Each of these properties exposes the platform-specific Appium driver that can be used to access UI elements.
