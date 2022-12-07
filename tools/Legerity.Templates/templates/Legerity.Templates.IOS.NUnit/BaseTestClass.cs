namespace Legerity.Templates.IOS.NUnit;

using System;
using System.Collections.Generic;
using Legerity;
using Legerity.IOS;

/// <summary>
/// Defines the base test class for setting up and running UI tests.
/// </summary>
public abstract class BaseTestClass : LegerityTestClass
{
    public const string IOSApplication = "com.company.app";

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTestClass"/> class.
    /// </summary>
    protected BaseTestClass()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTestClass"/> class with application launch option.
    /// </summary>
    /// <param name="options">The application launch options.</param>
    protected BaseTestClass(AppManagerOptions options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the implicit wait timeout, which is the amount of time the driver should wait when searching for an element if it is not immediately present.
    /// </summary>
    public static TimeSpan ImplicitWait => TimeSpan.FromSeconds(3);

    /// <summary>
    /// Gets the platform options to run tests on.
    /// </summary>
    protected static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
    {
        new IOSAppManagerOptions
        {
            AppId = IOSApplication,
            DeviceName = "iPhone SE (3rd generation) Simulator",
            DeviceId = "56755E6F-741B-478F-BB1B-A48E05ACFE8A",
            OSVersion = "15.4",
            DriverUri = "http://192.168.86.172:4723/wd/hub",
            LaunchAppiumServer = false,
            ImplicitWait = ImplicitWait,
        }
    };

    /// <summary>
    /// Sets up any required dependencies for a test before each test is run.
    /// </summary>
    [SetUp]
    public virtual void Initialize()
    {
    }

    /// <summary>
    /// Cleans up any initializes dependencies for a test after each test is run.
    /// </summary>
    [TearDown]
    public virtual void Cleanup()
    {
    }

    /// <summary>
    /// Cleans up all dependencies for a test fixture once all tests have run.
    /// </summary>
    [OneTimeTearDown]
    public virtual void FinalCleanup()
    {
        // Ensures that any running app driver instances being tracked are stopped.
        this.StopApps();
    }
}