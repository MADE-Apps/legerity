using System.Diagnostics.CodeAnalysis;

[assembly: LevelOfParallelism(5)]
[assembly: ExcludeFromCodeCoverage]

namespace Legerity.WinUI.Tests.Tests;
/// <summary>
/// Defines the base test class for setting up and running UI tests.
/// </summary>
public abstract class BaseTestClass : LegerityTestClass
{
    // These are the package family names of the Windows applications that will be launched. These can be found by running Get-AppxPackage in PowerShell.
    private const string WinUI3Application = "Microsoft.WinUI3ControlsGallery_8wekyb3d8bbwe!App";
    private const string UWPApplication = "Microsoft.XAMLControlsGallery_8wekyb3d8bbwe!App";

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
        new WindowsAppManagerOptions(WinUI3Application)
        {
            DriverUri = "http://127.0.0.1:4723",
            LaunchDriver = true,
            ImplicitWait = ImplicitWait,
        },
        new WindowsAppManagerOptions(UWPApplication)
        {
            DriverUri = "http://127.0.0.1:4723",
            LaunchDriver = true,
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

    /// <inheritdoc/>
    protected override void IgnoreTest(string reason)
    {
        Assert.Ignore(reason);
    }
}