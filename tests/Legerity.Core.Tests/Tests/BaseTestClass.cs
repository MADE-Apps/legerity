// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium.Chrome;

[assembly: LevelOfParallelism(5)]
[assembly: ExcludeFromCodeCoverage]

namespace Legerity.Core.Tests.Tests;
/// <summary>
/// Defines the base test class for setting up and running UI tests.
/// </summary>
public abstract class BaseTestClass : LegerityTestClass
{
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
    public static TimeSpan ImplicitWait => TimeSpan.FromSeconds(5);

    /// <summary>
    /// Creates a <see cref="WebAppManagerOptions"/> configured for Chrome with the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    /// <returns>A configured <see cref="WebAppManagerOptions"/>.</returns>
    protected static WebAppManagerOptions CreateChromeOptions(string url)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless=new");

        return new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Url = url,
            ImplicitWait = ImplicitWait,
            DriverOptions = chromeOptions
        };
    }

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
        this.StopApp(false);
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