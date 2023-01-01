namespace Legerity.Web.Tests.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using Helpers;
using OpenQA.Selenium.Remote;
using Pages;
using Shouldly;

[TestFixtureSource(nameof(PlatformOptions))]
internal class FileInputTests : BaseTestClass
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

        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        var fileInputPage = new FileInputPage(app);
        fileInputPage.AcceptCookies<FileInputPage>();
        fileInputPage.SwitchToContentFrame<FileInputPage>();

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

        RemoteWebDriver app = this.StartApp(this.Options, WaitUntilConditions.TitleContains("W3Schools"), ImplicitWait);

        var fileInputPage = new FileInputPage(app);
        fileInputPage.AcceptCookies<FileInputPage>();
        fileInputPage.SwitchToContentFrame<FileInputPage>();
        fileInputPage.SetFileInputFilePath(filePath);

        // Act
        fileInputPage.ClearFileInput();

        // Assert
        fileInputPage.FileInput.FilePath.ShouldBeEmpty();
    }
}