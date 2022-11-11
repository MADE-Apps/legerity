namespace WebTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using NUnit.Framework;

    public abstract class BaseTestClass : LegerityTestClass
    {
        private const string Url = "https://www.jamescroft.co.uk";

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestClass"/> class with application launch option.
        /// </summary>
        /// <param name="options">The application launch options.</param>
        protected BaseTestClass(AppManagerOptions options)
            : base(options)
        {
        }

        protected static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
        {
            new WebAppManagerOptions(
                WebAppDriverType.EdgeChromium,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = Url, ImplicitWait = TimeSpan.FromSeconds(10)
            },
            new WebAppManagerOptions(
                WebAppDriverType.Chrome,
                Path.Combine(Environment.CurrentDirectory))
            {
                Maximize = true, Url = Url, ImplicitWait = TimeSpan.FromSeconds(10)
            }
        };

        [SetUp]
        public virtual void Initialize()
        {
        }

        [TearDown]
        public virtual void Cleanup()
        {
        }

        [OneTimeTearDown]
        public virtual void FinalCleanup()
        {
            this.StopApps();
        }
    }
}