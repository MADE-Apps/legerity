namespace WindowsAlarmsAndClock.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WindowsAlarmsAndClock.Pages;

    [TestClass]
    public class AlarmTests : BaseTestClass
    {
        [TestMethod]
        public void AddAlarm()
        {
            // Arrange
            const string ExpectedAlarmName = "Test Add Alarm";
            var expectedAlarmTime = new TimeSpan(7, 5, 0);

            var alarmPage = new AlarmPage();

            // Act
            alarmPage.GoToAddAlarm().SetAlarmTime(expectedAlarmTime).SetAlarmName(ExpectedAlarmName).SaveAlarm();

            // Assert
            alarmPage.VerifyAlarmExists(ExpectedAlarmName, expectedAlarmTime);
        }

        [TestMethod]
        public void EditAlarm()
        {
            // Arrange
            const string ExpectedAlarmName = "Test Edit Alarm";
            var expectedAlarmTime = new TimeSpan(12, 30, 0);

            var alarmPage = new AlarmPage();
            alarmPage.GoToAddAlarm().SetAlarmTime(new TimeSpan(7, 5, 0)).SetAlarmName(ExpectedAlarmName).SaveAlarm();

            // Act
            alarmPage.GoToEditAlarm(ExpectedAlarmName).SetAlarmTime(expectedAlarmTime).SaveAlarm();

            // Assert
            alarmPage.VerifyAlarmExists(ExpectedAlarmName, expectedAlarmTime);
        }
    }
}