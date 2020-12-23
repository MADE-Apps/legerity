namespace MADESampleApp
{
    using Legerity;
    using Legerity.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        // The sample application ID if the MADE sample app is built through Visual Studio.
        private const string DebugSampleApp = "718d0506-e27e-48f3-b27f-8053d807fe29_7mzr475ysvhxg!App";

        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WindowsAppManagerOptions(DebugSampleApp)
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