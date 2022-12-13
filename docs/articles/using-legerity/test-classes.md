---
uid: using_legerity_test_classes
title: Test Classes
---

# Test classes

Writing UI tests should be simple and easy.

Legerity exposes an [`AppManager`](xref:using_legerity_app_manager) that is a lightweight wrapper for the application driver that allows you to start your applications using a configuration object.

Using your [testing framework](xref:using_legerity_test_frameworks) of choice, getting your application started in the appropriate Selenium driver is as simple as calling `AppManager.StartApp()` passing through an `AppManagerOptions` configuration object for the platform you want to run your tests on.

## Using the Legerity base test class

To make this easier for you, Legerity provides a `LegerityTestClass` class that you can inherit from in your test classes to start the application.

The base test class is designed to manage the `AppManager` lifecycle for you, so you only have to call the `StartApp` and `StopApp` methods from the setup and teardown methods of your test class.

```csharp
public class MyTests : LegerityTestClass
{
    public MyTests() 
        : base(new AndroidAppManagerOptions
            {
                AppId = AndroidApplication,
                AppActivity = AndroidApplicationActivity,
                DriverUri = "http://localhost:4723/wd/hub",
                LaunchAppiumServer = false,
                ImplicitWait = ImplicitWait,
            })
    {
    }

    [SetUp]
    public void SetUp()
    {
        this.StartApp();
    }

    [TearDown]
    public void TearDown()
    {
        this.StopApp();
    }
}
```

To understand more about the `AppManagerOptions` object, read through our [App Manager](xref:using_legerity_app_manager#configuring-the-app-manager) documentation.
