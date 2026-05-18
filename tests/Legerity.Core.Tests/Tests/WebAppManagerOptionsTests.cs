// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;

namespace Legerity.Core.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
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
        WebDriver app = this.StartApp(options);

        // Assert
        app.Manage().Window.Size.ShouldBe(options.DesiredSize);
    }
}