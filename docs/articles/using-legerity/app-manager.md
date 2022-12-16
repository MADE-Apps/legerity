---
uid: using_legerity_app_manager
title: App Manager
---

# App manager

The [`AppManager`](xref:Legerity.AppManager) is a lightweight wrapper for a Selenium application driver that allows you to start your applications using a Legerity [`AppManagerOptions`](xref:Legerity.AppManagerOptions) configuration object.

## Understanding the app manager options

Each platform has its own `AppManagerOptions` implementation that each include custom properties specific to them. For example, the [`AndroidAppManagerOptions`](xref:Legerity.Android.AndroidAppManagerOptions) class includes the `AppActivity` property that is specific to Android.

Here's a complete list of the `AppManagerOptions` implementations:

- [`AndroidAppManagerOptions`](xref:Legerity.Android.AndroidAppManagerOptions)
- [`IOSAppManagerOptions`](xref:Legerity.IOS.IOSAppManagerOptions)
- [`WindowsAppManagerOptions`](xref:Legerity.Windows.WindowsAppManagerOptions)
- [`WebAppManagerOptions`](xref:Legerity.Web.WebAppManagerOptions)

`AppManagerOptions` and `AppiumAppManagerOptions` are also available for use if you want to use the base implementations to create your own custom implementations for other platforms, as well as customising for your own needs.

## Configuring the app manager to start your app

The `AppManager` is straightforward to configure and use. You simply construct your `AppManagerOptions` object and pass it through to the `AppManager.StartApp` method. This will return your application driver that you can use to interact with your application.

```csharp
public class MyTests
{
    [Test]
    public void MyTest()
    {
        AppManagerOptions options = new AndroidAppManagerOptions
        {
            AppId = AndroidApplication,
            AppActivity = AndroidApplicationActivity,
            DriverUri = "http://localhost:4723/wd/hub",
            LaunchAppiumServer = false,
            ImplicitWait = ImplicitWait,
        };

        var app = AppManager.StartApp(options);
    }
}
```

> [!NOTE]
> When not running parallel tests, the `AppManager` also exposes an `App` property that will return the current application driver. This is useful when you want to interact with the application driver directly.

### Running parallel app tests

When running parallel tests, you will need to ensure that each test is using its own application driver. The `AppManager` handles this for you under the hood by creating new instances of an application driver for each call of the `StartApp` method.

The multiple launched application drivers are managed under the `StartedApps` collection on the `AppManager` class.  

> [!NOTE]
> In your tests, you shouldn't need to interact with the `StartedApps` collection directly, as the `AppManager` will handle this for you. However, it is exposed if there is a custom scenario that you need to handle.

### Waiting until the app is ready

When starting your application, you may want to wait until the application is ready before interacting with it. A good use case for this scenario is when you want to wait until a loading screen in your app has finished before interacting with it.

To do this, when you start your application, you can pass through a `Func<IWebDriver, bool>` to the `StartApp` method that will be verified until it returns `true` or the timeout is reached.

```csharp

public class MyTests
{
    [Test]
    public void MyTest()
    {
        AppManagerOptions options = new AndroidAppManagerOptions
        {
            AppId = AndroidApplication,
            AppActivity = AndroidApplicationActivity,
            DriverUri = "http://localhost:4723/wd/hub",
            LaunchAppiumServer = false,
            ImplicitWait = ImplicitWait
        };

        AppManager.StartApp(options, (driver) =>
        {
            return driver.FindElement(By.Id("loading")).Displayed;
        }, TimeSpan.FromSeconds(5));
    }
}
```

> [!NOTE]
> The `StartApp` method also has one final optional parameter that allows you to retry the wait condition for a configurable number of times before accepting the condition as failed.

## Stopping the app

When you have finished with your application, you can stop it using the `AppManager.StopApp` method. This will stop the driver, close the application, and has the ability to also stop the Appium server if it was launched by the [`AppiumAppManagerOptions`](xref:Legerity.AppiumAppManagerOptions).

```csharp
public class MyTests
{
    [Test]
    public void MyTest()
    {
        AppManagerOptions options = new AndroidAppManagerOptions
        {
            AppId = AndroidApplication,
            AppActivity = AndroidApplicationActivity,
            DriverUri = "http://localhost:4723/wd/hub",
            LaunchAppiumServer = false,
            ImplicitWait = ImplicitWait
        };

        var app = AppManager.StartApp(options);

        // Do some stuff with the app

        AppManager.StopApp(app);
    }
}
```

> [!NOTE]
> When not running parallel tests, the `AppManager` has a parameterless `StopApp` method that will stop the current application driver.

There is also a `StopApps` method that will stop all of the started application drivers. This is useful if you're running parallel tests and want to perform a cleanup of all of the started application drivers as part of a final teardown method.

```csharp
public class MyTests
{
    [Test]
    public void MyTest()
    {
        AppManagerOptions options = new AndroidAppManagerOptions
        {
            AppId = AndroidApplication,
            AppActivity = AndroidApplicationActivity,
            DriverUri = "http://localhost:4723/wd/hub",
            LaunchAppiumServer = false,
            ImplicitWait = ImplicitWait
        };

        var app = AppManager.StartApp(options);

        // Do some stuff with the app

        AppManager.StopApp(app);
    }

    [TearDown]
    public void TearDown()
    {
        AppManager.StopApps();
    }
}
```
