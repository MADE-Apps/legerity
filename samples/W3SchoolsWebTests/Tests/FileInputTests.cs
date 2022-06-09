namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Legerity;
    using Legerity.Web;
    using Legerity.Web.Elements.Core;
    using Legerity.Web.Extensions;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixtureSource(nameof(TestPlatformOptions))]
    public class FileInputTests : BaseTestClass
    {
        private const string Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_file";

        public FileInputTests(AppManagerOptions options)
            : base(options)
        {
        }

        static IEnumerable<AppManagerOptions> TestPlatformOptions => new List<AppManagerOptions>
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

        [Test]
        public void ShouldSetAbsoluteFilePath()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"msedgedriver.exe");

            FileInput fileInput = this.App.FindElementById("myfile") as RemoteWebElement;
            fileInput.SetAbsoluteFilePath(filePath);

            fileInput.WaitUntil(e => e.FilePath.Contains("msedgedriver"), TimeSpan.FromSeconds(5));

            // Cannot check absolute file path as browser security feature prevents seeing full URI.
            fileInput.FilePath.ShouldContain("msedgedriver.exe");
        }

        [Test]
        public void ShouldClearFile()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"msedgedriver.exe");

            FileInput fileInput = this.App.FindElementById("myfile") as RemoteWebElement;
            fileInput.SetAbsoluteFilePath(filePath);

            fileInput.ClearFile();

            // Cannot check absolute file path as browser security feature prevents seeing full URI.
            fileInput.FilePath.ShouldBe(string.Empty);
        }
    }
}