namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
[Parallelizable(ParallelScope.All)]
internal class FileInputTests : W3SchoolsBaseTestClass
{
    private const string WebApplication = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_file";

    public FileInputTests(AppManagerOptions options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the platform options to run tests on.
    /// </summary>
    protected static IEnumerable<AppManagerOptions> PlatformOptions => new List<AppManagerOptions>
    {
        new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true, Url = WebApplication, ImplicitWait = ImplicitWait, DriverOptions = ConfigureChromeOptions()
        }
    };

    [Test]
    public void ShouldSetFilePath()
    {
        // Arrange
        const string fileName = "chromedriver.exe";
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        RemoteWebDriver app = this.StartApp();

        FileInputPage fileInputPage = new FileInputPage(app)
            .AcceptCookies<FileInputPage>()
            .SwitchToContentFrame<FileInputPage>();

        // Act
        fileInputPage.SetFileInputFilePath(filePath);

        // Assert
        fileInputPage.FileInput.FilePath.ShouldContain(fileName);
    }

    [Test]
    public void ShouldClearFilePath()
    {
        // Arrange
        const string fileName = "chromedriver.exe";
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        RemoteWebDriver app = this.StartApp();

        FileInputPage fileInputPage = new FileInputPage(app)
            .AcceptCookies<FileInputPage>()
            .SwitchToContentFrame<FileInputPage>()
            .SetFileInputFilePath(filePath);

        // Act
        fileInputPage.ClearFileInput();

        // Assert
        fileInputPage.FileInput.FilePath.ShouldBeEmpty();
    }
}