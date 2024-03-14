using System;
using System.Drawing;
using System.IO;
using Legerity.Web;
using Shouldly;

namespace Legerity.Core.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class WebAppManagerOptionsTests : BaseTestClass
{
    [TestCase(WebAppDriverType.Chrome)]
    [TestCase(WebAppDriverType.Firefox)]
    [TestCase(WebAppDriverType.Opera)]
    public void ShouldLaunchBrowserAtDesiredSize(WebAppDriverType driverType)
    {
        // Arrange
        var options = new WebAppManagerOptions(
            driverType,
            Path.Combine(Environment.CurrentDirectory))
        {
            DesiredSize = new Size(1280, 800),
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait
        };

        // Act
        var app = StartApp(options);

        // Assert
        var size = app.Manage().Window.Size;
        size.ShouldBe(options.DesiredSize);
    }
}
