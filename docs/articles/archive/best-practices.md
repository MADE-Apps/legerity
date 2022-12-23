---
uid: best-practices
title: UI test best practices
---

# UI test best practices

## Understanding the page object pattern

The goal of the page object pattern is to use page objects to extract page interactions from your tests. Ideally, they will store all your selectors to find UI elements and their interactions for a page.

## Using the Legerity BasePage

As a part of the Core package, Legerity provides a [`BasePage`](https://github.com/MADE-Apps/legerity/blob/main/src/Legerity.Core/Pages/BasePage.cs) class which is a starting point for creating pages for your application.

Below is an example of a page object for the edit alarm page in the Windows Alarms & Clock application.

```csharp
namespace WindowsAlarmsAndClock.Pages
{
    using System;

    using Legerity.Pages;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    using WindowsAlarmsAndClock.Elements;

    public class EditAlarmPage : BasePage
    {
        private readonly By alarmTimePicker;

        private readonly By alarmNameTextBox;

        private readonly By alarmRepeatButton;

        private readonly By alarmSoundButton;

        private readonly By alarmSnoozeComboBox;

        private readonly By alarmSaveButton;

        private readonly By alarmCancelButton;

        private readonly By alarmDeleteButton;

        private readonly By alarmDeleteDialog;

        public EditAlarmPage()
        {
            this.alarmTimePicker = ByExtensions.AutomationId("AlarmTimePicker");
            this.alarmNameTextBox = ByExtensions.AutomationId("AlarmNameTextBox");
            this.alarmRepeatButton = ByExtensions.AutomationId("AlarmRepeatsToggleButton");
            this.alarmSoundButton = ByExtensions.AutomationId("AlarmSoundButton");
            this.alarmSnoozeComboBox = ByExtensions.AutomationId("AlarmSnoozeCombobox");
            this.alarmSaveButton = ByExtensions.AutomationId("AlarmSaveButton");
            this.alarmCancelButton = ByExtensions.AutomationId("CancelButton");
            this.alarmDeleteButton = ByExtensions.AutomationId("AlarmDeleteButton");
            this.alarmDeleteDialog = ByExtensions.AutomationId("DeleteConfirmationDialog");
        }

        protected override By Trait => ByExtensions.AutomationId("EditAlarmHeader");

        public EditAlarmPage SetAlarmTime(TimeSpan time)
        {
            CustomTimePicker customTimePicker = this.WindowsApp.FindElement(this.alarmTimePicker);
            customTimePicker.SetTime(time);
            return this;
        }

        public EditAlarmPage SetAlarmName(string name)
        {
            WindowsElement textBox = this.WindowsApp.FindElement(this.alarmNameTextBox);
            textBox.Click();
            textBox.SendKeys(name);
            return this;
        }

        public void SaveAlarm()
        {
            this.WindowsApp.FindElement(this.alarmSaveButton).Click();
        }

        public void DeleteAlarm()
        {
            this.WindowsApp.FindElement(this.alarmDeleteButton).Click();
            this.WindowsApp.FindElement(this.alarmDeleteDialog).FindElementByName("Delete").Click();
        }

        public void CancelEditAlarm()
        {
            this.WindowsApp.FindElement(this.alarmCancelButton).Click();
        }
    }
}
```

The page object contains the queries for all of the elements that can be interacted with, as well as common actions that can be performed on the page such as setting the name, alarm time, and the ability to save an alarm.

### Configuring a common page trait

Each page has a trait. This is a UI element that is always displayed on this page. This can often be a **title** element for the view or a specific menu item in a selected state.

The `Trait` is used when the page is constructed to ensure that the page is currently in view.

By default, there will be a 2-second wait for the element to appear before the test will fail.

## Showcase example with page object and tests

In the below example, a page is being defined for the XAML Controls Gallery app that showcases the functionality of a `ComboBox` control.

You'll notice in this example that there are multiple actions that this page can serve. Where actions can be chained, the instance of the page can be returned to produce a simple human-readable test.

### Example page object for ComboBoxPage

```csharp
namespace XamlControlsGallery.Pages.BasicInput
{
    using Legerity.Pages;
    using Legerity.Windows.Elements.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    public class ComboBoxPage : BasePage
    {
        private readonly By colorComboBox = By.Name("Colors");

        public ComboBox ColorComboBox => this.WindowsApp.FindElement(this.colorComboBox);

        protected override By Trait => By.XPath(".//*[@Name='ComboBox'][@AutomationId='TitleTextBlock']");

        public ComboBoxPage SetColorsComboBoxItem(string expectedItem)
        {
            this.ColorComboBox.SelectItem(expectedItem);
            return this;
        }

        public void VerifyColorsComboBoxItem(string expectedItem)
        {
            Assert.AreEqual(expectedItem, this.ColorComboBox.SelectedItem);
        }
    }
}
```

### Example tests for ComboBoxPage

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
