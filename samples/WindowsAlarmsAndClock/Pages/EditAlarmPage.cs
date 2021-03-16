namespace WindowsAlarmsAndClock.Pages
{
    using System;

    using Legerity.Pages;
    using Legerity.Windows.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    using WindowsAlarmsAndClock.Elements;

    /// <summary>
    /// Defines the add/edit alarm page of the Windows Alarms &amp; Clock application.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="EditAlarmPage"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("EditAlarmHeader");

        /// <summary>
        /// Sets the time of the alarm being edited.
        /// </summary>
        /// <param name="time">
        /// The time to set the alarm to.
        /// </param>
        /// <returns>
        /// The <see cref="EditAlarmPage"/>.
        /// </returns>
        public EditAlarmPage SetAlarmTime(TimeSpan time)
        {
            CustomTimePicker customTimePicker = this.WindowsApp.FindElement(this.alarmTimePicker);
            customTimePicker.SetTime(time);
            return this;
        }

        /// <summary>
        /// Sets the name of the alarm being edited.
        /// </summary>
        /// <param name="name">
        /// The name to set the alarm to.
        /// </param>
        /// <returns>
        /// The <see cref="EditAlarmPage"/>.
        /// </returns>
        public EditAlarmPage SetAlarmName(string name)
        {
            WindowsElement textBox = this.WindowsApp.FindElement(this.alarmNameTextBox);
            textBox.Click();
            textBox.SendKeys(name);
            return this;
        }

        /// <summary>
        /// Saves the alarm and navigates back to the <see cref="AlarmPage"/>.
        /// </summary>
        public void SaveAlarm()
        {
            this.WindowsApp.FindElement(this.alarmSaveButton).Click();
        }

        /// <summary>
        /// Deletes the alarm and navigates back to the <see cref="AlarmPage"/>.
        /// </summary>
        public void DeleteAlarm()
        {
            this.WindowsApp.FindElement(this.alarmDeleteButton).Click();
            this.WindowsApp.FindElement(this.alarmDeleteDialog).FindElementByName("Delete").Click();
        }

        /// <summary>
        /// Cancels editing the alarm and navigates back to the <see cref="AlarmPage"/>.
        /// </summary>
        public void CancelEditAlarm()
        {
            this.WindowsApp.FindElement(this.alarmCancelButton).Click();
        }
    }
}