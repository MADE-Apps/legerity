namespace W3SchoolsWebTests.Tests
{
    using System;
    using System.IO;
    using Legerity;
    using Legerity.Web.Elements.Core;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using Shouldly;
    using W3SchoolsWebTests;

    [TestFixture]
    public class FileInputTests : BaseTestClass
    {
        public override string Url => "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_input_type_file";

        [Test]
        public void ShouldSetAbsoluteFilePath()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Tools\Edge\MicrosoftWebDriver.exe");

            FileInput fileInput = AppManager.WebApp.FindElementById("myfile") as RemoteWebElement;
            fileInput.SetAbsoluteFilePath(filePath);

            // Cannot check absolute file path as browser security feature prevents seeing full URI.
            fileInput.FilePath.ShouldContain("MicrosoftWebDriver.exe");
        }

        [Test]
        public void ShouldClearFile()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Tools\Edge\MicrosoftWebDriver.exe");

            FileInput fileInput = AppManager.WebApp.FindElementById("myfile") as RemoteWebElement;
            fileInput.SetAbsoluteFilePath(filePath);

            fileInput.ClearFile();

            // Cannot check absolute file path as browser security feature prevents seeing full URI.
            fileInput.FilePath.ShouldBe(string.Empty);
        }
    }
}