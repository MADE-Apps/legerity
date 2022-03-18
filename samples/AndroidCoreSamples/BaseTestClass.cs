namespace AndroidCoreSamples
{
    using System;
    using System.IO;
    using Legerity;
    using Legerity.Android;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class BaseTestClass
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new AndroidAppManagerOptions(Path.Combine(Environment.CurrentDirectory, "Tools\\com.companyname.app2.apk"))
                {
                    LaunchAppiumServer = false,
                    DriverUri = "http://localhost:4723/wd/hub"
                });
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}