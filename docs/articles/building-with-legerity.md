---
uid: building-with-legerity
title: Writing UI tests
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

In the examples below, using NUnit, each test that implements the `BaseTestClass` will launch the application at the start of each test, then close the application once the test has been completed.

### Example base test class for a Windows application

This example showcases how to start your Windows application using the application's unique identifier.

When your tests start, the `LaunchWinAppDriver` property of the `WindowsAppManagerOptions` will automatically start a new WinAppDriver process, if one is not already running. This support allows you to easily run your tests as part of a CI build without additional overhead of scripting the process to run.

You also have additional properties that allows you to maximize the application window, or set the size of the window. This is useful in scenarios where your application has responsive UI and you wish to test it under those views.

```csharp
namespace MyWindowsApplication.UiTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Legerity;
    using Legerity.Windows;

    using NUnit.Framework;

    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    public abstract class BaseTestClass
    {
        public const string WindowsApplication = "com.madeapps.sampleapp_7mzr475ysvhxg!App";

        protected static WindowsDriver<WindowsElement> App => AppManager.WindowsApp;

        [SetUp]
        public void StartApp()
        {
            AppManager.StartApp(
                new WindowsAppManagerOptions(WindowsApplication)
                {
                    DriverUri = "http://127.0.0.1:4723",
                    LaunchWinAppDriver = true,
                    Maximize = true
                });
        }

        [TearDown]
        public void StopApp()
        {
            AppManager.StopApp();
        }
    }
}
```

### Example base test class for an Android application

This example showcases how to start your Android application using a path to a compiled APK. You can also choose to launch your application by application ID and activity if the application is already installed.

When your tests start, the `LaunchAppiumServer` property of the `AndroidAppManagerOptions` will automatically start a new Appium server process, if one is not already running. This support allows you to easily run your tests as part of a CI build without additional overhead of scripting the process to run.

You also have additional properties that allows you to choose the device that the application should be under test on using the `DeviceName` or `DeviceId` property. This is useful if you wish to pick a specific emulator or physical device.

```csharp
namespace MyAndroidApplication.UiTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Legerity;
    using Legerity.Android;

    using NUnit.Framework;

    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    public abstract class BaseTestClass
    {
        public const string AndroidApplication = "Tools\\Android\\com.made.sampleapp.apk";

        protected static AndroidDriver<AndroidElement> App => AppManager.AndroidApp;

        [SetUp]
        public void StartApp()
        {
            AppManager.StartApp(
                new AndroidAppManagerOptions(Path.Combine(Environment.CurrentDirectory, AndroidApplication))
                {
                    LaunchAppiumServer = true,
                    DriverUri = "http://localhost:4723/wd/hub"
                });
        }

        [TearDown]
        public void StopApp()
        {
            AppManager.StopApp();
        }
    }
}
```

### Example base test class for a Web application

This example showcases how to start your web application using a URL using a specific browser and associated driver. This example is using the Microsoft Edge browser with a path to the [Microsoft Edge Web Driver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/).

When your tests start, the web browser will launch the URL provided to begin running the test scenarios.

You also have additional properties that allows you to maximize the browser window, or set the size. This is useful in scenarios where your application has responsive UI and you wish to test it under those views.

In this example, the `AppManagerOptions.ExplicitWait` property has been set to 10 seconds. This property is available to all `AppManagerOptions` types and ensures that the provided wait time is used while finding elements. In this example, a query for a UI element will wait a maximum of 10 seconds before failing.

```csharp
namespace MyWebApplication.UiTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Legerity;
    using Legerity.Web;

    using NUnit.Framework;

    using OpenQA.Selenium.Remote;

    public abstract class BaseTestClass
    {
        public const string WebApplication = "http://localhost:5000";

        protected static RemoteWebDriver App => AppManager.WebApp;

        [SetUp]
        public void StartApp()
        {
            AppManager.StartApp(
                new WebAppManagerOptions(WebAppDriverType.Edge, Path.Combine(Environment.CurrentDirectory, "Tools\\Edge"))
                {
                    Maximize = true, 
                    Url = WebApplication, 
                    ImplicitWait = TimeSpan.FromSeconds(10)
                });
        }

        [TearDown]
        public void StopApp()
        {
            AppManager.StopApp();
        }
    }
}
```

### Example base test class for a cross-platform application

This example showcases how to start a cross-platform application that could potentially have the same user experience across all relevant platforms. It is also useful for testing the same applications across multiple browsers too.

Taking advantage of the `TestFixtureSource` capability of NUnit, this setup allows a test class to be configured with multiple methods of construction. In this example, we are providing a collection of `AppManagerOption` objects as the source. This allows any tests within the class to run the respective app drivers and perform the same test across multiple platforms.

As you are not limited here by the number of applications, you can use this scenario for running against multiple web browsers, multiple variants of your native application, or run tests for applications built with the same user experience like Uno Platform or Xamarin.

```csharp
namespace MyApplication.UiTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Legerity;
    using Legerity.Android;
    using Legerity.IOS;
    using Legerity.Web;
    using Legerity.Windows;

    using NUnit.Framework;

    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.iOS;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    public abstract class BaseTestClass
    {
        public const string AndroidApplication = "Tools\\Android\\com.made.sampleapp.apk";

        public const string WebApplication = "http://localhost:5000";

        public const string WindowsApplication = "com.madeapps.sampleapp_7mzr475ysvhxg!App";

        protected BaseTestClass(AppManagerOptions options)
        {
            Options = options;
        }

        protected static RemoteWebDriver App => AppManager.App;

        protected AppManagerOptions Options { get; }

        [SetUp]
        public void StartApp()
        {
            AppManager.StartApp(Options);
        }

        [TearDown]
        public void StopApp()
        {
            AppManager.StopApp();
            Options = null;
        }
    }

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class LoginPageTests : BaseTestClass
    {
        public LoginPageTests(AppManagerOptions options) : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new AndroidAppManagerOptions(Path.Combine(Environment.CurrentDirectory, AndroidApplication))
            {
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = true
            },
            new WebAppManagerOptions(
                WebAppDriverType.Edge,
                Path.Combine(Environment.CurrentDirectory, "Tools\\Edge"))
            {
                Maximize = true, 
                Url = WebApplication, 
                ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WindowsAppManagerOptions(WindowsApplication)
            {
                DriverUri = "http://127.0.0.1:4723", 
                LaunchWinAppDriver = true, 
                Maximize = true
            }
        };
    }
}
```
