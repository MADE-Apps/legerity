namespace W3SchoolsWebTests
{
    using System;
    using Legerity;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public abstract class BaseTestClass : LegerityTestClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestClass"/> class with application launch option.
        /// </summary>
        /// <param name="options">The application launch options.</param>
        protected BaseTestClass(AppManagerOptions options) : base(options)
        {
        }

        [SetUp]
        public virtual void Initialize()
        {
            base.StartApp();

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
            base.StopApp();
        }
    }
}