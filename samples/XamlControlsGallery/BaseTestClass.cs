namespace XamlControlsGallery
{
    using Legerity;
    using Legerity.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        // The sample application ID if the XamlControlsGallery sample app is built through Visual Studio.
        private const string DebugSampleApp = "Microsoft.XAMLControlsGallery.Debug_8wekyb3d8bbwe!App";

        // The sample application ID if the XamlControlsGallery sample app is installed from the Windows Store.
        private const string StoreSampleApp = "Microsoft.XAMLControlsGallery_8wekyb3d8bbwe!App";

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