namespace W3SchoolsWebTests
{
    using System;
    using Legerity;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public abstract class BaseTestClass : LegerityTestClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestClass"/> class with application launch option.
        /// </summary>
        /// <param name="options">The application launch options.</param>
        protected BaseTestClass(AppManagerOptions options)
            : base(options)
        {
        }

        public bool IsParallelized { get; set; } = false;

        [SetUp]
        public virtual void Initialize()
        {
            if (!this.IsParallelized)
            {
                this.StartApp();
            }
        }

        public override RemoteWebDriver StartApp(Func<IWebDriver, bool> waitUntil = default,
            TimeSpan? waitUntilTimeout = default, int waitUntilRetries = 0)
        {
            RemoteWebDriver app = base.StartApp(waitUntil, waitUntilTimeout, waitUntilRetries);

            try
            {
                IWebElement closePopup = app.FindElement(By.Id("accept-choices"));
                closePopup?.Click();
            }
            catch (Exception)
            {
                // Ignored.
            }

            app.SwitchTo().Frame("iframeResult");

            return app;
        }

        [TearDown]
        public virtual void Cleanup()
        {
            if (!this.IsParallelized)
            {
                base.StopApp();
            }
        }
    }
}