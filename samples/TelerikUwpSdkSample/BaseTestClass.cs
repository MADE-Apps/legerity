namespace TelerikUwpSdkSample
{
    using Legerity;
    using Legerity.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        // The sample application ID if the MADE sample app is built through Visual Studio.
        private const string DebugSampleApp = "b00d2088-7bb7-4523-a15e-4846e5cff02e_m0h4y8v6mb4st!App";

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