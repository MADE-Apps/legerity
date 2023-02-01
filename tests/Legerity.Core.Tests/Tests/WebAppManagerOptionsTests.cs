namespace Legerity.Core.Tests.Tests;

using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Shouldly;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
internal class WebAppManagerOptionsTests : BaseTestClass
{
    [Test]
    public void ShouldLaunchBrowserAtDesiredSize()
    {
        // Arrange
        var options = new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            DesiredSize = new Size(1280, 800),
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = new ChromeOptions()
        };
        
        // Act
        RemoteWebDriver app = this.StartApp(options);

        // Assert
        app.Manage().Window.Size.ShouldBe(options.DesiredSize);
    }
}