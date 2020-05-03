namespace WindowsAlarmsAndClock.Pages
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Legerity.Pages;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;

    /// <summary>
    /// Defines the alarm page of the Windows Alarms & Clock application.
    /// </summary>
    public class AlarmPage : BasePage
    {
        private readonly By addAlarmButton;

        private readonly By selectAlarmsButton;

        private readonly By alarmList;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlarmPage"/> class.
        /// </summary>
        public AlarmPage()
        {
            this.addAlarmButton = ByExtensions.AutomationId("AddAlarmButton");
            this.selectAlarmsButton = ByExtensions.AutomationId("SelectAlarmsButton");
            this.alarmList = ByExtensions.AutomationId("AlarmListView");
        }

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("AddAlarmButton");

        /// <summary>
        /// Navigates to adding an alarm.
        /// </summary>
        /// <returns>
        /// The <see cref="EditAlarmPage"/>.
        /// </returns>
        public EditAlarmPage GoToAddAlarm()
        {
            this.WindowsApp.FindElement(this.addAlarmButton).Click();
            return new EditAlarmPage();
        }

        /// <summary>
        /// Navigates to editing an alarm with the specified alarm name.
        /// </summary>
        /// <param name="alarmName">
        /// The name of the alarm to edit.
        /// </param>
        /// <returns>
        /// The <see cref="EditAlarmPage"/>.
        /// </returns>
        public EditAlarmPage GoToEditAlarm(string alarmName)
        {
            this.GetListAlarmElement(alarmName).Click();
            return new EditAlarmPage();
        }

        /// <summary>
        /// Verifies that an alarm exists within the alarm list.
        /// </summary>
        /// <param name="alarmName">
        /// The name of the alarm to verify exists.
        /// </param>
        /// <param name="time">
        /// The time of the alarm to verify exists.
        /// </param>
        public void VerifyAlarmExists(string alarmName, TimeSpan time)
        {
            string timeString = time.ToString(@"hh\:mm");
            Assert.IsNotNull(this.GetListAlarmElement($"{alarmName}, {timeString}"));
        }

        /// <summary>
        /// Verifies that an alarm does not exist within the alarm list.
        /// </summary>
        /// <param name="alarmName">
        /// The name of the alarm to verify does not exist.
        /// </param>
        /// <param name="time">
        /// The time of the alarm to verify does not exist.
        /// </param>
        public void VerifyAlarmDoesNotExist(string alarmName, TimeSpan time)
        {
            string timeString = time.ToString(@"hh\:mm");
            Assert.IsNull(this.GetListAlarmElement($"{alarmName}, {timeString}"));
        }

        private AppiumWebElement GetListAlarmElement(string name)
        {
            ReadOnlyCollection<AppiumWebElement> listElements =
                this.WindowsApp.FindElement(this.alarmList).FindElements(By.ClassName("ListViewItem"));

            return listElements.FirstOrDefault(
                element => element.GetAttribute("Name").Contains(name, StringComparison.CurrentCulture));
        }
    }
}