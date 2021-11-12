namespace WindowsCommunityToolkitSampleApp
{
    using Legerity;
    using Legerity.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        // The sample application ID if the WCT sample app is built through Visual Studio.
        private const string DebugSampleApp = "52b9212c-97a9-4639-9426-3e1ea9c1569e_vpw621za47p9m!App";

        // The sample application ID if the WCT sample app is installed from the Windows Store.
        private const string StoreSampleApp = "Microsoft.UWPCommunityToolkitSampleApp_8wekyb3d8bbwe!App";

        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WindowsAppManagerOptions(StoreSampleApp)
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