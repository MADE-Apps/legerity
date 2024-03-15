using Legerity.Web.Elements.Core;
using OpenQA.Selenium;

namespace Legerity.Web.Tests.Pages;

internal class FileInputPage : W3SchoolsBasePage
{
    private readonly By _fileInputLocator = By.Id("myfile");

    public FileInputPage(WebDriver app) : base(app)
    {
    }

    public FileInput FileInput => FindElement(_fileInputLocator);

    public FileInputPage SetFileInputFilePath(string filePath)
    {
        FileInput.SetAbsoluteFilePath(filePath);
        return this;
    }

    public FileInputPage ClearFileInput()
    {
        FileInput.ClearFile();
        return this;
    }
}
