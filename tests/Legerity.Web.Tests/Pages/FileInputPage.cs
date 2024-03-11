namespace Legerity.Web.Tests.Pages;

using Elements.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

internal class FileInputPage : W3SchoolsBasePage
{
    private readonly By fileInputLocator = By.Id("myfile");

    public FileInputPage(WebDriver app) : base(app)
    {
    }

    public FileInput FileInput => this.FindElement(this.fileInputLocator);

    public FileInputPage SetFileInputFilePath(string filePath)
    {
        this.FileInput.SetAbsoluteFilePath(filePath);
        return this;
    }

    public FileInputPage ClearFileInput()
    {
        this.FileInput.ClearFile();
        return this;
    }
}