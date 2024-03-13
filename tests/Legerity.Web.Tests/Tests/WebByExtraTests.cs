using System;
using System.IO;
using Legerity.Web.Tests.Pages;
using Shouldly;

namespace Legerity.Web.Tests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class WebByExtraTests : W3SchoolsBaseTestClass
{
    [Test]
    public void ShouldFindRadioButtonsByInputType()
    {
        // Arrange
        const int expectedCount = 6;

        var app = StartApp(new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true,
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = ConfigureChromeOptions()
        });

        var radioButtonPage = new RadioButtonPage(app)
            .AcceptCookies<RadioButtonPage>()
            .SwitchToContentFrame<RadioButtonPage>();

        // Act
        var radioButtons = radioButtonPage.FindElements(WebByExtras.InputType("radio"));

        // Assert
        radioButtons.Count.ShouldBe(expectedCount);
    }
}
