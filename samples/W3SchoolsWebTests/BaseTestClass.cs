namespace W3SchoolsWebTests
{
    using System;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public abstract class BaseTestClass
    {
        public abstract string Url { get; }

        [SetUp]
        public virtual void Initialize()
        {
            AppManager.StartApp(
                new WebAppManagerOptions(WebAppDriverType.EdgeChromium, Environment.CurrentDirectory)
                {
                    Maximize = true,
                    Url = this.Url
                });

            try
            {
                IWebElement closePopup = AppManager.WebApp.FindElement(By.Id("accept-choices"));
                closePopup?.Click();
            }
            catch (Exception)
            {
                // Ignored.
            }

            AppManager.WebApp.SwitchTo().Frame("iframeResult");
        }

        [TearDown]
        public virtual void Cleanup()
        {
            AppManager.StopApp();
        }
    }
}