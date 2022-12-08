---
uid: using_legerity_test_frameworks
title: Test Frameworks
---

# Test frameworks

Legerity is agnostic of .NET testing frameworks (e.g. NUnit, xUnit, MSTest, etc.) so you can work with what you know.

However, there are a few things to consider when using Legerity with your preferred test framework.

## Running UI tests on multiple platforms

The Legerity framework is capable of running the same UI tests across multiple platforms, including multiple browsers.

### Multiple platform test support with NUnit

In NUnit, this can be achieved using a `TestFixtureSource` attribute to specify the `AppManagerOptions` to the constructor of the `LegerityTestClass` class.

If you're using the [Legerity templates](xref:getting_started_quick_starts), you can see an example of this in the  `PlatformOptions` property of the `BaseTestClass` class.

```csharp
[TestFixtureSource(nameof(PlatformOptions))]
public class MyTests : BaseTestClass
{
    public MyTests(AppManagerOptions options) : base(options)
    {
    }

    protected static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
    {
        new AndroidAppManagerOptions
        {
            AppId = AndroidApplication,
            AppActivity = AndroidApplicationActivity,
            DriverUri = "http://localhost:4723/wd/hub",
            LaunchAppiumServer = false,
            ImplicitWait = ImplicitWait,
        }
    };
}
```

Adding the additional platforms to the `PlatformOptions` property automatically ensures that tests you've written in the test class are run on each using [Legerity's `AppManager`](xref:using_legerity_app_manager) to manage the app lifecycle.
