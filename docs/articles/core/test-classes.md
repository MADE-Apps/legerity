---
uid: core-test-classes
title: Test classes
---

# Test classes

[`LegerityTestClass`](xref:Legerity.LegerityTestClass) is an abstract base class that manages the application driver lifecycle for your tests. It wraps `AppManager.StartApp()` and `AppManager.StopApp()` so you can focus on writing test logic instead of driver plumbing.

You don't have to use `LegerityTestClass`. It's a convenience that eliminates boilerplate. If you prefer full control, you can call `AppManager` directly.

## Setting up a base test class

The recommended pattern is to create a project-level `BaseTestClass` that extends `LegerityTestClass` and configures your application options once:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string WebApplication = "https://myapp.example.com";

    public BaseTestClass()
        : base(new WebAppManagerOptions
        {
            DriverType = WebAppDriverType.Chrome,
            Url = WebApplication,
            ImplicitWait = TimeSpan.FromSeconds(5),
        })
    {
    }
}
```

All your test classes then inherit from `BaseTestClass` instead of `LegerityTestClass` directly. This centralizes configuration and makes it easy to change application settings in one place.

## Driver lifecycle

`LegerityTestClass` exposes `StartApp()` and `StopApp()` methods that you call from your test framework's setup and teardown attributes.

With NUnit:

```csharp
public class LoginTests : BaseTestClass
{
    [SetUp]
    public void SetUp()
    {
        StartApp();
    }

    [TearDown]
    public void TearDown()
    {
        StopApp();
    }

    [Test]
    public void ShouldDisplayLoginForm()
    {
        var loginPage = new LoginPage();
        loginPage.VerifyPageShown();
        Assert.That(loginPage.UsernameInput.Displayed, Is.True);
    }
}
```

With xUnit:

```csharp
public class LoginTests : BaseTestClass, IDisposable
{
    public LoginTests()
    {
        StartApp();
    }

    public void Dispose()
    {
        StopApp();
    }

    [Fact]
    public void ShouldDisplayLoginForm()
    {
        var loginPage = new LoginPage();
        loginPage.VerifyPageShown();
        Assert.True(loginPage.UsernameInput.Displayed);
    }
}
```

## Accessing the driver

Inside your test classes, use the `App` property to access the current driver:

```csharp
WebElement element = App.FindElement(By.Id("username"));
```

For platform-specific driver access:

```csharp
WindowsDriver windowsApp = WindowsApp;
AndroidDriver androidApp = AndroidApp;
IOSDriver iosApp = IOSApp;
WebDriver webApp = WebApp;
```

These properties are static and thread-safe (backed by `AsyncLocal<WebDriver>`), so they work correctly in parallel test execution.

## Cross-platform testing

For applications that run on multiple platforms (e.g., Uno Platform, .NET MAUI), you can configure multiple platform options using NUnit's `TestFixtureSource`:

```csharp
public abstract class BaseTestClass : LegerityTestClass
{
    private const string WindowsApp = "com.example.myapp_xxx!App";
    private const string AndroidApp = "com.example.myapp";
    private const string AndroidActivity = "crc64hash.MainActivity";

    public static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
    {
        new WindowsAppManagerOptions
        {
            AppId = WindowsApp,
            DriverUri = "http://localhost:4723",
            ImplicitWait = TimeSpan.FromSeconds(5),
        },
        new AndroidAppManagerOptions
        {
            AppId = AndroidApp,
            AppActivity = AndroidActivity,
            DriverUri = "http://localhost:4723",
            DeviceName = "Pixel_6_API_33",
            LaunchAppiumServer = true,
            ImplicitWait = TimeSpan.FromSeconds(10),
        },
    };
}

[TestFixtureSource(typeof(BaseTestClass), nameof(PlatformOptions))]
public class LoginTests : BaseTestClass
{
    public LoginTests(AppManagerOptions options)
        : base(options)
    {
    }

    [SetUp]
    public void SetUp() => StartApp();

    [TearDown]
    public void TearDown() => StopApp();

    [Test]
    public void ShouldDisplayLoginForm()
    {
        var loginPage = new LoginPage();
        loginPage.VerifyPageShown();
    }
}
```

NUnit creates a separate test fixture for each set of options, running your entire test suite against each platform. Your test code and page objects stay the same because Legerity's abstractions work across all platforms.

## Overriding options per test

You can start the app with different options for specific tests by passing options directly to `StartApp()`:

```csharp
[Test]
public void ShouldWorkInFirefox()
{
    StartApp(new WebAppManagerOptions
    {
        DriverType = WebAppDriverType.Firefox,
        Url = "https://myapp.example.com",
        ImplicitWait = TimeSpan.FromSeconds(5),
    });

    // Test runs in Firefox instead of the default browser
}
```

## Best practices

- **Create one `BaseTestClass` per project.** Centralizing configuration avoids duplication and makes global changes trivial.
- **Always call `StopApp()` in teardown.** This prevents leaked driver processes that consume resources and cause flaky tests.
- **Use `TestFixtureSource` for cross-platform suites.** This is cleaner than duplicating test classes per platform.
- **Keep test classes focused.** Each test class should cover one page or feature area. Use the page object pattern to keep interaction logic out of test methods.
