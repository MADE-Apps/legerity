# Page Object Pattern (POP)

The goal of the page object pattern is to use page objects to extract page interactions from your tests. Ideally, they will store all your selectors to find UI elements and their interactions for a page.

## BasePage.cs

As a part of the Legerity framework, we provide a [`BasePage`](../src/Legerity/Pages/BasePage.cs) class which is a starting point for creating pages for your application.

The Windows Alarms And Clock sample project provides an easy-to-understand example of how to implement a page within your tests. Take a look at the [EditAlarmPage](../samples/WindowsAlarmsAndClock/Pages/EditAlarmPage.cs) to get started.

### Trait

Each page has a trait. This is a UI element that is always displayed on this page. This can often be tied to a **title** element for the view or a specific menu item having been selected.

The Trait is used when the page is constructed to ensure that the page is currently in view.

By default, there will be a 2-second wait for the element to appear before the test will fail.

### Example

In the below example, a page is being defined for the XAML Controls Gallery app that showcases the functionality of a combo box control.

You'll notice in this example that there are multiple actions that this page can serve. Where actions can be chained, the instance of the page can be returned to produce a simple human-readable test.

```csharp
namespace XamlControlsGallery.Pages.BasicInput
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    /// <summary>
    /// Defines the ComboBox page of the XAML Controls Gallery application.
    /// </summary>
    public class ComboBoxPage : BasePage
    {
        private readonly By colorComboBox = By.Name("Colors");

        /// <summary>
        /// Gets the element associated with the color combo box.
        /// </summary>
        public ComboBox ColorComboBox => this.WindowsApp.FindElement(this.colorComboBox);

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => By.XPath(".//*[@Name='ComboBox'][@AutomationId='TitleTextBlock']");

        /// <summary>
        /// Sets the colors combo-box selected item to the specified item..
        /// </summary>
        /// <param name="expectedItem">
        /// The expected item.
        /// </param>
        /// <returns>
        /// The <see cref="ComboBoxPage"/>.
        /// </returns>
        public ComboBoxPage SetColorsComboBoxItem(string expectedItem)
        {
            this.ColorComboBox.SelectItem(expectedItem);
            return this;
        }

        /// <summary>
        /// Verifies that the colors combo-box has been updated.
        /// </summary>
        /// <param name="expectedItem">
        /// The selected item of the combo-box to verify updated.
        /// </param>
        public void VerifyColorsComboBoxItem(string expectedItem)
        {
            Assert.AreEqual(expectedItem, this.ColorComboBox.SelectedItem);
        }
    }
}
```

#### Example test for page

```csharp
namespace XamlControlsGallery.Tests.BasicInput
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using XamlControlsGallery.Pages;
    using XamlControlsGallery.Pages.BasicInput;

    [TestClass]
    public class ComboBoxTests : BaseTestClass
    {
        private static ComboBoxPage ComboBoxPage { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            ComboBoxPage = new NavigationMenu().GoToComboBox();
        }

        [TestMethod]
        public void SetColorsComboBoxToGreen()
        {
            var expectedItem = "Green";

            ComboBoxPage.SetColorsComboBoxItem(expectedItem)
                .VerifyColorsComboBoxItem(expectedItem);
        }
    }
}
```
