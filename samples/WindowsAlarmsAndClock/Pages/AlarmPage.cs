namespace WindowsAlarmsAndClock.Pages
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Elements;
    using Legerity.Extensions;
    using Legerity.Windows.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;

    /// <summary>
    /// Defines the alarm page of the Windows Alarms &amp; Clock application.
    /// </summary>
    public class AlarmPage : AppPage
    {
        private readonly By addAlarmButton;

        private readonly By alarmList;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlarmPage"/> class.
        /// </summary>
        public AlarmPage()
        {
            this.addAlarmButton = ByExtensions.AutomationId("AddAlarmButton");
            this.alarmList = ByExtensions.AutomationId("AlarmListView");
        }

        public AlarmPopup AlarmPopup => this.WindowsApp.FindElement(ByExtensions.AutomationId("EditFlyout"));

        /// <summary>
        /// Gets a given trait of the page to verify that the page is in view.
        /// </summary>
        protected override By Trait => ByExtensions.AutomationId("AddAlarmButton");

        /// <summary>
        /// Navigates to adding an alarm.
        /// </summary>
        /// <returns>
        /// The <see cref="AlarmPage"/>.
        /// </returns>
        public AlarmPage GoToAddAlarm()
        {
            this.WindowsApp.FindElement(this.addAlarmButton).Click();
            return this;
        }

        /// <summary>
        /// Navigates to editing an alarm with the specified alarm name.
        /// </summary>
        /// <param name="alarmName">
        /// The name of the alarm to edit.
        /// </param>
        /// <returns>
        /// The <see cref="AlarmPage"/>.
        /// </returns>
        public AlarmPage GoToEditAlarm(string alarmName)
        {
            this.GetListAlarmElement(alarmName).Click();
            return this;
        }

        public AlarmPage SetAlarmTime(TimeSpan time)
        {
            this.AlarmPopup.SetTime(time);
            return this;
        }

        public AlarmPage SetAlarmName(string name)
        {
            this.AlarmPopup.SetName(name);
            return this;
        }

        public AlarmPage SaveAlarm()
        {
            this.AlarmPopup.SaveAlarm();
            return this;
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
                element => element.GetName().Contains(name, StringComparison.CurrentCulture));
        }
    }
}