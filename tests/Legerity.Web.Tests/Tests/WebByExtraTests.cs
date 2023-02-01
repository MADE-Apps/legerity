namespace Legerity.Web.Tests.Tests;

using System;
using Legerity.Web.Tests.Pages;
using OpenQA.Selenium.Remote;
using System.Collections.ObjectModel;
using System.IO;
using Shouldly;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
internal class WebByExtraTests : W3SchoolsBaseTestClass
{
    [Test]
    public void ShouldFindRadioButtonsByInputType()
    {
        // Arrange
        const int expectedCount = 6;

        RemoteWebDriver app = this.StartApp(new WebAppManagerOptions(
            WebAppDriverType.Chrome,
            Path.Combine(Environment.CurrentDirectory))
        {
            Maximize = true,
            Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_radio",
            ImplicitWait = ImplicitWait,
            DriverOptions = ConfigureChromeOptions()
        });

        RadioButtonPage radioButtonPage = new RadioButtonPage(app)
            .AcceptCookies<RadioButtonPage>()
            .SwitchToContentFrame<RadioButtonPage>();

        // Act
        ReadOnlyCollection<RemoteWebElement>
            radioButtons = radioButtonPage.FindElements(WebByExtras.InputType("radio"));

        // Assert
        radioButtons.Count.ShouldBe(expectedCount);
    }
}