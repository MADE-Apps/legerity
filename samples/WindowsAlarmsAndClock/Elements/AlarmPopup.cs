namespace WindowsAlarmsAndClock.Elements
{
    using System;
    using Legerity.Windows.Elements;
    using Legerity.Windows.Elements.Core;
    using Legerity.Windows.Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Defines a <see cref="WindowsElement"/> wrapper for the AlarmPopup control.
    /// </summary>
    public class AlarmPopup : WindowsElementWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlarmPopup"/> class.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/> reference.
        /// </param>
        public AlarmPopup(WindowsElement element)
            : base(element)
        {
        }

        /// <summary>
        /// Allows conversion of a <see cref="WindowsElement"/> to the <see cref="AlarmPopup"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="WindowsElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="DurationPicker"/>.
        /// </returns>
        public static implicit operator AlarmPopup(WindowsElement element)
        {
            return new AlarmPopup(element);
        }

        /// <summary>
        /// Allows conversion of a <see cref="AppiumWebElement"/> to the <see cref="AlarmPopup"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AlarmPopup"/>.
        /// </returns>
        public static implicit operator AlarmPopup(AppiumWebElement element)
        {
            return new AlarmPopup(element as WindowsElement);
        }

        /// <summary>
        /// Allows conversion of a <see cref="RemoteWebElement"/> to the <see cref="AlarmPopup"/> without direct casting.
        /// </summary>
        /// <param name="element">
        /// The <see cref="AppiumWebElement"/>.
        /// </param>
        /// <returns>
        /// The <see cref="AlarmPopup"/>.
        /// </returns>
        public static implicit operator AlarmPopup(RemoteWebElement element)
        {
            return new AlarmPopup(element as WindowsElement);
        }

        public CustomTimePicker DurationPicker => this.FindElement(ByExtensions.AutomationId("DurationPicker"));

        public TextBox AlarmNameInput => this.FindElement(By.Name("Alarm name"));

        public Button SaveButton => this.Element.FindElement(ByExtensions.AutomationId("PrimaryButton"));

        public void SetTime(TimeSpan time)
        {
            this.DurationPicker.SetTime(time);
        }

        public void SetName(string name)
        {
            this.AlarmNameInput.SetText(name);
        }

        public void SaveAlarm()
        {
            this.SaveButton.Click();
        }
    }
}