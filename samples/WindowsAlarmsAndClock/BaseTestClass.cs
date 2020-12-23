namespace WindowsAlarmsAndClock
{
    using Legerity;
    using Legerity.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WindowsAppManagerOptions("Microsoft.WindowsAlarms_8wekyb3d8bbwe!App")
                {
                    DriverUri = "http://127.0.0.1:4723",
                    LaunchWinAppDriver = true
                });
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}